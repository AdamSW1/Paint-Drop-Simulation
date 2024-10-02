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
}

