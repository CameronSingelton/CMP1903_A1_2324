using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Xml.Schema;

namespace CMP1903_A1_2324
{
    internal class Game
    {
        private bool _Play_game = true;
        private string _play_again = " ";
        private int _P1totalscore = 0;
        private int _P2totalscore = 0;
        private Double _played_games = 0;
        private int _P1_7out_HS = 0;
        private int _P2_7out_HS = 0;
        private int _P1_TM_HS = 0;
        private int _P2_TM_HS = 0;
        private string _comp = " ";
        private string _game = " ";
        Player P1 = new Player();
        Player P2 = new Player();
        ///<summary> creates dice and then rolls the dice and gives statistics</summary>
        ///<returns>returns total value and amount of rolls</returns>
        public void Roll_dice()
        {


            while (_Play_game == true)
            {
                _P1totalscore = 0;
                _P2totalscore = 0;
                while (true)
                {
                    try
                    {
                        Console.WriteLine("what game do you want to play Sevenout(7out) or Three or More(TM)");
                        _game = Console.ReadLine().ToLower();
                        if (_game == "7out" || _game == "sevenout")
                        {
                            SevensOut P1sevensOut = new SevensOut();
                            SevensOut P2sevensOut = new SevensOut();
                            Console.WriteLine("Player 1 turn");
                            _P1totalscore = P1sevensOut.Game();
                            Console.WriteLine("Player 2 turn");
                            _P2totalscore = P2sevensOut.Game();
                            Console.WriteLine("P1 score = " + _P1totalscore + "\nP2 score = " + _P2totalscore);
                            High_scores(1);
                            Wins();
                            Play_again();
                            _played_games++;
                            break;
                        }
                        else if (_game == "tm" || _game == "three or more")
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

                            ThreeOrMore P1threeOrMore = new ThreeOrMore();
                            ThreeOrMore P2threeOrMore = new ThreeOrMore();
                            while ((_P1totalscore < 20) && (_P2totalscore < 20))
                            {
                                Console.WriteLine("Player 1 turn");
                                _P1totalscore = P1threeOrMore.Game(true);
                                if (_comp == "c" || _comp == "computer")
                                {
                                    Console.WriteLine("Player 2 turn");
                                    _P2totalscore = P2threeOrMore.Game(true);
                                }
                                else
                                {
                                    Console.WriteLine("Player 2 turn");
                                    _P2totalscore = P2threeOrMore.Game();
                                }
                                Console.WriteLine("P1 score = " + _P1totalscore + "\nP2 score = " + _P2totalscore);
                            }
                            High_scores(2);
                            Wins();
                            Play_again();
                            _played_games++;
                            break;
                        }
                        else
                        {
                            throw new ArgumentException("please enter sevenout or 7out or or three or more or tm");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());

                    }
                }
            }
            statistics();
        }





        ///<summary> takes dice values and outputs statistics </summary>

        public void statistics()
        {
            Console.WriteLine("played " + _played_games);
            Console.Write("Player 1 ");
            P1.Print_wins();
            Console.WriteLine($"Player 1 percentage win rate = {((P1.Wins / _played_games) * 100)}%");
            Console.WriteLine($"Player 1 sevenout highscore = {_P1_7out_HS}\nPlayer1 three or more highscore = {_P1_TM_HS}");
            Console.Write("Player 2 ");
            P2.Print_wins();
            Console.WriteLine($"Player 2 percentage win rate =  {((P2.Wins / _played_games) * 100)}%");
            Console.WriteLine($"Player 2 sevenout highscore = {_P2_7out_HS}\nPlayer 2 three or more highscore = {_P2_TM_HS}");
        }
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
                if (_P1totalscore > _P1_7out_HS)
                {
                    _P1_7out_HS = _P1totalscore;
                }
                if (_P2totalscore > _P2_7out_HS)
                {
                    _P2_7out_HS = _P2totalscore;
                }
            }
            else if (game == 2)
            {
                if (_P1totalscore > _P1_TM_HS)
                {
                    _P1_TM_HS = _P1totalscore;
                }
                if (_P2totalscore > _P2_TM_HS)
                {
                    _P2_TM_HS = _P2totalscore;
                }
            }
        }
    }
}