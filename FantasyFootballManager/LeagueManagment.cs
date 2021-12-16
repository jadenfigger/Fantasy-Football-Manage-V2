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

            txtEWeek.Text = ProjectControllerData.cLeague.EndWeek.ToString();
            txtCWeek.Text = ProjectControllerData.cLeague.CurrWeek.ToString();
        }

        private void tabPage2_Enter(object sender, EventArgs e)
        {
            playerMatchupGrid.Rows.Clear();
            for (var i = 0; i < ProjectControllerData.cLeague.Schedule[ProjectControllerData.cLeague.CurrWeek].Count; i++)
            {
                var team1Name = ProjectControllerData.cLeague.Schedule[ProjectControllerData.cLeague.CurrWeek][i][0].ToString();
                var team2Name = ProjectControllerData.cLeague.Schedule[ProjectControllerData.cLeague.CurrWeek][i][1].ToString();

                playerMatchupGrid.Rows.Add(team1Name, "", team2Name);
                playerMatchupGrid.Rows[i].Height = 35;
            }

            txtCurrentWeektb2.Text = ProjectControllerData.cLeague.CurrWeek.ToString();

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

                foreach (var player in team.PlayerHistory[ProjectControllerData.cLeague.CurrWeek].Values)
                {
                    cLineupSave[cLineupSave.Count - 1].Add(player);
                }
            }
        }

        private void btnCalculateTotalsMain_Click(object sender, EventArgs e)
        {
            CalculatePointsForCWeek();

            for (var i = 0; i < ProjectControllerData.cLeague.Teams.Count; i++) 
            {
                lineupsGrid.Rows[i].Cells[4].Value = ProjectControllerData.cLeague.Teams[i].PlayerTotals[ProjectControllerData.cLeague.CurrWeek][3].ToString();
            }

        }

        public void CalculatePointsForCWeek()
        {
            ProjectControllerData.cLeague.PointCalculationVariables = new List<double>() { Convert.ToDouble(txtPassBonus.Text), Convert.ToDouble(txtRushBonus.Text), Convert.ToDouble(txtRecBonus.Text), Convert.ToDouble(txtPassYds.Text), Convert.ToDouble(txtPassTds.Text), Convert.ToDouble(txtPassCmp.Text), Convert.ToDouble(txtRushYds.Text), Convert.ToDouble(txtRushAtt.Text), Convert.ToDouble(txtRushTds.Text), Convert.ToDouble(txtRec.Text), Convert.ToDouble(txtRecTds.Text), Convert.ToDouble(txtRecYds.Text) };

            FillCurrentPlayersLineup();

            foreach (var team in cLineupSave)
            {
                var temp = ProjectControllerData.cLeague.Teams[cLineupSave.IndexOf(team)];
                if (ProjectControllerData.cLeague.Teams[cLineupSave.IndexOf(team)].PlayerTotals.Count < ProjectControllerData.cLeague.CurrWeek)
                {
                    ProjectControllerData.cLeague.Teams[cLineupSave.IndexOf(team)].PlayerTotals.Add(ProjectControllerData.cLeague.CurrWeek, new List<double>());

                    ProjectControllerData.cLeague.Teams[cLineupSave.IndexOf(team)].PlayerTotals[ProjectControllerData.cLeague.CurrWeek].Add(-1);
                    ProjectControllerData.cLeague.Teams[cLineupSave.IndexOf(team)].PlayerTotals[ProjectControllerData.cLeague.CurrWeek].Add(-1);
                    ProjectControllerData.cLeague.Teams[cLineupSave.IndexOf(team)].PlayerTotals[ProjectControllerData.cLeague.CurrWeek].Add(-1);
                    ProjectControllerData.cLeague.Teams[cLineupSave.IndexOf(team)].PlayerTotals[ProjectControllerData.cLeague.CurrWeek].Add(-1);
                }

                double total = 0;

                for (var i = 0; i < 3; i++)
                {
                    var playerStatsList = WebScraper.GetPlayerStats(team[i*2].ID, ProjectControllerData.cLeague.CurrWeek);

                    var playerTotal = ProjectControllerData.CalculatePointTotal(playerStatsList);
                    if (playerTotal != -1)
                    {
                        total += playerTotal;
                    }

                    ProjectControllerData.cLeague.Teams[cLineupSave.IndexOf(team)].PlayerTotals[ProjectControllerData.cLeague.CurrWeek][i] = playerTotal;
                }
                ProjectControllerData.cLeague.Teams[cLineupSave.IndexOf(team)].PlayerTotals[ProjectControllerData.cLeague.CurrWeek][3] = total;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SqlDataAccess.SaveCLeague();
            ProjectControllerData.SaveSchedule();
        }


        private void tabPage3_Enter(object sender, EventArgs e)
        {

        }

        private void selWeek_Click(object sender, EventArgs e)
        {
            selWeek.Items.Clear();
            for (var i = 1; i <= ProjectControllerData.cLeague.CurrWeek; i++)
            {
                selWeek.Items.Add(i);
            }
        }

        private void selWeek_DropDownClosed(object sender, EventArgs e)
        {
            var index = ProjectControllerData.cLeague.CurrWeek;
            if (selWeek.SelectedValue != null)
            {
                index = Convert.ToInt32(selWeek.ValueMember);
                ProjectControllerData.cWeek = Convert.ToInt32(selWeek.SelectedItem);

            }
            playerMatchupsGrid2.Rows.Clear();
            for (var i = 0; i < ProjectControllerData.cLeague.Schedule[index].Count; i++)
            {
                var team1Name = ProjectControllerData.cLeague.Schedule[index][i][0].ToString();
                var team2Name = ProjectControllerData.cLeague.Schedule[index][i][1].ToString();

                playerMatchupsGrid2.Rows.Add(team1Name, "", team2Name);
                playerMatchupsGrid2.Rows[i].Height = 35;
            }

            txtTb3Title.Text = $"Week {index} Infomation";

        }

        private void playerMatchupsGrid2_DoubleClick(object sender, EventArgs e)
        {
            var w = ProjectControllerData.cWeek;
            var x = selWeek;
            var teamMatchup = ProjectControllerData.cLeague.Schedule[w][playerMatchupsGrid2.Rows.IndexOf(playerMatchupsGrid2.SelectedRows[0])];

            var team1 = ProjectControllerData.cLeague.Teams.Where(team => team.TeamName == teamMatchup[0]).ToList()[0];
            var team2 = ProjectControllerData.cLeague.Teams.Where(team => team.TeamName == teamMatchup[1]).ToList()[0];

            txtTeam1Name.Text = team1.TeamName;
            txtTeam2Name.Text = team2.TeamName;

            if (w == ProjectControllerData.cLeague.CurrWeek)
            {
                txtQBName1.Text = team1.PlayerHistory[w][0].Name;
                txtRBName1.Text = team1.PlayerHistory[w][2].Name;
                txtWRName1.Text = team1.PlayerHistory[w][4].Name;

                txtQBName2.Text = team2.PlayerHistory[w][0].Name;
                txtRBName2.Text = team2.PlayerHistory[w][2].Name;
                txtWRName2.Text = team2.PlayerHistory[w][4].Name;
            }
            

            var temp = team1.PlayerTotals;
            try
            {
                txtQBPoints1.Text = team1.PlayerTotals[w][0] == -1 ? "N/A" : team1.PlayerTotals[w][0].ToString();
                txtRBPoints1.Text = team1.PlayerTotals[w][1] == -1 ? "N/A" : team1.PlayerTotals[w][0].ToString();
                txtWRPoints1.Text = team1.PlayerTotals[w][2] == -1 ? "N/A" : team1.PlayerTotals[w][0].ToString();
                txtTotPoints1.Text = team1.PlayerTotals[w][3] == -1 ? "N/A" : team1.PlayerTotals[w][3].ToString();
            }
            catch
            {
                txtQBPoints1.Text = "N/A";
                txtRBPoints1.Text = "N/A";
                txtWRPoints1.Text = "N/A";
                txtTotPoints1.Text = "N/A";
            }

            try
            {
                txtQBPoints2.Text = team2.PlayerTotals[w][0] == -1 ? "N/A" : team2.PlayerTotals[w][0].ToString();
                txtRBPoints2.Text = team2.PlayerTotals[w][1] == -1 ? "N/A" : team2.PlayerTotals[w][1].ToString();
                txtWRPoints2.Text = team2.PlayerTotals[w][2] == -1 ? "N/A" : team2.PlayerTotals[w][2].ToString();
                txtTotPoints2.Text = team2.PlayerTotals[w][3] == -1 ? "N/A" : team2.PlayerTotals[w][3].ToString();

            }
            catch
            {
                txtQBPoints2.Text = "N/A";
                txtRBPoints2.Text = "N/A";
                txtWRPoints2.Text = "N/A";
                txtTotPoints2.Text = "N/A";
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            CalculatePointsForCWeek();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            ProjectControllerData.cWeek = Convert.ToInt32(selWeek.SelectedItem);
        }

        private void btnNextWeek_Click(object sender, EventArgs e)
        {
            ProjectControllerData.cLeague.CurrWeek += 1;
        }
    }
}
