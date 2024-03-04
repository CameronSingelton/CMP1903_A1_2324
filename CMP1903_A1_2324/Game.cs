using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Xml.Schema;

namespace CMP1903_A1_2324
{
  internal class Game
  {
    /*
     * The Game class should create three die objects, roll them, sum and report the total of the three dice rolls.
     *
     * EXTRA: For extra requirements (these aren't required though), the dice rolls could be managed so that the
     * rolls could be continous, and the totals and other statistics could be summarised for example.
     */
    //Methods
    ///<summary> 
    ///creates dice and then rolls the dice and gives statistics
    ///</summary>
    public int Roll_dice()
    {
      Console.WriteLine("how many rolls do you want?");
      int Amount_rolls = int.Parse(Console.ReadLine());
      if (Amount_rolls == 3)
      {
        //creates instatnces of die
        Die Dice_1 = new Die();
        Die Dice_2 = new Die();
        Die Dice_3 = new Die();
        // calls the ROll for all die 
        Dice_1.Roll();
        Thread.Sleep(1);
        Dice_2.Roll();
        Thread.Sleep(1);
        Dice_3.Roll();
        Thread.Sleep(1);
        int Total_value = statistics(Dice_1.Dice_value, Dice_2.Dice_value, Dice_3.Dice_value);
        return Total_value;
      }
      else
      {
        Die Dice_1 = new Die();
        int[] _Dice_values = Dice_1.ContinuousRoll(Amount_rolls);
        int Total = Continuos_statistics(_Dice_values,Amount_rolls);
        return Total;
      }
    }
    ///<summary> 
    ///takes dice values and outputs statistics 
    ///</summary>
    public int statistics(int Dice_Value_1, int Dice_Value_2, int Dice_Value_3)
    {
      int Total_Value = Dice_Value_1 + Dice_Value_2 + Dice_Value_3;
      Console.WriteLine($"1={Dice_Value_1}\n2={Dice_Value_2}\n3={Dice_Value_3}\ntotal={Total_Value}");
      return Total_Value;
    }
    public int Continuos_statistics(int[] Dice_Values,int Amount_rolls)
    {

      int Total_Value = Dice_Values[1] + Dice_Values[2] * 2 + Dice_Values[3] * 3 + Dice_Values[4] * 4 + Dice_Values[5] * 5 + Dice_Values[6] * 6;
      Console.WriteLine($"you rolled {Dice_Values[1]} one(s)\nyou rolled {Dice_Values[2]} two(s)\nyou rolled {Dice_Values[3]} three(s)\nyou rolled {Dice_Values[4]} fours(s)\nyou rolled {Dice_Values[5]} five(s)\nyou rolled {Dice_Values[6]} six(s)\ntotal={Total_Value}");
      return Total_Value;
    }
  }
}
