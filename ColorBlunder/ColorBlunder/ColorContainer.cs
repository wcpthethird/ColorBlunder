using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace ColorBlunder
{
    public class ColorContainer
    {
        readonly Random rand = new Random();
        public List<Color> solutionColors;
        public List<Color> shuffledColors;

        public ColorContainer()
        {
            ValidateColors();
        }

        public void ValidateColors()
        {
            List<Color> baseColors = new List<Color>()
            {
                RandomColor(),
                RandomColor()
            };

            float colorDifference = Math.Abs(baseColors[1].GetHue() - baseColors[0].GetHue());

            if (CheckValue(colorDifference))
            {
                GenerateColorGradient(baseColors, 10);
            }
            else
            {
                ValidateColors();
            }
        }

        public void GenerateColorGradient(List<Color> baseColors, int size)
        {
            var tempGradientList = new List<Color>();
            for (int i = 0; i < size; i++)
            {
                var rAverage = baseColors[0].R + (baseColors[1].R - baseColors[0].R) * i / size;
                var gAverage = baseColors[0].G + (baseColors[1].G - baseColors[0].G) * i / size;
                var bAverage = baseColors[0].B + (baseColors[1].B - baseColors[0].B) * i / size;
                tempGradientList.Add(Color.FromArgb(rAverage, gAverage, bAverage));
            }
            solutionColors = tempGradientList
                .OrderBy(color => color.GetHue())
                .ToList();

            shuffledColors = solutionColors
                .GetRange(1, 9)
                .OrderBy(color => rand.Next())
                .ToList();
        }

        bool CheckValue(double difference)
        {
            return (difference >= 45 && difference <= 90);
        }

        public Color RandomColor()
        {
            int r = rand.Next(255);
            int g = rand.Next(255);
            int b = rand.Next(255);
            Color startColor = Color.FromArgb(r, g, b);
            return startColor;
        }
    }
}
