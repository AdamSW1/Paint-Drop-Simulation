using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternGenerationLib
{
    public static class PatternGenerationFactory
    {
        public static IPatternGenerator CreatePattern(String type) {
            switch (type)
            {
                case "phyllotaxis":
                    return new PhyllotaxisPatternGeneration();
                default:
                    throw new ArgumentException("No Type");
            }
        }
    }
}
