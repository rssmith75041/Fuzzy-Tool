using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Fuzzy_Tool
{
    public sealed class ParserModern
    {
        private string error_str = "No Error";

        public string Error_Str { get => error_str; private set => error_str = value; }

        public int Error_No { get; private set; }

        // Variable table: X1, X2, V, etc.
        public Dictionary<string, float> Vars { get; } = new(StringComparer.OrdinalIgnoreCase);

        #region Tokenizer

        private enum TokenType
        {
            Number,
            Identifier,
            Plus,
            Minus,
            Mul,
            Div,
            Pow,
            LParen,
            RParen,
            End
        }

        private readonly struct Token
        {
            public TokenType Type { get; }
            public string Text { get; }

            public Token(TokenType type, string text)
            {
                Type = type;
                Text = text;
            }
        }

        private string _input = string.Empty;
        private Token _current;
        private int _pos;

        private void NextToken()
        {
            SkipWs();

            if (_pos >= _input.Length)
            {
                _current = new Token(TokenType.End, string.Empty);
                return;
            }

            char c = _input[_pos];
            if (char.IsDigit(c) || c == '.')
            {
                int start = _pos;
                while (_pos < _input.Length && (char.IsDigit(_input[_pos]) || _input[_pos] == '.')) { _pos++; }
                string num = _input.Substring(start, _pos - start);
                _current = new Token(TokenType.Number, num);
                return;
            }

            if (char.IsLetter(c))
            {
                int start = _pos;
                while (_pos < _input.Length && (char.IsLetterOrDigit(_input[_pos]) || _input[_pos] == '_')) { _pos++; }
                string id = _input.Substring(start, _pos - start);
                _current = new Token(TokenType.Identifier, id);
                return;
            }

            _pos++;
            _current = c switch
            {
                '+' => new Token(TokenType.Plus, "+"),
                '-' => new Token(TokenType.Minus, "-"),
                '*' => new Token(TokenType.Mul, "*"),
                '/' => new Token(TokenType.Div, "/"),
                '^' => new Token(TokenType.Pow, "^"),
                '(' => new Token(TokenType.LParen, "("),
                ')' => new Token(TokenType.RParen, ")"),
                _ => new Token(TokenType.End, string.Empty)
            };

            if (_current.Type == TokenType.End)
            {
                Error_Str = $"unknown operator/char {c}";
                Error_No = 5; // unknown operator/char
            }
        }

        private void SkipWs()
        {
            while (_pos < _input.Length && char.IsWhiteSpace(_input[_pos])) { _pos++; }
        }

        #endregion

        #region Parser core (Expr / Term / Power / Factor)

        public float Evaluate(string expr)
        {
            Error_No = 0;
            _input = NormalizeEquation(expr); // turn "1X2" into "1*X2"
            _pos = 0;
            NextToken();

            float v = ParseExpr();
            if (_current.Type != TokenType.End && Error_No == 0)
            {
                Error_Str = $"junk at end";
                Error_No = 3; // junk at end
            }

            return v;
        }

        private float ParseExpr()
        {
            float v = ParseTerm();

            while (Error_No == 0 && (_current.Type == TokenType.Plus || _current.Type == TokenType.Minus))
            {
                var op = _current.Type;
                NextToken();
                float rhs = ParseTerm();
                if (op == TokenType.Plus) v += rhs;
                else v -= rhs;
            }

            return v;
        }

        private float ParseTerm()
        {
            float v = ParsePower();

            while (Error_No == 0 && (_current.Type == TokenType.Mul || _current.Type == TokenType.Div))
            {
                var op = _current.Type;
                NextToken();
                float rhs = ParsePower();

                if (op == TokenType.Mul) v *= rhs;
                else
                {
                    if (Math.Abs(rhs) < 1e-12f)
                    {
                        Error_Str = $"absolute value of right hand to small {Math.Abs(rhs)}";
                        Error_No = 7;
                        return 0;
                    }

                    v /= rhs;
                }
            }

            return v;
        }

        private float ParsePower()
        {
            float v = ParseFactor();

            while (Error_No == 0 && _current.Type == TokenType.Pow)
            {
                NextToken();
                float rhs = ParseFactor();

                if (Math.Abs(v) < 1e-12f && Math.Abs(rhs) < 1e-12f)
                {
                    Error_Str = $"power {v} is 0^0 or power {rhs} is 0^0";
                    Error_No = 8; // 0^0
                    return 0;
                }

                v = (float)Math.Pow(v, rhs);
            }

            return v;
        }

        private float ParseFactor()
        {
            if (_current.Type == TokenType.Plus)
            {
                NextToken();
                return ParseFactor();
            }

            if (_current.Type == TokenType.Minus)
            {
                NextToken();
                return -ParseFactor();
            }

            switch (_current.Type)
            {
                case TokenType.Number:
                    {
                        float v = float.Parse(_current.Text, CultureInfo.InvariantCulture);
                        NextToken();
                        return v;
                    }
                case TokenType.Identifier:
                    {
                        string name = _current.Text;
                        NextToken();

                        if (_current.Type == TokenType.LParen) { return ParseFunctionCall(name); }
                        if (!Vars.TryGetValue(name, out float val))
                        {
                            Error_Str = $"unknown variable {name}";
                            Error_No = 6; // unknown variable
                            return 0;
                        }

                        return val;
                    }
                case TokenType.LParen:
                    {
                        NextToken();
                        float v = ParseExpr();
                        if (_current.Type != TokenType.RParen)
                        {
                            Error_No = 4;
                            return 0;
                        }
                        NextToken();
                        return v;
                    }
                default:
                    Error_Str = $"unknown or missing token {_current.Type}";
                    Error_No = 9;
                    return 0;
            }
        }

        private float ParseFunctionCall(string name)
        {
            // current is '('
            NextToken();

            float arg = ParseExpr();
            if (_current.Type != TokenType.RParen)
            {
                Error_Str = "missing right parenthesis";
                Error_No = 4;
                return 0;
            }
            NextToken();

            if (Error_No != 0) { return 0; }
            switch (name.ToUpperInvariant())
            {
                case "ABS": return Do_ABS(arg);
                case "COS": return Do_COS(arg);
                case "RAN": return Do_RAN(arg);
                case "SGN": return Do_SGN(arg);
                case "SIN": return Do_SIN(arg);
                case "SQRT": return Do_SQRT(arg);
                case "TAN": return Do_TAN(arg);
                default:
                    {
                        Error_Str = $"invalid function {name}";
                        Error_No = 1;
                        return 0;
                    }
            }
        }

        #endregion

        #region Functions

        private float Do_ABS(float v) => Math.Abs(v);

        private float Do_SQRT(float v)
        {
            if (v > 0) return (float)Math.Sqrt(v);
            if (Math.Abs(v) < 1e-12f) return 0;
            error_str = $"invalid square root {Math.Abs(v).ToString()}";
            Error_No = 2;
            return 0;
        }

        private float Do_COS(float v) => (float)Math.Cos(v * (Math.PI / 180.0));
        private float Do_SIN(float v) => (float)Math.Sin(v);
        private float Do_TAN(float v) => (float)Math.Tan(v * (Math.PI / 180.0));
        private float Do_RAN(float v) => (float)(Random.Shared.NextDouble() * v);
        private float Do_SGN(float v) => v > 0 ? 1f : v< 0 ? -1f : 0;

        #endregion

        #region Helpers

        // Turn "1X2-1X1+V" into "1*X2-1*X1+V"
        private static string NormalizeEquation(string eq)
        {
            if (string.IsNullOrEmpty(eq)) return eq;

            var sb = new StringBuilder(eq.Length * 2);
            for (int i = 0; i < eq.Length; i++)
            {
                char c = eq[i];
                sb.Append(c);

                if ((char.IsDigit(c) || c == '.') && i + 1 < eq.Length && char.IsLetter(eq[i + 1])) { sb.Append('*'); }
            }

            return sb.ToString();
        }

        #endregion

        #region RK4: N‑equation system

        // Evaluate all derivatives for the system: eqs[i] -> dXi/dt
        private void EvalSystem(string[] eqs, float[] state, float vInput, float[] deriv)
        {
            Vars["V"] = vInput;
            for (int i = 0; i < state.Length; i++) { Vars["X" + (i + 1)] = state[i]; }
            for (int i = 0; i < eqs.Length; i++) { deriv[i] = Evaluate(eqs[i]); }
        }

        // One RK4 step for an N‑state system
        public void RK4Step(string[] eqs, float h, float vInput, float[] state)
        {
            int n = state.Length;

            float[] k1 = new float[n];
            float[] k2 = new float[n];
            float[] k3 = new float[n];
            float[] k4 = new float[n];
            float[] temp = new float[n];

            // k1 = f(x)
            EvalSystem(eqs, state, vInput, k1);

            // k2 = f(x + h/2 * k1)
            for (int i = 0; i < n; i++) { temp[i] = state[i] + 0.5f * h * k1[i]; }
            EvalSystem(eqs, temp, vInput, k2);

            // k3 = f(x + h/2 * k2)
            for (int i = 0; i < n; i++) { temp[i] = state[i] + 0.5f * h * k2[i]; }
            EvalSystem(eqs, temp, vInput, k3);

            // k4 = f(x + h * k3)
            for (int i = 0; i < n; i++) { temp[i] = state[i] + h * k3[i]; }
            EvalSystem(eqs, temp, vInput, k4);

            // Final RK4 update
            for (int i = 0; i < n; i++) { state[i] += (h / 6f) * (k1[i] + 2f * k2[i] + 2f * k3[i] + k4[i]); }
        }

        public int Process_Equations(string eq1, string eq2, float step, float vInput, float y1, float y2, ref string yout1, ref string yout2, int interval)
        {
            string[] eqs = { eq1, eq2 };
            float[] state = { y1, y2 };
            for (int i = 0; i < interval; i++) { RK4Step(eqs, step, vInput, state); }
            yout1 = state[0].ToString("F5", CultureInfo.InvariantCulture);
            yout2 = state[1].ToString("F5", CultureInfo.InvariantCulture);
            return Error_No;
        }

        public int Process_Equations_N(string[] eqs, float step, float vInput, float[] initialState, out float[] finalState, int interval)
        {
            int n = eqs.Length;
            float[] state = new float[n];
            Array.Copy(initialState, state, n);
            for (int i = 0; i < interval; i++) { RK4Step(eqs, step, vInput, state); }
            finalState = state;
            return Error_No;
        }

        #endregion
    }
}
