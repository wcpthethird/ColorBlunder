using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Color = System.Drawing.Color;

namespace ColorBlunder
{
    public class ColorContainer : BoxView
    {
        public int Column { get; set; }
        public int Row { get; set; }
        public bool IsSelected { get; set; }
    }
}
