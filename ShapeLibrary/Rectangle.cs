using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeLibrary;
public class Rectangle : IRectangle
{
    public float X { get; }

    public float Y { get;  }

    public float Width { get; }

    public float Height { get; }

    public Vector[] Vertices
    {
        get
        {
            Vector[] Vertices = new Vector[4];

            Vector vertice1 = new(X, Y);
            Vector vertice2 = new(X + Width, Y);
            Vector vertice3 = new(X + Width, Y + Height); 
            Vector vertice4 = new(X, Y + Height);
            Vertices[0] = vertice1;
            Vertices[1] = vertice2;
            Vertices[2] = vertice3;
            Vertices[3] = vertice4;
            return Vertices;
        }
    }

    public Colour Colour {  get; }

    public Rectangle(float x, float y, float width, float height, Colour colour)
    {
        X = x;
        Y = y;
        Width = width;
        Height = height;
        Colour = colour;
    }
}

