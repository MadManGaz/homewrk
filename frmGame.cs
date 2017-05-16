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
    public partial class frmGame : Form
    {
        // Global variables used in class
        private int counter = 30, score = 0;
        private double answer;
        private string input;

        // Getters and setters for properties
        public int Counter { get => counter; set => counter = value; }
        public int Score { get => score; set => score = value; }
        public double Answer { get => answer; set => answer = value; }
        public string Input { get => input; set => input = value; }

        public frmGame()
        {
            InitializeComponent();
        }

        // Directs user to main menu when x button is pressed
        private void frmGame_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmMainMenu frmMainMenu = new frmMainMenu();
            frmMainMenu.Show();
        }

        // Appends points to the score variable if the user gets a question right
        private void btnCheck_Click(object sender, EventArgs e)
        {
            if(Input == null)
            {
                Input = "0";
            }

            if (int.Parse(Input) == Answer)
            {
                Score += 20;
                lblScore.Text = Score.ToString();
            }

            Input = "0";

            LoadNewQuestion();
        }

        // When the form loads, sets up buttons and loads a new question
        private void frmGame_Load(object sender, EventArgs e)
        {
            setUpButtons();
            LoadNewQuestion();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        // Sets up digit input based on GameButton class
        private void setUpButtons()
        {
            // Initializes array of GameButton objects
            GameButton[] buttonArray = new GameButton[10];
            int buttonHeight = pnlCalcButtons.Height / 4; 
            int buttonWidth = pnlCalcButtons.Width / 3; 

            int number = 1;

            // Sets position of first button on the panel
            int xPos = 0, yPos = 0;

            // Loops 10 times, correctly drawing the buttons on the panel, creating
            // a new button instance each time
            for (int i = 0; i < buttonArray.Length; i++)
            {
                if (i == 0)
                {
                    xPos = 0;
                }
                else if (i == 3 || i == 6)
                {

                    xPos = 0;
                    yPos = yPos + buttonHeight;

                }
                else if (i == 9)
                {
                    xPos = buttonWidth;
                    yPos += buttonHeight;
                }
                else
                {
                    xPos += buttonWidth;
                }
                buttonArray[i] = new GameButton(this, number, xPos, yPos, buttonWidth, buttonHeight);

                number++;
            }

            // Code specific to the last button to set its value to 0
            buttonArray[9].Text = "0";
            buttonArray[9].DisplayNum = 0;        }

        // When the help button is clicked, this shows a dialog with useful information
        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("The objective of the game is to answer as many questions\n" +
                "correctly as possible within the time limit. The more answers\n" +
                "you get correct, the higher your score.");
        }

        // Ends the game when the timer reaches zero; opens OutOfTime form
        private void tmrCountdown_Tick(object sender, EventArgs e)
        {
            Counter--;
            lblCountdown.Text = Counter.ToString();

            if (Counter == 0)
            {
                frmOutOfTime OutOfTime = new frmOutOfTime(this);
                
                OutOfTime.Show();
                tmrCountdown.Stop();
                Hide();
            }
        }

        // The following code loads a new question to the appropriate label
        // in frmGame
        public void LoadNewQuestion()
        {
            // Loads the NumberProblem list from CSV file and instantiates a random
            // number generator and the string builder.
            List<NumberProblem> problemList = CSV.LoadFile();
            Random rand = new Random();
            StringBuilder sb = new StringBuilder();

            // Create a new variable that stores a random number that is within the range
            // of indexes used in the list
            int randIndex = rand.Next(0, (problemList.Count - 1));

            // String builder concatenates the operands, operator and product from a random
            // object in the list
            sb = sb.AppendFormat("{0} {1} {2} = ", problemList.ElementAt(randIndex).FirstNumber, 
                problemList.ElementAt(randIndex).NumOperator, problemList.ElementAt(randIndex).SecondNumber);

            // Appends the contents of the string builder to the question label in frmGame
            lblQuestion.Text = sb.ToString();

            // Takes SumNumber property from object and assigns it to a variable to be used to
            // check users answer.
            Answer = problemList.ElementAt(randIndex).SumNumber;
        }
    }
}
