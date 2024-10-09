using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeLibrary;
public static class ShapesFactory
{
    public static ICircle CreateCircle(float X, float Y, float radius, Colour colour)
    {
        return new Circle(X, Y, radius, colour);
    }
    public static IRectangle CreateRectangle(float x, float y, float width, float height, Colour colour) { 
        return new Rectangle(x, y, width, height, colour);
    }
}

