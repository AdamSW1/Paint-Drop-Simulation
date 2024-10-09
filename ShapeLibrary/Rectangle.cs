using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeLibrary;
internal class Rectangle : IRectangle
{
    public float X { get; }

    public float Y { get;  }

    public float Width { get; }

    public float Height { get; }

    private Vector[] _vertices;

    public Vector[] Vertices
    {
        get
        {
            if (_vertices == null)
            {
                _vertices = new Vector[4];
                Vector vertice1 = new(X, Y);
                Vector vertice2 = new(X + Width, Y);
                Vector vertice3 = new(X + Width, Y + Height);
                Vector vertice4 = new(X, Y + Height);
                _vertices[0] = vertice1;
                _vertices[1] = vertice2;
                _vertices[2] = vertice3;
                _vertices[3] = vertice4;
            }
            return _vertices;
        }
    }

    public Colour Colour {  get; }

    public Rectangle(float x, float y, float width, float height, Colour colour)
    {
        if (x < 0 || y < 0 || width < 0 || height < 0)
        {
            throw new ArgumentException("x,y, width or height cannot be less than 0");
        }
        X = x;
        Y = y;
        Width = width;
        Height = height;
        Colour = colour;
    }
}

