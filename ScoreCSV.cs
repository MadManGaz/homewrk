using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace OOPAssignment2
{
    class ScoreCSV
    {
        // This variable gets the current executible path, as well as the csv file that the
        // software will be using.
        private static string path = Environment.CurrentDirectory + "/scoreList.csv";

        // Loads the questions into NumberProblem objects then puts them in a List<T>
        public static List<Score> LoadFile()
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
                    List<Score> scoreList= new List<Score>();

                    while ((input = StrRd.ReadLine()) != null && input.Length > 0)
                    {
                        data = input.Split(',');

                        scoreList.Add(new Score(data[0], int.Parse(data[1])));
                    }

                    StrRd.Close();

                    // Returns the list of problems
                    return scoreList;
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
        public static void SaveFile(List<Score> scoreList)
        {

            // The StreamWriter prints all the properties of the objects onto a file seperated
            // by commas, with each object sperated into new lines.
            StreamWriter StrWrt = new StreamWriter(path, false);

            StrWrt.Write("");
            StrWrt.Close();

            StrWrt = new StreamWriter(path, true);

            // A for loop is used to iterate through the contents of the List.
            for (int i = 0; i < scoreList.Count; i++)
            {
                StrWrt.WriteLine("{0},{1}", scoreList.ElementAt(i).UserInitial,
                    scoreList.ElementAt(i).UserScore);
            }

            StrWrt.Close();
        }
    }
}
