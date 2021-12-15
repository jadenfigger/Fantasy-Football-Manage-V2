using ProjectController;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FantasyFootballManager
{
    public partial class LeagueManagment : Form
    {
        public static List<List<PlayerModel>> cLineupSave;
        public LeagueManagment()
        {
            InitializeComponent();
        }
        private void LeagueManagment_Load(object sender, EventArgs e)
        {
            if (ProjectControllerData.cLeague == null)
            {
                ProjectControllerData.cLeague = new LeagueModel("Test", 4, 1, 10);
                ProjectControllerData.cLeague.Teams.Add(new TeamModel("team1"));
                ProjectControllerData.cLeague.Teams.Add(new TeamModel("team2"));
                ProjectControllerData.cLeague.Teams.Add(new TeamModel("team3"));
                ProjectControllerData.cLeague.Teams.Add(new TeamModel("team4"));

                ProjectControllerData.cLeague.GenerateRandomSchedule();
            }
        }
        private void label9_Click(object sender, EventArgs e)
        {
        }

        private void tabPage1_Enter(object sender, EventArgs e)
        {
            teamsGridView.Rows.Clear();
            foreach (var team in ProjectControllerData.cLeague.Teams)
            {
                teamsGridView.Rows.Add(team.TeamName, $"{team.Wins}-{team.Wins + team.Losses}");
                teamsGridView.Rows[teamsGridView.Rows.Count - 1].Height = 35;
            }

            txtSWeek.Text = ProjectControllerData.cLeague.StartWeek.ToString();
            txtEWeek.Text = ProjectControllerData.cLeague.EndWeek.ToString();
            txtCWeek.Text = ProjectControllerData.cWeek.ToString();


        }

        private void tabPage2_Enter(object sender, EventArgs e)
        {
            playerMatchupGrid.Rows.Clear();
            for (var i = 0; i < ProjectControllerData.cLeague.Schedule.Schedule[ProjectControllerData.cWeek].Count; i++)
            {
                var team1Name = ProjectControllerData.cLeague.Schedule.Schedule[ProjectControllerData.cWeek][i][0].ToString();
                var team2Name = ProjectControllerData.cLeague.Schedule.Schedule[ProjectControllerData.cWeek][i][1].ToString();

                playerMatchupGrid.Rows.Add(team1Name, "", team2Name);
                playerMatchupGrid.Rows[i].Height = 35;
            }

            txtCurrentWeektb2.Text = ProjectControllerData.cWeek.ToString();

            lineupsGrid.Rows.Clear();
            FillCurrentPlayersLineup();
            for (var i = 0; i < ProjectControllerData.cLeague.Teams.Count; i++)
            {
                lineupsGrid.Rows.Add(ProjectControllerData.cLeague.Teams[i].TeamName);
                lineupsGrid.Rows[lineupsGrid.Rows.Count - 1].Height = 35;

                var qbs = new List<string>() { cLineupSave[i][0].Name, cLineupSave[i][1].Name };
                var rbs = new List<string>() { cLineupSave[i][2].Name, cLineupSave[i][3].Name };
                var wrs = new List<string>() { cLineupSave[i][4].Name, cLineupSave[i][5].Name };

                var qbsComboBox = (DataGridViewComboBoxCell)lineupsGrid.Rows[i].Cells[1];
                var rbsComboBox = (DataGridViewComboBoxCell)lineupsGrid.Rows[i].Cells[2];
                var wrsComboBox = (DataGridViewComboBoxCell)lineupsGrid.Rows[i].Cells[3];

                qbsComboBox.DataSource = qbs;
                qbsComboBox.Value = qbs[0];
                rbsComboBox.DataSource = rbs;
                rbsComboBox.Value = rbs[0];
                wrsComboBox.DataSource = wrs;
                wrsComboBox.Value = wrs[0];
            }
        }

        public void FillCurrentPlayersLineup()
        {
            cLineupSave = new List<List<PlayerModel>>();
            foreach (var team in ProjectControllerData.cLeague.Teams)
            {

                cLineupSave.Add(new List<PlayerModel>());

                cLineupSave[cLineupSave.Count - 1].Add(new PlayerModel("Kyler Murray", "1999-2021", "Car", "MurrKy00"));
                cLineupSave[cLineupSave.Count - 1].Add(new PlayerModel("Tom Brady", "1999-2021", "Car", "BradTo00"));
                cLineupSave[cLineupSave.Count - 1].Add(new PlayerModel("Jonathan Taylor", "1999-2021", "Car", "TaylJo02"));
                cLineupSave[cLineupSave.Count - 1].Add(new PlayerModel("Derrick Henry", "1999-2021", "Car", "HenrDe00"));
                cLineupSave[cLineupSave.Count - 1].Add(new PlayerModel("Cooper Kupp", "1999-2021", "Car", "KuppCo00"));
                cLineupSave[cLineupSave.Count - 1].Add(new PlayerModel("Chris Godwin", "1999-2021", "Car", "GodwCh00"));

                //cLineupSave.Add(new List<PlayerModel>());
                //var temp = team.PlayerHistory;
                //foreach (var player in team.PlayerHistory[ProjectControllerData.cWeek].Values)
                //{
                //    cLineupSave[cLineupSave.Count - 1].Add(player);
                //}
            }
        }

        private void btnCalculateTotalsMain_Click(object sender, EventArgs e)
        {
            foreach (var team in cLineupSave)
            {
                foreach (var player in team)
                {
                    var playerStatsList = WebScraper.GetPlayerStats(player.ID);

                    var playerTotal = CalculatePointTotal(playerStatsList);

                }
            }
        }

        public double CalculatePointTotal(List<int> stats)
        {
            double tot = 0;

            //"pass_yds", "pass_td", "rush_att", "rush_yds", "rush_td", "rec", "rec_yds", "rec_td", "pass_cmp"

            if (stats[0] != -1 && stats[0] != 0)
            {
                tot += stats[0] / Convert.ToDouble(txtPassYds.Text);
                if (Convert.ToDouble(stats[0]) >= Convert.ToDouble(txtPassBonus.Text))
                {
                    tot += 5;
                }
            }
            if (stats[1] != -1 && stats[1] != 0)
            {
                tot += stats[1] * Convert.ToDouble(txtPassTds.Text);
            }
            if (stats[2] != -1 && stats[2] != 0)
            {
                tot += stats[2] * Convert.ToDouble(txtRushAtt.Text);
            }
            if (stats[3] != -1 && stats[3] != 0)
            {
                tot += stats[3] / Convert.ToDouble(txtRushYds.Text);
                if (Convert.ToDouble(stats[3]) >= Convert.ToDouble(txtRushBonus.Text))
                {
                    tot += 5;
                }
            }
            if (stats[4] != -1 && stats[4] != 0)
            {
                tot += stats[4] * Convert.ToDouble(txtRushTds.Text);
            }
            if (stats[5] != -1 && stats[5] != 0)
            {
                tot += stats[5] * Convert.ToDouble(txtRec.Text);
            }
            if (stats[6] != -1 && stats[6] != 0)
            {
                tot += stats[6] / Convert.ToDouble(txtRecYds.Text);
                if (Convert.ToDouble(stats[6]) >= Convert.ToDouble(txtRecBonus.Text))
                {
                    tot += 5;
                }
            }
            if (stats[7] != -1 && stats[7] != 0)
            {
                tot += stats[7] * Convert.ToDouble(txtRecTds.Text);
            }
            if (stats[8] != -1 && stats[8] != 0)
            {
                tot += stats[8] * Convert.ToDouble(txtPassCmp.Text);
            }
            return Math.Round(tot, 2);
        }
    }
}
