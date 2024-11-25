using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternGenerationLib
{
    public static class PatternGenerationFactory
    {
        public static IPatternGenerator CreatePattern(String type, int numIterations = 0) {
            switch (type)
            {
                case "phyllotaxis":
                    return new PhyllotaxisPatternGeneration();
                case "koch":
                    if (numIterations < 1) {
                        throw new ArgumentException("Number of iterations cannot be less than 1");
                    }

                    return new KochCurvePatternGeneration(numIterations);
                default:
                    throw new ArgumentException("No Type");
            }
        }
    }
}
