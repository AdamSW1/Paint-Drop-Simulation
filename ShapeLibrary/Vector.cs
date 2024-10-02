using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeLibrary;

public class Vector
{
    public float X {get;}
    public float Y {get;}

    public Vector(float x, float y) {
        this.X = x;
        this.Y = y;
    }

    public Vector(Vector v)
    {
        this.X = v.X;
        this.Y = v.Y;
    }

    public static Vector operator +(Vector v1, Vector v2)
    {
        return new Vector(v1.X + v2.X, v1.Y + v2.Y);
    }

    public static Vector operator -(Vector v1, Vector v2)
    {
        return new Vector(v1.X - v2.X, v1.Y - v2.Y);
    }

    public static Vector operator *(Vector v1, int scalar)
    {
        return new Vector(v1.X * scalar, v1.Y * scalar);
    }


}

