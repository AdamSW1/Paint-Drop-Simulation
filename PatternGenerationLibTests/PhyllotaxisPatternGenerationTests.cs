using PaintDropSimulation;
using PatternGenerationLib;
using ShapeLibrary;
namespace PatternGenerationLibTests;

[TestClass]
public class PhyllotaxisPatternGenerationTests
{
    [TestMethod]
    public void TestPatternGeneration_returnsCorrectPoints()
    {
        PhyllotaxisPatternGeneration patternGeneration = new();

        Surface surface = new Surface(800, 420);
        Vector? actualFirst = patternGeneration.CalculatePatternPoint(surface);
        Vector? expectedFirst = new(400, 210);

        Vector? actualSecond = patternGeneration.CalculatePatternPoint(surface);
        Vector? expectedSecond = new(388.940f, 220.1338f);

        Assert.IsNotNull(actualFirst);
        Assert.IsNotNull(actualSecond);

        Assert.AreEqual(expectedFirst.Value.X, actualFirst.Value.X, 0.001);
        Assert.AreEqual(expectedFirst.Value.X, actualFirst.Value.X, 0.001);

        Assert.AreEqual(expectedSecond.Value.X, actualSecond.Value.X, 0.001);
        Assert.AreEqual(expectedSecond.Value.Y, actualSecond.Value.Y, 0.001);

    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void TestPointCalculation_NullSurface_throwsArgumentNullException()
    {
        PhyllotaxisPatternGeneration patternGeneration = new();
        Surface? surface = null;
        patternGeneration.CalculatePatternPoint(surface!);
    }

}