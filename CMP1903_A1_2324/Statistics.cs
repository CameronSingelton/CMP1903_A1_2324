using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903_A1_2324
{
    internal class Statistics
    {
        /// <summary>prints statistics</summary>
        /// <param name="played_games">how many games have been played </param> 
        /// <param name="played_TM">how many games of three or more played</param>
        /// <param name="played_7out">how many games of 7out played</param>
        /// <param name="P1_Wins">how many wins player1 has</param>
        /// <param name="P2_Wins">how many wins player2 has</param>
        /// <param name="P1Highscores">lists that contains the high scores of player 1</param>
        /// <param name="P2Highscores">lists that contains the high scores of player 2</param>
        
        public void Stats(double played_games,int played_TM,int played_7out,double P1_Wins, double P2_Wins, List<int>P1Highscores, List<int> P2Highscores)
        {
            //prints statistics in console
            Console.WriteLine("\tStatistics");
            //prints how many gemes are played
            Console.WriteLine($"  played games statistics\ntotal played games = {played_games}\ntotal games of sevenout = {played_7out}\ntotal games of three or more = {played_TM}");
            //prints all of Player1 statistics
            Console.WriteLine($"\n\tPlayer1 stats\nPlayer 1 wins= {P1_Wins}\nPlayer 1 percentage win rate = {((P1_Wins / played_games) * 100)}%\nPlayer 1 sevenout highscore = {P1Highscores[0]}\nPlayer1 three or more highscore = {P1Highscores[1]}");
            //prints all of Player2 statistics
            Console.WriteLine($"\n\tPlayer2 stats\nPlayer 2 wins = {P2_Wins}\nPlayer 2 percentage win rate = {((P2_Wins / played_games) * 100)}%\nPlayer 2 sevenout highscore = {P2Highscores[0]} \nPlayer2 three or more highscore =  {P2Highscores[1]}");
        }
    }
}
