using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Policy;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using System.Xml.Linq;

namespace Fuzzy_Tool
{
    public static class Global
    {
        [JsonIgnore]
        public static Fuzzy_Main_Form? FuzzyMainForm { get; set; }
        [JsonIgnore]
        public static Fuzzy_Control_Form? FuzzyControlForm { get; set; }
        [JsonIgnore]
        public static Fuzzy_Firing_Form? FuzzyFiringForm { get; set; }
        //[JsonIgnore]
        //public static Fuzzy_Set_Form? FuzzySetForm { get; set; }
        [JsonIgnore]
        public static Fuzzy_Form? FuzzyForm { get; set; }

        public static float[,] X_GridValues { get; set; } = new float[7, 7];
        public static float[,] slope { get; set; } = new float[7, 2];

        public static float[] CategoryValues { get; set; }  = new float[7];
        public static float[] InitialState { get; set; }  = new float[2];
        public static float[] CurrentState { get; set; } = new float[2];  // new state, [1] = x velocity
        public static float[] IdealState { get; set; } = new float[2];
        public static float[] X_Weights { get; set; } = new float[14];    //weights for E and dE

        public static float Step_h { get; set; } = 0.0f;
        public static int Which_Parser { get; set; } = 0;                       //Modern
        public static float Noisef;
        public static float XError;
        public static float dError;
        public static float Fuzzy;
        public static float Zoomx;
        public static float Zoomy;
        public static float Zoomd;

        public static string[,] RuleBaseX = new string[7, 7];
        public static string[,] FuzzySet = new string[7, 4];
        public static string[] CatNames = new string[7];

        //Will need to convert this to an array
        public static string[]? Equations = null;

        public static string FuzzyFolder = string.Empty;
        public static string GraphType = string.Empty;
        public static string Comment = string.Empty;
        public static string Noiseq = string.Empty;

        public static bool XVelocityAsdError = false;
        public static bool CategoryValuesFlag;
        public static bool XGridValuesFlag;
        public static bool Pause_Execution;
        public static bool Stop_Execution;
        public static bool Allow_Subsets;
        public static bool FuzzySetsFlag;
        public static bool InitialFlag;
        public static bool IdealFlag;
        public static bool Rulsaveit;
        public static bool Setsaveit;
        public static bool Executing;
        public static bool Fuzsaved;
        public static bool Rulsaved;
        public static bool Setsaved;
        public static bool Stepping;
        public static bool Cancel;

        public static int ImplicationRule { get; set; } = 0;                  // <- Legacy Parser Only
        public static int MaxIter { get; set; } = 1000;
        public static int Interval = 0;
        public static int Noise1 = 0;
        public static int Noise2 = 0;

        public static float GoalErr = 0;
        public static int yx;
        public static int yder;
        public static float lastX;
        public static float lastE;
        public static float lastF;
        public static float lastD;
        public static float plotx;
        public static float ploty;
        public static float g_top;
        public static float g_h;
        public static bool autox;
        public static bool autod;
        public static long xColor;
        public static long dColor;
        public static int shiftx;

        public static void Get_Slopes()
        {
            for (int i = 0; i < 6; i++)
            {
                if (FuzzySet[i, 0].ToString() != "-INF" && FuzzySet[i, 2].ToString() != "INF" && FuzzySet[i, 0].ToString() != "")
                {
                    slope[i, 0] = 1 / (float.Parse(FuzzySet[i, 1].ToString()) - float.Parse(FuzzySet[i, 0].ToString()));

                    if (FuzzySet[i, 3].ToString() == "") //triangle
                    {
                        slope[i, 1] = -1 / (float.Parse(FuzzySet[i, 2].ToString()) - float.Parse(FuzzySet[i, 1].ToString()));
                    }
                    else //trapezoidal
                    {
                        slope[i, 1] = -1 / (float.Parse(FuzzySet[i, 3].ToString()) - float.Parse(FuzzySet[i, 2].ToString()));
                    }
                }
                else if (FuzzySet[i, 0].ToString() == "-INF")
                {
                    slope[i, 1] = -1 / (float.Parse(FuzzySet[i, 2].ToString()) - float.Parse(FuzzySet[i, 1].ToString()));
                }
                else if (FuzzySet[i, 2].ToString() == "INF")
                {
                    slope[i, 0] = 1 / (float.Parse(FuzzySet[i, 1].ToString()) - float.Parse(FuzzySet[i, 0].ToString()));
                }
            }
        }

        public static float Max(float a, float b)
        {
            if (a > b) { return a; }
            return b;
        }

        public static float Min(float a, float b)
        {
            if (a < b) { return a; }
            return b;
        }

        public static void ResetBlankProject()
        {
            dColor = Color.LightGreen.ToArgb();
            xColor = Color.White.ToArgb();

            CategoryValuesFlag = false;
            XGridValuesFlag = false;
            Allow_Subsets = false;
            FuzzySetsFlag = false;
            InitialFlag = false;
            IdealFlag = false;
            Rulsaveit = false;
            Setsaveit = false;
            Fuzsaved = true;
            Rulsaved = true;
            Setsaved = true;
            autox = false;
            autod = false;

            GraphType = "dE";
            Comment = "";
            Noiseq = "";

            Step_h = .001f;
            Noise1 = 0;
            Noise2 = 0;
            Noisef = 0;
            g_top = 10;
            Zoomy = 10;
            g_h = -20;
            Zoomx = 1;

            Interval = 10;
            shiftx = 0;
            
            for (int j = 0; j <= 6; j++)
            {
                for (int i = 0; i <= 3; i++)
                {
                    FuzzySet[j, i] = "";
                }
            }

            for (int i = 0; i < 6; i++)
            {
                slope[i, 0] = 0;
                slope[i, 1] = 0;
            }

            for (int i = 0; i <= 6; i++)
            {
                CategoryValues[i] = 0;
            }

            InitialState[0] = 0;
            InitialState[1] = 0;
            CurrentState[0] = 0;
            CurrentState[1] = 0;
            IdealState[0] = 0;
            IdealState[1] = 0;

            for (int i = 0; i <= 6; i++)
            {
                for (int j = 0; j <= 6; j++)
                {
                    X_GridValues[i, j] = 0;
                }
            }

            for (int i = 0; i <= 6; i++)
            {
                for (int j = 0; j <= 6; j++)
                {
                    RuleBaseX[i, j] = "ZE";
                }
            }
            
            FuzzyForm = new Fuzzy_Form();
            FuzzyForm.MdiParent = FuzzyMainForm;

            FuzzyControlForm = new Fuzzy_Control_Form();
            FuzzyControlForm.MdiParent = FuzzyMainForm;
            FuzzyFiringForm = new Fuzzy_Firing_Form();
            FuzzyFiringForm.MdiParent = FuzzyMainForm;
        }

        public static void SetupArrays()
        {
            for (int j = 0; j < 7; j++)
            {
                for (int i = 0; i < 7; i++)
                {
                    switch (RuleBaseX[j, i])
                    {
                        case "NL": X_GridValues[j, i] = CategoryValues[0]; break;
                        case "NM": X_GridValues[j, i] = CategoryValues[1]; break;
                        case "NS": X_GridValues[j, i] = CategoryValues[2]; break;
                        case "ZE": X_GridValues[j, i] = CategoryValues[3]; break;
                        case "PS": X_GridValues[j, i] = CategoryValues[4]; break;
                        case "PM": X_GridValues[j, i] = CategoryValues[5]; break;
                        case "PL": X_GridValues[j, i] = CategoryValues[6]; break;
                    }
                }
            }
        }
    }
}
