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
    public partial class ScheduleManager : Form
    {
        public static List<string> dt;
        public ScheduleManager()
        {
            InitializeComponent();
        }

        private void ScheduleManager_Load(object sender, EventArgs e)
        {
            
        }

        private void scheduleGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                return;
            }
            var cCell = (DataGridViewComboBoxCell)scheduleGrid.Rows[e.RowIndex].Cells[e.ColumnIndex];

            if (cCell.Selected)
            {
                var temp = cCell.FormattedValue.ToString();
                dt.Remove(cCell.FormattedValue.ToString());
            }
        }

        private void scheduleGrid_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            for (var i = 0; i < scheduleGrid.Rows.Count; i++)
            {
                var lCell = (DataGridViewComboBoxCell)scheduleGrid.Rows[i].Cells[0];
                var rCell = (DataGridViewComboBoxCell)scheduleGrid.Rows[i].Cells[2];
                
                if (dt.Contains(lCell.FormattedValue.ToString()))
                {
                    dt.Remove(lCell.FormattedValue.ToString());
                }
                if (dt.Contains(rCell.FormattedValue.ToString()))
                {
                    dt.Remove(rCell.FormattedValue.ToString());
                }

                var lCol = (DataGridViewComboBoxColumn)scheduleGrid.Columns[0];
                var rCol = (DataGridViewComboBoxColumn)scheduleGrid.Columns[2];

                lCol.DataSource = dt;
                rCol.DataSource = dt;

            }
        }

        private void btnViewLeague_Click(object sender, EventArgs e)
        {
            ProjectControllerData.cLeague.GenerateRandomSchedule();


            ProjectControllerData.cLeague.PointCalculationVariables = new List<double>() { 300, 100, 150, 20, 6, 0, 10, 0.1, 6, 1, 6, 10 };
            ProjectControllerData.cLeague.CatchupPointsToCurrWeek();

            SqlDataAccess.SaveCLeague();

            LeagueManagment lmForm = new LeagueManagment();
            this.Hide();
            lmForm.ShowDialog();
            this.Close();
        }

        private void btnFinSchedule_Click(object sender, EventArgs e)
        {
            if (ProjectControllerData.cLeague.Schedule != null)
            {
                SqlDataAccess.SaveCLeague();
            }
            else
            {
                MessageBox.Show("Please genenerate a ranodm schedule or enter custom one.", "No Entry", MessageBoxButtons.OK);
                return;
            }
        }
    }
}
