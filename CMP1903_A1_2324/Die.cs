﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903_A1_2324
{
    internal class Die
    {
        /*
         * The Die class should contain one property to hold the current die value,
         * and one method that rolls the die, returns and integer and takes no parameters.
         */

        //Property
        int _dice_value = 0;

        //Method
        public int Roll() 
          {
          Random random = new Random();
          _dice_value = random.Next(1, 7);
          return _dice_value; 
          }

    }
}
