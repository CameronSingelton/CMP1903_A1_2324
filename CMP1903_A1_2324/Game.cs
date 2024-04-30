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
        //creates instatnces of player
        Player P1 = new Player();
        Player P2 = new Player();
        //creats instance of statiatics
        Statistics statistics = new Statistics();
        //creates instances of sevenout for different players
        SevensOut P1sevensOut = new SevensOut();
        SevensOut P2sevensOut = new SevensOut();
        //creates instances of ThreeOrMore for different players
        ThreeOrMore P1threeOrMore = new ThreeOrMore();
        ThreeOrMore P2threeOrMore = new ThreeOrMore();
        //creates instance of testing
        Testing testing = new Testing();

        // private varible that when true runs the code when false ends the program
        private bool _Play_game = true;

        //private varable to contain how many games have been played
        private double _played_games = 0;
        private int _played_TM = 0;
        private int _played_7out=0;
        //to tell if the game is computer or player
        private string _comp = " ";
        ///<summary> creates games and runs there method and contains the menu</summary>
        public void Roll_dice()
        {
            //runs untill break is run
            while (true)
            {
                //trys code so if any errors inputs are entered raises and handles them
                try
                {
                    Console.WriteLine("Do you want to play with a computer(c) or another player(p)(on the same machine)");
                    _comp = Console.ReadLine().ToLower();
                    //runs if _comp dosn't contain specidic strings
                    if (_comp != "c" && _comp != "computer" && _comp != "p" && _comp != "player")
                    {
                        // raise error if _comp dosn't contain specidic strings
                        throw new ArgumentException("Please enter computer or c or p or player");
                    }
                    else
                    {
                        //breaks out of while true
                        break;
                    }
                }
                //catches all exceptions
                catch (Exception ex)
                {
                    //prints error
                    Console.WriteLine(ex.ToString());

                }
            }
            //runs code along as _play_game is true
            while (_Play_game == true)
            {
                //resets total scores for the player
                  P1.total_score = 0;
                  P2.total_score = 0;
                //runs untill break is run
                while (true)
                {
                    //trys code so if any errors inputs are entered raises and handles them
                    try
                    {
                        //prints menu in console
                        Console.WriteLine("\n\tMenu\nenter 1 for games\nenter 2 for statistics\nenter 3 to run test\nenter 4 to exit");
                        int Menu_select = int.Parse(Console.ReadLine());//reads and contains the input form the console in Menu_select
                        //if user enters 1
                        if (Menu_select == 1)
                        {
                            //runs untill break is run
                            while (true)
                            {
                                //trys code so if any errors inputs are entered raises and handles them
                                try
                                {
                                    //prints game menu
                                    Console.WriteLine("\tGames Menu\nenter 1 for Sevenout\nenter 2 for three or more");
                                    Menu_select = int.Parse(Console.ReadLine());//reads and contains the input form the console in Menu_select
                                    //runs 7out if Menu_select == 1
                                    if (Menu_select == 1)
                                    {
                                        //prints rules of game
                                        Console.WriteLine("\n\tRules\nRoll the two dice, noting the total rolled each time.\nIf it is a 7 - stop.\nIf it is any other number - add it to your total.\nIf it is a double - add double the total to your score (3,3 would add 12 to your total)");
                                       //prints it is players 1 turn
                                        Console.WriteLine("Player 1 turn");
                                       //calls sevenout game and contains returns value as score
                                          P1.total_score = P1sevensOut.Game(false);
                                        //prints it is players 2 turn
                                        Console.WriteLine("Player 2 turn");
                                        //calls sevenout game and contains returns value as score
                                          P2.total_score = P2sevensOut.Game(false);
                                        //prints players scores
                                        Console.WriteLine("P1 score = " +   P1.total_score + "\nP2 score = " +   P2.total_score);
                                        //calls mentod High_scores
                                        //calls mentod Update_High_scores for all players
                                        P1.Update_High_scores(1);
                                        P2.Update_High_scores(1);
                                        //calls method Wins
                                        Wins();
                                        //increase played games by 1
                                        _played_games++;
                                        _played_7out++;
                                        //breaks out of the while true loop
                                        break;
                                    }
                                    //if user enters 2
                                    else if (Menu_select == 2)
                                    {
                                        Console.WriteLine("\n\tRules\nRoll all 5 dice hoping for a 3-of-a-kind or better.\nIf 2-of-a-kind is rolled, player may choose to rethrow all, or the remaining dice.\n3-of-a-kind: 3 points\n4-of-a-kind: 6 points\n5-of-a-kind: 12 points\nFirst to a total of 20.");
                                        P1threeOrMore.totalscore = 0;
                                        P2threeOrMore.totalscore = 0;
                                        while ((  P1.total_score < 20) && (  P2.total_score < 20))
                                        {
                                            //prints it is players 1 turn
                                            Console.WriteLine("\n\nPlayer 1 turn");
                                              P1.total_score = P1threeOrMore.Game(false);
                                            if (_comp == "c" || _comp == "computer")
                                            {
                                                //prints it is players 2 turn
                                                Console.WriteLine("\n\nPlayer 2 turn");
                                                  P2.total_score = P2threeOrMore.Game(true);
                                            }
                                            else
                                            {
                                                //prints it is players 2 turn
                                                Console.WriteLine("Player 2 turn");
                                                  P2.total_score = P2threeOrMore.Game(false);
                                            }
                                            //prints players scores
                                            Console.WriteLine("P1 score = " +   P1.total_score + "\nP2 score = " +   P2.total_score);
                                        }
                                        //calls mentod Update_High_scores for all players
                                        P1.Update_High_scores(2);
                                        P2.Update_High_scores(2);
                                        //calls method Wins
                                        Wins();
                                        //increase played games by 1
                                        _played_games++;
                                        _played_TM++;
                                        //breaks out of the while true loop
                                        break;
                                    }
                                    else
                                    {
                                        //raises argument erro if user enter none of the options
                                        throw new ArgumentException("please enter 1 or 2");
                                    }
                                }
                                //catches FormatException
                                catch (FormatException ex)
                                {
                                    //prints what tye should enter
                                    Console.WriteLine("please enter 1 or 2");
                                    //prints error
                                    Console.WriteLine(ex.ToString());
                                }
                                //catches all exceptions
                                catch (Exception ex)
                                {
                                    //prints errors
                                    Console.WriteLine(ex.ToString());
                                }
                               
                            }
                        }
                        // if user enters 2 
                        else if (Menu_select == 2)
                        {
                            //calls stats method from statistics
                            statistics.Stats(_played_games,_played_TM,_played_7out, P1.Wins,P2.Wins, P1.High_scores,P2.High_scores);
                        }
                        //if user enters 3
                        else if (Menu_select == 3)
                        {
                            //calls test method form testing
                            testing.Test();
                        }
                        else if (Menu_select == 4)
                        {
                            //makes _play_game false
                            _Play_game=false;
                            //breaks out of while true loop
                            break;
                        }
                        //if user dosn't enter a option
                        else
                        {
                            //raises argument excpetion
                            throw new ArgumentException("please enter 1,2 or 3");
                        }
                    }
                    //catches FormatException
                    catch (FormatException ex)
                    {
                        //prints what tye should enter
                        Console.WriteLine("please enter 1 or 2");
                        //prints error
                        Console.WriteLine(ex.ToString());
                    }
                    //catches all exceptions
                    catch (Exception ex)
                    {
                        //prints errors
                        Console.WriteLine(ex.ToString());
                    }
                }
            }

        }
        ///<summary> cheack scores against eachother to see who wins </summary>
        public void Wins()
        {
            if (  P1.total_score >  P2.total_score)
            {
                Console.WriteLine("player 1 wins");
                P1.Wins++;
                  P1.total_score = 0;
                  P2.total_score = 0;
            }
            else if (  P1.total_score <   P2.total_score)
            {
                Console.WriteLine("player 2 wins");
                P2.Wins++;
                  P1.total_score = 0;
                  P2.total_score = 0;
            }
            else
            {
                Console.WriteLine("draw no one wins");
                  P1.total_score = 0;
                  P2.total_score = 0;
            }
        }
    }
}