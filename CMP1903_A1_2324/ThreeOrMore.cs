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
        /// <summary>getter and setter for _die_counts </summary>
        public int[] die_counts
        {
            get { return _die_counts; }
            set { _die_counts = value; }
        }
        /// <summary>getter and setter for _totalscore </summary>
        public int totalscore
        {
            get { return _totalscore; }
            set { _totalscore = value; }
        }
        /// <summary>getter and setter for _die_values </summary>
        public List<int> die_values
        {
            get { return _die_values; }
            set { _die_values = value; }
        }
        /// <summary>getter and setter for _roll_count </summary>
        public int roll_count
        {
            get { return _roll_count; }
            set { _roll_count = value; }
        }
        /// <summary>getter and setter for _totalscore </summary>
        public int total_score
        {
            get { return _totalscore; }
            set { _totalscore = value; }
        }
        /// <summary>three or more game </summary>
        /// <param name="comp">tells if player is comp or player</param>
        public int Game(bool comp)
        {
            //sets roll count to 5
            _roll_count = 5;
            //makes it so it is round 1
            int rounds = 1;
            //clears the _die_counts array
            Array.Clear(_die_counts, 0, _die_counts.Length);
            //clears _die_value list
            _die_values.Clear();
            while (rounds < 3)
            {
                //calls method roll 
               this.Roll();
                Thread.Sleep(100);
                //to see if the cound contains 1 and it is the max meaning the highest set is 1
                if (_die_counts.Contains(1) && _die_counts.Max() == 1)
                {
                    //prints that they have rolled none of a kind
                    Console.WriteLine("you rolled no pairs or higher");
                    //if it is the first round
                    if (rounds == 1)
                    {
                        Console.WriteLine("rolling all die");
                        //clears all values from _die_counts 
                        Array.Clear(_die_counts, 0, _die_counts.Length);
                        //clears all values from _dief_value
                        _die_values.Clear();
                        //adds 1 to rounds
                        rounds++;
                    }
                    else
                    {
                        Console.WriteLine("you gained no points");
                        //adds 1 to rounds
                        rounds++;
                    }
                    continue;
                }
                //to see if the cound contains 2 and it is the max meaning the highest set is 2
                else if (_die_counts.Contains(2) && _die_counts.Max() == 2)
                {
                    Console.WriteLine("you got a pair or pair(s)");
                    while (true)
                    {
                        try
                        {
                            //if it is round 1
                            if (rounds == 1)
                            {
                                //if player not computer
                                if (comp == false)
                                {
                                    //gives user choice to roll all or remaining dice
                                    Console.WriteLine("do you want to _reroll all (a) the dice or _reroll remaining (r)");
                                    _reroll = Console.ReadLine();//stores user enter in varable _reroll
                                }
                                else
                                {
                                    //sets _reroll to r
                                    _reroll = "r";
                                }
                                if (_reroll == "all" || _reroll == "a")
                                {
                                    Console.WriteLine("rolling all die");
                                    //clears all values from _die_counts 
                                    Array.Clear(_die_counts, 0, _die_counts.Length);
                                    //clears all values from _dief_value
                                    _die_values.Clear();
                                    rounds++;
                                }
                                else if (_reroll == "remaining" || _reroll == "r")
                                {
                                    Console.WriteLine("rolling remaining die");
                                    this.Remaining_dice(2);
                                    rounds++;
                                }
                                else
                                {
                                    //throws error if user enters a string that not an optioin
                                    throw new ArgumentException("please enter all or a or remaining or r ");
                                }
                                //breaks out of while(true)
                                break;
                            }
                            //if round 2 
                            else
                            {
                                Console.WriteLine("you gained no points");
                                //adds one to rounds
                                rounds++;
                                break;
                            }
                        }
                        //catches all errors
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.ToString());
                        }
                    }
                }
                //to see if the cound contains 3 and it is the max meaning the highest set is 3
                else if (_die_counts.Contains(3) && _die_counts.Max() == 3)
                {
                    Console.WriteLine("you rolled a 3 of a kind");
                    if (rounds == 1)
                    {
                        Console.WriteLine("rolling remaining die");
                        //calls method remaining_dice
                        this.Remaining_dice(3);
                        //adds 1 to rounds
                        rounds++;
                    }
                    //if round 2
                    else
                    {
                        Console.WriteLine("you gained 3 points");
                        //adds 3 points to totalscore
                        this.totalscore += 3;
                        //adds 1 to rounds
                        rounds++; ;
                    }
                    continue;
                }
                //to see if the cound contains 4 and it is the max meaning the highest set is 4
                else if (_die_counts.Contains(4) && _die_counts.Max() == 4)
                {
                    Console.WriteLine("you rolled a 4 of a kind");
                    if (rounds == 1)
                    {
                        Console.WriteLine("rolling remaining die");
                        this.Remaining_dice(4);
                        //adds 1 to rounds
                        rounds++;
                    }
                    //if round 2
                    else
                    {
                        Console.WriteLine("you gained 6 points");
                        //adds 6 to totalscore
                        this.totalscore += 6;
                        //adds 1 to rounds
                        rounds++; ;
                    }
                    continue;
                }
                //this means that all numbers rolled were the same
                else
                {
                    Console.WriteLine("you rolled a 5 of a kind");
                    Console.WriteLine("you gained 12 points");
                    //adds 12 to totalscore
                    this.totalscore += 12;
                    //set rounds to 3 so turn ends because can't get higher score
                    rounds=3;
                    continue;
                }
            }
            //when rounds ==3 it will return totalscore
            return this.totalscore;
        }
        /// <summary>rools numbers for the specified amount and prints them </summary>
        public override void Roll()
        {
            //makes varable i 
            int i = 0;
            //runs untin i = roll count
            while (i != roll_count)
            {
                //calls original Roll before overrided 
                base.Roll();
                //sleeps for 1 millisecond
                Thread.Sleep(1);
                //adds rolled value to _die_values
                _die_values.Add(this.Die_value);
                //increases index of rolled number by 1 in _die_counts
                _die_counts[this.Die_value] = _die_counts[this.Die_value] + 1;
                //increases i by 1
                i++;
            }
            //sorted _die_values in assendingn order
            _die_values.Sort();
            Console.Write("your dice values = ");
            //prints die values 
            for (int x = 0; x < _die_values.Count; x++)
            {
                Console.Write(_die_values[x] + ", ");
            }
            Console.WriteLine(" ");

        }
        /// <summary>clears arrays and then readds the keeped value </summary>
        /// <param name="count">the number in _die_counts you are looking for</param>
        public void Remaining_dice(int count)
        {
            //LINQ query to find the index of the specified count given and finding the index
            var pick = (from n in _die_counts
                        where n == count
                        select Array.IndexOf(die_counts, n)).ToList();
            //the index of the count specified
            int keep = pick[0];
            //the times that number was rolled
            int keep_count = _die_counts[keep];
            //adds back the number as many times as it ws rolled before
            Array.Clear(_die_counts, 0, _die_counts.Length);
            _die_values.Clear();
            for (int i = 0; i < keep_count; i++)
            {
                _die_values.Add(keep);
                _die_counts[keep] = _die_counts[keep] + 1;
            }
            //takes the amount of kept rolled to make so only 5 number are rolled
            roll_count = roll_count - keep_count;
        }
    }
}

