//#define test
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903_A1_2324
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
                * Create a Game object and call its methods.
                * Create a Testing object to verify the output and operation of the other classes.
                */
            //prints testing code to show that the code is being tested
#if test
            {
                Console.WriteLine("testing code");
                //creates instance of testing
                Testing testing = new Testing();
                //calls function test from class testing
                testing.Test();
                //prints testing code to show that the code is running
            }
#else
            {
                Console.WriteLine("running code");
                //creates instance of game
                Game game = new Game();
                //calls game method of Rolls_dice
                game.Roll_dice();
            }
#endif
        }
    }
}
