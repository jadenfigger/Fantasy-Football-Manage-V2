using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectController
{
    public class TeamModel
    {
        public Dictionary<int, Dictionary<int, PlayerModel>> PlayerHistory;
        public string TeamName;
        public int Wins = 0;
        public int Losses = 0;

        public Dictionary<int, List<int>> playerTotals;
        public int totalPoints;
        public TeamModel(string name=null)
        {
            TeamName = name;
            PlayerHistory = new Dictionary<int, Dictionary<int, PlayerModel>>();
            //if (teamHistoryData != null)
            //{
            //    PlayerHistory = teamHistoryData;
            //}
        }
    }
}
