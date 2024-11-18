using PaintDropSimulation;
using ShapeLibrary;

namespace PaintDropSimulationTests;
[TestClass]
public class SurfaceTests
{
    [TestMethod]
    public void Test_constructor_passed()
    {
        try
        {
            Surface surface = new(100, 100);
            Assert.AreEqual(100, surface.Width);
            Assert.AreEqual(100, surface.Height);
        }
        catch
        {
            Assert.Fail();
        }
    }

    [TestMethod]
    [DataRow(0, 100)]
    [DataRow(100, 0)]
    [DataRow(-10, 100)]
    [DataRow(100, -10)]
    [ExpectedException(typeof(ArgumentException))]
    public void Test_constructor_throwsException(int width, int height)
    {
        Surface surface = new Surface(width, height);
    }

    [TestMethod]
    public void Test_addPaintDrop_appends()
    {
        Surface surface = new(100, 100);
        Circle circle = new Circle(10, 10, 50, new Colour(0, 0, 0));
        PaintDrop drop = new PaintDrop(circle);

        List<IPaintDrop> expected = new()
            {
                drop
            };

        surface.AddPaintDrop(drop);

        CollectionAssert.AreEquivalent(expected, surface.Drops);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void Test_AddPaintDrop_nullDrop_throwsException()
    {
        Surface surface = new(100, 100);
        PaintDrop drop = null!;

        surface.AddPaintDrop(drop);
    }

    [TestMethod]
    public void Test_GeneratePaintDropPattern_addsDrop()
    {
        Surface surface = new(100, 100);
        Boolean isCalled = false;
        surface.OnCalculatePatternPoint += (ISurface surface) =>
        {
            isCalled = true;
            return new Vector(1, 2);
        };

        surface.GeneratePaintDropPattern(5, new Colour(0, 0, 0));

        ICircle actual = surface.Drops[0].Circle;

        ICircle expected = new Circle(1, 2, 10, new Colour(0, 0, 0));

        Assert.IsTrue(isCalled);
        Assert.AreEqual(1, surface.Drops.Count);
        Assert.AreEqual(expected.Center.X, actual.Center.X);
        Assert.AreEqual(expected.Center.Y, actual.Center.Y);

    }

    [TestMethod]
    public void Test_GeneratePaintDropPattern_nullVector_doesntAdd()
    {
        Surface surface = new(100, 100);
        Boolean isCalled = false;
        surface.OnCalculatePatternPoint += (ISurface surface) =>
        {
            isCalled = true;
            return null;
        };

        surface.GeneratePaintDropPattern(5, new Colour(0, 0, 0));
        Assert.IsTrue(isCalled);
        Assert.AreEqual(0, surface.Drops.Count);
    }

    [TestMethod]
    public void Test_dropInsideBorder_IsAdded()
    {
        Surface surface = new(10, 10);

        ICircle circleA = new Circle(5, 5, 2, new Colour(0, 0, 0));
        PaintDrop dropA = new PaintDrop(circleA);

        surface.AddPaintDrop(dropA);

        Assert.AreEqual(1, surface.Drops.Count);

    }

    [TestMethod]
    public void Test_dropOnBorder_IsAdded()
    {
        Surface surface = new(10, 10);

        ICircle circleA = new Circle(10, 10, 10, new Colour(0, 0, 0));
        PaintDrop dropA = new PaintDrop(circleA);

        surface.AddPaintDrop(dropA);

        Assert.AreEqual(1, surface.Drops.Count);
    }

    [TestMethod]
    public void Test_dropOutsideBorder_isRemoved()
    {
        Surface surface = new(10, 10);

        ICircle circleA = new Circle(200, 200, 10, new Colour(0, 0, 0));
        PaintDrop dropA = new PaintDrop(circleA);

        surface.AddPaintDrop(dropA);

        Assert.AreEqual(0, surface.Drops.Count);

    }

}

