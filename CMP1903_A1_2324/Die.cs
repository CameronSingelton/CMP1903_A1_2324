using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace CMP1903_A1_2324
{
  internal class Die
  {
    /*
     * The Die class should contain one property to hold the current die value,
     * and one method that rolls the die, returns and integer and takes no parameters.
     */
    //Property
    //creating Propertys to hold dice value and create the array
    private int _Dice_value = 0;
    private int[] _Dice_values = { 0, 0, 0, 0, 0, 0, 0 };
    
    //getter and setter for _Dice_value
    public int Dice_value
    {
      get { return _Dice_value; }
      set { _Dice_value = value; }
    }
    //Method
    ///<summary> 
    ///makes a random number from 1 to 6 
    ///</summary>
    public void Roll()
    {
      //creates instance of random
      Random _Random = new Random();
      //makes a random intiger between 1 and 6
      _Dice_value = _Random.Next(1, 7);
    }
    ///<summary> 
    ///makes a random number from 1 to 6 for amount of rolls specified
    ///</summary>
    public int[] ContinuousRoll(int Roll_count)
    {
      //creates instance of random
      Random _Random = new Random();
      //for loop to control the amount of times it roll the dice
      for (int i = 0; i < Roll_count; i++)
      {
        //creates random number between 1,6 and adds 1 to the array position
        _Dice_values[_Random.Next(1, 7)] = _Dice_values[_Random.Next(1, 7)] + 1;
      }
      //returns the array _Dice_values
      return _Dice_values;
    }
  }
}
