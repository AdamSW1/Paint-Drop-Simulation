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

        private IRectangle? _boundingBox;
        public IRectangle BoundingBox {
            get
            {
                _boundingBox ??= UpdateBoundingBox();
                return _boundingBox;
            }
        }

        public PaintDrop(ICircle circle)
        {
            Circle = circle ?? throw new ArgumentNullException(nameof(circle), "circle cannot be null");
        }

        public void Marble(IPaintDrop other)
        {
            if(other is null) throw new ArgumentNullException(nameof(other), "other drop cannot be null");

            Vector center = other.Circle.Center;
            float radius = other.Circle.Radius;

            for (int i = 0; i < Circle.Vertices.Length; i++)
            {
                Vector substracted = Circle.Vertices[i] - center;
                //Math.Pow is expensive, for squaring just multiplication is better
                float radiusSquared = (float)radius * radius;
                float magnitudeSubstracted = Vector.MagnitudeSquared(substracted);
                float discriminant = (float)Math.Sqrt(1 + (radiusSquared / magnitudeSubstracted));
                Vector multiplied = substracted * discriminant;
                Circle.Vertices[i] = center + multiplied;
            }
            _boundingBox = UpdateBoundingBox();
        }

        private IRectangle UpdateBoundingBox()
        {
            float topLeftX = Circle.Vertices.Min(v => v.X);
            float topLeftY = Circle.Vertices.Min(v => v.Y);

            float bottomRightX = Circle.Vertices.Max(v => v.X);
            float bottomRightY = Circle.Vertices.Max(v => v.Y);

            float width = bottomRightX - topLeftX;
            float height = bottomRightY - topLeftY;

            return ShapesFactory.CreateRectangle(topLeftX, topLeftY, width, height, new Colour(0, 0, 0));
        }
    }
}
