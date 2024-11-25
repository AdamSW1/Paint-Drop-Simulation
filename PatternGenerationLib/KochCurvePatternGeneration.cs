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
        if(surface == null) throw new ArgumentNullException(nameof(surface),"surface cannot be null");
        
        //On first call, generates all the points needed to 
        // create the pattern
        if(_kochPoints.Count == 0)
        {
            Vector start = new(0, surface.Height / 2);
            Vector end = new(surface.Width, surface.Height / 2);
            _kochPoints = GenerateKochCurvePoints(start, end, _maxIterations);
        }

        if(_index >= _kochPoints.Count)
        {
            return null;
        }

        // get the next point in the pattern
        Vector nextPoint = _kochPoints[_index];
        _index++;
        return nextPoint;

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
        List<Vector> points = new List<Vector>();

        //on the last iteration you only need to pass the start and end points
        if ( iterations == 0)
        {
            points.Add(start);
            points.Add(end);
            return points;
        }

        float dx = end.X - start.X;
        float dy = end.Y - start.Y;

        /// The first point before the start of the triangle in the curve
        /// See following image for clearer explanation of points p1, p2 and p3 locations
        /// <img src="{./media/basicCurvePattern.png}" /> 
        Vector p1 = new(start.X + dx / 3, start.Y + dy / 3);

        // The point immediately after the triagle
        Vector p3 = new(start.X + 2 * dx / 3, start.Y + 2 * dy / 3);

        float angle = MathF.Atan2(dy, dx);

        //rotate the angle at point p2 by 60 degrees (pi/3 in rads) to create the triangle
        float angleRotated = angle - MathF.PI / 3;

        //math magic to get the length of the segment
        float length = MathF.Sqrt(dx * dx + dy * dy) / 3;
        Vector p2 = new(
            p1.X + length * MathF.Cos(angleRotated),
            p1.Y + length * MathF.Sin(angleRotated)
        );

        // use recursion to generate all the points from:
        // start to p1, p1 to p2, p2 to p3 and p3 to the end
        // AddRange method of list takes another list and appends it to this one
        points.AddRange(GenerateKochCurvePoints(start,p1,iterations-1));
        points.AddRange(GenerateKochCurvePoints(p1, p2, iterations-1));
        points.AddRange(GenerateKochCurvePoints(p2, p3, iterations-1));
        points.AddRange(GenerateKochCurvePoints(p3, end, iterations-1));

        return points;
    }


    public void ResetIndex()
    {
        _index = 0;
        _kochPoints.Clear();
    }
}

