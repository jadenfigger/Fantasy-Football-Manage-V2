using ProjectController;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FantasyFootballManager
{
    public partial class AddTeams : Form
    {
        public bool _ctrl = false;
        public bool copied = false;
        public PlayerModel copy = null;
        public static Dictionary<int, List<PlayerModel>> gridPlayerModel;

        public AddTeams()
        {
            InitializeComponent();
        }

        private void AddTeams_Load(object sender, EventArgs e)
        {
            //if (ProjectControllerData.cLeague == null)
            //{
            //    ProjectControllerData.cLeague = new LeagueModel("Test", 1, 1, 10);
            //    //ProjectControllerData.cLeague.Teams.Add(new TeamModel("team1"));
            //    //ProjectControllerData.cLeague.Teams.Add(new TeamModel("team2"));
            //    //ProjectControllerData.cLeague.Teams.Add(new TeamModel("team3"));
            //    //ProjectControllerData.cLeague.Teams.Add(new TeamModel("team4"));

            //}
            
            
            if (ProjectControllerData.cLeague.Teams.Count > 0)
            {
                txtTeamName.Text = ProjectControllerData.cLeague.Teams[ProjectControllerData.cLeague.Teams.Count - 1].TeamName;
            }

            FillGrid();


            gbMain.Text = $"Team {ProjectControllerData.cTeam + 1} Infomation";
        }

        public void FillEmptyGrid()
        {
            playerHistoryGrid.Rows.Clear();
            for (var i = 0; i < ProjectControllerData.cLeague.CurrWeek; i++)
            {
                playerHistoryGrid.Rows.Add($"{i+1}");
                playerHistoryGrid.Rows[i].Height = 35;
            }
        }

        public void FillGrid()
        {
            FillEmptyGrid();

            if (ProjectControllerData.cWeek == 0 || ProjectControllerData.cLeague.Teams.Count <= ProjectControllerData.cTeam)
            {
                return;
            }

            foreach (var week in ProjectControllerData.cLeague.Teams[ProjectControllerData.cTeam].PlayerHistory)
            {
                foreach (var pos in week.Value)
                {
                    playerHistoryGrid.Rows[week.Key-1].Cells[pos.Key + 1].Value = pos.Value.Name;
                }
            }
        }

        private void btnAddTeam_Click(object sender, EventArgs e)
        {

            if (txtTeamName.Text.Equals(""))
            {
                MessageBox.Show("Please fill out team name before selecting players", "No Entry", MessageBoxButtons.OK);
                return;
            }

            bool teamNameValid = TeamNameValid();
            
            if (!teamNameValid)
            {
                MessageBox.Show("The entered team name is already in use", "Invalid Entry", MessageBoxButtons.OK);
                txtTeamName.Focus();
                return;
            }

            foreach (DataGridViewRow rw in playerHistoryGrid.Rows)
            {
                for (int i = 0; i < rw.Cells.Count; i++)
                {
                    if (rw.Cells[i].Value == null || rw.Cells[i].Value == DBNull.Value || String.IsNullOrWhiteSpace(rw.Cells[i].Value.ToString()))
                    {
                        MessageBox.Show("Please fill out entire player grid", "Not all fields filled", MessageBoxButtons.OK);
                        playerHistoryGrid.Focus();
                        return;
                    }
                }
            }

            if (ProjectControllerData.cLeague.Teams.Count < ProjectControllerData.cTeam+1)
            {
                ProjectControllerData.cLeague.Teams.Add(new TeamModel(txtTeamName.Text));
                
            } 
            else
            {
                ProjectControllerData.cLeague.Teams[ProjectControllerData.cTeam].TeamName = txtTeamName.Text;
            }

            ProjectControllerData.cTeam += 1;
            gbMain.Text = $"Team {ProjectControllerData.cTeam + 1} Infomation";
            txtTeamName.Text = "";
            txtTeamName.Focus();

            for (var row = 0; row < ProjectControllerData.cLeague.CurrWeek; row++)
            {
                for (var col = 1; col <= 6; col++)
                {
                    var cCell = playerHistoryGrid.Rows[row].Cells[col].Value = "";
                }
            }


            if (ProjectControllerData.cLeague.NumOfTeams == ProjectControllerData.cTeam)
            {
                ScheduleManager sForm = new ScheduleManager();
                this.Hide();
                sForm.ShowDialog();
                this.Close();
            }
        }

        public bool TeamNameValid()
        {
            bool temp = false;
            foreach (var team in ProjectControllerData.cLeague.Teams)
            {
                if (team.TeamName == txtTeamName.Text && ProjectControllerData.cTeam != ProjectControllerData.cLeague.Teams.IndexOf(team))
                {
                    temp = true;
                }
            }
            return !temp;
        }

        private void playerHistoryGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.ColumnIndex == 0)
            {
                return;
            }
            // 1 == QB1, 2 == QB2, 3 == RB1, ect
            ProjectControllerData.cPos = e.ColumnIndex - 1;

            ProjectControllerData.cWeek = Convert.ToInt32(e.RowIndex+1);
            if (txtTeamName.Text.Equals(""))
            {
                MessageBox.Show("Please fill out team name before selecting players", "No Entry", MessageBoxButtons.OK);
                return;
            }
            if (ProjectControllerData.cLeague.Teams.Count != ProjectControllerData.cTeam+1)
            {
                var t = new TeamModel();
                if (TeamNameValid())
                {
                    t.TeamName = txtTeamName.Text;
                    ProjectControllerData.cLeague.Teams.Add(t);
                }
                else
                {
                    MessageBox.Show("The entered team name is already in use", "Invalid Entry", MessageBoxButtons.OK);
                    txtTeamName.Focus();
                    return;
                }
            }
            
            if (!ProjectControllerData.cLeague.Teams[ProjectControllerData.cTeam].PlayerHistory.ContainsKey(ProjectControllerData.cWeek))
            {
                ProjectControllerData.cLeague.Teams[ProjectControllerData.cTeam].PlayerHistory.Add(ProjectControllerData.cWeek, new Dictionary<int, PlayerModel>());
            }

            FindPlayer atForm = new FindPlayer();
            this.Hide();
            atForm.ShowDialog();
            this.Close();
        }

        void playerHistoryGrid_KeyUp(object sender, KeyEventArgs e)
        {
            _ctrl = false;
        }

        void playerHistoryGrid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control)
                _ctrl = true;
        }

        void playerHistoryGrid_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (playerHistoryGrid.SelectedCells[0].ColumnIndex == 0)
            {
                return;
            }
            // ctrl + c
            if (_ctrl && e.KeyChar == (char)3)
            {
                Debug.Print("c");
                if (playerHistoryGrid.SelectedCells.Count > 0)
                {
                    var rowIndex = playerHistoryGrid.SelectedCells[0].RowIndex;
                    var colIndex = playerHistoryGrid.SelectedCells[0].ColumnIndex;

                    if (!ProjectControllerData.cLeague.Teams[ProjectControllerData.cTeam].PlayerHistory.ContainsKey(rowIndex+1))
                    {
                        ProjectControllerData.cLeague.Teams[ProjectControllerData.cTeam].PlayerHistory.Add(rowIndex+1, new Dictionary<int, PlayerModel>());
                    }

                    var toBeCopied = ProjectControllerData.cLeague.Teams[ProjectControllerData.cTeam].PlayerHistory[rowIndex+1][colIndex - 1];
                    
                    copy = (PlayerModel)toBeCopied.Clone();
                    copied = true;
                    
                }
            }
            // ctrl + v
            if (_ctrl && e.KeyChar == (char)22)
            {
                Debug.Print("v");
                if (playerHistoryGrid.SelectedCells.Count > 0)
                {
                    var rowIndex = playerHistoryGrid.SelectedCells[0].RowIndex;
                    var colIndex = playerHistoryGrid.SelectedCells[0].ColumnIndex;
                    
                    if (copied)
                    {
                        if (!ProjectControllerData.cLeague.Teams[ProjectControllerData.cTeam].PlayerHistory.ContainsKey(rowIndex + 1))
                        {
                            ProjectControllerData.cLeague.Teams[ProjectControllerData.cTeam].PlayerHistory.Add(rowIndex+1, new Dictionary<int, PlayerModel>());
                        }

                        if (ProjectControllerData.cLeague.Teams[ProjectControllerData.cTeam].PlayerHistory[rowIndex+1].ContainsKey(colIndex-1))
                        {
                            ProjectControllerData.cLeague.Teams[ProjectControllerData.cTeam].PlayerHistory[rowIndex+1][colIndex - 1] = copy;
                        }
                        else
                        {
                            ProjectControllerData.cLeague.Teams[ProjectControllerData.cTeam].PlayerHistory[rowIndex+1].Add(colIndex - 1, copy);
                        }

                        FillGrid();
                    }
                }
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (playerHistoryGrid.SelectedCells.Count > 0)
            {
                var rowIndex = playerHistoryGrid.SelectedCells[0].RowIndex;
                var colIndex = playerHistoryGrid.SelectedCells[0].ColumnIndex;

                try
                {
                    ProjectControllerData.cLeague.Teams[ProjectControllerData.cTeam].PlayerHistory[rowIndex].Remove(colIndex - 1);
                    FillGrid();
                }
                catch { }
            }
        }
    }
}
