using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeLibrary;

public struct Vector
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
        //Math.pow is expensive, for squaring just multiplication is better
        float squaredX = (float)v.X * v.X;
        float squaredY = (float)v.Y * v.Y;

        return (float)Math.Sqrt(squaredX + squaredY);
    }

    /*
     * Instead of getting a magnitude and squaring it later
     * its more efficient to just have a method that returns the magnitude before
     * the square root
     */
    public static float MagnitudeSquared(Vector v)
    {
        float squaredX = (float)v.X * v.X;
        float squaredY = (float)v.Y * v.Y;

        return (float)squaredX + squaredY;
    }

    public static Vector Normalize(Vector v)
    {
        float mag = Magnitude(v);

        return new Vector(v / mag);
    }

    public override string ToString()
    {
        return $"({this.X },{ this.Y})";
    }

}

