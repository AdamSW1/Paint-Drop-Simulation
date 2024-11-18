using PaintDropSimulation;
using ShapeLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternGenerationLib;
internal class PhyllotaxisPatternGeneration : IPatternGenerator
{
    private int _index = 0;
    private int MaxPoints;
    private const int scalingFactor = 15;
    private const float goldenAngle = 137.5f;

    public PhyllotaxisPatternGeneration() { }

    public Vector? CalculatePatternPoint(ISurface surface)
    {
        if(surface == null) throw new ArgumentNullException(nameof(surface),"surface cannot be null");
        int centerX = surface.Width / 2;
        int centerY = surface.Height / 2;

        float radius = scalingFactor * MathF.Sqrt(_index);

        float theta = _index * (MathF.PI / 180 * goldenAngle);

        float dropX = centerX + (radius * MathF.Cos(theta));

        float dropY = centerY + (radius * MathF.Sin(theta));


        if (dropX > surface.Width || dropX < 0 || dropY > surface.Height || dropY < 0)
        {
            return null;
        }

        _index++;

        return new Vector(dropX, dropY);
    }

    public void ResetIndex()
    {
        _index = 0;
    }
}

