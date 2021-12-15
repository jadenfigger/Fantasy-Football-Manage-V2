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
        public int StartWeek;
        public int EndWeek;
        public List<TeamModel> Teams;
        public ScheduleModel Schedule = null;

        public LeagueModel(string name, int teamCount, int sWeek, int eWeek)
        {
            LeagueName = name;
            NumOfTeams = teamCount;
            StartWeek = sWeek;
            EndWeek = eWeek;
            Teams = new List<TeamModel>();
            Schedule = new ScheduleModel();
        }

        public void GenerateRandomSchedule()
        {
            EmptySchedule();

            for (var i = StartWeek; i <= EndWeek; i++)
            {
                var atn = GetAllTeamNames();

                for (var j = 0; j < Teams.Count / 2; j++)
                {
                    for (var z = 0; z < 2; z++)
                    {
                        var r = new Random();
                        var randomIndex = r.Next(0, atn.Count - 1);
                        Schedule.Schedule[i][j][z] = atn[randomIndex];
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
            Schedule.Schedule = new Dictionary<int, List<List<string>>>();
            for (var i = StartWeek; i <= EndWeek; i++)
            {
                Schedule.Schedule.Add(i, new List<List<string>>());
                for (var j = 0; j < Teams.Count / 2; j++)
                {
                    Schedule.Schedule[i].Add(new List<string>() { null, null });
                }
            }
        }
    }
}
