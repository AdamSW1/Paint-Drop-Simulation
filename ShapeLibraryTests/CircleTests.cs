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
        Circle circle = new(x, y, radius, new(0,0,0));
    }
}

