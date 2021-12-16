using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectController
{
    public class LeagueModel
    {
        public string LeagueName;
        public int NumOfTeams;
        public int EndWeek;
        public int CurrWeek;
        public List<TeamModel> Teams;
        public Dictionary<int, List<List<string>>> Schedule;
        public List<double> PointCalculationVariables;

        public LeagueModel(string name, int teamCount, int eWeek, int cWeek)
        {
            LeagueName = name;
            NumOfTeams = teamCount;
            EndWeek = eWeek;
            CurrWeek = cWeek;
            Teams = new List<TeamModel>();
        }

        public void CatchupPointsToCurrWeek()
        {
            CurrWeek = WebScraper.GetCurrentWeek();

            if (CurrWeek == 0)
            {
                return;
            }
            for (var teamIndex = 0; teamIndex < NumOfTeams; teamIndex++)
            {
                for (var i = 1; i < CurrWeek; i++)
                {
                    double total = 0;
                    Teams[teamIndex].PlayerTotals.Add(i, new List<double>());
                    for (var j = 0; j < 3; j++)
                    {
                        var pPoints = ProjectControllerData.CalculatePointTotal(WebScraper.GetPlayerStats(Teams[teamIndex].PlayerHistory[i][j].ID, i));
                        total += pPoints;
                        Teams[teamIndex].PlayerTotals[i].Add(pPoints);
                    }
                    Teams[teamIndex].PlayerTotals[i].Add(total);
                }
            }
        }

        public void GenerateRandomSchedule()
        {
            EmptySchedule();

            for (var i = 1; i <= EndWeek; i++)
            {
                var atn = GetAllTeamNames();

                for (var j = 0; j < Teams.Count / 2; j++)
                {
                    for (var z = 0; z < 2; z++)
                    {
                        var r = new Random();
                        var randomIndex = r.Next(0, atn.Count - 1);
                        Schedule[i][j][z] = atn[randomIndex];
                        atn.RemoveAt(randomIndex);
                    }
                }
            }
        }

        public List<string> GetAllTeamNames()
        {
            var allTeamNames = new List<string>();
            foreach (var t in Teams)
            {
                allTeamNames.Add(t.TeamName);
            }
            return allTeamNames;
        }

        public void EmptySchedule()
        {
            Schedule = new Dictionary<int, List<List<string>>>();
            for (var i = 1; i <= EndWeek; i++)
            {
                Schedule.Add(i, new List<List<string>>());
                for (var j = 0; j < Teams.Count / 2; j++)
                {
                    Schedule[i].Add(new List<string>() { null, null });
                }
            }
        }
    }
}
