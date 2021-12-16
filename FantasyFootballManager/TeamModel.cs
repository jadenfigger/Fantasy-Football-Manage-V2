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
        public int totalPoints;

        public Dictionary<int, List<double>> PlayerTotals;
        public TeamModel(string name=null)
        {
            TeamName = name;
            PlayerHistory = new Dictionary<int, Dictionary<int, PlayerModel>>();
            PlayerTotals = new Dictionary<int, List<double>>();

            //if (teamHistoryData != null)
            //{
            //    PlayerHistory = teamHistoryData;
            //}
        }
    }
}
