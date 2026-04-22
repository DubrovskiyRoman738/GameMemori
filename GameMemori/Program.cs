using System;
using System.Windows.Forms;

namespace GameMemori
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Запускаем главное меню
            Application.Run(new MainMenuForm());
        }
    }
}