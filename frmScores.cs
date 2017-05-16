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
    public partial class frmScores : Form
    {
        public frmScores()
        {
            InitializeComponent();
        }

        private void frmScores_Load(object sender, EventArgs e)
        {
            // Clear score list
            rtbScores.Clear();

            // Load score objects from CSV
            List<Score> scoreList = ScoreCSV.LoadFile();

            // If the CSV wasn't empty, then
            if (scoreList != null)
            {
                // initialize an instance of StringBuilder
                StringBuilder StrBld = new StringBuilder();

                rtbScores.AppendText("Initials            Score\n");

                // Iterate the scoreList
                for (int i = 0; i < scoreList.Count; i++)
                {
                    // For each property in an object in the list, print them out in a formatted,
                    // human readable form.
                    StrBld.AppendFormat("{0, -20}{1, -20}",
                        scoreList.ElementAt(i).UserInitial,
                        scoreList.ElementAt(i).UserScore.ToString());

                    // Append the contents of the StringBuilder object to the rich text box
                    rtbScores.AppendText(StrBld.ToString() + "\n");

                    // Clear the contents of the string builder object
                    StrBld.Clear();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmMainMenu MainMenu = new frmMainMenu();
            MainMenu.Show();
            Hide();
        }

        // Directs user to main menu when x button is pressed
        private void frmScores_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmMainMenu MainMenu = new frmMainMenu();
            MainMenu.Show();
        }
    }
}
