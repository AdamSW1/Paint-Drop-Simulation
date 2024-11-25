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

    /// <summary>
    /// Generates a list of vectors representing each point on the curve. 
    /// The number of points and overall appearance of the curve depend on the amount
    /// of iterations done.
    /// <see href="https://nostarch.com/download/PythonPlayground_SampleChapter1.pdf"/>
    /// <seealso href="https://natureofcode.com/fractals/#the-koch-curve"/>
    /// </summary>
    /// <param name="start">A Vector representing the start point of all the points in the curve</param>
    /// <param name="end">A Vector representing the end point of all the points in the curve</param>
    /// <param name="iterations"></param>
    /// <returns>A list of vectors with all the points in the pattern</returns>
    private List<Vector> GenerateKochCurvePoints(Vector start, Vector end, int iterations) { 
    }


    public void ResetIndex()
    {
        _index = 0;
        _kochPoints.Clear();
    }
}

