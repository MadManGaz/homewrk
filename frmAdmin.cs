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
    public partial class frmAdmin : Form
    {
        public frmAdmin()
        {
            InitializeComponent();
        }

        // Closing window returns user to Main Menu
        private void frmAdmin_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmMainMenu frmMainMenu = new frmMainMenu();
            frmMainMenu.Show();
            Hide();
        }

        // When the admin menu loads, it has to load in the number problems.
        private void frmAdmin_Load(object sender, EventArgs e)
        {
            // Calls on method that refreshed the problem list.
            RefreshProblemList();

            List<NumberProblem> problemList = CSV.LoadFile();

            txtNum1.Text = problemList.ElementAt(0).FirstNumber.ToString();
            txtOperator.Text = problemList.ElementAt(0).NumOperator.ToString();
            txtNum2.Text = problemList.ElementAt(0).SecondNumber.ToString();
            txtMarker.Text = "1";
        }

        // Refreshes the problem list after changes are made.
        private void RefreshProblemList()
        {
            // Clear problem list
            rtbAdmin.Clear();

            // Load number problem objects from CSV
            List<NumberProblem> problemList = CSV.LoadFile();

            // If the CSV wasn't empty, then
            if (problemList != null)
            {
                // initialize an instance of StringBuilder
                StringBuilder StrBld = new StringBuilder();

                // Iterate the problemList
                for (int i = 0; i < problemList.Count; i++)
                {
                    // For each property in an object in the list, print them out in a formatted,
                    // human readable form.
                    StrBld.AppendFormat("{0}            {1} {2} {3} = {4}",
                        (i + 1),
                        problemList.ElementAt(i).FirstNumber.ToString(),
                        problemList.ElementAt(i).NumOperator.ToString(),
                        problemList.ElementAt(i).SecondNumber.ToString(),
                        problemList.ElementAt(i).SumNumber.ToString());

                    // Append the contents of the StringBuilder object to the rich text box
                    rtbAdmin.AppendText(StrBld.ToString() + "\n");

                    // Clear the contents of the string builder object
                    StrBld.Clear();
                } 
            }
        }

        // This method adds a new number problem object to the list, then saves it to CSV
        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Load from CSV
            List<NumberProblem> problemList = CSV.LoadFile();

            // If all input in the text boxes are legal, then
            if ((txtNum1.Text.All(Char.IsDigit) && txtNum2.Text.All(Char.IsDigit))
                    && (txtOperator.Text.Equals("+") || txtOperator.Text.Equals("-")
                    || txtOperator.Text.Equals("/") || txtOperator.Text.Equals("*")))
            {
                // Add a new number problem object to the list from the text boxes using a constructor
                problemList.Add(new NumberProblem(int.Parse(txtNum1.Text), int.Parse(txtNum2.Text), 
                    char.Parse(txtOperator.Text)));
            }

            // if input isn't legal, clear input and ask user to try again
            else
            {
                txtNum1.Clear();
                txtNum2.Clear();
                txtOperator.Clear();
                MessageBox.Show("Please ensure you only use digits for operands and legal operators for the operator.");
            }

            // Save List to CSV
            CSV.SaveFile(problemList);

            // Refrresh the problem list
            RefreshProblemList();
        }

        // Change the properties of a pre-existing object in the List
        private void btnEdit_Click(object sender, EventArgs e)
        {
            // Load from CSV
            List<NumberProblem> problemList = CSV.LoadFile();

            // If input is legal, then
            if (txtMarker.Text.All(Char.IsDigit) && int.Parse(txtMarker.Text) > 0 
                && int.Parse(txtMarker.Text) <= problemList.Count)
            {
                // If input is legal,
                if ((txtNum1.Text.All(Char.IsDigit) && txtNum2.Text.All(Char.IsDigit))
                            && (txtOperator.Text.Equals("+") || txtOperator.Text.Equals("-")
                            || txtOperator.Text.Equals("/") || txtOperator.Text.Equals("*")))
                {
                    // Change the properties of the object
                    int index = int.Parse(txtMarker.Text) - 1;

                    problemList.ElementAt(index).FirstNumber = int.Parse(txtNum1.Text);
                    problemList.ElementAt(index).SecondNumber = int.Parse(txtNum2.Text);
                    problemList.ElementAt(index).NumOperator = char.Parse(txtOperator.Text);
                }

                else
                {
                    // Clear everything and ask the user to try again
                    txtNum1.Clear();
                    txtNum2.Clear();
                    txtOperator.Clear();

                    MessageBox.Show("Please ensure you only use digits for operands and legal operators for the operator.");
                }
            }

            else
            {
                txtMarker.Clear();

                MessageBox.Show("Please ensure that the index is between 1 and " + problemList.Count.ToString());
            }

            // Save everything
            CSV.SaveFile(problemList);

            // Refresh rich text box
            RefreshProblemList();
        }


        // Removes item from the List then saves to CSV and refreshes problem list
        private void btnRemove_Click(object sender, EventArgs e)
        {
            List<NumberProblem> problemList = CSV.LoadFile();

            if (txtMarker.Text.All(Char.IsDigit))
            {
                if (int.Parse(txtMarker.Text) > 0 && int.Parse(txtMarker.Text) <= problemList.Count)
                {
                    problemList.RemoveAt((int.Parse(txtMarker.Text) - 1));
                }

                else
                {
                    txtMarker.Clear();
                    MessageBox.Show("Ensure index is between 1 and " + problemList.Count.ToString());
                }
            }

            else
            {
                txtMarker.Clear();
                MessageBox.Show("Please only enter a number in the index field");
            }

            CSV.SaveFile(problemList);

            RefreshProblemList();
        }
    }
}
