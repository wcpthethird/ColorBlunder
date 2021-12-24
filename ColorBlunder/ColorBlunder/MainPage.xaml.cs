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
        readonly Colors colors = new Colors();

        public MainPage()
        {
            InitializeComponent();
            colors.PickColors();
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
            Box0_0.BackgroundColor = colors.solution[0].Color;
            Box0_1.BackgroundColor = colors.solution[1].Color;
            Box0_2.BackgroundColor = colors.solution[2].Color;
            Box0_3.BackgroundColor = colors.solution[3].Color;
            Box0_4.BackgroundColor = colors.solution[4].Color;
            Box0_5.BackgroundColor = colors.solution[5].Color;
            Box0_6.BackgroundColor = colors.solution[6].Color;
            Box0_7.BackgroundColor = colors.solution[7].Color;
            Box0_8.BackgroundColor = colors.solution[8].Color;
            Box0_9.BackgroundColor = colors.solution[9].Color;
        }

        public void SetProblemColors()
        {
            Box0_0.BackgroundColor = colors.problem[0].Color;
            Box0_1.BackgroundColor = colors.problem[1].Color;
            Box0_2.BackgroundColor = colors.problem[2].Color;
            Box0_3.BackgroundColor = colors.problem[3].Color;
            Box0_4.BackgroundColor = colors.problem[4].Color;
            Box0_5.BackgroundColor = colors.problem[5].Color;
            Box0_6.BackgroundColor = colors.problem[6].Color;
            Box0_7.BackgroundColor = colors.problem[7].Color;
            Box0_8.BackgroundColor = colors.problem[8].Color;
            Box0_9.BackgroundColor = colors.problem[9].Color;
        }
    }
}
