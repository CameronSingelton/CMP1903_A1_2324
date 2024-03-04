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
    private int _Dice_value = 0;
    private int[] _Dice_values = { 0, 0, 0, 0, 0, 0, 0 };
    //Property
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
      Random _Random = new Random();
      _Dice_value = _Random.Next(1, 7);
    }
    public int[] ContinuousRoll(int Roll_count)
    {
      Random _Random = new Random();
      for (int i = 0; i < Roll_count; i++)
      {
        _Dice_values[_Random.Next(1, 7)] = _Dice_values[_Random.Next(1, 7)] + 1;
      }
      return _Dice_values;
    }
  }
}
