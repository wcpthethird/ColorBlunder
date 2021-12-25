using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using Color = System.Drawing.Color;

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

        private void SetSolutionColors(List<Color> solutionColors)
        {
            Box0_0.Color = solutionColors[0];
            Box0_1.Color = solutionColors[1];
            Box0_2.Color = solutionColors[2];
            Box0_3.Color = solutionColors[3];
            Box0_4.Color = solutionColors[4];
            Box0_5.Color = solutionColors[5];
            Box0_6.Color = solutionColors[6];
            Box0_7.Color = solutionColors[7];
            Box0_8.Color = solutionColors[8];
            Box0_9.Color = solutionColors[9];
        }

        public void SetProblemColors(List<Color> problemColors)
        {
            Box0_0.Color = problemColors[0];
            Box0_1.Color = problemColors[1];
            Box0_2.Color = problemColors[2];
            Box0_3.Color = problemColors[3];
            Box0_4.Color = problemColors[4];
            Box0_5.Color = problemColors[5];
            Box0_6.Color = problemColors[6];
            Box0_7.Color = problemColors[7];
            Box0_8.Color = problemColors[8];
            Box0_9.Color = problemColors[9];
            CheckSolution(colors.solution, colors.problem);
        }

        public void CheckSolution(List<Color> solution, List<Color> problem)
        {
            List<int> tempProblem = new List<int>();
            List<int> tempSolution = new List<int>();

            for (int i = 0; i < solution.Count; i++)
            {
                int solutionIndex = i;
                int problemIndex = problem.FindIndex(a => a.Name.Contains(solution[i].Name));
                tempProblem.Add(problemIndex);
                tempSolution.Add(solutionIndex);
            }
            if (tempProblem.SequenceEqual(tempSolution))
            {
                GameOverMessage();
            }
            return;
        }

        public void GameOverMessage()
        {
            DisplayAlert("Game Over", "You Win!", "Close");
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
            List<Color> tempProblem = colors.problem;

            int colorOneIndex = tempProblem.FindIndex(x => x == selectedColors[0]);
            int colorTwoIndex = tempProblem.FindIndex(x => x == selectedColors[1]);

            tempProblem[colorTwoIndex] = selectedColors[0];
            tempProblem[colorOneIndex] = selectedColors[1];

            colors.problem = tempProblem;

            SetProblemColors(colors.problem);
        }
    }
}
