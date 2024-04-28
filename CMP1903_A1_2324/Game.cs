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
        private int _played_games = 0;
        private int _P1_7out_HS = 0;
        private int _P2_7out_HS = 0;
        private int _P1_TM_HS = 0;
        private int _P2_TM_HS = 0;
        player P1 = new player();
        player P2 = new player();
        ///<summary> creates dice and then rolls the dice and gives statistics</summary>
        ///<returns>returns total value and amount of rolls</returns>
        public void Roll_dice()
        {
            try
            {
                while (_Play_game == true)
                {
                    _P1totalscore = 0;
                    _P2totalscore = 0;
                    Console.WriteLine("Do you want to play with a computer(c) or another player(p)(on the same macine)");
                    string comp = Console.ReadLine().ToLower();
                    Console.WriteLine("what game do you want to play Sevenout(7out) or Three or More(TM)");
                    string game = Console.ReadLine().ToLower();
                    _played_games++;
                    Console.WriteLine(game);
                    if (game == "7out" || game == "sevenout")
                    {
                        SevensOut P1sevensOut = new SevensOut();
                        SevensOut P2sevensOut = new SevensOut();
                        _P1totalscore = P1sevensOut.Game();
                        _P2totalscore = P2sevensOut.Game();
                        Console.WriteLine("P1 score = " + _P1totalscore + "\nP2 score = " + _P2totalscore);
                        High_scores(1);
                        Wins();
                        Play_again();
                        continue;
                    }
                    else if (game == "tm" || game == "three or more")
                    {
                        ThreeOrMore P1threeOrMore = new ThreeOrMore();
                        ThreeOrMore P2threeOrMore = new ThreeOrMore();
                        while ((_P1totalscore < 20) && (_P2totalscore < 20))
                        {
                            Console.WriteLine("Player 1 turn");
                            _P1totalscore = P1threeOrMore.Game(true);
                            if (comp == "c" || comp == "computer")
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
                        continue;
                    }
                    else
                    {
                        throw new ArgumentException();
                    }
                }
                statistics();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                Console.WriteLine("try again");
                Roll_dice();
            }

        }
        ///<summary> takes dice values and outputs statistics </summary>
        ///<param name="Dice_Value_1">contains first dice value</param>
        ///<param name="Dice_Value_2">contains second dice value</param>
        ///<param name="Dice_Value_3">contains third dice value</param>
        ///<returns>total value of all dice</returns>
        public void statistics()
        {
            Console.WriteLine("played " + _played_games);
            P1.Print_wins();
            Console.WriteLine($"P1 percnetage win = {((P1.Wins / _played_games) * 100)}");
            Console.WriteLine($"Player1 sevenout highscore = {_P1_7out_HS}\nPlayer1 three or more highscore = {_P1_TM_HS}");
            P2.Print_wins();
            Console.WriteLine($"Player1 percentage win =  {((P2.Wins / _played_games) * 100)}");
            Console.WriteLine($"Player1 sevenout highscore = {_P2_7out_HS}\nPlayer1 three or more highscore = {_P2_TM_HS}");
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
            Console.WriteLine("do you want to play another game?: ");
            _play_again = Console.ReadLine().ToLower();
            if (_play_again == "y" || _play_again == "yes")
            {
                _Play_game = true;
            }
            else if (_play_again == "n" || _play_again == "no")
            {
                _Play_game = false;
            }
            else
            {
                throw new ArgumentException();
            }
        }
        public void High_scores(int game)
        { if (game == 1)
            {
                if (_P1totalscore > _P1_7out_HS)
                {
                    _P1_7out_HS = _P1totalscore;
                }
                else if (_P2totalscore > _P2_7out_HS)
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
                else if (_P2totalscore > _P2_TM_HS)
                {
                    _P2_TM_HS = _P2totalscore;
                }
            }

        }
    }
}
