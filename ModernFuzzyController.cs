using System;
using System.Collections.Generic;
using System.Linq;

namespace Fuzzy_Tool
{
    public class ModernFuzzyController
    {
        public FuzzyVariable ErrorVar { get; set; }
        public FuzzyVariable DErrorVar { get; set; }
        public FuzzyVariable OutputVar { get; set; }
        public List<FuzzyRule> Rules { get; set; }

        public ModernFuzzyController(FuzzyVariable e, FuzzyVariable de, FuzzyVariable outVar, List<FuzzyRule> rules)
        {
            ErrorVar = e;
            DErrorVar = de;
            OutputVar = outVar;
            Rules = rules;
        }

        public float Compute(float e, float de)
        {
            // Fuzzify
            var deVals = DErrorVar.Sets.ToDictionary(mf => mf.Name, mf => mf.Compute(de));
            var eVals = ErrorVar.Sets.ToDictionary(mf => mf.Name, mf => mf.Compute(e));

            // Rule evaluation (Mamdani MIN)
            Dictionary<string, float> outputStrength = new();

            foreach (var rule in Rules)
            {
                float strength = Math.Min(eVals[rule.ErrorSet], deVals[rule.DErrorSet]);

                if (!outputStrength.ContainsKey(rule.OutputSet)) { outputStrength[rule.OutputSet] = strength; }
                else { outputStrength[rule.OutputSet] = Math.Max(outputStrength[rule.OutputSet], strength); }
            }

            // Defuzzify (centroid of peaks)
            float num = 0;
            float den = 0;

            foreach (var mf in OutputVar.Sets)
            {
                if (outputStrength.TryGetValue(mf.Name, out float s))
                {
                    float peak = mf.B; // center of triangle
                    num += peak * s;
                    den += s;
                }
            }

            return (den == 0) ? 0 : num / den;
        }
    }
}
