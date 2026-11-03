using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fuzzy_Tool
{
    public class Parser
    {
        /*char ErrStr1[50],ErrStr2[50];*/
        /*
            ERROR: 1 - Undefined function name.
            ERROR: 2 - Trying to take square root of negitive number.
            ERROR: 3 - Missing open parenthesis (
            ERROR: 4 - Missing closing parenthesis )
            ERROR: 5 - Unknown operator. Legal operators are: ^ * / + -
            ERROR: 6 - Missing open parenthesis or Unknown command.
            ERROR: 7 - Trying to divide by zero (0)
            ERROR: 8 - Trying to do 0^0 or 0^-#, # < 0.
        */

        public string Error_Str { get; private set; } = "No Error";

        public int Error_No { get; private set; } = 0;

        public Parser()
        {

        }

        /*
         Expr()
         <expr> ::= <term> { <addop> <term> }
        */
        private void Expr(string s, ref float v, ref int index)
        {
            Term(s, ref v, ref index);

            if (Error_No == 0)
            {
                float v1 = v;
                char op;

                op = AddOp(s, ref index);
                while ((op != '\x0') && (Error_No == 0))
                {
                    Term(s, ref v, ref index);

                    if (Error_No == 0)
                    {
                        if (op == '+') { v += v1; }
                        else if (op == '-') { v = v1 - v; }
                        else
                        {
                            Error_Str = $"Unknown operator: {op}. Legal operators are: ^ * / + -";
                            Error_No = 5;
                        }

                        v1 = v;
                        op = AddOp(s, ref index);
                    }
                }
            }
        }

        /*
         Term()
         <term> ::= <factor> { <multop> <factor> }
        */
        private void Term(string s, ref float v, ref int index)
        {
            Factor(s, ref v, ref index);

            if (Error_No == 0)
            {
                float v1 = v;
                char op;

                op = MultOp(s, ref index);
                while ((op != '\x0') && (Error_No == 0))
                {
                    Factor(s, ref v, ref index);

                    if (Error_No == 0)
                    {
                        if (op == '*') v *= v1;
                        else if (op == '/')
                        {
                            if (v != 0) v = v1 / v;
                            else
                            {
                                Error_Str = $"Trying to divide by zero (0): {v1}/{v}";
                                Error_No = 7;
                            }
                        }
                        else if (op == '^')
                        {
                            if ((v < 0) && (v1 != 0)) { v = 1 / (float)Math.Pow(v1, (-1 * v)); }
                            else if ((v == 0) && (v1 < 0)) { v = -1; }
                            else if ((v == 0) && (v1 > 0)) { v = 1; }
                            else if ((v1 == 0) && (v > 0)) { v = 0; }
                            else if ((v1 == 0) && (v <= 0))
                            {
                                Error_Str = $"Trying to do 0^0 or 0^-#, # < 0";
                                Error_No = 8;
                            }
                            else { v = (float)Math.Pow(v1, v); }
                        }
                        else
                        {
                            Error_Str = $"Unknown operator: {op}. Legal operators are: ^ * / + -";
                            Error_No = 5;
                        }

                        v1 = v;
                        op = MultOp(s, ref index);
                    }
                }
            }
        }

        /*
         Factor()
         <factor> ::= value | <func> | ( <expr> )
        */
        private void Factor(string s, ref float v, ref int index)
        {
            if (s[index] == '(')
            {
                if (Expect(s, '(', ref index))
                {
                    ++index;
                    Expr(s, ref v, ref index);
                    if (!Expect(s, ')', ref index))
                    {
                        Error_Str = $"Missing closing parenthesis )";
                        Error_No = 4;
                    }
                }
                else
                {
                    Error_Str = $"Missing open parenthesis (";
                    Error_No = 3;
                }
            }
            else if (!FindValue(s, ref v, ref index))
            {
                if (!Do_Func(s, ref v, ref index))
                {
                    Error_Str = $"Missing open parenthesis or Unknown command: {s}";
                    Error_No = 6;
                }
            }
        }

        /*
         Do_Func()
         <func> ::= <fname> ( <expr> )
        */
        private bool Do_Func(string s, ref float v, ref int index)
        {
            string name = string.Empty;

            if (FName(s, ref name, ref index))
            {
                if (Expect(s, '(', ref index))
                {
                    Expr(s, ref v, ref index);

                    if (!Expect(s, ')', ref index))
                    {
                        Error_Str = "Missing closing parenthesis )";
                        Error_No = 4;
                        return false;
                    }
                }
                else
                {
                    Error_Str = $"Missing open parenthesis (";
                    Error_No = 3;
                    return false;
                }

                if (Error_No == 0)
                {
                    switch(name.ToUpper())
                    {
                        case "ABS": { v = Do_ABS(v); } break;
                        case "COS": { v = Do_COS(v); } break;
                        case "RAN": { v = Do_RAN(v); } break;
                        case "SGN": { v = Do_SGN(v); } break;
                        case "SIN": { v = Do_SIN(v); } break;
                        case "SQRT": { v = Do_SQRT(v); } break;
                        case "TAN": { v = Do_TAN(v); } break;
                        default:
                            {
                                Error_Str = $"Undefined function name: {name}";
                                Error_No = 1;
                                return false;
                            }
                    }

                    index++;
                }
            }

            return true;
        }

        /*
         FName()
         <fname> ::= ABS | SQRT | COS | SIN | TAN | RAN | SGN
        */
        private bool FName(string s, ref string name, ref int index)
        {
            if (!GetFuncName(s, ref name, ref index)) { return false; }
            if (!name.ToUpper().Equals("ABS") && !name.ToUpper().Equals("SQRT") && !name.ToUpper().Equals("COS") &&
                !name.ToUpper().Equals("SIN") && !name.ToUpper().Equals("TAN") && !name.ToUpper().Equals("RAN") &&
                !name.ToUpper().Equals("SGN"))
            {
                return false;
            }

            return true;
        }

        /*
         AddOp()
         <addop> ::= + | -
        */
        private char AddOp(string s, ref int index)
        {
            if (index >= s.Length) { return '\x0'; }
            char rvalue = '\x0';
            char op = s[index];

            switch(op)
            {
                case '+':
                case '-':
                    {
                        rvalue = op;
                        index++;
                    }
                    break;
            }

            return rvalue;
        }

        /*
         MultOp()
         <multop> ::= * | /
        */
        private char MultOp(string s, ref int index)
        {
            if (index >= s.Length) { return '\x0'; }
            char rvalue = '\x0';
            char op = s[index];

            switch(op)
            {
                case '*':
                case '/':
                case '^':
                    {
                        rvalue = op;
                        index++;
                    }
                    break;
            }

            return rvalue;
        }

        /*
         Expect()
        */
        private bool Expect(string s, char c, ref int index)
        {
            bool rvalue = true;
            if (s[index] != c) { rvalue = false; }
            return rvalue;
        }

        /*
         FindValue()
        */
        private bool FindValue(string s, ref float v, ref int index)
        {
            bool result = true;
            int indx = 1, i;

            if ((s[index] == '-') && NumChar(s[index + 1])) { indx = 2; }
            else if (s[index] == '-')
            {
                index++;
                Expr(s, ref v, ref index);
                v *= -1;
            }
            while ((indx <= (s.Length - (index))) && (NumChar(s[(index) + indx - 1]))) { ++indx; }
            if (indx == 1) { result = false; }
            else
            {
                string ts = s.Substring(index, indx - 1);
                v = float.Parse($"{float.Parse(ts):F5}");
                index += ts.Length;//++;
            }

            return result;
        }

        /*
         GetFuncName()
        */
        private bool GetFuncName(string s, ref string name, ref int index)
        {
            bool found_open_paren = false;
            int ndx = index;

            while ((index < s.Length) && (!found_open_paren))
            {
                if (s[index] != '(') { index++; }
                else { found_open_paren = true; }
            }

            if (index < s.Length) { 
                string temp = s.Substring(ndx, index - ndx);
                name = new string(temp);
                return true;
            }

            return false;
        }

        /*
         NumChar()
        */
        private bool NumChar(char s)
        {
            bool rvalue = false;

            switch (s)
            {
                case '0':
                case '1':
                case '2':
                case '3':
                case '4':
                case '5':
                case '6':
                case '7':
                case '8':
                case '9':
                case '.': rvalue = true; break;
            }

            return rvalue;
        }

        /*
         Do_ABS()
        */
        private float Do_ABS(float v)
        {
            return Math.Abs(v);
        }

        /*
         Do_SQRT()
        */
        private float Do_SQRT(float v)
        {
            if (v > 0) { return (float)Math.Sqrt(v); }
            else if (v == 0) { return 0; }
            else
            {
                Error_Str = $"Trying to take square root of negitive number: {v}";
                Error_No = 2;
                return 0;
            }
        }

        /*
          Do_COS()
        */
        private float Do_COS(float v)
        {
            return (float)Math.Cos(v * (3.14159 / 180));
        }

        /*
          Do_SIN()
        */
        private float Do_SIN(float v)
        {
            return (float)Math.Sin(v);// * (3.14159 / 180));
        }

        /*
          Do_TAN()
        */
        private float Do_TAN(float v)
        {
            return (float)Math.Tan(v * (3.14159 / 180));
        }

        private float Do_RAN(float v)
        {
            return (float)(Random.Shared.NextDouble() * v);
        }

        private float Do_SGN(float v)
        {
            return v > 0 ? 1f : v < 0 ? -1f : 0;
        }

        private float Get_XNew(string Eq, float h, float U_T, float Xn, float[] I_Cond)
        {
            float k1 = 0.0f, k2 = 0.0f, k3 = 0.0f, k4 = 0.0f, rk = 0.0f;

            k1 = h * Do_K1(Eq, U_T, I_Cond);
            k2 = h * Do_K2(Eq, h, U_T, I_Cond, k1);
            k3 = h * Do_K3(Eq, h, U_T, I_Cond, k2);
            k4 = h * Do_K4(Eq, h, U_T, I_Cond, k3);

            rk = (float)(Xn + ((1.0 / 6.0) * (k1 + 2 * k2 + 2 * k3 + k4)));
            return rk;
        }

        private float Do_K1(string Eq, float U_T, float[] I_Cond)
        {
            string formula = Fix_Length(80);
            string temp = Fix_Length(50);

            int len = Eq.Length, t = 0, c = 0;
            float rvalue = 0.0f;

            while (c < len)
            {
                if ((Eq[c] != 'X') && (Eq[c] != 'U')) { formula = Set_Str_Pos(formula, t, Eq[c]); }// formula[t] = Eq[c];
                else if (Eq[c] == 'U')
                {
                    temp = $"{U_T:F5}";
                    if (U_T < 0) t--;
                    formula = Set_Str_Pos(formula, t, '\x0');
                    formula = formula[..t] + temp + formula[(t + temp.Length)..];
                    //formula += temp;
                    t += temp.Length - 1;
                    c += 3;
                }
                else
                {
                    c++;
                    switch (Eq[c])
                    {
                        case '1': { temp = $"{I_Cond[0]:F5}"; } break;// gcvt(I_Cond[0], 10, temp); break;
                        case '2': { temp = $"{I_Cond[1]:F5}"; } break;// gcvt(I_Cond[1], 10, temp); break;
                    }

                    formula = Set_Str_Pos(formula, t++, '*');
                    formula = formula[..t] + temp + formula[(t + temp.Length)..];
                    //formula += temp;
                    t += temp.Length - 1;
                }
                c++;
                t++;
            }

            rvalue = Evaluate(formula);
            return rvalue;
        }

        private float Do_K2(string Eq, float h, float U_T, float[] I_Cond, float K1)
        {
            string temp = Fix_Length(50), formula = Fix_Length(80);
            int len = Eq.Length, t = 0, c = 0;
            float rvalue = 0.0f;

            while (c < len)
            {
                if ((Eq[c] != 'X') && (Eq[c] != 'U')) { formula = Set_Str_Pos(formula, t, Eq[c]); } //formula[t] = Eq[c];
                else if (Eq[c] == 'U')
                {
                    temp = $"{U_T:F5}";
                    if (U_T < 0) t--;
                    formula = formula[..t] + temp + formula[(t + temp.Length)..];
                    //formula += temp;
                    t += temp.Length - 1;
                    c += 3;
                }
                else
                {
                    c++;
                    switch (Eq[c])
                    {
                        case '1': { temp = $"{I_Cond[0]:F5}"; } break;
                        case '2': { temp = $"{I_Cond[1]:F5}"; } break;
                    }

                    formula = Set_Str_Pos(formula, t++, '*');// [t++] = '*';
                    formula = Set_Str_Pos(formula, t++, '(');// [t++] = '(';
                    formula = formula[..t] + temp + formula[(t + temp.Length)..];
                    //formula += temp;
                    t += temp.Length;
                    formula = Set_Str_Pos(formula, t++, '+');// [t++] = '+';
                    formula = Set_Str_Pos(formula, t++, '(');// [t++] = '(';

                    if (Eq[c] == '1') { temp = $"{h:F5}"; } //gcvt(h, 10, temp);
                    else { temp = $"{K1:F5}"; } //gcvt(K1, 10, temp);

                    formula = formula[..t] + temp + formula[(t + temp.Length)..];
                    //formula += temp;
                    t += temp.Length;
                    formula = Set_Str_Pos(formula, t++, '/');// [t++] = '/';
                    formula = Set_Str_Pos(formula, t++, '2');// [t++] = '2';
                    formula = Set_Str_Pos(formula, t++, ')');// [t++] = ')';
                    formula = Set_Str_Pos(formula, t, ')');// [t] = ')';
                }
                c++;
                t++;
            }

            rvalue = Evaluate(formula);
            return rvalue;
        }

        private float Do_K3(string Eq, float h, float U_T, float[] I_Cond, float K2)
        {
            string temp = Fix_Length(50), formula = Fix_Length(80);
            int len = Eq.Length, t = 0, c = 0;
            float rvalue = 0.0f;

            while (c < len)
            {
                if ((Eq[c] != 'X') && (Eq[c] != 'U')) { formula = Set_Str_Pos(formula, t, Eq[c]); } //formula[t] = Eq[c];
                else if (Eq[c] == 'U')
                {
                    temp = $"{U_T:F5}";
                    if (U_T < 0) t--;
                    formula = formula[..t] + temp + formula[(t + temp.Length)..];
                    //formula += temp;
                    t += temp.Length - 1;
                    c += 3;
                }
                else
                {
                    c++;
                    switch (Eq[c])
                    {
                        case '1': { temp = $"{I_Cond[0]:F5}"; } break;
                        case '2': { temp = $"{I_Cond[1]:F5}"; } break;
                    }
                    formula = Set_Str_Pos(formula, t++, '*');//formula[t++] = '*';
                    formula = Set_Str_Pos(formula, t++, '(');//formula[t++] = '(';
                    formula = formula[..t] + temp + formula[(t + temp.Length)..];
                    //formula += temp;
                    t += temp.Length;
                    formula = Set_Str_Pos(formula, t++, '+');//formula[t++] = '+';
                    formula = Set_Str_Pos(formula, t++, '(');//formula[t++] = '(';

                    if (Eq[c] == '1') { temp = $"{h:F5}"; }// gcvt(h, 10, temp);
                    else { temp = $"{K2:F5}"; }// gcvt(K2, 10, temp);

                    formula = formula[..t] + temp + formula[(t + temp.Length)..];
                    //formula += temp;
                    t += temp.Length;
                    formula = Set_Str_Pos(formula, t++, '/');// [t++] = '/';
                    formula = Set_Str_Pos(formula, t++, '2');// [t++] = '2';
                    formula = Set_Str_Pos(formula, t++, ')');// [t++] = ')';
                    formula = Set_Str_Pos(formula, t, ')');// [t] = ')';
                }
                c++;
                t++;
            }

            rvalue = Evaluate(formula);
            return rvalue;
        }

        private float Do_K4(string Eq, float h, float U_T, float[] I_Cond, float K3)
        {
            string temp = Fix_Length(50), formula = Fix_Length(80);
            int len = Eq.Length, t = 0, c = 0;
            float rvalue = 0.0f;

            while (c < len)
            {
                if ((Eq[c] != 'X') && (Eq[c] != 'U')) { formula = Set_Str_Pos(formula, t, Eq[c]); }// formula[t] = Eq[c];
                else if (Eq[c] == 'U')
                {
                    temp = $"{U_T:F5}";
                    if (U_T < 0) t--;
                    formula = formula[..t] + temp + formula[(t + temp.Length)..];
                    //formula += temp;
                    t += temp.Length - 1;
                    c += 3;
                }
                else
                {
                    c++;
                    switch (Eq[c])
                    {
                        case '1': { temp = $"{I_Cond[0]:F5}"; } break;
                        case '2': { temp = $"{I_Cond[1]:F5}"; } break;
                    }

                    formula = Set_Str_Pos(formula, t++, '*');//formula[t++] = '*';
                    formula = Set_Str_Pos(formula, t++, '(');//formula[t++] = '(';
                    formula = formula[..t] + temp + formula[(t + temp.Length)..];
                    //formula += temp;
                    t += temp.Length;

                    formula = Set_Str_Pos(formula, t++, '+');//formula[t++] = '+';
                    if (Eq[c] == '1') { temp = $"{h:F5}"; }// gcvt(h, 10, temp);
                    else { temp = $"{K3:F5}"; }// gcvt(K3, 10, temp);

                    formula = formula[..t] + temp + formula[(t + temp.Length)..];
                    //formula += temp;
                    t += temp.Length;
                    formula = Set_Str_Pos(formula, t, ')');// [t] = ')';
                }
                c++;
                t++;
            }

            rvalue = Evaluate(formula);
            return rvalue;
        }

        private char[] Initialize_Array(int length)
        {
            char[] rValue = new char[length];

            for (int i = 0; i < length; i++)
            {
                rValue[i] = (char)0;
            }

            return rValue;
        }

        private string Fix_Length(int length)
        {
            return "".PadRight(length);
        }

        private string Set_Str_Pos(string s, int index, char c)
        {
            return s[..index] + c + s[(index + 1)..];
        }

        /*
         Evaluate()
        */
        public float Evaluate(string formula)
        {
            int index = 0;
            float v = 0;

            Error_No = 0;
            Expr(formula, ref v, ref index);

            return v;
        }

        /*
          XEVALUATE
        */
        public int X_Evaluate(string Eq, ref string Ret)
        {
            Error_No = 0;
            string formula = Eq;
            float xe = Evaluate(formula);
            Ret = $"{xe:F5}";
            return Error_No;
        }

        /*
          ProcessEquations()
        */
        public int Process_Equations(string Eq1, string Eq2, float Step, float Fuzzy, float Y1, float Y2, ref string YOUT1, ref string YOUT2,
            int Interval)
        {
            float X1_new = 0.0f, X2_new = 0.0f, Sstep, Ffuzzy;
            float[] FY = new float[2];
            Error_No = 0;

            Sstep = Step;
            Ffuzzy = Fuzzy;
            FY[0] = Y1;
            FY[1] = Y2;

            for (int i = 0; i < Interval; i++)
            {
                X1_new = Get_XNew(Eq1, Sstep, Ffuzzy, FY[0], FY);
                X2_new = Get_XNew(Eq2, Sstep, Ffuzzy, FY[1], FY);
                FY[0] = X1_new;
                FY[1] = X2_new;
            }

            YOUT1 = $"{X1_new:F5}";
            YOUT2 = $"{X2_new:F5}";

            return Error_No;
        }
    }
}
