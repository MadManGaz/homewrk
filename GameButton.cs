using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOPAssignment2
{
    class GameButton : Button
    {
        // Global variables used in this class
        private int displayNum;
        private frmGame game;

        // constructor to create the properties for this class
        public GameButton(frmGame game, int displayNum, int posX, int posY, int buttonWidth, int buttonHeight)
            : base()
        {
            DisplayNum = displayNum;
            this.game = game;
            Text = displayNum.ToString();
            Left = posX;
            Top = posY;
            Width = buttonWidth;
            Height = buttonHeight;
            Click += GameButton_Click;
            game.pnlCalcButtons.Controls.Add(this);
        }

        public int DisplayNum { get => displayNum; set => displayNum = value; }

        // When the button is clicked the number is appended to the question label,
        // and also appended to an input variable.
        private void GameButton_Click(object sender, EventArgs e)
        {
            game.lblQuestion.Text += DisplayNum.ToString();
            game.Input += DisplayNum.ToString();
        }
    }
}
