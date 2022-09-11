using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MemoryGameUI
{
    public class MainGameForm : Form
    {
        public MainGameForm()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // MainGameForm
            // 
            this.ClientSize = new System.Drawing.Size(951, 437);
            this.Name = "MainGameForm";
            this.Text = "Memory Game";
            this.Load += new System.EventHandler(this.MainGameForm_Load);
            this.ResumeLayout(false);

        }

        private void MainGameForm_Load(object sender, EventArgs e)
        {

        }
    }
}
