using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeLibrary;
public struct Colour
{
    public int Red { get; }
    public int Green { get; }
    public int Blue { get; }

    public Colour(int red, int green, int blue)
    {
        if (red < 0 || red > 255)
        {
            throw new ArgumentException("Colour 'red' cannot be less than 0 or greater than 255");
        }
        if (green < 0 || green > 255)
        {
            throw new ArgumentException("Colour 'green' cannot be less than 0 or greater than 255");
        }
        if (blue < 0 || blue > 255)
        {
            throw new ArgumentException("Colour 'blue' cannot be less than 0 or greater than 255");
        }

        this.Red = red;
        this.Green = green;
        this.Blue = blue;
    }

    public static Colour operator +(Colour a, Colour b)
    {
        int newRed = a.Red + b.Red;
        int newGreen = a.Green + b.Green;
        int newBlue = a.Blue + b.Blue;

        if (newRed > 255)
        {
            newRed = 255;
        }
        if (newGreen > 255)
        {
            newGreen = 255;
        }
        if (newBlue > 255)
        {
            newBlue = 255;
        }

        return new Colour(newRed, newGreen, newBlue);
    }


    public static Colour operator -(Colour a, Colour b)
    {
        int newRed = a.Red - b.Red;
        int newGreen = a.Green - b.Green;
        int newBlue = a.Blue - b.Blue;

        if (newRed < 0)
        {
            newRed = 0;
        }
        if (newGreen < 0)
        {
            newGreen = 0;
        }
        if (newBlue < 0)
        {
            newBlue = 0;
        }

        return new Colour(newRed, newGreen, newBlue);
    }

    public static Colour operator *(Colour a, int num)
    {

        int newRed = a.Red * num;
        int newGreen = a.Green * num;
        int newBlue = a.Blue * num;

        if (newRed < 0)
        {
            newRed = 0;
        }
        if (newGreen < 0)
        {
            newGreen = 0;
        }
        if (newBlue < 0)
        {
            newBlue = 0;
        }

        if(newRed > 255)
        {
            newRed = 255;
        }
        if( newGreen  > 255)
        {
            newGreen = 255;
        }
        if( newBlue > 255)
        {
            newBlue = 255;
        }

        return new Colour(newRed, newGreen, newBlue);
    }

    public static bool operator ==(Colour a, Colour b)
    {
        return a.Red == b.Red && a.Green == b.Green && a.Blue == b.Blue;
    }
    public static bool operator !=(Colour a, Colour b)
    {
        return a.Red == b.Red && a.Green == b.Green && a.Blue == b.Blue;
    }


}

