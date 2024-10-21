using ShapeLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

[assembly: InternalsVisibleTo("PaintDropSimulationTests")]
namespace PaintDropSimulation
{
    internal class PaintDrop : IPaintDrop
    {
        public ICircle Circle { get; }

        public PaintDrop(ICircle circle)
        {
            Circle = circle ?? throw new ArgumentNullException("circle cannot be null");
        }

        public void Marble(IPaintDrop other)
        {
            if(other is null) throw new ArgumentNullException("other drop cannot be null");

            Vector center = other.Circle.Center;
            float radius = other.Circle.Radius;

            for (int i = 0; i < Circle.Vertices.Length; i++)
            {
                Vector substracted = Circle.Vertices[i] - center;
                float radiusSquared = (float)Math.Pow(radius, 2);
                float magnitudeSubstracted = Vector.Magnitude(substracted);
                float discriminant = (float)Math.Sqrt(1 + (radiusSquared / Math.Pow(magnitudeSubstracted, 2)));
                Vector multiplied = substracted * discriminant;
                Circle.Vertices[i] = center + multiplied;
            }
        }
    }
}
