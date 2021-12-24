using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace ColorBlunder
{
    public class Colors
    {
        readonly Random rand = new Random();
        public List<ColorContainer> solution;
        public List<ColorContainer> problem;

        private void GenerateColorGradient(List<Color> baseColors, int size)
        {
            var tempGradientList = new List<Color>();
            for (int i = 0; i < size; i++)
            {
                var rAverage = baseColors[0].R + (baseColors[1].R - baseColors[0].R) * i / size;
                var gAverage = baseColors[0].G + (baseColors[1].G - baseColors[0].G) * i / size;
                var bAverage = baseColors[0].B + (baseColors[1].B - baseColors[0].B) * i / size;
                tempGradientList.Add(Color.FromArgb(rAverage, gAverage, bAverage));
            }
            tempGradientList
                .OrderBy(color => color.GetHue())
                .ToList();
            SetColorProperties(tempGradientList);
        }

        private void SetColorProperties(List<Color> tempColors)
        {
            solution = new List<ColorContainer>();
            foreach (Color color in tempColors)
            {
                solution.Add(new ColorContainer
                {
                    Color = color,
                    Row = tempColors.IndexOf(color),
                    Column = 0
                });
            }
            SetProblemColors(solution);
        }

        private void SetProblemColors(List<ColorContainer> tempColors)
        {
            problem = new List<ColorContainer>();
            tempColors = solution.GetRange(1, solution.Count - 2);
            tempColors = tempColors.OrderBy(c => rand.Next()).ToList();
            tempColors.Insert(0, solution.First());
            tempColors.Add(solution.Last());
            problem = tempColors;
        }

        private bool CheckValue(double difference)
        {
            return (difference >= 45 && difference <= 90);
        }

        private void ValidateColors(List<Color> baseColors)
        {
            float colorDifference = Math.Abs(baseColors[1].GetHue() - baseColors[0].GetHue());
            if (CheckValue(colorDifference))
            {
                GenerateColorGradient(baseColors, 10);
            }
            else PickColors();
        }

        private Color RandomColor()
        {
            int r = rand.Next(255);
            int g = rand.Next(255);
            int b = rand.Next(255);
            Color startColor = Color.FromArgb(r, g, b);
            return startColor;
        }

        public void PickColors()
        {
            List<Color> baseColors = new List<Color>()
            {
                RandomColor(),
                RandomColor()
            };
            ValidateColors(baseColors);
        }
    }
}
