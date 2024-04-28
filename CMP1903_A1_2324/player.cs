using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903_A1_2324
{
    internal class player
    {
        private int _wins = 0;

        public int Wins
        { 
            get { return _wins; } 
            set { _wins = value; }
        }

        public void Print_wins()
        {
            Console.WriteLine(this + "wins= " + Wins);
        }   

    }
}
