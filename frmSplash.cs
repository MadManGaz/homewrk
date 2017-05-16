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
    public partial class frmSplash : Form
    {
        public frmSplash()
        {
            InitializeComponent();
        }

        // Timer is used to wait a while before opening the main menu then closing the splash screen.
        private void tmrCounter_Tick(object sender, EventArgs e)
        {
            frmMainMenu frmMainMenu = new frmMainMenu();
            frmMainMenu.Show();
            Hide();
            // After first timer tick, the timer stops to prevent more windows from opening.
            tmrCounter.Stop();
        }
    }
}
