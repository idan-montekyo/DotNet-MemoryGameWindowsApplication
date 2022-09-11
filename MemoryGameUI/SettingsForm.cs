using System;
using System.Windows.Forms;

namespace MemoryGameUI
{
    class SettingsForm : Form
    {
        private Label labelFirstPlayerName;
        private TextBox textBoxFirstPlayerName;
        private TextBox textBoxSecondPlayerName;
        private Button buttonChooseOpponent;
        private Label labelBoardSize;
        private Button buttonBoardSize;
        private Button buttonStart;
        private Label labelSecondPlayerName;
        private static readonly string sr_AgainstAFriendTAG = "Against A Friend";
        private static readonly string sr_AgainstComputerTAG = "Against Computer";
        private static int s_BoardSizeIndex = 0;
        private static readonly string[] sr_BoardSizesCollection = { "4 x 4", "4 x 5", "4 x 6", "5 x 4", "5 x 6", "6 x 4", "6 x 5", "6 x 6" };

        public SettingsForm()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.labelFirstPlayerName = new System.Windows.Forms.Label();
            this.labelSecondPlayerName = new System.Windows.Forms.Label();
            this.textBoxFirstPlayerName = new System.Windows.Forms.TextBox();
            this.textBoxSecondPlayerName = new System.Windows.Forms.TextBox();
            this.buttonChooseOpponent = new System.Windows.Forms.Button();
            this.labelBoardSize = new System.Windows.Forms.Label();
            this.buttonBoardSize = new System.Windows.Forms.Button();
            this.buttonStart = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelFirstPlayerName
            // 
            this.labelFirstPlayerName.AutoSize = true;
            this.labelFirstPlayerName.Location = new System.Drawing.Point(20, 20);
            this.labelFirstPlayerName.Name = "labelFirstPlayerName";
            this.labelFirstPlayerName.Size = new System.Drawing.Size(137, 20);
            this.labelFirstPlayerName.TabIndex = 0;
            this.labelFirstPlayerName.Text = "First Player Name:";
            // 
            // labelSecondPlayerName
            // 
            this.labelSecondPlayerName.AutoSize = true;
            this.labelSecondPlayerName.Location = new System.Drawing.Point(20, 50);
            this.labelSecondPlayerName.Name = "labelSecondPlayerName";
            this.labelSecondPlayerName.Size = new System.Drawing.Size(161, 20);
            this.labelSecondPlayerName.TabIndex = 0;
            this.labelSecondPlayerName.Text = "Second Player Name:";
            // 
            // textBoxFirstPlayerName
            // 
            this.textBoxFirstPlayerName.Location = new System.Drawing.Point(140, 14);
            this.textBoxFirstPlayerName.Name = "textBoxFirstPlayerName";
            this.textBoxFirstPlayerName.Size = new System.Drawing.Size(100, 26);
            this.textBoxFirstPlayerName.TabIndex = 1;
            // 
            // textBoxSecondPlayerName
            // 
            this.textBoxSecondPlayerName.Enabled = false;
            this.textBoxSecondPlayerName.Location = new System.Drawing.Point(140, 44);
            this.textBoxSecondPlayerName.Name = "textBoxSecondPlayerName";
            this.textBoxSecondPlayerName.Size = new System.Drawing.Size(100, 26);
            this.textBoxSecondPlayerName.TabIndex = 1;
            this.textBoxSecondPlayerName.Text = "- computer -";
            // 
            // buttonChooseOpponent
            // 
            this.buttonChooseOpponent.BackColor = System.Drawing.SystemColors.ControlLight;
            this.buttonChooseOpponent.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.buttonChooseOpponent.Location = new System.Drawing.Point(247, 42);
            this.buttonChooseOpponent.Name = "buttonChooseOpponent";
            this.buttonChooseOpponent.Size = new System.Drawing.Size(100, 26);
            this.buttonChooseOpponent.TabIndex = 2;
            this.buttonChooseOpponent.Text = "Against A Friend";
            this.buttonChooseOpponent.UseVisualStyleBackColor = false;
            this.buttonChooseOpponent.Click += new System.EventHandler(this.buttonChooseOpponent_Click);
            // 
            // labelBoardSize
            // 
            this.labelBoardSize.AutoSize = true;
            this.labelBoardSize.Location = new System.Drawing.Point(20, 80);
            this.labelBoardSize.Name = "labelBoardSize";
            this.labelBoardSize.Size = new System.Drawing.Size(91, 20);
            this.labelBoardSize.TabIndex = 0;
            this.labelBoardSize.Text = "Board Size:";
            // 
            // buttonBoardSize
            // 
            this.buttonBoardSize.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.buttonBoardSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.buttonBoardSize.Location = new System.Drawing.Point(20, 100);
            this.buttonBoardSize.Name = "buttonBoardSize";
            this.buttonBoardSize.Size = new System.Drawing.Size(125, 100);
            this.buttonBoardSize.TabIndex = 3;
            this.buttonBoardSize.Text = "4 x 4";
            this.buttonBoardSize.UseVisualStyleBackColor = false;
            this.buttonBoardSize.Click += new System.EventHandler(this.buttonBoardSize_Click);
            // 
            // buttonStart
            // 
            this.buttonStart.BackColor = System.Drawing.Color.LimeGreen;
            this.buttonStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.buttonStart.Location = new System.Drawing.Point(265, 166);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(85, 35);
            this.buttonStart.TabIndex = 2;
            this.buttonStart.Text = "Start!";
            this.buttonStart.UseVisualStyleBackColor = false;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // SettingsForm
            // 
            this.ClientSize = new System.Drawing.Size(365, 217);
            this.Controls.Add(this.buttonBoardSize);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.buttonChooseOpponent);
            this.Controls.Add(this.textBoxSecondPlayerName);
            this.Controls.Add(this.textBoxFirstPlayerName);
            this.Controls.Add(this.labelBoardSize);
            this.Controls.Add(this.labelSecondPlayerName);
            this.Controls.Add(this.labelFirstPlayerName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "SettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Memory Game - Settings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void buttonChooseOpponent_Click(object sender, EventArgs e)
        {
            changeTextOnButtonChooseOpponent();
            changeSecondPlayerTextBoxState();
        }

        private void changeTextOnButtonChooseOpponent()
        {
            if (this.buttonChooseOpponent.Text == sr_AgainstAFriendTAG)
            {
                this.buttonChooseOpponent.Text = sr_AgainstComputerTAG;
            }
            else
            {
                this.buttonChooseOpponent.Text = sr_AgainstAFriendTAG;
            }
        }

        private void changeSecondPlayerTextBoxState()
        {
            if (this.textBoxSecondPlayerName.Enabled)
            {
                this.textBoxSecondPlayerName.Text = "- computer -";
            }
            else
            {
                this.textBoxSecondPlayerName.Text = string.Empty;
            }
            this.textBoxSecondPlayerName.Enabled = !this.textBoxSecondPlayerName.Enabled;
        }

        private void buttonBoardSize_Click(object sender, EventArgs e)
        {
            changeBoardSize();
        }

        private void changeBoardSize()
        {
            s_BoardSizeIndex++;
            if (s_BoardSizeIndex == sr_BoardSizesCollection.Length)
            {
                s_BoardSizeIndex = 0;
            }
            this.buttonBoardSize.Text = sr_BoardSizesCollection[s_BoardSizeIndex];
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            if (string.Empty == this.textBoxFirstPlayerName.Text ||
                (this.textBoxSecondPlayerName.Enabled && string.Empty == this.textBoxSecondPlayerName.Text))
            {
                MessageBox.Show("Please fill in the name field.");
            }
            else
            {
                if (this.textBoxSecondPlayerName.Enabled)
                {
                    UIUtils.InitializeNames(this.textBoxFirstPlayerName.Text, this.textBoxSecondPlayerName.Text, false);
                }
                else
                {
                    UIUtils.InitializeNames(this.textBoxFirstPlayerName.Text);
                }
                this.Close();
            }
        }
    }
}
