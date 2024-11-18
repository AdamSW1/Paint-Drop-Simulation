using ShapeLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

[assembly: InternalsVisibleTo("PaintDropSimulationTests")]
[assembly: InternalsVisibleTo("PatternGenerationLibTests")]
namespace PaintDropSimulation
{
    internal class Surface : ISurface
    {
        public int Width { get; }

        public int Height { get; }
        public List<IPaintDrop> Drops { get; } = new();

        public event CalculatePatternPoint? OnCalculatePatternPoint;

        public Surface(int width, int height)
        {
            if(width <= 0 || height <= 0)
            {
                throw new ArgumentException("width and height cannot be less than 0");
            }

            Width = width;
            Height = height;
        }


        public void AddPaintDrop(IPaintDrop drop)
        {
            if (drop is null) throw new ArgumentNullException(nameof(drop), "Drop cannot be null");

            foreach (IPaintDrop d in Drops)
            {
                d.Marble(drop);
            }

            Drops.Add(drop);
        }

        public void GeneratePaintDropPattern(int radius, Colour colour)
        {
            if(OnCalculatePatternPoint is null)
            {
                throw new ArgumentNullException(nameof(OnCalculatePatternPoint), "Event cannot be null");
            }

            Vector? newDropVector = OnCalculatePatternPoint?.Invoke(this);

            if (!newDropVector.HasValue)
            {
                return;
            }

            ICircle circle = ShapesFactory.CreateCircle(newDropVector.Value.X, newDropVector.Value.Y, radius, colour);

            IPaintDrop drop = PaintDropSimulationFactory.CreatePaintDrop(circle);

            AddPaintDrop(drop);
        }
    }
}
