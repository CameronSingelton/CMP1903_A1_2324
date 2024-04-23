using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903_A1_2324
{
    internal class ThreeOrMore:Die,Igame
    {
        public int Game()
        {
            List<int> list = new List<int>();
            //Die die = new Die();
           for (int i = 0; i >= 5; i++)
            {
                this.Roll();
                list.Add(this.Dice_value);
            }
            return 0;
        }

    }
}
