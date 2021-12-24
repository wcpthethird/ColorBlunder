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
        readonly static Colors colors = new Colors();
        private List<BoxView> userSolution = colors.problem;

        public MainPage()
        {
            InitializeComponent();
            SetSolutionColors();
        }

        private void BtnGenerate_Clicked(object sender, EventArgs e)
        {
            colors.PickColors();
            SetSolutionColors();
        }

        private void BtnPlay_Clicked(object sender, EventArgs e)
        {
            SetProblemColors();
        }

        private void SetSolutionColors()
        {
            Box0_0.Color = colors.solution[0].Color;
            Box0_1.Color = colors.solution[1].Color;
            Box0_2.Color = colors.solution[2].Color;
            Box0_3.Color = colors.solution[3].Color;
            Box0_4.Color = colors.solution[4].Color;
            Box0_5.Color = colors.solution[5].Color;
            Box0_6.Color = colors.solution[6].Color;
            Box0_7.Color = colors.solution[7].Color;
            Box0_8.Color = colors.solution[8].Color;
            Box0_9.Color = colors.solution[9].Color;
        }

        public void SetProblemColors()
        {
            Box0_0.Color = colors.problem[0].Color;
            Box0_1.Color = colors.problem[1].Color;
            Box0_2.Color = colors.problem[2].Color;
            Box0_3.Color = colors.problem[3].Color;
            Box0_4.Color = colors.problem[4].Color;
            Box0_5.Color = colors.problem[5].Color;
            Box0_6.Color = colors.problem[6].Color;
            Box0_7.Color = colors.problem[7].Color;
            Box0_8.Color = colors.problem[8].Color;
            Box0_9.Color = colors.problem[9].Color;
        }

        public void CheckSolution()
        {
            if (colors.solution == userSolution)
            {
                DisplayAlert("Game Over", "You Win!", "Close");
            }
        }

        private void ColorContainer_Tapped(object sender, EventArgs e)
        {
            var colorContainer = (BoxView)sender;
            colorContainer.Scale = 0.925;


            CheckSolution();
        }
    }
}
