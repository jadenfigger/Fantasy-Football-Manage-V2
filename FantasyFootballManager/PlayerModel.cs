using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectController
{
    public class PlayerModel
    {
        public string Name;
        public string YearsPlayed;
        public string Team;
        public string ID;

        public PlayerModel(string name, string yearsPlayed, string team, string id)
        {
            Name = name;
            YearsPlayed = yearsPlayed;
            Team = team;
            ID = id;
        }

        public Object Clone()
        {
            return new PlayerModel(Name, YearsPlayed, Team, ID);
        }
    }
}
