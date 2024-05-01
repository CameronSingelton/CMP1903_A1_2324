using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace CMP1903_A1_2324
{
  internal abstract class Die:Irollable
  {
    /*
     * The Die class should contain one property to hold the current die value,
     * and one method that rolls the die, returns and integer and takes no parameters.
     */
    //Property
    //creating Propertys to hold dice value and create the array
    protected int _die_Value = 0;

    
    //getter and setter for _diceValue
    /// <summary>getter and setter for _diceValue</summary>
    public int Die_value
    {
      get { return _die_Value; }
      set { _die_Value = value; }
    }
    //Method
    ///<summary> makes a random number from 1 to 6 </summary>
    public virtual void Roll()
    {
      //creates instance of random
      Random _Random = new Random();
      //makes a random intiger between 1 and 6
      _die_Value = _Random.Next(1, 7);
    }
    /*
    //old code
    ///<summary> makes a random number from 1 to 6 for amount of rolls specified</summary>
    ///<param name="Roll_count">is the amount of rolls given by the user</param>
    public int[] ContinuousRoll(int Roll_count)
    {
    //creates instance of random
    Random Random = new Random();
    //for loop to control the amount of times it roll the dice
    for (int i = 0; i < Roll_count; i++)
    {
        //creates random number between 1,6 and adds 1 to the array position
        _diceValues[Random.Next(1, 7)] = _diceValues[Random.Next(1, 7)] + 1;
    }
    //returns the array _diceValues
    return _diceValues;
     }
     */
  }
}
