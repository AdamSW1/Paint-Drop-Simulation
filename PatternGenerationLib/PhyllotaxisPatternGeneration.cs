using PaintDropSimulation;
using ShapeLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternGenerationLib;
public class PhyllotaxisPatternGeneration : IPatternGenerator
{
    private int _index = 0;
    private const int scalingFactor = 15;
    private const float goldenAngle = 137.5f;


    public Vector? CalculatePatternPoint(ISurface surface)
    {
        int centerX = surface.Width / 2;
        int centerY = surface.Height / 2;

        float radius = scalingFactor * MathF.Sqrt(_index);

        float theta = _index * goldenAngle;

        float dropX = centerX + (radius * MathF.Cos(theta));

        float dropY = centerY + (radius * MathF.Sin(theta));

        _index++;

        return new Vector(dropX, dropY);
    }
}

