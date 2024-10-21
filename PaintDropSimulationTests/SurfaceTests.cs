using PaintDropSimulation;
using ShapeLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaintDropSimulationTests
{
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
        [DataRow(0,100)]
        [DataRow(100,0)]
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
        [ExpectedException (typeof(ArgumentNullException))]
        public void Test_AddPaintDrop_nullDrop_throwsException()
        {
            Surface surface = new(100,100);
            PaintDrop drop = null!;

            surface.AddPaintDrop(drop);
        }
    }
}
