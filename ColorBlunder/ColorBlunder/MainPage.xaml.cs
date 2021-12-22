using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Color = System.Drawing.Color;

namespace ColorBlunder
{
    public partial class MainPage : ContentPage
    {
        List<Color> shuffledColors;
        private List<Color> _solutionColors;

        public MainPage()
        {
            ColorGrid colorGrid = new ColorGrid();

            InitializeComponent();
            LoadColors();
            colorGrid.ReadyColors();
        }

        public void LoadColors()
        {
            Colors hueContainer = new Colors();

            _solutionColors = hueContainer.solutionColors;
            shuffledColors = hueContainer.shuffledColors;
            SetSolutionColors();
        }

        private void SetSolutionColors()
        {
            Box0_0.BackgroundColor = _solutionColors[0];
            Box0_1.BackgroundColor = _solutionColors[1];
            Box0_2.BackgroundColor = _solutionColors[2];
            Box0_3.BackgroundColor = _solutionColors[3];
            Box0_4.BackgroundColor = _solutionColors[4];
            Box0_5.BackgroundColor = _solutionColors[5];
            Box0_6.BackgroundColor = _solutionColors[6];
            Box0_7.BackgroundColor = _solutionColors[7];
            Box0_8.BackgroundColor = _solutionColors[8];
            Box0_9.BackgroundColor = _solutionColors[9];
        }

        public void SetShuffledColors()
        {
            Box0_1.BackgroundColor = shuffledColors[0];
            Box0_2.BackgroundColor = shuffledColors[1];
            Box0_3.BackgroundColor = shuffledColors[2];
            Box0_4.BackgroundColor = shuffledColors[3];
            Box0_5.BackgroundColor = shuffledColors[4];
            Box0_6.BackgroundColor = shuffledColors[5];
            Box0_7.BackgroundColor = shuffledColors[6];
            Box0_8.BackgroundColor = shuffledColors[7];
        }

        private void BtnGenerate_Clicked(object sender, EventArgs e)
        {
            LoadColors();
        }

        private void BtnPlay_Clicked(object sender, EventArgs e)
        {
            SetShuffledColors();
        }
    }
}
