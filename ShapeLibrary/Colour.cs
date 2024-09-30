using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeLibrary;
    public struct Colour
    {
        public int red { get; }
        public int green { get; } 
        public int blue { get; }

        public Colour(int red, int green, int blue)
        {
            this.red = red;
            this.green = green;
            this.blue = blue;
        }

        
    }

