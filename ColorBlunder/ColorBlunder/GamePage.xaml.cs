using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Forms;
using Color = System.Drawing.Color;

namespace ColorBlunder
{
    public partial class GamePage : ContentPage
    {
        readonly Colors colors = new Colors();
        public ObservableCollection<Color> tempSolution;
        public List<Color> userSolution;
        public List<Color> selectedColors;
        public bool solved = false;

        public GamePage()
        {
            InitializeComponent();
            StartGame();
            tempSolution = new ObservableCollection<Color>(colors.solution);
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
            userSolution = new List<Color>(colors.problem);
            selectedColors = new List<Color>();
            SetColors(unsolved);
            solved = true;
        }

        private void SetColors(List<Color> solution)
        {
            Box0_0.BackgroundColor = solution[0];
            Box0_1.BackgroundColor = solution[1];
            Box0_2.BackgroundColor = solution[2];
            Box0_3.BackgroundColor = solution[3];
            Box0_4.BackgroundColor = solution[4];
            Box0_5.BackgroundColor = solution[5];
            Box0_6.BackgroundColor = solution[6];
            Box0_7.BackgroundColor = solution[7];
            Box0_8.BackgroundColor = solution[8];
            Box0_9.BackgroundColor = solution[9];
        }

        private void SetColors(ObservableCollection<Color> userSolution)
        {
            Box0_0.BackgroundColor = userSolution[0];
            Box0_1.BackgroundColor = userSolution[1];
            Box0_2.BackgroundColor = userSolution[2];
            Box0_3.BackgroundColor = userSolution[3];
            Box0_4.BackgroundColor = userSolution[4];
            Box0_5.BackgroundColor = userSolution[5];
            Box0_6.BackgroundColor = userSolution[6];
            Box0_7.BackgroundColor = userSolution[7];
            Box0_8.BackgroundColor = userSolution[8];
            Box0_9.BackgroundColor = userSolution[9];
            CheckSolution(userSolution);
        }

        public bool CheckSolution(ObservableCollection<Color> userSolution)
        {
            List<int> tempProblem = new List<int>();
            List<int> tempSolution = new List<int>();

            for (int i = 0; i < colors.solution.Count; i++)
            {
                int solutionIndex = i;
                int problemIndex = userSolution.ToList().FindIndex(a => a.Name.Contains(colors.solution[i].Name));
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

        private void SwitchGridPosition(List<Color> selectedColors, List<Color> userSolution)
        {
            int colorOneIndex = userSolution.FindIndex(x => x == selectedColors[0]);
            int colorTwoIndex = userSolution.FindIndex(x => x == selectedColors[1]);

            userSolution[colorTwoIndex] = selectedColors[0];
            userSolution[colorOneIndex] = selectedColors[1];

            selectedColors.Clear();

            tempSolution = new ObservableCollection<Color>(userSolution);
            SetColors(tempSolution);
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
                selectedColors.Add(selectedColor.BackgroundColor);
                if (selectedColors.Count == 2)
                {
                    SwitchGridPosition(selectedColors, userSolution);
                }
            }
        }

        public async void NewGamePrompt()
        {
            bool answer = await DisplayAlert("New Game", "Would you like to start a new game?", "Yes", "No");
            if (!answer)
            {
                return;
            }
            else
            {
                StartGame();
            }
        }

        public void StartGame()
        {
            colors.PickColors();
            SetColors(colors.solution);
            solved = false;
        }

        public void StartGame(bool gameState)
        {
            if (!gameState)
            {
                StartGame();
            }
            else
            {
                NewGamePrompt();
            }
        }

        public void NewGame()
        {
            if (CheckSolved(solved))
            {
                StartGame();
            }
        }

        public bool CheckSolved(bool gameState)
        {
            return gameState;
        }
    }
}
