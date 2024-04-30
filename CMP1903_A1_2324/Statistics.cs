using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903_A1_2324
{
    internal class Statistics
    {
        public void Stats(double played_games,double P1_Wins, double P2_Wins, List<int>Highscores)
        {
            Console.WriteLine("\tStatistics");
            Console.WriteLine($"played games = {played_games}\n");
            Console.WriteLine($"Player 1 wins= {P1_Wins}\nPlayer 1 percentage win rate = {((P1_Wins / played_games) * 100)}%\nPlayer 1 sevenout highscore = {Highscores[0]}\nPlayer1 three or more highscore = {Highscores[1]}");
            Console.WriteLine($"\nPlayer 2 wins = {P2_Wins}\nPlayer 2 percentage win rate = {((P2_Wins / played_games) * 100)}%\nPlayer 2 sevenout highscore = {Highscores[2]}\nPlayer2 three or more highscore = {Highscores[3]}");
        }
    }
}
