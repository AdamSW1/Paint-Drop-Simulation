using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaintDropSimulation
{
    internal class Surface : ISurface
    {
        public int Width { get; }

        public int Height { get; }
        public List<IPaintDrop> Drops { get; }

        public Surface(int width, int height)
        {
            if(width <= 0 || height <= 0)
            {
                throw new ArgumentException("width and height cannot be less than 0");
            }

            Width = width;
            Height = height;
        }

        public void AddPaintDrop(IPaintDrop drop)
        {
            Drops.Add(drop);

            foreach (IPaintDrop d in Drops)
            {
                d.Marble(drop);
            }
        }
    }
}
