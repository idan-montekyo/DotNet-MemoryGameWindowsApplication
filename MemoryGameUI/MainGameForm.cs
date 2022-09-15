using System;
using System.Windows.Forms;
using System.Drawing;
using MemoryGameLogic;

namespace MemoryGameUI
{
    public class MainGameForm : Form
    {
        private Label labelCurrentPlayer;
        private Label labelCurrentPlayerName;
        private Label labelPlayer1Name;
        private Label labelPlayer1Score;
        private Label labelPlayer2Name;
        private Label labelPlayer2Score;
        private Timer timer1500ToResetNonIdenticalPictureBoxesAndChangeCurrentPlayerLabelsState;
        private Timer timer1500AllowToChooseCard;
        private Timer timer1500StartPcTurn;
        private System.ComponentModel.IContainer components;
        private static readonly int sr_SpaceFromBorders = 20;
        private static readonly int sr_SpaceBetweenPictureBoxes = 10;
        private static readonly int sr_SpaceBetweenLabels = 20;
        private static readonly Size sr_PictureBoxSize = new Size(75, 75);
        private static readonly Color sr_FormColor = Color.FromName("Control");
        private static readonly Color sr_Player1Color = Color.PaleGreen;
        private static readonly Color sr_Player2Color = Color.Plum;

        public MainGameForm()
        {
            GameUtils.AllowToChooseCard = false;
            InitializeComponent();
            initializeNamesAndScores();
            createBoardProgramatically(this, GameUtils.BoardSize[0], GameUtils.BoardSize[1]);
            relocateLabelsAndResizeForm(this);
            GameUtils.AllowToChooseCard = true;
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.labelCurrentPlayer = new System.Windows.Forms.Label();
            this.labelPlayer1Name = new System.Windows.Forms.Label();
            this.labelPlayer2Name = new System.Windows.Forms.Label();
            this.labelCurrentPlayerName = new System.Windows.Forms.Label();
            this.labelPlayer1Score = new System.Windows.Forms.Label();
            this.labelPlayer2Score = new System.Windows.Forms.Label();
            this.timer1500ToResetNonIdenticalPictureBoxesAndChangeCurrentPlayerLabelsState = new System.Windows.Forms.Timer(this.components);
            this.timer1500AllowToChooseCard = new System.Windows.Forms.Timer(this.components);
            this.timer1500StartPcTurn = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // labelCurrentPlayer
            // 
            this.labelCurrentPlayer.AutoSize = true;
            this.labelCurrentPlayer.BackColor = System.Drawing.Color.PaleGreen;
            this.labelCurrentPlayer.Location = new System.Drawing.Point(20, 300);
            this.labelCurrentPlayer.Name = "labelCurrentPlayer";
            this.labelCurrentPlayer.Size = new System.Drawing.Size(113, 20);
            this.labelCurrentPlayer.TabIndex = 1;
            this.labelCurrentPlayer.Text = "Current Player:";
            // 
            // labelPlayer1Name
            // 
            this.labelPlayer1Name.AutoSize = true;
            this.labelPlayer1Name.BackColor = System.Drawing.Color.PaleGreen;
            this.labelPlayer1Name.Location = new System.Drawing.Point(20, 330);
            this.labelPlayer1Name.Name = "labelPlayer1Name";
            this.labelPlayer1Name.Size = new System.Drawing.Size(107, 20);
            this.labelPlayer1Name.TabIndex = 1;
            this.labelPlayer1Name.Text = "Player1Name:";
            // 
            // labelPlayer2Name
            // 
            this.labelPlayer2Name.AutoSize = true;
            this.labelPlayer2Name.BackColor = System.Drawing.Color.Plum;
            this.labelPlayer2Name.Location = new System.Drawing.Point(20, 360);
            this.labelPlayer2Name.Name = "labelPlayer2Name";
            this.labelPlayer2Name.Size = new System.Drawing.Size(107, 20);
            this.labelPlayer2Name.TabIndex = 1;
            this.labelPlayer2Name.Text = "Player2Name:";
            // 
            // labelCurrentPlayerName
            // 
            this.labelCurrentPlayerName.AutoSize = true;
            this.labelCurrentPlayerName.BackColor = System.Drawing.Color.PaleGreen;
            this.labelCurrentPlayerName.Location = new System.Drawing.Point(143, 300);
            this.labelCurrentPlayerName.Name = "labelCurrentPlayerName";
            this.labelCurrentPlayerName.Size = new System.Drawing.Size(149, 20);
            this.labelCurrentPlayerName.TabIndex = 1;
            this.labelCurrentPlayerName.Text = "current player name";
            // 
            // labelPlayer1Score
            // 
            this.labelPlayer1Score.AutoSize = true;
            this.labelPlayer1Score.BackColor = System.Drawing.Color.PaleGreen;
            this.labelPlayer1Score.Location = new System.Drawing.Point(137, 330);
            this.labelPlayer1Score.Name = "labelPlayer1Score";
            this.labelPlayer1Score.Size = new System.Drawing.Size(103, 20);
            this.labelPlayer1Score.TabIndex = 1;
            this.labelPlayer1Score.Text = "player1 score";
            // 
            // labelPlayer2Score
            // 
            this.labelPlayer2Score.AutoSize = true;
            this.labelPlayer2Score.BackColor = System.Drawing.Color.Plum;
            this.labelPlayer2Score.Location = new System.Drawing.Point(137, 360);
            this.labelPlayer2Score.Name = "labelPlayer2Score";
            this.labelPlayer2Score.Size = new System.Drawing.Size(103, 20);
            this.labelPlayer2Score.TabIndex = 1;
            this.labelPlayer2Score.Text = "player2 score";
            // 
            // timer1500ToResetNonIdenticalPictureBoxesAndChangeCurrentPlayerLabelsState
            // 
            this.timer1500ToResetNonIdenticalPictureBoxesAndChangeCurrentPlayerLabelsState.Interval = 1500;
            this.timer1500ToResetNonIdenticalPictureBoxesAndChangeCurrentPlayerLabelsState.Tick += new System.EventHandler(this.timer1500ToResetNonIdenticalPictureBoxesAndChangeCurrentPlayerLabelsState_Tick);
            // 
            // timer1500AllowToChooseCard
            // 
            this.timer1500AllowToChooseCard.Interval = 1500;
            this.timer1500AllowToChooseCard.Tick += new System.EventHandler(this.timer1500AllowToChooseCard_Tick);
            // 
            // timer1500StartPcTurn
            // 
            this.timer1500StartPcTurn.Interval = 1500;
            this.timer1500StartPcTurn.Tick += new System.EventHandler(this.timer1500StartPcTurn_Tick);
            // 
            // MainGameForm
            // 
            this.ClientSize = new System.Drawing.Size(689, 399);
            this.Controls.Add(this.labelPlayer2Score);
            this.Controls.Add(this.labelPlayer2Name);
            this.Controls.Add(this.labelPlayer1Score);
            this.Controls.Add(this.labelPlayer1Name);
            this.Controls.Add(this.labelCurrentPlayerName);
            this.Controls.Add(this.labelCurrentPlayer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainGameForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Memory Game";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void initializeNamesAndScores()
        {
            this.BackColor = sr_FormColor;
            this.labelCurrentPlayerName.Text = GameUtils.Player1.Name;
            this.labelPlayer1Name.Text = string.Format("{0}:", GameUtils.Player1.Name);
            this.labelPlayer1Score.Text = GameUtils.GetStringWithXPairs(0);
            this.labelPlayer2Name.Text = string.Format("{0}:", GameUtils.IsSinglePlayerMode ? GameUtils.Pc.Name : GameUtils.Player2.Name);
            this.labelPlayer2Score.Text = GameUtils.GetStringWithXPairs(0);
        }

        private void createBoardProgramatically(MainGameForm i_Container, int i_NumberOfRows, int i_NumberOfColumns)
        {
            int xPosition = sr_SpaceFromBorders;
            int yPosition = sr_SpaceFromBorders;

            for (int row = 0; row < i_NumberOfRows; row++)
            {
                for (int column = 0; column < i_NumberOfColumns; column++)
                {
                    PictureBox pictureBox = new PictureBox();
                    pictureBox.Name = string.Format("{0}{1}", row, column);
                    pictureBox.Location = new Point(xPosition, yPosition);
                    pictureBox.Size = sr_PictureBoxSize;
                    pictureBox.BackColor = sr_FormColor;
                    pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                    pictureBox.ImageLocation = Images.RearSideDefaultImageLocation;
                    pictureBox.Padding = new Padding(2);
                    pictureBox.Click += new EventHandler(this.card_Click);
                    i_Container.Controls.Add(pictureBox);

                    xPosition += sr_PictureBoxSize.Width + sr_SpaceBetweenPictureBoxes;
                }

                xPosition = sr_SpaceFromBorders;
                yPosition += sr_PictureBoxSize.Height + sr_SpaceBetweenPictureBoxes;
            }
        }

        private void card_Click(object sender, EventArgs e)
        {
            if (GameUtils.AllowToChooseCard)
            {
                playerTryFlipCard(sender as PictureBox);
            }
        }

        private void playerTryFlipCard(PictureBox i_PictureBox)
        {

            byte row = byte.Parse(i_PictureBox.Name[0].ToString());
            byte column = byte.Parse(i_PictureBox.Name[1].ToString());
            tryFlipCard(i_PictureBox, row, column);
        }

        private void relocateLabelsAndResizeForm(MainGameForm i_Form)
        {
            int rightBorder = GameUtils.BoardSize[1] * (sr_PictureBoxSize.Width + sr_SpaceBetweenPictureBoxes)
                              + 2 * sr_SpaceFromBorders - sr_SpaceBetweenPictureBoxes;
            int bottomBorder = GameUtils.BoardSize[0] * (sr_PictureBoxSize.Height + sr_SpaceBetweenPictureBoxes)
                               + sr_SpaceFromBorders - sr_SpaceBetweenPictureBoxes;

            bottomBorder += sr_SpaceFromBorders;
            labelCurrentPlayer.Location = new Point(labelCurrentPlayer.Location.X, bottomBorder);
            labelCurrentPlayerName.Location = new Point(labelCurrentPlayer.Right, bottomBorder);
            bottomBorder += sr_SpaceBetweenLabels;
            labelPlayer1Name.Location = new Point(labelPlayer1Name.Location.X, bottomBorder);
            labelPlayer1Score.Location = new Point(labelPlayer1Name.Right, bottomBorder);
            bottomBorder += sr_SpaceBetweenLabels;
            labelPlayer2Name.Location = new Point(labelPlayer2Name.Location.X, bottomBorder);
            labelPlayer2Score.Location = new Point(labelPlayer2Name.Right, bottomBorder);

            bottomBorder += labelPlayer2Name.Height + sr_SpaceFromBorders;
            i_Form.ClientSize = new Size(rightBorder, bottomBorder);
        }

        private void timer1500ToResetNonIdenticalPictureBoxesAndChangeCurrentPlayerLabelsState_Tick(object sender, EventArgs e)
        {
            this.timer1500ToResetNonIdenticalPictureBoxesAndChangeCurrentPlayerLabelsState.Stop();
            GameUtils.SetNonIdenticalSlotsVisibility(false);
            resetNonIdenticalPictureBoxes();
            switchTurnAndRefreshLabel();
            if (GameUtils.IsSinglePlayerMode && !GameUtils.IsPlayer1TurnToPlay)
            {
                timer1500StartPcTurn.Start();
            }
        }

        private void resetNonIdenticalPictureBoxes()
        {
            foreach (PictureBox pictureBox in GameUtils.PictureBoxesPicked)
            {
                pictureBox.ImageLocation = Images.RearSideDefaultImageLocation;
                pictureBox.BackColor = sr_FormColor;
            }
        }

        private void switchTurnAndRefreshLabel()
        {
            GameUtils.IsPlayer1TurnToPlay = !GameUtils.IsPlayer1TurnToPlay;
            if (GameUtils.IsPlayer1TurnToPlay)
            {
                labelCurrentPlayerName.Text = GameUtils.Player1.Name;
                labelCurrentPlayerName.BackColor = sr_Player1Color;
                labelCurrentPlayer.BackColor = sr_Player1Color;
            }
            else
            {
                labelCurrentPlayerName.Text = GameUtils.IsSinglePlayerMode ? GameUtils.Pc.Name : GameUtils.Player2.Name;
                labelCurrentPlayerName.BackColor = sr_Player2Color;
                labelCurrentPlayer.BackColor = sr_Player2Color;
            }
        }

        private void timer1500AllowToChooseCard_Tick(object sender, EventArgs e)
        {
            this.timer1500AllowToChooseCard.Stop();
            GameUtils.AllowToChooseCard = true;
        }

        private void timer1500StartPcTurn_Tick(object sender, EventArgs e)
        {
            timer1500StartPcTurn.Stop();
            playTurnOfPc();
        }

        private void playTurnOfPc()
        {
            if (!GameUtils.IsSecondCardFlip)
            {
                int[] arrayOfTwoSlots = GameUtils.Pc.GetPositionOfTwoRandomSlots();
                int rowsAndColumnsOfTwoSlots = 4;
                if (rowsAndColumnsOfTwoSlots == arrayOfTwoSlots.Length)
                {
                    pcTryFlipCard((byte)arrayOfTwoSlots[0], (byte)arrayOfTwoSlots[1]);
                    pcTryFlipCard((byte)arrayOfTwoSlots[2], (byte)arrayOfTwoSlots[3]);
                }
                else
                {
                    int numberOfCardsToFlipInATurn = 2;
                    for (int i = 0; i < numberOfCardsToFlipInATurn; i++)
                    {
                        byte[] hiddenSlot = GameUtils.Pc.GetRandomHiddenRowAndColumn(GameUtils.Board);
                        pcTryFlipCard(hiddenSlot[0], hiddenSlot[1]);
                    }
                }
            }
        }

        private void pcTryFlipCard(byte i_Row, byte i_Column)
        {
            Control[] correspondingPictureBoxes = this.Controls.Find(string.Format("{0}{1}", i_Row, i_Column), true);
            PictureBox pictureBoxPicked = correspondingPictureBoxes[0] as PictureBox;
            tryFlipCard(pictureBoxPicked, i_Row, i_Column);
        }

        private void tryFlipCard(PictureBox i_PictureBox, byte i_Row, byte i_Column)
        {
            bool flipSucceeded = false;
            char valueFound = '\0';
            flipSucceeded = GameUtils.Board.TryFlipCard(i_Row, i_Column, ref valueFound);
            if (flipSucceeded)
            {
                GameUtils.SetInputForEachTurn(i_Row, i_Column, valueFound);
                i_PictureBox.ImageLocation = GameUtils.Board.Matrix[i_Row, i_Column].ImageLocation;
                i_PictureBox.BackColor = GameUtils.IsPlayer1TurnToPlay ? sr_Player1Color : sr_Player2Color;

                int flipNumber = GameUtils.IsSecondCardFlip ? 1 : 0;
                GameUtils.PictureBoxesPicked[flipNumber] = i_PictureBox;

                if (GameUtils.IsSecondCardFlip)
                {
                    GameUtils.AllowToChooseCard = false;
                    bool isEqual = GameUtils.Board.CheckForSlotValueMatch(GameUtils.Turn1Row, GameUtils.Turn1Column,
                                                                          GameUtils.Turn2Row, GameUtils.Turn2Column);

                    if (isEqual)
                    {
                        GameUtils.Board.UpdateCouplesFoundOnBoard();
                        increaseScoreToCurrentPlayer();
                        bool isGameEnded = GameUtils.CheckIfGameEndedAndShowGameOverMessage(this);
                        if (isGameEnded)
                        {
                            this.Close();
                        }
                        else
                        {
                            if (!GameUtils.IsSinglePlayerMode || (GameUtils.IsSinglePlayerMode && GameUtils.IsPlayer1TurnToPlay))
                            {
                                this.timer1500AllowToChooseCard.Start();
                            }
                            else
                            {
                                this.timer1500StartPcTurn.Start();
                            }
                        }
                    }
                    else
                    {
                        this.timer1500ToResetNonIdenticalPictureBoxesAndChangeCurrentPlayerLabelsState.Start();
                        if (!GameUtils.IsSinglePlayerMode || (GameUtils.IsSinglePlayerMode && !GameUtils.IsPlayer1TurnToPlay))
                        {
                            this.timer1500AllowToChooseCard.Start();
                        }
                    }

                    GameUtils.SaveSlotsToPcMemoryInCaseOfSinglePlayerMode(GameUtils.Value1, GameUtils.Turn1Row, GameUtils.Turn1Column,
                                                                          GameUtils.Value2, GameUtils.Turn2Row, GameUtils.Turn2Column);
                }

                GameUtils.IsSecondCardFlip = !GameUtils.IsSecondCardFlip;
            }
        }

        private void increaseScoreToCurrentPlayer()
        {
            if (GameUtils.IsPlayer1TurnToPlay)
            {
                GameUtils.Player1.Score++;
                labelPlayer1Score.Text = GameUtils.GetStringWithXPairs(GameUtils.Player1.Score);
            }
            else
            {
                if (GameUtils.IsSinglePlayerMode)
                {
                    GameUtils.Pc.Score++;
                    labelPlayer2Score.Text = GameUtils.GetStringWithXPairs(GameUtils.Pc.Score);
                }
                else
                {
                    GameUtils.Player2.Score++;
                    labelPlayer2Score.Text = GameUtils.GetStringWithXPairs(GameUtils.Player2.Score);
                }
            }
        }
    }
}