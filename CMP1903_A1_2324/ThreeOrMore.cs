using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CMP1903_A1_2324
{
    internal class ThreeOrMore : Die, Igame
    {
        private int[] _die_counts = { 0, 0, 0, 0, 0, 0, 0 };
        private List<int> _die_values = new List<int> { };
        private int _totalscore = 0;
        private int _roll_count = 5;
        private string _reroll = " ";
        public int[] die_counts
        {
            get { return _die_counts; }
            set { _die_counts = value; }
        }
        public int totalscore
        {
            get { return _totalscore; }
            set { _totalscore = value; }
        }
        public List<int> die_values
        {
            get { return _die_values; }
            set { _die_values = value; }
        }
        public int roll_count
        {
            get { return _roll_count; }
            set { _roll_count = value; }
        }
        public int Game(bool comp)
        {
            _roll_count = 5;
            int rounds = 1;
            Array.Clear(_die_counts, 0, _die_counts.Length);
            _die_values.Clear();
            while (rounds < 3)
            {
                this.Roll();
                if (_die_counts.Contains(1) && _die_counts.Max() == 1)
                {
                    Console.WriteLine("you gained no points");
                    rounds++;
                    break;
                }
                else if (_die_counts.Contains(2) && _die_counts.Max() == 2)
                {
                    Console.WriteLine("you got a pair");
                    while (true)
                    {
                        try
                        { 
                            if (rounds == 1)
                            {
                                if (comp == false)
                                {
                                    Console.WriteLine("do you want to _reroll all (a) the dice or _reroll remaining (r)");
                                    _reroll = Console.ReadLine();
                                }
                                else
                                {
                                    _reroll = "r";
                                }
                                if (_reroll == "all" || _reroll == "a")
                                {
                                    Array.Clear(_die_counts, 0, _die_counts.Length);
                                    _die_values.Clear();
                                    rounds++;
                                    break;

                                }
                                else if (_reroll == "remaining" || _reroll == "r")
                                {
                                    this.Remaining_dice();
                                    rounds++;
                                    break;
                                }
                                else
                                {
                                    throw new ArgumentException("please enter all or a or remaining or r ");
                                }
                            }
                            else
                            {
                                Console.WriteLine("you gained no points");
                                rounds++;
                                break;
                            }
                    }
                        catch (Exception ex)
                        {
                        Console.WriteLine(ex.ToString());
                        }
                }
            }

                else if (_die_counts.Contains(3) && _die_counts.Max() == 3)
            {
                Console.WriteLine("you gained 3 points");
                this.totalscore += 3;
                rounds++;
                break;
            }
            else if (_die_counts.Contains(4) && _die_counts.Max() == 4)
            {
                Console.WriteLine("you gained 6 points");
                this.totalscore += 6;
                rounds++;
                break;
            }
            else
            {
                Console.WriteLine("you gained 12 points");
                this.totalscore += 12;
                rounds++;
                break;
            }
        }
            return this.totalscore;
        }




    public override void Roll()
    {
        int i = 0;
        while (i != roll_count)
        {

            base.Roll();
            Thread.Sleep(1);
            _die_values.Add(this.Die_value);
            _die_counts[this.Die_value] = _die_counts[this.Die_value] + 1;
            i++;
        }
        _die_values.Sort();
        Console.WriteLine(" ");
        for (int x = 0; x < _die_values.Count; x++)
        {
            Console.Write(_die_values[x] + ", ");
        }
        Console.WriteLine(" ");

    }
    public void Remaining_dice()
    {
        var pick = (from n in _die_counts
                    where n == 2
                    select Array.IndexOf(die_counts, n)).ToList();
        int keep = pick[0];
        int keep_count = _die_counts[keep];
        Array.Clear(_die_counts, 0, _die_counts.Length);
        _die_values.Clear();
        for (int i = 0; i < keep_count; i++)
        {
            _die_values.Add(keep);
            _die_counts[keep] = _die_counts[keep] + 1;
        }
        roll_count = roll_count - keep_count;
    }
}
}

