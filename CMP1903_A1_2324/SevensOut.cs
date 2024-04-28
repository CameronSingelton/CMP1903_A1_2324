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
        private int _Dice_value1 = 0;
        private int _Dice_value2 = 0;
        private int _End_value =0;
        public int totalvalue
        {
            get { return _totalvalue; }
            set { _totalvalue = value; }
        }
        public int dice_value1
        {
            get { return _Dice_value1; }
            set {  _Dice_value1= value; }
        }
        public int dice_value2
        {
            get { return _Dice_value2; }
            set { _Dice_value2 = value; }
        }
        public int end_value
        {
            get { return _End_value; }
            set { _End_value = value; }
        }
        public int Game()
        {
            
            while (_Dice_value1 + _Dice_value2 != 7)
            {
                this.Roll();
                _Dice_value1 = this.Die_value;
                Thread.Sleep(1);  
                this.Roll();
                _Dice_value2 = this.Die_value;
                Thread.Sleep(1);
                if (( _Dice_value1 +  _Dice_value2) == 7)
                {
                    end_value = (_Dice_value1 + _Dice_value2); 
                    break;
                }
                else if ( _Dice_value1 ==  _Dice_value2)
                {
                    this._totalvalue += ( _Dice_value1+ _Dice_value2)*2;
                    continue;
                }
                else
                {
                    this._totalvalue +=  _Dice_value1 +  _Dice_value2;
                    continue; 
                }
            }
            return this._totalvalue;
        }
    }
}
