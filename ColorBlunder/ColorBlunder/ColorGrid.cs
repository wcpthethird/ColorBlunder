using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ColorBlunder
{
    public class ColorGrid
    {
        public ColorGrid()
        {
            ReadyColors();
            _ = new Grid
            {
                ColumnDefinitions =
            {
                new ColumnDefinition()
            },
                RowDefinitions =
            {
                new RowDefinition(),
                new RowDefinition(),
                new RowDefinition(),
                new RowDefinition(),
                new RowDefinition(),
                new RowDefinition(),
                new RowDefinition(),
                new RowDefinition(),
                new RowDefinition(),
                new RowDefinition()
            }
            };
        }

        public void ReadyColors()
        {
            Colors colors = new Colors();
            List<ColorContainer> cContainers = new List<ColorContainer>();
            foreach (Color c in colors.solutionColors)
            {
                ColorContainer cContainer = new ColorContainer
                {
                    Column = 0,
                    Row = colors.solutionColors.IndexOf(c),
                    Color = c,
                    IsSelected = false
                };
                cContainers.Add(cContainer);
            }
        }
    }
}
