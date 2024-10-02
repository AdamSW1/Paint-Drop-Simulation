using ShapeLibrary;
using System.Runtime.Intrinsics.X86;
using System.Security.Cryptography;

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


    [TestMethod]
    [DataRow(100,100,100,100,100,100)]
    [DataRow(255,100,100,100,100,100)]
    [DataRow(100,255,100,100,100,100)]
    [DataRow(100,100,255,100,100,100)]
    public void Test_Addition_passes(int R1, int G1, int B1, int R2, int G2, int B2)
    {
        Colour ColourA = new Colour(R1, G1, B1);
        Colour ColourB = new Colour(R2, G2, B2);
        int expectedRed = R1 + R2;
        int expectedGreen = G1 + G2;
        int expectedBlue = B1 + B2;

        if(expectedRed > 255)
        {
            expectedRed = 255;
        }
        if (expectedGreen > 255)
        {
            expectedGreen = 255;
        }
        if (expectedBlue > 255)
        {
            expectedBlue = 255;
        }

        Colour Added = ColourA + ColourB;

        int actualRed = Added.Red;
        int actualGreen = Added.Green;
        int actualBlue = Added.Blue;

        Assert.AreEqual(expectedRed, actualRed);
        Assert.AreEqual(expectedGreen, actualGreen);
        Assert.AreEqual(expectedBlue, actualBlue);

    }


}