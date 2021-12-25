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
        readonly Colors colors = new Colors();
        public List<Color> tempSolution;
        public List<Color> selectedColors = new List<Color>();
        public bool solved = false;


        public MainPage()
        {
            InitializeComponent();
            StartGame();
        }

        private void BtnGenerate_Clicked(object sender, EventArgs e)
        {
            StartGame(CheckSolved(solved));
        }

        private void BtnPlay_Clicked(object sender, EventArgs e)
        {
            PlayGame(colors.problem);
        }

        public void PlayGame(List<Color> unsolved)
        {
            tempSolution = new List<Color>(colors.problem);
            selectedColors = new List<Color>();
            SetColors(unsolved);
            solved = true;
        }

        private void SetColors(List<Color> colors)
        {
            Box0_0.Color = colors[0];
            Box0_1.Color = colors[1];
            Box0_2.Color = colors[2];
            Box0_3.Color = colors[3];
            Box0_4.Color = colors[4];
            Box0_5.Color = colors[5];
            Box0_6.Color = colors[6];
            Box0_7.Color = colors[7];
            Box0_8.Color = colors[8];
            Box0_9.Color = colors[9];
        }

        public bool CheckSolution(List<Color> solution, List<Color> problem)
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
                solved = false;
                GameOverMessage();
                return true;
            }
            return false;
        }

        private void SwitchGridPosition(List<Color> selectedColors)
        {
            List<Color> tempProblem = tempSolution;

            int colorOneIndex = tempProblem.FindIndex(x => x == selectedColors[0]);
            int colorTwoIndex = tempProblem.FindIndex(x => x == selectedColors[1]);

            tempProblem[colorTwoIndex] = selectedColors[0];
            tempProblem[colorOneIndex] = selectedColors[1];

            tempSolution = tempProblem;
            selectedColors.Clear();
            SetColors(tempSolution);
            CheckSolution(colors.solution, tempSolution);
        }

        public void GameOverMessage()
        {
            NewGamePrompt();
            DisplayAlert("Game Over", "You Win!", $"Close");
        }

        private void ColorContainer_Tapped(object sender, EventArgs e)
        {
            BoxView selectedColor = (BoxView)sender;
            if (CheckSolved(solved))
            {
                selectedColors.Add(selectedColor.Color);
                if (selectedColors.Count == 2) SwitchGridPosition(selectedColors);
            }
        }

        public async void NewGamePrompt()
        {
            bool answer = await DisplayAlert("New Game", "Would you like to start a new game?", "Yes", "No");
            if (!answer) return;
            else StartGame();
        }

        public void StartGame()
        {
            colors.PickColors();
            SetColors(colors.solution);
            solved = false;
        }

        public void StartGame(bool gameState)
        {
            if (!gameState) StartGame();
            else NewGamePrompt();
        }

        public void NewGame()
        {
            if (CheckSolved(solved)) StartGame();
        }

        public bool CheckSolved(bool gameState)
        {
            if (gameState) return true;
            else return false;
        }
    }
}
