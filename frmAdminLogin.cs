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
    public partial class frmAdminLogin : Form
    {
        public frmAdminLogin()
        {
            InitializeComponent();
        }

        // When the X button is pressed, the user is returned to the main menu
        private void frmAdminLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmMainMenu frmMainMenu = new frmMainMenu();
            frmMainMenu.Show();
        }

        // Performs login validation; the username and password must be correct for the user to get in.
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = "Username", password = "password";

            // The username is not case sensitive, the password however is.
            if (txtUsername.Text.ToLower().Equals(username.ToLower()) && txtPassword.Text.Equals(password))
            {
                frmAdmin frmAdmin = new frmAdmin();
                frmAdmin.Show();
                Hide();
            }

            else
            {
                txtUsername.Text = "";
                txtPassword.Text = "";

                // Text boxes are cleared and the user is asked to try again if the username or password is incorrect.
                MessageBox.Show("Username or Password incorrect, please try again!");
            }
        }
    }
}
