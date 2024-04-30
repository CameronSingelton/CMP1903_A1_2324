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
  internal class Testing:Die
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

            List<string> lines= new List<string>();
            StreamReader fr = new StreamReader("C:\\Users\\camer\\OneDrive\\Documents\\GitHub\\CMP1903_A1_2324\\Test_log.txt");
            //Reads the first line in the file
            var line = fr.ReadLine();
            //Continue to read until you reach end of file
            while (line != null)
            {
                //write the line to console window
                lines.Add(line);
                //Reads the next line
                line = fr.ReadLine();
            }
            fr.Close();
            StreamWriter fw = new StreamWriter("C:\\Users\\camer\\OneDrive\\Documents\\GitHub\\CMP1903_A1_2324\\Test_log.txt");
            int x = 0;
            foreach (string i in lines)
            {
                fw.WriteLine(lines[x]);
                x = x + 1;
            }
        Game game_test = new Game();
        SevensOut sevensOut = new SevensOut();
        sevensOut.Game(false);
        ThreeOrMore threeOrMore = new ThreeOrMore();
        int totalscore = 0;
        while (totalscore < 20)
        {
            totalscore=threeOrMore.Game(true);
        }
        //calls game method Roll_dice and returns total of dice and amount of rolls 
        this.Roll();
        //checks if the values are with in the paramiters
        DateTime localDate = DateTime.Now;
        fw.WriteLine(localDate);
        Debug.Assert(this.Die_value <= 6, "number is over 6");
        if (this.Die_value <=6)
        {
            fw.WriteLine("dice number under 6 test = passed");

        }
        else
        {
            fw.WriteLine("dice number under 6 test = failed");
        }
            
        Debug.Assert(this.Die_value >= 1, "number is less than 1");
        if (this.Die_value >= 1)
        {
            fw.WriteLine("dice number over 1 test = passed");

        }
        else
        {
            fw.WriteLine("dice number over 1 test = failed");
        }
        Console.WriteLine(sevensOut.dice_value1 + sevensOut.dice_value2);
        Debug.Assert(sevensOut.dice_value1 + sevensOut.dice_value2 == 7, "sevenout game dice add incorrectly test ");
        if (sevensOut.dice_value1 + sevensOut.dice_value2 == 7)
        {
            fw.WriteLine("sevenout game dice add correctly test = passed");

        }
        else
        {
            fw.WriteLine("sevenout game dice add correctly test  = 7 = failed");
        }
        Debug.Assert(sevensOut.end_value == 7, "last roll didn't end in 7");
        if (sevensOut.end_value == 7)
        {
            fw.WriteLine("sevenout game ended when number = 7 test = passed");

        }
        else
        {
            fw.WriteLine("sevenout game ended when number = 7 = failed");
        }
        Debug.Assert(threeOrMore.totalscore >=20, "ended before score was 20 or over");
        if (threeOrMore.totalscore >= 20)
        {
            fw.WriteLine("sevenout game ended when number = 7 test = passed");

        }
        else
        {
            fw.WriteLine("sevenout game ended when number = 7 = Failed");
        }

         fw.Close();
        Console.WriteLine("all tests have been performed");
    }
  }
}
