using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace ColorBlunder
{
    public class ColorContainer : Colors
    {
        public int Column { get; set; }
        public int Row { get; set; }
        public Color Color { get; set; }
        public bool IsSelected { get; set; }
    }
}
