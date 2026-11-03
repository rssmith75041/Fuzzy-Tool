using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fuzzy_Tool
{
    public sealed class TwoStateSystem
    {
        // State: X1, X2
        public float X1 { get; private set; }
        public float X2 { get; private set; }

        // Input: V (your U_T / Fuzzy)
        public float V { get; set; }

        public TwoStateSystem(float x1Init, float x2Init)
        {
            X1 = x1Init;
            X2 = x2Init;
        }

        // Right-hand side of the ODEs
        // dX1/dt =  1*X2 - 1*X1 + V
        // dX2/dt = -1*X2 - 1*X1 + V
        private void Derivatives(float x1, float x2, float v, out float dx1, out float dx2)
        {
            dx1 = (1f * x2) - (1f * x1) + v;
            dx2 = (-1f * x2) - (1f * x1) + v;
        }

        // One RK4 step of size h
        public void StepRK4(float h)
        {
            float k1_x1, k1_x2;
            float k2_x1, k2_x2;
            float k3_x1, k3_x2;
            float k4_x1, k4_x2;

            // k1
            Derivatives(X1, X2, V, out k1_x1, out k1_x2);
            // k2
            Derivatives(X1 + 0.5f * h * k1_x1, X2 + 0.5f * h * k1_x2, V, out k2_x1, out k2_x2);
            // k3
            Derivatives(X1 + 0.5f * h * k2_x1, X2 + 0.5f * h * k2_x2, V, out k3_x1, out k3_x2);
            // k4
            Derivatives(X1 + h * k3_x1, X2 + h * k3_x2, V, out k4_x1, out k4_x2);
            // Combine
            X1 += (h / 6f) * (k1_x1 + 2f * k2_x1 + 2f * k3_x1 + k4_x1);
            X2 += (h / 6f) * (k1_x2 + 2f * k2_x2 + 2f * k3_x2 + k4_x2);
        }
    }
}

/*

Usage:
-----------------------------------------------------
var sys = new TwoStateSystem(x1Init: 0f, x2Init: 0f);
sys.V = fuzzyOutput;   // your controller output
sys.StepRK4(h);        // advance one time step

float y1 = sys.X1;
float y2 = sys.X2;

 */