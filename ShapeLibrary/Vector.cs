using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeLibrary;

public class Vector
{
    public float X { get; }
    public float Y { get; }

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

    public static Vector operator *(Vector v1, float scalar)
    {
        return new Vector(v1.X * scalar, v1.Y * scalar);
    }

    public static Vector operator /(Vector v1, float scalar){

        if (scalar == 0)
        {
            throw new ArgumentException("Cannot divide by zero");
        }

        return new Vector(v1.X / scalar, v1.Y / scalar);
    }

    public static float Magnitude(Vector v)
    {
        if (v == null)
        {
            throw new ArgumentNullException(nameof(v), "vector cannot be null");
        }
        float squaredX = (float)Math.Pow(v.X, 2);
        float squaredY = (float)Math.Pow(v.Y, 2);

        return (float)Math.Sqrt(squaredX + squaredY);
    }

    public static Vector Normalize(Vector v)
    {
        if (v == null)
        {
            throw new ArgumentNullException(nameof(v), "Vector cannot be null");
        }

        float mag = Magnitude(v);

        return new Vector(v / mag);

    }


}

