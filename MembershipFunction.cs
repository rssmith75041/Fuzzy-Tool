using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fuzzy_Tool
{
    public class MembershipFunction
    {
        public string Name { get; set; } = "";
        public string Shape { get; set; } = "Triangle"; // Triangle or Trapezoid

        public float A { get; set; }
        public float B { get; set; }
        public float C { get; set; }
        public float D { get; set; } // only used for trapezoid

        public float Compute(float x)
        {
            if (Shape == "Triangle")
            {
                if (x <= A || x >= C) return 0;
                if (x == B) return 1;
                if (x < B) return (x - A) / (B - A);
                return (C - x) / (C - B);
            }

            if (Shape == "Trapezoid")
            {
                if (x <= A || x >= D) return 0;
                if (x >= B && x <= C) return 1;
                if (x < B) return (x - A) / (B - A);
                return (D - x) / (D - C);
            }

            return 0;
        }
    }
}
