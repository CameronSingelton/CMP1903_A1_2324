using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Services;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Xml.Schema;


namespace CMP1903_A1_2324
{
    internal class Game
    {
        Player P1 = new Player();
        Player P2 = new Player();
        Statistics statisticss = new Statistics();
        private bool _Play_game = true;
        private string _play_again = " ";
        private int _P1totalscore = 0;
        private int _P2totalscore = 0;
        private double _played_games = 0;
        private List<int> _Highscores = new List<int> {0,0,0,0 };
        private string _comp = " ";
        private string _game = " ";
        ///<summary> creates dice and then rolls the dice and gives statistics</summary>
        ///<returns>returns total value and amount of rolls</returns>
        public void Roll_dice()
        {
            while (true)
            {
                try
                {
                    Console.WriteLine("Do you want to play with a computer(c) or another player(p)(on the same machine)");
                    _comp = Console.ReadLine().ToLower();
                    if (_comp != "c" && _comp != "computer" && _comp != "p" && _comp != "player")
                    {
                        throw new ArgumentException("Please enter computer or c or p or player");
                    }
                    else
                    {
                        break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());

                }
            }
            while (_Play_game == true)
            {
                _P1totalscore = 0;
                _P2totalscore = 0;
                while (true)
                {
                    try
                    {
                        Console.WriteLine("\n\tMenu\nenter 1 for games\nenter 2 for statistics\nenter 3 to run test\nenter 4 to exit");
                        int Menu_select = int.Parse(Console.ReadLine());
                        if (Menu_select == 1)
                        {
                            while (true)
                            {
                                try
                                {
                                    Console.WriteLine("\tGames Menu\nenter 1 for Sevenout\nenter 2 for three or more");
                                    Menu_select = int.Parse(Console.ReadLine());

                                    if (Menu_select == 1)
                                    {
                                        SevensOut P1sevensOut = new SevensOut();
                                        SevensOut P2sevensOut = new SevensOut();
                                        Console.WriteLine("\n\tRules\nRoll the two dice, noting the total rolled each time.\nIf it is a 7 - stop.\nIf it is any other number - add it to your total.\nIf it is a double - add double the total to your score (3,3 would add 12 to your total)");
                                        Console.WriteLine("Player 1 turn");
                                        _P1totalscore = P1sevensOut.Game(false);
                                        Console.WriteLine("Player 2 turn");
                                        _P2totalscore = P2sevensOut.Game(false);
                                        Console.WriteLine("P1 score = " + _P1totalscore + "\nP2 score = " + _P2totalscore);
                                        High_scores(1);
                                        Wins();
                                        _played_games++;
                                        break;
                                    }
                                    else if (Menu_select == 2)
                                    {
                                        ThreeOrMore P1threeOrMore = new ThreeOrMore();
                                        ThreeOrMore P2threeOrMore = new ThreeOrMore();
                                        Console.WriteLine("\n\tRules\nRoll all 5 dice hoping for a 3-of-a-kind or better.\nIf 2-of-a-kind is rolled, player may choose to rethrow all, or the remaining dice.\n3-of-a-kind: 3 points\n4-of-a-kind: 6 points\n5-of-a-kind: 12 points\nFirst to a total of 20.");
                                        while ((_P1totalscore < 20) && (_P2totalscore < 20))
                                        {
                                            Console.WriteLine("\nPlayer 1 turn");
                                            _P1totalscore = P1threeOrMore.Game(false);
                                            if (_comp == "c" || _comp == "computer")
                                            {
                                                Console.WriteLine("\nPlayer 2 turn");
                                                _P2totalscore = P2threeOrMore.Game(true);
                                            }
                                            else
                                            {
                                                Console.WriteLine("Player 2 turn");
                                                _P2totalscore = P2threeOrMore.Game(false);
                                            }
                                            Console.WriteLine("P1 score = " + _P1totalscore + "\nP2 score = " + _P2totalscore);
                                        }
                                        High_scores(2);
                                        Wins();

                                        _played_games++;
                                        break;
                                    }
                                    else
                                    {
                                        throw new ArgumentException("please enter 1 or 2");
                                    }
                                }
                                catch (FormatException ex)
                                {
                                    Console.WriteLine("please enter 1 or 2");
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine(ex.ToString());
                                }
                               
                            }
                        }
                        else if (Menu_select == 2)
                        {
                            statisticss.Stats(_played_games, P1.Wins,P2.Wins, _Highscores);
                        }
                        else if (Menu_select == 3)
                        {
                            Testing testing = new Testing();
                            testing.Test();
                        }
                        else if (Menu_select == 4)
                        {
                            _Play_game=false;
                            break;
                        }
                        else
                        {
                            throw new ArgumentException("please enter 1,2 or 3");
                        }
                    }
                    catch (FormatException ex)
                    {
                        Console.WriteLine("please enter 1,2 or 3");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                    }
                }
            }

        }
        





        ///<summary> takes dice values and outputs statistics </summary>
        public void Wins()
        {
            if (_P1totalscore > _P2totalscore)
            {
                Console.WriteLine("player 1 wins");
                P1.Wins++;
                _P1totalscore = 0;
                _P2totalscore = 0;
            }
            else if (_P1totalscore < _P2totalscore)
            {
                Console.WriteLine("player 2 wins");
                P2.Wins++;
                _P1totalscore = 0;
                _P2totalscore = 0;
            }
            else
            {
                Console.WriteLine("draw no one wins");
                _P1totalscore = 0;
                _P2totalscore = 0;
            }
        }

        public void Play_again()
        {
            while (true)
            {
                try
                {
                    Console.WriteLine("do you want to play another game?: ");
                    _play_again = Console.ReadLine().ToLower();
                    if (_play_again == "y" || _play_again == "yes")
                    {
                        _Play_game = true;
                        break;
                    }
                    else if (_play_again == "n" || _play_again == "no")
                    {
                        _Play_game = false;
                        break;
                    }
                    else
                    {
                        throw new ArgumentException("enter y or yes or n or no");
                    }
                }

                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());

                }
            }
        }
        public void High_scores(int game)
        {
            if (game == 1)
            {
                if (_P1totalscore > _Highscores[0])
                {
                    _Highscores[0] = _P1totalscore;
                }
                if (_P2totalscore > _Highscores[2])
                {
                    _Highscores[2] = _P2totalscore;
                }
            }
            else if (game == 2)
            {
                if (_P1totalscore > _Highscores[1])
                {
                    _Highscores[1] = _P1totalscore;
                }
                if (_P2totalscore > _Highscores[3])
                {
                    _Highscores[3] = _P2totalscore;
                }
            }
        }
    }
}