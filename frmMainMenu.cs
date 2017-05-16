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
    public partial class frmMainMenu : Form
    {
        public frmMainMenu()
        {
            InitializeComponent();
        }

        // When the X button is pressed, the application ends with exit code 0
        private void frmMainMenu_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        // Clicking this button will close the main menu and open the game menu
        private void btnGame_Click(object sender, EventArgs e)
        {
            frmGame frmGame = new frmGame();
            frmGame.Show();
            Hide();
        }

        // Closes the main menu and opens the admin login menu
        private void btnAdmin_Click(object sender, EventArgs e)
        {
            frmAdminLogin frmAdminLogin = new frmAdminLogin();
            frmAdminLogin.Show();
            Hide();
        }

        private void frmMainMenu_Load(object sender, EventArgs e)
        {
            
        }

        // Directs user to high scores form
        private void btnScores_Click(object sender, EventArgs e)
        {
            frmScores scores = new frmScores();
            scores.Show();
            Hide();
        }
    }
}
