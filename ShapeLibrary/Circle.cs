using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

[assembly: InternalsVisibleTo("ShapeLibraryTests")]
namespace ShapeLibrary;
internal class Circle : ICircle
{
    public float Radius { get; }

    public Vector Center { get; }

    private const int points = 6;

    private Vector[] _vertices;
    public Vector[] Vertices
    {
        get
        {
            if(_vertices == null)
            {
                _vertices = new Vector[points];
                double pi = Math.PI;
                double angle = (2 * pi) / points;
                for (int i = 0; i < points; i++) {
                    double theta = angle * i;
                    float X = (float)(Center.X + (Radius * Math.Cos(theta)));
                    float Y = (float)(Center.Y + (Radius * Math.Sin(theta)));
                    _vertices[i] = new Vector(X, Y);
                }
            }
            return _vertices;
        }
    }

    public Colour Colour { get;  }

    public Circle(float X, float Y, float radius, Colour colour)
    {
        if(radius < 0)
        {
            throw new ArgumentException("Radius cannot be negative");
        }
        if (X < 0 || Y < 0)
        {
            throw new ArgumentException("X and Y positions cannot be less than 0");
        }
        Center = new Vector(X, Y);
        Radius = radius;
        Colour = colour;
    }
}

