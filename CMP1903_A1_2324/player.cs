using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903_A1_2324
{
    internal class Player
    {
        //private varabe to contain players wins
        private double _wins = 0;
        //contains the total_score of the player
        private int _total_score = 0;
        //list to contain  High scores
        private List<int> _High_scores = new List<int> { 0, 0 };

        public double Wins
        { 
            get { return _wins; } 
            set { _wins = value; }
        }

        public int total_score
        {
            get { return _total_score; }
            set { _total_score = value; }
        }
        public List<int> High_scores
        {
            get { return _High_scores; }
            set { _High_scores = value; }
        }
        ///<summary> prints the wins of the player</summary>
        public void Print_wins()
        {
            Console.WriteLine("wins= " + Wins);
        }
        ///<summary> check scores againsteachother to see of player has new high score </summary>
        ///<param name="game">tells what game highscore needs checking</param>
        public void Update_High_scores(int game)
        {
            //if gamed played was 7out
            if (game == 1)
            {
                //checks if current totalscore is higher than current highscore
                if (this._total_score > _High_scores[0])
                {
                    //sets highscore to curent totalscore
                    _High_scores[0] = this._total_score;
                }
            }
            //if game played was three or more
            else if (game == 2)
            {//checks if current totalscore is higher than current highscore
                if (this._total_score > _High_scores[1])
                {
                    //sets highscore to curent totalscore
                    _High_scores[1] = this._total_score;
                }
            }
        }
    }
}
