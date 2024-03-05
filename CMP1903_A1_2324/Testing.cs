using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

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
    ///<summary> 
    ///tests values to make sure they are within parameters 
    ///</summary>
    public void Test()
    {
      //creates instance of die and game 
      Die die = new Die();
      Game game = new Game();
      //calls game method Roll_dice
      var Total_Value= game.Roll_dice();
      die.Roll();
      //checks if the values are with in the paramiters
      Debug.Assert(die.Dice_value <= 6, "number is over 6");
      Debug.Assert(die.Dice_value >= 1, "number is less than 1");
      Debug.Assert(Total_Value.Item1 <= (Total_Value.Item2*6), $"total is over {Total_Value.Item2 * 6}");
      Debug.Assert(Total_Value.Item1 >= (Total_Value.Item2), $"total is under{Total_Value.Item2}");

    }

  }
}
