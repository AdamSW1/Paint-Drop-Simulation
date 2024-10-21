using PaintDropSimulation;
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
    }
}
