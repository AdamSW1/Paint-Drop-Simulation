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
    [DataRow(-10, 10, 10)]
    [DataRow(10, -10, 10)]
    [DataRow(10, 10, -10)]
    [ExpectedException(typeof(ArgumentException))]
    public void Test_constructor_throwsError(float x, float y, float radius)
    {
        Circle circle = new(x, y, radius, new(0,0,0));
    }
}

