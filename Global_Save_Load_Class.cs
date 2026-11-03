using System;

namespace Fuzzy_Tool
{
    public class Global_Save_Load_Class
    {
        // jagged instead of [,]
        public float[][] X_GridValues = new float[7][];
        public float[][] slope = new float[7][];

        public float[] CategoryValues = new float[7];
        public float[] InitialState = new float[2];
        public float[] CurrentState = new float[2];  // new state, [1] = x velocity
        public float[] IdealState = new float[2];
        public float[] X_Weights = new float[14];    //weights for E and dE

        public float Step_h = 0.0f;
        public int Which_Parser = 0;
        public float Noisef;
        public float XError;
        public float dError;
        public float Fuzzy;
        public float Zoomx;
        public float Zoomy;
        public float Zoomd;

        // jagged instead of [,]
        public string[][] RuleBaseX = new string[7][];
        public string[][] FuzzySet = new string[7][];
        public string[] CatNames = new string[7];

        public string[]? Equations = null;

        public string FuzzyFolder = string.Empty;
        public string GraphType = string.Empty;
        public string Comment = string.Empty;
        public string Noiseq = string.Empty;

        public bool XVelocityAsdError = false;
        public bool CategoryValuesFlag;
        public bool XGridValuesFlag;
        public bool Pause_Execution;
        public bool Stop_Execution;
        public bool Allow_Subsets;
        public bool FuzzySetsFlag;
        public bool InitialFlag;
        public bool IdealFlag;
        public bool Rulsaveit;
        public bool Setsaveit;
        public bool Executing;
        public bool Fuzsaved;
        public bool Rulsaved;
        public bool Setsaved;
        public bool Stepping;
        public bool Cancel;

        public int ImplicationRule = 0;
        public int MaxIter = 1000;
        public int Interval = 0;
        public int Noise1 = 0;
        public int Noise2 = 0;

        public float GoalErr = 0;
        public int yx;
        public int yder;
        public float lastX;
        public float lastE;
        public float lastF;
        public float lastD;
        public float plotx;
        public float ploty;
        public float g_top;
        public float g_h;
        public bool autox;
        public bool autod;
        public long xColor;
        public long dColor;
        public int shiftx;

        // helpers: 2D <-> jagged

        private static float[][] ToJagged(float[,] array)
        {
            int rows = array.GetLength(0);
            int cols = array.GetLength(1);
            var jagged = new float[rows][];

            for (int r = 0; r < rows; r++)
            {
                jagged[r] = new float[cols];
                for (int c = 0; c < cols; c++)
                {
                    jagged[r][c] = array[r, c];
                }
            }

            return jagged;
        }

        private static float[,] FromJagged(float[][] jagged)
        {
            int rows = jagged.Length;
            int cols = jagged[0].Length;
            var array = new float[rows, cols];

            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < cols; c++)
                {
                    array[r, c] = jagged[r][c];
                }
            }

            return array;
        }

        private static string[][] ToJagged(string[,] array)
        {
            int rows = array.GetLength(0);
            int cols = array.GetLength(1);
            var jagged = new string[rows][];

            for (int r = 0; r < rows; r++)
            {
                jagged[r] = new string[cols];
                for (int c = 0; c < cols; c++)
                {
                    jagged[r][c] = array[r, c];
                }
            }

            return jagged;
        }

        private static string[,] FromJagged(string[][] jagged)
        {
            int rows = jagged.Length;
            int cols = jagged[0].Length;
            var array = new string[rows, cols];

            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < cols; c++)
                {
                    array[r, c] = jagged[r][c];
                }
            }

            return array;
        }

        // snapshot from Global -> this serializable class
        public static Global_Save_Load_Class ToData()
        {
            return new Global_Save_Load_Class
            {
                X_GridValues = ToJagged(Global.X_GridValues),
                slope = ToJagged(Global.slope),

                CategoryValues = Global.CategoryValues,
                InitialState = Global.InitialState,
                CurrentState = Global.CurrentState,
                IdealState = Global.IdealState,
                X_Weights = Global.X_Weights,

                Step_h = Global.Step_h,
                Which_Parser = Global.Which_Parser,
                Noisef = Global.Noisef,
                XError = Global.XError,
                dError = Global.dError,
                Fuzzy = Global.Fuzzy,
                Zoomx = Global.Zoomx,
                Zoomy = Global.Zoomy,
                Zoomd = Global.Zoomd,

                RuleBaseX = ToJagged(Global.RuleBaseX),
                FuzzySet = ToJagged(Global.FuzzySet),
                CatNames = Global.CatNames,
                Equations = Global.Equations,

                FuzzyFolder = Global.FuzzyFolder,
                GraphType = Global.GraphType,
                Comment = Global.Comment,
                Noiseq = Global.Noiseq,

                XVelocityAsdError = Global.XVelocityAsdError,
                CategoryValuesFlag = Global.CategoryValuesFlag,
                XGridValuesFlag = Global.XGridValuesFlag,
                Pause_Execution = Global.Pause_Execution,
                Stop_Execution = Global.Stop_Execution,
                Allow_Subsets = Global.Allow_Subsets,
                FuzzySetsFlag = Global.FuzzySetsFlag,
                InitialFlag = Global.InitialFlag,
                IdealFlag = Global.IdealFlag,
                Rulsaveit = Global.Rulsaveit,
                Setsaveit = Global.Setsaveit,
                Executing = Global.Executing,
                Fuzsaved = Global.Fuzsaved,
                Rulsaved = Global.Rulsaved,
                Setsaved = Global.Setsaved,
                Stepping = Global.Stepping,
                Cancel = Global.Cancel,

                ImplicationRule = Global.ImplicationRule,
                MaxIter = Global.MaxIter,
                Interval = Global.Interval,
                Noise1 = Global.Noise1,
                Noise2 = Global.Noise2,

                GoalErr = Global.GoalErr,
                yx = Global.yx,
                yder = Global.yder,
                lastX = Global.lastX,
                lastE = Global.lastE,
                lastF = Global.lastF,
                lastD = Global.lastD,
                plotx = Global.plotx,
                ploty = Global.ploty,
                g_top = Global.g_top,
                g_h = Global.g_h,
                autox = Global.autox,
                autod = Global.autod,
                xColor = Global.xColor,
                dColor = Global.dColor,
                shiftx = Global.shiftx
            };
        }

        // push loaded data back into Global
        public void FromData()
        {
            Global.X_GridValues = FromJagged(this.X_GridValues);
            Global.slope = FromJagged(this.slope);

            Global.CategoryValues = this.CategoryValues;
            Global.InitialState = this.InitialState;
            Global.CurrentState = this.CurrentState;
            Global.IdealState = this.IdealState;
            Global.X_Weights = this.X_Weights;

            Global.Step_h = this.Step_h;
            Global.Which_Parser = this.Which_Parser;
            Global.Noisef = this.Noisef;
            Global.XError = this.XError;
            Global.dError = this.dError;
            Global.Fuzzy = this.Fuzzy;
            Global.Zoomx = this.Zoomx;
            Global.Zoomy = this.Zoomy;
            Global.Zoomd = this.Zoomd;

            Global.RuleBaseX = FromJagged(this.RuleBaseX);
            Global.FuzzySet = FromJagged(this.FuzzySet);
            Global.CatNames = this.CatNames;
            Global.Equations = this.Equations;

            Global.FuzzyFolder = this.FuzzyFolder;
            Global.GraphType = this.GraphType;
            Global.Comment = this.Comment;
            Global.Noiseq = this.Noiseq;

            Global.XVelocityAsdError = this.XVelocityAsdError;
            Global.CategoryValuesFlag = this.CategoryValuesFlag;
            Global.XGridValuesFlag = this.XGridValuesFlag;
            Global.Pause_Execution = this.Pause_Execution;
            Global.Stop_Execution = this.Stop_Execution;
            Global.Allow_Subsets = this.Allow_Subsets;
            Global.FuzzySetsFlag = this.FuzzySetsFlag;
            Global.InitialFlag = this.InitialFlag;
            Global.IdealFlag = this.IdealFlag;
            Global.Rulsaveit = this.Rulsaveit;
            Global.Setsaveit = this.Setsaveit;
            Global.Executing = this.Executing;
            Global.Fuzsaved = this.Fuzsaved;
            Global.Rulsaved = this.Rulsaved;
            Global.Setsaved = this.Setsaved;
            Global.Stepping = this.Stepping;
            Global.Cancel = this.Cancel;

            Global.ImplicationRule = this.ImplicationRule;
            Global.MaxIter = this.MaxIter;
            Global.Interval = this.Interval;
            Global.Noise1 = this.Noise1;
            Global.Noise2 = this.Noise2;

            Global.GoalErr = this.GoalErr;
            Global.yx = this.yx;
            Global.yder = this.yder;
            Global.lastX = this.lastX;
            Global.lastE = this.lastE;
            Global.lastF = this.lastF;
            Global.lastD = this.lastD;
            Global.plotx = this.plotx;
            Global.ploty = this.ploty;
            Global.g_top = this.g_top;
            Global.g_h = this.g_h;
            Global.autox = this.autox;
            Global.autod = this.autod;
            Global.xColor = this.xColor;
            Global.dColor = this.dColor;
            Global.shiftx = this.shiftx;
        }
    }
}
