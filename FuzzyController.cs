using System;
using System.Linq;

namespace Fuzzy_Tool
{
    public class FuzzyController
    {
        public int[] DominantCat { get; private set; } = new int[2];
        private float[] maxWeight = new float[2];

        private float ParseF(int j, int k)
        {
            switch(Global.FuzzySet[j, k])
            {
                case "INF": return float.PositiveInfinity;
                case "-INF": return float.NegativeInfinity;
                default: return float.Parse(Global.FuzzySet[j, k]);
            }
            
        }

        // ---------------------------------------------------------------------
        // MEMBERSHIP CALCULATION
        // ---------------------------------------------------------------------

        private void ComputeMemberships(float x, float[,] weightRow, int rowIndex)
        {
            for (int j = 0; j < 7; j++)
            {
                weightRow[rowIndex, j] = 0f;

                string aStr = Global.FuzzySet[j, 0];
                string bStr = Global.FuzzySet[j, 1];
                string cStr = Global.FuzzySet[j, 2];
                string dStr = Global.FuzzySet[j, 3];

                // -INF
                if (aStr == "-INF")
                {
                    float b = ParseF(j, 1);
                    float c = ParseF(j, 2);

                    if (x <= b)
                    {
                        weightRow[rowIndex, 0] = 1f;
                        if (1f > maxWeight[rowIndex])
                        {
                            maxWeight[rowIndex] = 1f;
                            DominantCat[rowIndex] = 0;
                        }
                    }
                    else if (x > b && x <= c)
                    {
                        float val = (x - c) * Global.slope[j, 1];
                        weightRow[rowIndex, j] = val;

                        if (val > maxWeight[rowIndex])
                        {
                            maxWeight[rowIndex] = val;
                            DominantCat[rowIndex] = j;
                        }
                    }
                    continue;
                }

                // +INF
                if (cStr == "INF")
                {
                    float a = ParseF(j, 0);
                    float b = ParseF(j, 1);

                    if (x >= b)
                    {
                        weightRow[rowIndex, 6] = 1f;
                        if (1f > maxWeight[rowIndex])
                        {
                            maxWeight[rowIndex] = 1f;
                            DominantCat[rowIndex] = 6;
                        }
                    }
                    else if (x >= a && x < b)
                    {
                        float val = (x - a) * Global.slope[j, 0];
                        weightRow[rowIndex, j] = val;

                        if (val > maxWeight[rowIndex])
                        {
                            maxWeight[rowIndex] = val;
                            DominantCat[rowIndex] = j;
                        }
                    }
                    continue;
                }

                // Triangle or trapezoid
                if (aStr == "") continue;

                float a2 = ParseF(j, 0);
                float b2 = ParseF(j, 1);
                float c2 = ParseF(j, 2);

                if (dStr == "") // triangle
                {
                    if (x >= a2 && x <= c2)
                    {
                        float val;

                        if (x == b2)
                            val = 1f;
                        else if (x < b2)
                            val = (x - a2) * Global.slope[j, 0];
                        else
                            val = (x - c2) * Global.slope[j, 1];

                        weightRow[rowIndex, j] = val;

                        if (val > maxWeight[rowIndex])
                        {
                            maxWeight[rowIndex] = val;
                            DominantCat[rowIndex] = j;
                        }
                    }
                }
                else // trapezoid
                {
                    float d2 = ParseF(j, 3);

                    if (x >= a2 && x <= d2)
                    {
                        float val;

                        if (x >= b2 && x <= c2)
                            val = 1f;
                        else if (x < b2)
                            val = (x - a2) * Global.slope[j, 0];
                        else
                            val = (x - d2) * Global.slope[j, 1];

                        weightRow[rowIndex, j] = val;

                        if (val > maxWeight[rowIndex])
                        {
                            maxWeight[rowIndex] = val;
                            DominantCat[rowIndex] = j;
                        }
                    }
                }
            }
        }

        // ---------------------------------------------------------------------
        // IMPLICATION
        // ---------------------------------------------------------------------

        private float Implication(float a, float b)
        {
            switch (Global.ImplicationRule)
            {
                case 0: return Math.Max(a, b);
                case 1: return Math.Min(a, b);
                case 2: return ((1 - a) > Math.Min(a, b)) ? 1 - a : Math.Min(a, b);
                case 3: return (a <= b) ? 1 : 0;
                case 4: return (a <= b) ? 1 : b;
                case 5: return (a <= b) ? 1 : b / a;
                case 6: return Math.Max(1 - a, b);
                case 7: return Math.Min(1, 1 - a + b);
                case 8: return 1 - a + a * b;
                case 9: return Math.Min(Math.Min(Math.Max(1 - a, b), Math.Max(a, 1 - a)), Math.Max(b, 1 - b));
                case 10: return (a <= b) ? 1 : Math.Min(1 - a, b);
                case 11: return (a == 0 && b == 0) ? 1 : (float)Math.Pow(b, a);
                case 12: return 1 - a + (float)Math.Pow(a, 2) * b;
            }

            return 0;
        }

        // ---------------------------------------------------------------------
        // MAIN DEFUZZIFICATION
        // ---------------------------------------------------------------------

        public float Compute()
        {
            float[,] Weight = new float[2, 7];
            DominantCat = new int[2];
            maxWeight[0] = maxWeight[1] = -1f;

            float z = 0f, s = 0f;

            // Memberships
            ComputeMemberships(Global.XError, Weight, 0);
            ComputeMemberships(Global.dError, Weight, 1);

            // -----------------------------------------------------------------
            // APPLY WEIGHTS SAFELY
            // -----------------------------------------------------------------

            // Ensure weights exist
            if (Global.X_Weights == null || Global.X_Weights.Length < 14)
            {
                Global.X_Weights = Enumerable.Repeat(1f, 14).ToArray();
            }

            // If all weights are zero, restore defaults
            if (Global.X_Weights.All(w => w == 0f))
            {
                for (int i = 0; i < 14; i++)
                {
                    Global.X_Weights[i] = 1f;
                }
            }

            // Apply weights
            for (int i = 0; i < 7; i++)
            {
                Weight[0, i] *= Global.X_Weights[i];       // E weights
                Weight[1, i] *= Global.X_Weights[i + 7];   // dE weights
            }

            // -----------------------------------------------------------------
            // RULE AGGREGATION + DEFUZZIFICATION
            // -----------------------------------------------------------------

            for (int j = 0; j < 7; j++)
            {
                for (int i = 0; i < 7; i++)
                {
                    float wX = Weight[0, i];
                    float wD = Weight[1, j];

                    if (wX != 0f && wD != 0f)
                    {
                        float Cz = Implication(wX, wD);
                        z += Cz * Global.X_GridValues[j, i];
                        s += Cz;
                    }
                }
            }

            return (z != 0f && s != 0f) ? z / s : 0f;
        }
    }
}
