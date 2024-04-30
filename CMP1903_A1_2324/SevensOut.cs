using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CMP1903_A1_2324
{
    internal class SevensOut:Die,Igame
    {
        private int _totalvalue = 0;
        private int _Die_value1 = 0;
        private int _Die_value2 = 0;
        private int _End_value =0;
        /// <summary>getter and setter for _totalvalue </summary>
        public int totalvalue
        {
            get { return _totalvalue; }
            set { _totalvalue = value; }
        }
        /// <summary>getter and setter for _Die_value1 </summary>
        public int dice_value1
        {
            get { return _Die_value1; }
            set {  _Die_value1= value; }
        }
        /// <summary>getter and setter for _Die_value2 </summary>
        public int dice_value2
        {
            get { return _Die_value2; }
            set { _Die_value2 = value; }
        }
        /// <summary>getter and setter for _End_value </summary>
        public int end_value
        {
            get { return _End_value; }
            set { _End_value = value; }
        }
        /// <summary>playes the game of sevenout </summary>
        /// <param name="comp">tells if the user is a player of computer</param>
        /// <returns>returns the score</returns>
        public int Game(bool comp)
        {
            //restests values
            _Die_value1 = 0;
            _Die_value2 = 0;
            _totalvalue = 0;
            //while the values don't add up to 7 game plays
            while (_Die_value1 + _Die_value2 != 7)
            {
                //calls roll method inherited from Die
                this.Roll();
                //sleeps for 1 millisecond
                Thread.Sleep(1);
                //stores rolled value in _Die_value1
                _Die_value1 = this.Die_value;
                //calls roll method inherited from Die
                this.Roll();
                //stores rolled value in _Die_value2
                _Die_value2 = this.Die_value;
                //sleeps for 1 millisecond
                Thread.Sleep(1);
                //prints die values and total
                Console.WriteLine($"die 1 = {_Die_value1}\ndie 2 = {_Die_value2}\ntotal = {(_Die_value1+_Die_value2)}\n");
                //sleaps for 100 millisecond
                Thread.Sleep(100);
                // if die values added = 7 
                if (( _Die_value1 +  _Die_value2) == 7)
                {
                    //for testing if the last values added up to 7
                    end_value = (_Die_value1 + _Die_value2); 
                    //continue while
                    continue;
                }
                //if both values are the same
                else if ( _Die_value1 ==  _Die_value2)
                {
                    //takes the values of the dice added and doubles it and adds it to _totalvalue
                    this._totalvalue += ( _Die_value1+ _Die_value2)*2;
                    continue;
                }
                //if vaues don't add up to 7 and not the same
                else
                {
                    //takes the values of the dice added and adds it to _totalvalue
                    this._totalvalue +=  _Die_value1 +  _Die_value2;
                    continue; 
                }
            }
            //returns value to be the sccore
            return this._totalvalue;
        }
    }
}
