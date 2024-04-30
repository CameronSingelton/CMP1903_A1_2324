using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903_A1_2324
{
    internal class Player
    {
        private double _wins = 0;

        public double Wins
        { 
            get { return _wins; } 
            set { _wins = value; }
        }

        public void Print_wins()
        {
            Console.WriteLine("wins= " + Wins);
        }   

    }
}
