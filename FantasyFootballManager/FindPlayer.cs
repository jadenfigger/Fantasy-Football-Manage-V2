using HtmlAgilityPack;
using ProjectController;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace FantasyFootballManager
{
    public partial class FindPlayer : Form
    {
        public List<List<string>> players;
        public FindPlayer()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            allPlayersGrid.Rows.Clear();
            if (txtPlayerName.Text.Equals(""))
            {
                MessageBox.Show("Please fill out the player name search box", "Invalid Entry", MessageBoxButtons.OK);
                txtPlayerName.Focus();
                return;
            }
            players = WebScraper.FindPlayersByName(txtPlayerName.Text);
            if (players == null)
            {
                MessageBox.Show("No players were found with the entered name", "Try Again", MessageBoxButtons.OK);
                txtPlayerName.Focus();
                return;
            }


            for (var i=0; i<players.Count; i++)
            {
                allPlayersGrid.Rows.Add(players[i][0], players[i][1], "     "+players[i][3]);
                allPlayersGrid.Rows[i].Height = 35;
            }
        }

        

        private void btnSelPlayer_Click(object sender, EventArgs e)
        {
            var i = allPlayersGrid.SelectedRows[0].Index;
            if (i == null)
            {
                MessageBox.Show("Please select a player", "No player selection", MessageBoxButtons.OK);
                return;
            }
            if (ProjectControllerData.cLeague.Teams[ProjectControllerData.cTeam].PlayerHistory[ProjectControllerData.cWeek].ContainsKey(ProjectControllerData.cPos))
            {
                ProjectControllerData.cLeague.Teams[ProjectControllerData.cTeam].PlayerHistory[ProjectControllerData.cWeek][ProjectControllerData.cPos] = new PlayerModel(players[i][0], players[i][1], players[i][3], players[i][2]);
            }
            else
            {
                var p = new PlayerModel(players[i][0], players[i][1], players[i][3], players[i][2]);
                ProjectControllerData.cLeague.Teams[ProjectControllerData.cTeam].PlayerHistory[ProjectControllerData.cWeek].Add(ProjectControllerData.cPos, p);
            }

            AddTeams atForm = new AddTeams();
            this.Hide();
            atForm.ShowDialog();
            this.Close();
        }
    }
}
