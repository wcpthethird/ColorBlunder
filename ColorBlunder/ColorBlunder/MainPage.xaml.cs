using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ColorBlunder
{
    public partial class MainPage : ContentPage
    {
        readonly Colors colors;
        public List<Color> selectedColors = new List<Color>();

        public MainPage()
        {
            colors = new Colors();

            InitializeComponent();
            SetSolutionColors(colors.solution);
        }

        private void BtnGenerate_Clicked(object sender, EventArgs e)
        {
            colors.PickColors();
            SetSolutionColors(colors.solution);
        }

        private void BtnPlay_Clicked(object sender, EventArgs e)
        {
            SetProblemColors(colors.problem);
        }

        private void SetSolutionColors(List<BoxView> solutionColors)
        {
            Box0_0.Color = solutionColors[0].Color;
            Box0_1.Color = solutionColors[1].Color;
            Box0_2.Color = solutionColors[2].Color;
            Box0_3.Color = solutionColors[3].Color;
            Box0_4.Color = solutionColors[4].Color;
            Box0_5.Color = solutionColors[5].Color;
            Box0_6.Color = solutionColors[6].Color;
            Box0_7.Color = solutionColors[7].Color;
            Box0_8.Color = solutionColors[8].Color;
            Box0_9.Color = solutionColors[9].Color;
        }

        public void SetProblemColors(List<BoxView> problemColors)
        {
            Box0_0.Color = problemColors[0].Color;
            Box0_1.Color = problemColors[1].Color;
            Box0_2.Color = problemColors[2].Color;
            Box0_3.Color = problemColors[3].Color;
            Box0_4.Color = problemColors[4].Color;
            Box0_5.Color = problemColors[5].Color;
            Box0_6.Color = problemColors[6].Color;
            Box0_7.Color = problemColors[7].Color;
            Box0_8.Color = problemColors[8].Color;
            Box0_9.Color = problemColors[9].Color;
        }

        public bool CheckSolution()
        {
            if (colors.problem != colors.solution)
            {
                return false;
            }
            return true;
        }

        public void GameOverMessage()
        {
            if (CheckSolution())
            {
                DisplayAlert("Game Over", "You Win!", "Close");
            }
        }

        private void ColorContainer_Tapped(object sender, EventArgs e)
        {
            BoxView selectedColor = (BoxView)sender;

            selectedColors.Add(selectedColor.Color);

            if (selectedColors.Count == 2)
            {
                SwitchGridPosition(selectedColors);
                selectedColors.Clear();
            }
        }

        private void SwitchGridPosition(List<Color> selectedColors)
        {
            List<BoxView> tempProblem = colors.problem;

            int colorOneIndex = tempProblem.FindIndex(x => x.Color == selectedColors[0]);
            int colorTwoIndex = tempProblem.FindIndex(x => x.Color == selectedColors[1]);

            tempProblem[colorTwoIndex].Color = selectedColors[0];
            tempProblem[colorOneIndex].Color = selectedColors[1];

            colors.problem = tempProblem;

            SetProblemColors(colors.problem);
        }
    }
}
