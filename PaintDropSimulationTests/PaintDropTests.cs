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

        [TestMethod]
        public void Test_marbling_valid()
        {
            ICircle circleA = new Circle(200, 200, 50, new Colour(0, 0, 0));
            ICircle circleB = new Circle(280, 200, 50, new Colour(0, 0, 0));

            circleA.Vertices[0] = new Vector(235.36f, 164.64f);

            PaintDrop dropA = new PaintDrop(circleA);
            PaintDrop dropB = new PaintDrop(circleB);

            float expectedX = 220.598f;
            float expectedY = 152.946f;

            dropA.Marble(dropB);

            Assert.AreEqual(expectedX, dropA.Circle.Vertices[0].X, 0.01);
            Assert.AreEqual(expectedY, dropA.Circle.Vertices[0].Y, 0.01);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Test_marbling_throwsError()
        {
            ICircle circleA = new Circle(200, 200, 50, new Colour(0, 0, 0));

            PaintDrop dropA = new PaintDrop(circleA);
            PaintDrop dropB = null!;

            dropA.Marble(dropB);

        }

        [TestMethod]
        public void Test_boundingBox_updates()
        {
            ICircle circleA = new Circle(200, 200, 50, new Colour(0, 0, 0));
            ICircle circleB = new Circle(280, 200, 50, new Colour(0, 0, 0));

            PaintDrop dropA = new(circleA);
            PaintDrop dropB = new(circleB);

            IRectangle previousBoundingBox = dropA.BoundingBox;

            dropA.Marble(dropB);

            CollectionAssert.AreNotEquivalent(previousBoundingBox.Vertices, dropA.BoundingBox.Vertices);
        }
    }
}
