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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCreateLeague_Click(object sender, EventArgs e)
        {
            if (txtLName.Text.Equals("") || txtNumOfTeams.Text.Equals(""))
            {
                MessageBox.Show("Please fill out all fields", "Invalid Entry", MessageBoxButtons.OK);
                txtLName.Focus();
                return;
            }
            if (Convert.ToInt32(txtNumOfTeams.Text)%2 != 0)
            {
                MessageBox.Show("Number of teams must be an even integer", "Invalid Entry", MessageBoxButtons.OK);
                txtNumOfTeams.Focus();
                return;
            }

            ProjectControllerData.cLeague = new LeagueModel(txtLName.Text, Convert.ToInt32(txtNumOfTeams.Text), Convert.ToInt32(sEndWeek.Value), WebScraper.GetCurrentWeek());
            SqlDataAccess.CreateLeague();

            AddTeams atForm = new AddTeams();
            this.Hide();
            atForm.ShowDialog();
            this.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var leagueNames = ProjectControllerData.FindAllLeagues();
            foreach (var lName in leagueNames)
            {
                lbAllLeagues.Items.Add(lName.Split('.')[1].Replace("/", String.Empty));
            }
        }

        private void lbAllLeagues_DrawItem(object sender, DrawItemEventArgs e)
        {
            ListBox list = (ListBox)sender;
            if (e.Index > -1)
            {
                object item = list.Items[e.Index];
                e.DrawBackground();
                e.DrawFocusRectangle();
                Brush brush = new SolidBrush(e.ForeColor);
                SizeF size = e.Graphics.MeasureString(item.ToString(), e.Font);
                e.Graphics.DrawString(item.ToString(), e.Font, brush, e.Bounds.Left + (e.Bounds.Width / 2 - size.Width / 2), e.Bounds.Top + (e.Bounds.Height / 2 - size.Height / 2));
            }
        }

        private void lbAllLeagues_DoubleClick(object sender, EventArgs e)
        {
            var leagueSelectedName = lbAllLeagues.SelectedItem.ToString();

            SqlDataAccess.LoadLeague(leagueSelectedName);

            LeagueManagment lmForm = new LeagueManagment();
            this.Hide();
            lmForm.ShowDialog();
            this.Close();
        }
    }
}
