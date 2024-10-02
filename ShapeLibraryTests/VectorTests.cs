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

    [TestMethod]
    [DataRow(2, 3, 4)]
    [DataRow(-2, 3, 4)]
    [DataRow(2, -3, 4)]
    [DataRow(2, 3, -4)]
    [DataRow(-2, 3, -4)]
    [DataRow(2, -3, -4)]
    public void Test_Multiplication(float vX, float vY, float scalar)
    {
        Vector v = new Vector(vX, vY);
        float expectedX = vX * scalar;
        float expectedY = vY * scalar;

        Vector multiplied = v * scalar;

        Assert.IsNotNull (multiplied);
        Assert.AreEqual(expectedX, multiplied.X);
        Assert.AreEqual(expectedY, multiplied.Y);
    }

    [TestMethod]
    [DataRow(4, 6, 2)]
    [DataRow(-4, 6, 3)]
    [DataRow(4, -6, 3)]
    [DataRow(4, 6, -3)]
    public void Test_Division_noZeros(float vx, float vy, float scalar){ 
        Vector v = new Vector(vx, vy);
        float expectedX = vx / scalar;
        float expectedY = vy / scalar;

        Vector divided = v / scalar;

        Assert.IsNotNull (divided);
        Assert.AreEqual(expectedX, divided.X, 0.0001);
        Assert.AreEqual(expectedY, divided.Y, 0.0001);
    }

    [TestMethod]
    [DataRow(4, 6, 0)]
    [DataRow(-4, 6, 0)]
    [DataRow(4, -6, 0)]
    [ExpectedException(typeof(ArgumentException))]
    public void test_Division_throwsArgumentException(float vx, float vy, float scalar)
    {
        Vector v = new Vector(vx, vy);
        float expectedX = vx / scalar;
        float expectedY = vy / scalar;

        Vector divided = v / scalar;
    }

    [TestMethod]
    [DataRow(1, 2)]
    [DataRow(-1, 2)]
    [DataRow(1, -2)]
    [DataRow(0, 0)]
    public void test_magnitude(float vx, float vy)
    {
        Vector v = new Vector(vx, vy);

        float expectedMag = (float)Math.Sqrt(Math.Pow(vx, 2) + Math.Pow(vy, 2)); 
        float actualMag = Vector.Magnitude(v);

        Assert.AreEqual(expectedMag, actualMag, 0.0001);
    }
}

