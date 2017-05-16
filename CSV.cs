using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace OOPAssignment2
{
    class CSV
    {
        // This variable gets the current executible path, as well as the csv file that the
        // software will be using.
        private static string path = Environment.CurrentDirectory + "/problemList.csv";

        // Loads the questions into NumberProblem objects then puts them in a List<T>
        public static List<NumberProblem> LoadFile()
        {
            while (true)
            {
                try
                {
                    string input;
                    string[] data;

                    // Stream reader looks for commas in the file as a split and then loads them into parameters
                    // per line.
                    StreamReader StrRd = new StreamReader(path);
                    List<NumberProblem> problemList = new List<NumberProblem>();

                    while ((input = StrRd.ReadLine()) != null && input.Length > 0)
                    {
                        data = input.Split(',');

                        problemList.Add(new NumberProblem
                            (int.Parse(data[0]), int.Parse(data[1]), char.Parse(data[2])));
                    }

                    StrRd.Close();

                    // Returns the list of problems
                    return problemList;
                }

                //If the problemList.csv file does not exist, this will create it.
                catch (FileNotFoundException)
                {
                    StreamWriter strWrt = new StreamWriter(path, false);
                    strWrt.Write("");
                    strWrt.Close();
                }
            }
        }

        // This code will take in a collection and save it to a CSV file.
        public static void SaveFile(List<NumberProblem> problemList)
        {

            // The StreamWriter prints all the properties of the objects onto a file seperated
            // by commas, with each object sperated into new lines.
            StreamWriter StrWrt = new StreamWriter(path, false);

            StrWrt.Write("");
            StrWrt.Close();

            StrWrt = new StreamWriter(path, true);

            // A for loop is used to iterate through the contents of the List.
            for (int i = 0; i < problemList.Count; i++)
            {
                StrWrt.WriteLine("{0},{1},{2}", problemList.ElementAt(i).FirstNumber,
                    problemList.ElementAt(i).SecondNumber, problemList.ElementAt(i).NumOperator);
            }

            // Closes the stream
            StrWrt.Close();
        }
    }
}
