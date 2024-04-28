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
        player P1 = new player();
        player P2 = new player();
        ///<summary> creates dice and then rolls the dice and gives statistics</summary>
        ///<returns>returns total value and amount of rolls</returns>
        public (int,int) Roll_dice()
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
                    Console.WriteLine(game);
                    if (game == "tm" || game == "three or more")
                    {
                        ThreeOrMore P1threeOrMore = new ThreeOrMore();
                        ThreeOrMore P2threeOrMore = new ThreeOrMore();
                        while ((_P1totalscore < 20) && (_P2totalscore < 20))
                        {
                            Console.WriteLine("Player 1 turn");
                            _P1totalscore = P1threeOrMore.Game(true);
                            if (comp =="c" || comp == "computer")
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
                        Wins();
                        Play_again();
                        continue;
                    }
                    else if (game == "7out" || game == "sevenout")
                    {
                        SevensOut P1sevensOut = new SevensOut();
                        SevensOut P2sevensOut = new SevensOut();
                        _P1totalscore = P1sevensOut.Game();
                        _P2totalscore = P2sevensOut.Game();
                        Console.WriteLine("P1 score = " + _P1totalscore+"\nP2 score = " + _P2totalscore);
                        Wins();
                        Play_again();
                        continue;
                    }
                    else
                    {
                        throw new ArgumentException();
                    }
                }
                Console.WriteLine("P1 Wins = " + P1.Wins + "\nP2 wins = " + P2.Wins);
                return (0, 0);

                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                Console.WriteLine("try again");
                Roll_dice();
                return (0, 0);
            }

        }
    ///<summary> takes dice values and outputs statistics </summary>
    ///<param name="Dice_Value_1">contains first dice value</param>
    ///<param name="Dice_Value_2">contains second dice value</param>
    ///<param name="Dice_Value_3">contains third dice value</param>
    ///<returns>total value of all dice</returns>
    public int statistics(int Dice_Value_1, int Dice_Value_2, int Dice_Value_3)
    {
      //adds dice values together
      int totalValue = Dice_Value_1 + Dice_Value_2 + Dice_Value_3;
      Console.WriteLine($"1={Dice_Value_1}\n2={Dice_Value_2}\n3={Dice_Value_3}\ntotal={totalValue}");
      return totalValue;
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
  }
}
