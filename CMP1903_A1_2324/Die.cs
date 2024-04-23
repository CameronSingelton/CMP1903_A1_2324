using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace CMP1903_A1_2324
{
  internal class Die:Irollable
  {
    /*
     * The Die class should contain one property to hold the current die value,
     * and one method that rolls the die, returns and integer and takes no parameters.
     */
    //Property
    //creating Propertys to hold dice value and create the array
    private int _diceValue = 0;
    private int[] _diceValues = {0, 0, 0, 0, 0, 0, 0 };
    
    //getter and setter for _diceValue
    /// <summary>getter and setter for _diceValue</summary>
    public int Dice_value
    {
      get { return _diceValue; }
      set { _diceValue = value; }
    }
    //Method
    ///<summary> makes a random number from 1 to 6 </summary>
    public void Roll()
    {
      //creates instance of random
      Random _Random = new Random();
      //makes a random intiger between 1 and 6
      _diceValue = _Random.Next(1, 7);
    }
  }
}
