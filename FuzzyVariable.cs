using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fuzzy_Tool
{
    public class FuzzyVariable
    {
        public string Name { get; set; } = "";
        public float Min { get; set; } = 0;
        public float Max { get; set; } = 100;

        public List<MembershipFunction> Sets { get; set; } = new();
    }
}
