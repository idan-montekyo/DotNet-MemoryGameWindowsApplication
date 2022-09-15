using System;
using MemoryGameLogic;
using System.Windows.Forms;

namespace MemoryGameUI
{
    public static class GameUtils
    {
        private static bool s_StartProgram = false;
        private static bool s_NewGame = false;
        private static Player s_Player1;
        private static Player s_Player2;
        private static Pc s_Pc;
        private static Board s_Board;
        private static bool s_IsSinglePlayerMode;
        private static bool s_Player1TurnToPlay;
        private static bool s_IsSecondCardFlip;
        private static bool s_AllowToChooseCard;
        private static byte s_Turn1Row;
        private static byte s_Turn1Column;
        private static byte s_Turn2Row;
        private static byte s_Turn2Column;
        private static char s_ValueFoundInTurn1;
        private static char s_ValueFoundInTurn2;
        private static readonly PictureBox[] sr_TwoPictureBoxesPickedInASingleTurn = new PictureBox[2];

        public static ref Player Player1
        {
            get { return ref s_Player1; }
        }

        public static ref Player Player2
        {
            get { return ref s_Player2; }
        }

        public static Pc Pc
        {
            get { return s_Pc; }
        }

        public static Board Board
        {
            get { return s_Board; }
        }

        public static int[] BoardSize
        {
            get 
            {
                int[] boardSize = { s_Board.Rows, s_Board.Columns };
                return boardSize;
            }
        }
        
        public static bool IsSinglePlayerMode
        {
            get { return s_IsSinglePlayerMode; }
        }

        public static bool IsPlayer1TurnToPlay
        {
            get { return s_Player1TurnToPlay; }
            set { s_Player1TurnToPlay = value; }
        }

        public static bool IsSecondCardFlip
        {
            get { return s_IsSecondCardFlip; }
            set { s_IsSecondCardFlip = value; }
        }

        public static bool AllowToChooseCard
        {
            get { return s_AllowToChooseCard; }
            set { s_AllowToChooseCard = value; }
        }

        public static byte Turn1Row
        {
            get { return s_Turn1Row; }
            set { }
        }
        
        public static byte Turn1Column
        {
            get { return s_Turn1Column; }
        }
        
        public static byte Turn2Row
        {
            get { return s_Turn2Row; }
        }
        
        public static byte Turn2Column
        {
            get { return s_Turn2Column; }
        }

        public static char Value1
        {
            get { return s_ValueFoundInTurn1; }
            set { s_ValueFoundInTurn1 = value; }
        }

        public static char Value2
        {
            get { return s_ValueFoundInTurn2; }
            set { s_ValueFoundInTurn2 = value; }
        }

        public static PictureBox[] PictureBoxesPicked
        {
            get { return sr_TwoPictureBoxesPickedInASingleTurn; }
        }

        [STAThread]
        public static void Run()
        {
            bool isFirstRun = true;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new SettingsForm());
            if (s_StartProgram)
            {
                s_NewGame = true;
                while (s_NewGame)
                {
                    if (!isFirstRun)
                    {
                        InitializePlayersAndBoardFromSettings(s_Player1.Name, s_Player2.Name, IsSinglePlayerMode, (byte)s_Board.Rows, (byte)s_Board.Columns);
                    }
                    isFirstRun = false;
                    s_NewGame = false;
                    s_Player1TurnToPlay = true;
                    s_IsSecondCardFlip = false;
                    s_AllowToChooseCard = true;
                    Application.Run(new MainGameForm());
                }
            }
        }

        public static void InitializePlayersAndBoardFromSettings(string i_FirstPlayerName, string i_SecondPlayerName, bool i_IsSinglePlayerMode,
                                                                 byte i_NumberOfRows, byte i_NumberOfColumns)
        {
            s_Player1 = new Player(i_FirstPlayerName);
            s_Board = new Board(i_NumberOfRows, i_NumberOfColumns);
            s_IsSinglePlayerMode = i_IsSinglePlayerMode;
            s_StartProgram = true;
            if (i_IsSinglePlayerMode)
            {
                s_Pc = new Pc();
            }
            else
            {
                s_Player2 = new Player(i_SecondPlayerName);
            }
        }

        public static string GetStringWithXPairs(int i_NumberOfPairs)
        {
            return string.Format("{0} {1}", i_NumberOfPairs, i_NumberOfPairs == 1 ? "Pair" : "Pairs");
        }

        public static void SetInputForEachTurn(byte i_Row, byte i_Column, char i_ValueFound)
        {
            if (!s_IsSecondCardFlip)
            {
                s_Turn1Row = i_Row;
                s_Turn1Column = i_Column;
                s_ValueFoundInTurn1 = i_ValueFound;
            }
            else
            {
                s_Turn2Row = i_Row;
                s_Turn2Column = i_Column;
                s_ValueFoundInTurn2 = i_ValueFound;
            }
        }

        public static void SaveSlotsToPcMemoryInCaseOfSinglePlayerMode(char i_Value1, byte i_Row1, byte i_Column1, char i_Value2, byte i_Row2, byte i_Column2)
        {
            if (s_IsSinglePlayerMode)
            {
                s_Pc.SaveSlotToMemory(i_Value1, i_Row1, i_Column1);
                s_Pc.SaveSlotToMemory(i_Value2, i_Row2, i_Column2);
                if (s_Board.CheckForSlotValueMatch(i_Row1, i_Column1, i_Row2, i_Column2))
                {
                    s_Pc.RemoveMatchedSlots(i_Value1);
                }
            }
        }

        public static bool CheckIfGameEndedAndShowGameOverMessage(Form i_Form)
        {
            bool isGameEnded = s_Board.IsBoardFullyUnveiled;
            if (isGameEnded)
            {
                string winnerMessage = string.Empty;
                int secondPlayerScore = s_IsSinglePlayerMode ? s_Pc.Score : s_Player2.Score;
                string secondPlayerName = s_IsSinglePlayerMode ? s_Pc.Name : s_Player2.Name;

                if (s_Player1.Score > secondPlayerScore)
                {
                    winnerMessage = string.Format("The winner is {0} !", s_Player1.Name);
                }
                else if (secondPlayerScore > s_Player1.Score)
                {
                    winnerMessage = string.Format("The winner is {0} !", secondPlayerName);
                }
                else
                {
                    winnerMessage = "It's a tie !";
                }

                string gameOverMessage = string.Format("{0}{1}Would you like to start a new game ?", winnerMessage, Environment.NewLine);
                DialogResult gameOverDialogResult = MessageBox.Show(gameOverMessage, "Game Over", MessageBoxButtons.YesNo);
                if (DialogResult.Yes == gameOverDialogResult)
                {
                    s_NewGame = true;
                }
            }

            return isGameEnded;
        }

        public static void SetNonIdenticalSlotsVisibility(bool i_IsVisible)
        {
            s_Board.SetSlotVisibility(i_IsVisible, s_Turn1Row, s_Turn1Column);
            s_Board.SetSlotVisibility(i_IsVisible, s_Turn2Row, s_Turn2Column);
        }
    }
}
