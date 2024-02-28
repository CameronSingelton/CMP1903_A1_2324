using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        Die Dice_1 = new Die();
        Die Dice_2 = new Die();
        Die Dice_3 = new Die();
        //Methods
        public void Roll_dice() 
          {
            int Dice_Value_1=Dice_1.Roll();
            int Dice_Value_2=Dice_2.Roll();
            int Dice_Value_3=Dice_3.Roll();
            statistics(Dice_Value_1, Dice_Value_2, Dice_Value_3);
          }
        public void statistics (int Dice_Value_1, int Dice_Value_2, int Dice_Value_3) 
        {
            int Total_Value = Dice_Value_1 + Dice_Value_2 + Dice_Value_3;
            Console.WriteLine(Total_Value);
        }

    }
}
