using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fuzzy_Tool
{
    public class FuzzyRule
    {
        public string ErrorSet { get; set; } = "";
        public string DErrorSet { get; set; } = "";
        public string OutputSet { get; set; } = "";

        public override string ToString()
        {
            return $"IF Error is {ErrorSet} AND dError is {DErrorSet} THEN Output is {OutputSet}";
        }
    }
}
