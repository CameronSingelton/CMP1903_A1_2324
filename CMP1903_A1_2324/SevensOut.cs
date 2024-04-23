using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CMP1903_A1_2324
{
    internal class SevensOut:Igame
    {
        public int Game()
        {
            int totalvalue = 0;
            Die Die1 = new Die();
            Die Die2 = new Die();
            while (Die1.Dice_value + Die2.Dice_value != 7)
            {
                Die1.Roll();
                Thread.Sleep(1);  
                Die2.Roll();
                Thread.Sleep(1);
                Console.WriteLine(Die1.Dice_value);
                Console.WriteLine(Die2.Dice_value+"\n");
                if ((Die1.Dice_value + Die2.Dice_value) == 7)
                {
                    break;
                }
                else if (Die1.Dice_value == Die2.Dice_value)
                {
                    totalvalue += (Die1.Dice_value+Die2.Dice_value)*2;
                    Console.WriteLine((Die1.Dice_value + Die2.Dice_value)*2 + "\n");
                    continue;
                }
                else
                {
                    totalvalue += Die1.Dice_value + Die2.Dice_value;
                    Console.WriteLine((Die1.Dice_value + Die2.Dice_value) + "\n"); ;
                    continue; 
                }
            }
            return totalvalue;
        }
    }
}
