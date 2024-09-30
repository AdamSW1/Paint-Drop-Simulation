using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeLibrary;
    public struct Colour
    {
        public int red { get; }
        public int green { get; } 
        public int blue { get; }

        public Colour(int red, int green, int blue)
        {
            this.red = red;
            this.green = green;
            this.blue = blue;
        }

    public static Colour operator +(Colour a, Colour b)
    {
        int newRed = a.red + b.red;
        int newGreen = a.green + b.green;
        int newBlue = a.blue + b.blue;

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
        int newRed = a.red - b.red;
        int newGreen = a.green - b.green;
        int newBlue = a.blue - b.blue;

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
}

