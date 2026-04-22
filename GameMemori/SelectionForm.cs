using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using GameMemoriLogic;

namespace GameMemori
{
    public partial class SelectionForm : Form
    {
        public GameMode SelectedMode { get; private set; }
        public BoardSize SelectedSize { get; private set; }
        public string SelectedTheme { get; private set; }

        public SelectionForm()
        {
            InitializeComponent();
        }

        private void BtnStart_Click(object sender, EventArgs e)
        {
            if (rbSolo.Checked)
                SelectedMode = GameMode.Solo;
            else if (rbOneVsOne.Checked)
                SelectedMode = GameMode.OneVsOne;
            else
                SelectedMode = GameMode.FourPlayers;

            if (rb2x2.Checked)
                SelectedSize = BoardSize.Small2x2;
            else if (rb2x4.Checked)
                SelectedSize = BoardSize.Small2x4;
            else if (rb4x4.Checked)
                SelectedSize = BoardSize.Medium4x4;
            else if (rb4x8.Checked)
                SelectedSize = BoardSize.Large4x8;
            else
                SelectedSize = BoardSize.ExtraLarge8x8;

            if (rbOnePiece.Checked)
                SelectedTheme = "OnePiece";
            else if (rbJoJo.Checked)
                SelectedTheme = "JoJo";
            else
                SelectedTheme = "Mix";

            DialogResult = DialogResult.OK;
            Close();
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void rb2x4_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}