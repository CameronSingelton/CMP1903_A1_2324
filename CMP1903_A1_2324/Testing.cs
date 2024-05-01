using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;
using System.IO;

namespace CMP1903_A1_2324
{
    internal class Testing : Die
    {
        /*
         * This class should test the Game and the Die class.
         * Create a Game object, call the methods and compare their output to expected output.
         * Create a Die object and call its method.
         * Use debug.assert() to make the comparisons and tests.
         */

        //Method
        ///<summary>tests values to make sure they are within parameters </summary>
        public void Test()
        {
            //to read file
            StreamReader fr = new StreamReader("C:\\Users\\camer\\OneDrive\\Documents\\GitHub\\CMP1903_A1_2324\\Test_log.txt");
            //creates instace of 7out
            SevensOut sevensOut = new SevensOut();
            //creates instance of three or more
            ThreeOrMore threeOrMore = new ThreeOrMore();
            //list to store the lines from the file
            List<string> lines = new List<string>();
            //count for the line that needs to be printed
            int x = 0;
            //to store total value for testing
            int totalscore = 0;
            //Reads the first line in the file
            var line = fr.ReadLine();
            //Continue to read until you reach end of file
            while (line != null)
            {
                //adds line ot lines list
                lines.Add(line);
                //Reads the next line
                line = fr.ReadLine();
            }
            //closes file reading
            fr.Close();
            //to write to file
            StreamWriter fw = new StreamWriter("C:\\Users\\camer\\OneDrive\\Documents\\GitHub\\CMP1903_A1_2324\\Test_log.txt");
            //
            foreach (string i in lines)
            {
                fw.WriteLine(lines[x]);
                x++;
            }
            //runs 7out game
            sevensOut.Game(false);
            //will stop when totalscore >=20
            while (totalscore < 20)
            {
                //runs three or more game
                totalscore = threeOrMore.Game(true);
            }
            //calls game method Roll_dice and returns total of dice and amount of rolls 
            this.Roll();
            //gets current data and time
            DateTime localDate = DateTime.Now;
            //writes date and time into file
            fw.WriteLine(localDate);

            //checks that die value is not over 6
            Debug.Assert(this.Die_value <= 6, "number is over 6");
            //checks that die value is not over 6
            if (this.Die_value <= 6)
            {
                //writes test result to file
                fw.WriteLine("dice number under 6 test = passed");
                Console.WriteLine("dice number under 6 test = passed");


            }
            else
            {
                //writes test result to file
                fw.WriteLine("dice number under 6 test = failed");
                Console.WriteLine("dice number under 6 test = failed");

            }
            //checks that die value is not lower 1
            Debug.Assert(this.Die_value >= 1, "number is less than 1");
            //checks that die value is not lower 1
            if (this.Die_value >= 1)
            {
                //writes test result to file
                fw.WriteLine("dice number over 1 test = passed");
                Console.WriteLine("dice number over 1 test = passed");


            }
            else
            {
                //writes test result to file
                fw.WriteLine("dice number over 1 test = failed");
                Console.WriteLine("dice number over 1 test = failed");

            }
            //checks that 7out dice values added up properly
            Debug.Assert(sevensOut.dice_value1 + sevensOut.dice_value2 == 7, "sevenout game dice add incorrectly test ");
            //checks that 7out dice values added up properly
            if (sevensOut.dice_value1 + sevensOut.dice_value2 == 7)
            {
                //writes test result to file
                fw.WriteLine("sevenout game dice add correctly test = passed");
                Console.WriteLine("sevenout game dice add correctly test = passed");


            }
            else
            {
                //writes test result to file
                fw.WriteLine("sevenout game dice add correctly test  = 7 = failed");
                Console.WriteLine("sevenout game dice add correctly test = failed");
            }
            //checks that 7out ends when dice values added =7 
            Debug.Assert(sevensOut.end_value == 7, "last roll didn't end in 7");
            //checks that 7out ends when dice values added =7 
            if (sevensOut.end_value == 7)
            {
                //writes test result to file
                fw.WriteLine("sevenout game ended when number = 7 test = passed");
                Console.WriteLine("sevenout game ended when number = 7 test = passed");


            }
            else
            {
                //writes test result to file
                fw.WriteLine("sevenout game ended when number = 7 = failed");
                Console.WriteLine("sevenout game ended when number = 7 test = failed");

            }
            //checks if when game ended total score was over or equal to 20
            Debug.Assert(threeOrMore.totalscore >= 20, "ended before score was 20 or over");
            //checks if when game ended total score was over or equal to 20
            if (threeOrMore.totalscore >= 20)
            {
                //writes test result to file
                fw.WriteLine("three or more endes when players scoreis 20 or over test = passed");
                Console.WriteLine("three or more endes when players scoreis 20 or over test = passed");


            }
            else
            {
                //writes test result to file
                fw.WriteLine("three or more endes when players scoreis 20 or over test= failed");
                Console.WriteLine("three or more endes when players scoreis 20 or over test= failed");

            }
            //checks if die counts sum is over 5

            Debug.Assert(threeOrMore.die_counts.Sum()==5, "die count contains more than 5 counts ");
            //checks if die counts is sum over 5
            if (threeOrMore.die_counts.Sum()== 5)
            {
                //writes test result to file
                fw.WriteLine("three or more die count dosn't contain more than 5 counts test = passed");
                Console.WriteLine("three or more die count dosn't contain more than 5 counts test = passed");


            }
            else
            {
                //writes test result to file
                fw.WriteLine("three or more die count dosn't contain more than 5 counts test= failed");
                Console.WriteLine("three or more die count dosn't contain more than 5 counts test = failed");

            }
            //checks if die value dosn't contain more than 5 values
            Debug.Assert(threeOrMore.die_values.Count() == 5, "die values over 5 ");
            //checks if die value dosn't contain more than 5 values
            if (threeOrMore.die_values.Count() == 5)
            {
                //writes test result to file
                fw.WriteLine("three or more die value dosn't contain more than 5 values test = passed");
                Console.WriteLine("three or more die value dosn't contain more than 5 values test = passed");


            }
            else
            {
                //writes test result to file
                fw.WriteLine("three or more die value dosn't contain more than 5 values test= failed");
                Console.WriteLine("three or more die value dosn't contain more than 5 values test = failed");

            }
            //closees file writing
            fw.Close();
            Console.WriteLine("all tests have been performed");
        }
    }
}
