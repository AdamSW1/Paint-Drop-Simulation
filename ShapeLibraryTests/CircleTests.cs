using ShapeLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeLibraryTests;

[TestClass]
public class CircleTests
{
    [TestMethod]
    public void Test_constructor_valid()
    {
        try
        {
            Circle circle = new(10, 10, 100, new Colour(0 , 0 , 0));

        }
        catch
        {
            Assert.Fail();
        }
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void Test_constructor_throwsError()
    {
        Circle circle = new(10, 10, -10, new(0,0,0));
    }

    [TestMethod]
    public void Test_verticesGetter()
    {
        float x = 10;
        float y = 10;
        float radius = 50;

        Circle circle = new(x, y, radius, new(0,0,0));

        float expectedFirstX = 60f;
        float expectedFirstY = 10f;

        float expectedLastX = 59.97f;
        float expectedLastY = 8.42f;

        Assert.AreEqual(expectedFirstX, circle.Vertices[0].X, 0.1);
        Assert.AreEqual(expectedFirstY, circle.Vertices[0].Y, 0.1);
        Assert.AreEqual(expectedLastX, circle.Vertices[199].X, 0.1);
        Assert.AreEqual(expectedLastY, circle.Vertices[199].Y, 0.1);
    }
}

