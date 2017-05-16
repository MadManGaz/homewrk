using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPAssignment2
{
    // This class will be used as an object in a collecion to represent basic arithmetic
    // questions.
    class NumberProblem
    {
        private int firstNumber, secondNumber;
        private char numOperator;
        private double sumNumber;

        // Constructor for the class
        public NumberProblem(int firstNumber, int secondNumber, char numOperator)
        {
            FirstNumber = firstNumber;
            SecondNumber = secondNumber;
            NumOperator = numOperator;
            SumNumber = getSum(firstNumber, secondNumber, numOperator);
        }

        // Getters and setters to create public properties
        public int FirstNumber { get => firstNumber; set => firstNumber = value; }
        public int SecondNumber { get => secondNumber; set => secondNumber = value; }
        public char NumOperator { get => numOperator; set => numOperator = value; }
        public double SumNumber { get => sumNumber; set => sumNumber = value; }

        // Calculates the sum based on 2 operands and an operator
        double getSum(int FirstNumber, int SecondNumber, char NumOperator)
        {
            if (NumOperator == '+')
            {
                return FirstNumber + SecondNumber;
            }

            else if (NumOperator == '-')
            {
                return FirstNumber - SecondNumber;
            }

            else if (NumOperator == '*')
            {
                return FirstNumber * SecondNumber;
            }

            else if (NumOperator == '/')
            {
                return FirstNumber / SecondNumber;
            }

            else
            {
                return 0;
            }
        }
    }
}
