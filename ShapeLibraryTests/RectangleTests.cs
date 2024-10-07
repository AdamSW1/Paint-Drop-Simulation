using ShapeLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeLibraryTests;

[TestClass]
public class RectangleTests
{
    [TestMethod]
    public void Test_constructor_valid()
    {
        Colour colour = new(0,0 ,0);
        Rectangle rect = new(10, 10, 10, 10, colour);
        float expectedX = 10;
        float expectedY = 10;
        float expectedWidth = 10;
        float expectedHeight = 10;

            
        Assert.AreEqual(expectedX, rect.X);
        Assert.AreEqual(expectedY, rect.Y);
        Assert.AreEqual(expectedWidth, rect.Width);
        Assert.AreEqual(expectedHeight, rect.Height);
    }

    [TestMethod]
    [DataRow(-10, 10, 10, 10)]
    [DataRow(10, -10, 10, 10)]
    [DataRow(10, 10, -10, 10)]
    [DataRow(10, 10, 10, -10)]
    [ExpectedException(typeof(ArgumentException))]
    public void Test_constructor_throwsError(float x, float y, float width, float height) {
        Colour colour = new(0, 0, 0);
        Rectangle rect = new(x, y, width, height, colour);
    }

    [TestMethod]
    public void Test_getVertices()
    {
        Colour colour = new(0, 0, 0);
        Rectangle rect = new(10, 10, 10, 10, colour);
        Vector[] vertices = rect.Vertices;

        Vector[] expectedVertices = new Vector[4];
        expectedVertices[0] = new Vector(10,10);
        expectedVertices[1] = new Vector(20, 10);
        expectedVertices[2] = new Vector(20, 20);
        expectedVertices[3] = new Vector(10, 20);

        CollectionAssert.AreEqual(expectedVertices, vertices);

        
    }
}



