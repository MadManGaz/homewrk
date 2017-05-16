using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPAssignment2
{
    class Score
    {
        // Private variables.
        private string userInitial;
        private int userScore;

        // Constructor for class
        public Score(string userInitial, int userScore)
        {
            UserInitial = userInitial;
            UserScore = userScore;
        }

        // Getters and setters for public properties
        public string UserInitial { get => userInitial; set => userInitial = value; }
        public int UserScore { get => userScore; set => userScore = value; }
    }
}
