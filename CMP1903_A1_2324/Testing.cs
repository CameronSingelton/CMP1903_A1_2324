using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903_A1_2324
{
    internal class Testing
    {
        /*
         * This class should test the Game and the Die class.
         * Create a Game object, call the methods and compare their output to expected output.
         * Create a Die object and call its method.
         * Use debug.assert() to make the comparisons and tests.
         */

        //Method
        public void test(int Dice_Value_1, int Dice_Value_2, int Dice_Value_3)
        {
            Debug.Assert(Dice_Value_1 <6, "number is over 6");
            Debug.Assert(Dice_Value_1 >1, "number is less than 1");
            Debug.Assert(Dice_Value_2 <6, "number is over 6");
            Debug.Assert(Dice_Value_2 >1, "number is less than 1");
            Debug.Assert(Dice_Value_3 <6, "number is over 6");
            Debug.Assert(Dice_Value_3 >1, "number is less than 1");
        }

    }
}
