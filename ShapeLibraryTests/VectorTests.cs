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

}

