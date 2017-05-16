using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOPAssignment2
{
    public partial class frmOutOfTime : Form
    {
        private frmGame game;

        public frmOutOfTime(frmGame game)
        {
            this.game = game;
            InitializeComponent();
        }

        // Assigns the users score to the score label in the OutOfTime form
        private void frmOutOfTime_Load(object sender, EventArgs e)
        {
            lblScore.Text = game.Score.ToString();
        }

        // Clicking no will save the user score to a CSV, and then return to the main menu.
        private void btnNo_Click(object sender, EventArgs e)
        {
            if (txtInitials.Text != "")
            {
                List<Score> scoreList = ScoreCSV.LoadFile();
                scoreList.Add(new Score(txtInitials.Text.ToUpper(), game.Score));
                ScoreCSV.SaveFile(scoreList);

                frmMainMenu MainMenu = new frmMainMenu();
                MainMenu.Show();
                Hide(); 
            }

            else
            {
                MessageBox.Show("Please enter your initials");
                txtInitials.Clear();
            }
        }

        // If yes is clicked the user score will be saved and the game will be restarted.
        private void btnYes_Click(object sender, EventArgs e)
        {
            if (txtInitials.Text != "")
            {
                List<Score> scoreList = ScoreCSV.LoadFile();
                scoreList.Add(new Score(txtInitials.Text.ToUpper(), game.Score));
                ScoreCSV.SaveFile(scoreList);

                // Resets variables in frmGame object to default and starts timer
                game.Score = 0;
                game.lblScore.Text = "0";
                game.Counter = 30;
                game.Show();
                game.LoadNewQuestion();
                game.tmrCountdown.Start();
                this.Hide();
            }

            else
            {
                MessageBox.Show("Please enter your initials");
                txtInitials.Clear();
            }
        }

        // Returns user to main menu when x button is clicked
        private void frmOutOfTime_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmMainMenu MainMenu = new frmMainMenu();
        }
    }
}
