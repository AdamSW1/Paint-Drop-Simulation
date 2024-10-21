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
    public class PaintDropTests
    {
        [TestMethod]
        public void Test_constructor_passes()
        {
            try
            {
                ICircle circle = new Circle(10, 10, 50, new Colour(0,0,0));
                PaintDrop paintDrop = new PaintDrop(circle);

                Assert.AreEqual(circle, paintDrop.Circle);
            }
            catch
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Test_constructor_fails() {
            PaintDrop paintDrop = new PaintDrop(null!);
        }
    }
}
