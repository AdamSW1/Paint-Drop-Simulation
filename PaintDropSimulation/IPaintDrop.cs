using ShapeLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PaintDropSimulation
{
    public interface IPaintDrop
    {
        /// <summary>
        /// Represents a circle to be marbled
        /// </summary>
        ICircle Circle { get; }

        /// <summary>
        /// Represents the bounding box around the paitn drop
        /// </summary>
        IRectangle BoundingBox {  get; }

        /// <summary>
        /// Performs the marbling algorithm
        /// </summary>
        /// <param name="other">The other paintdrop to be combined with</param>
        void Marble(IPaintDrop other);
    }
}
