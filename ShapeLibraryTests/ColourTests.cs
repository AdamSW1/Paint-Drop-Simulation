using ShapeLibrary;

namespace ShapeLibraryTests;

[TestClass]
public class ColourTests
{
    [TestMethod]
    public void Test_Constructor_Passes()
    {
        try
        {
            Colour colour = new Colour(255, 255, 255);
        } catch (Exception ex) {
            Assert.Fail();
        }
    }

    [TestMethod]
    [DataRow(260, 100, 100)]
    [DataRow(100, 260, 100)]
    [DataRow(100, 100, 260)]
    [DataRow(-10, 100, 100)]
    [DataRow(100, -10, 100)]
    [DataRow(100, 100, -10)]
    [ExpectedException(typeof(ArgumentException))]
    public void Test_Constructor_InvalidValues(int r, int g, int b)
    {
        Colour colour = new Colour(r, g, b);

    }


}