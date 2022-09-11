using System;
using System.Windows.Forms;

namespace MemoryGameUI
{
    public static class UIUtils
    {
        private static bool s_StartGame = false;
        private static string s_FirstPlayerName;
        private static string s_SecondPlayerName;
        private static bool s_IsSinglePlayerMode;

        [STAThread]
        public static void Run()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new SettingsForm());
            if (s_StartGame)
            {
                Application.Run(new MainGameForm());
            }
        }

        public static void InitializeNames(string i_FirstPlayerName, string i_SecondPlayerName = "PC", bool i_IsSinglePlayerMode = true)
        {
            s_FirstPlayerName = i_FirstPlayerName;
            s_SecondPlayerName = i_SecondPlayerName;
            s_IsSinglePlayerMode = i_IsSinglePlayerMode;
            s_StartGame = true;
        }
    }
}
