using System;
using System.Drawing;
using System.Windows.Forms;

namespace GameMemori
{
    public partial class MainMenuForm : Form
    {
        public MainMenuForm()
        {
            InitializeComponent();
        }

        private void BtnStart_Click(object sender, EventArgs e)
        {
            // Открываем форму выбора режима
            var selectionForm = new SelectionForm();
            if (selectionForm.ShowDialog() == DialogResult.OK)
            {
                // Запускаем основную игру
                var gameForm = new GameMemori(
                    selectionForm.SelectedMode,
                    selectionForm.SelectedSize,
                    selectionForm.SelectedTheme
                );
                gameForm.ShowDialog();
            }
        }

        private void BtnAbout_Click(object sender, EventArgs e)
        {
            // Открываем форму "Об игре"
            var aboutForm = new AboutForm();
            aboutForm.ShowDialog();
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            // Подтверждение выхода
            DialogResult result = MessageBox.Show(
                "Вы уверены, что хотите выйти из игры?",
                "Подтверждение выхода",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void lblSubtitle_Click(object sender, EventArgs e)
        {

        }
    }
}