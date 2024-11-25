using PaintDropSimulation;
using ShapeLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternGenerationLib;
internal class KochCurvePatternGeneration : IPatternGenerator
{

    private List<Vector> _kochPoints = new List<Vector>();
    private int _index = 0;
    private int _maxIterations;

    public KochCurvePatternGeneration(int maxIterations) { 
        _maxIterations = maxIterations;
    }

    public Vector? CalculatePatternPoint(ISurface surface)
    {
        throw new NotImplementedException();
    }

    public void ResetIndex()
    {
        _index = 0;
        _kochPoints.Clear();
    }
}

