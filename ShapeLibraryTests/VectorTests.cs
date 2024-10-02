using ShapeLibrary;


namespace ShapeLibraryTests;

[TestClass]
public class VectorTests
{
    [TestMethod]
    public void Test_standardConstructor() {
        try
        {
            Vector v = new(1, 2);
        }
        catch
        {
            Assert.Fail();
        }
    }

    [TestMethod]
    public void Test_CopyConstructor()
    {
        Vector v1 = new(2, 3);
        Vector v2 = new(v1);
        
        float expectedX = 2;
        float expectedY = 3;
        
        Assert.IsNotNull(v2.X);
        Assert.IsNotNull(v2.Y);
        Assert.AreEqual(expectedX, v2.X);
        Assert.AreEqual(expectedY, v2.Y);
    } 

    [TestMethod]
    [DataRow(1, 2, 3, 4)]
    [DataRow(-1, 2, 3, 4)]
    [DataRow(1, -2, 3, 4)]
    [DataRow(1, 2, -3, 4)]
    [DataRow(1, 2, 3, -4)]
    public void Test_Addition(float v1X, float v1Y, float v2X, float v2Y)
    {
        Vector v1 = new Vector(v1X, v1Y);
        Vector v2 = new Vector(v2X, v2Y);
        float expectedX = v1X + v2X;
        float expectedY = v1Y + v2Y;

        Vector added = v1 + v2;

        Assert.IsNotNull(added);
        Assert.AreEqual(expectedX, added.X);
        Assert.AreEqual(expectedY, added.Y);
    }

    [TestMethod]
    [DataRow(1, 2, 3, 4)]
    [DataRow(-1, 2, 3, 4)]
    [DataRow(1, -2, 3, 4)]
    [DataRow(1, 2, -3, 4)]
    [DataRow(1, 2, 3, -4)]
    public void Test_Substraction(float v1X, float v1Y, float v2X, float v2Y)
    {
        Vector v1 = new Vector(v1X, v1Y);
        Vector v2 = new Vector(v2X, v2Y);
        float expectedX = v1X - v2X;
        float expectedY = v1Y - v2Y;

        Vector added = v1 - v2;

        Assert.IsNotNull(added);
        Assert.AreEqual(expectedX, added.X);
        Assert.AreEqual(expectedY, added.Y);
    }
}

