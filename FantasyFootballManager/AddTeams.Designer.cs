
namespace FantasyFootballManager
{
    partial class AddTeams
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.gbMain = new System.Windows.Forms.GroupBox();
            this.btnRemove = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btnAddTeam = new System.Windows.Forms.Button();
            this.playerHistoryGrid = new System.Windows.Forms.DataGridView();
            this.Weeks = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sQB = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bQB = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sRB = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bRB = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sWR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bWR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtTeamName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.gbMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.playerHistoryGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Rockwell", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(192, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(500, 46);
            this.label1.TabIndex = 1;
            this.label1.Text = "Fantasy Football Manager";
            // 
            // gbMain
            // 
            this.gbMain.Controls.Add(this.btnRemove);
            this.gbMain.Controls.Add(this.label2);
            this.gbMain.Controls.Add(this.btnAddTeam);
            this.gbMain.Controls.Add(this.playerHistoryGrid);
            this.gbMain.Controls.Add(this.txtTeamName);
            this.gbMain.Controls.Add(this.label4);
            this.gbMain.Font = new System.Drawing.Font("Rockwell", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbMain.Location = new System.Drawing.Point(12, 72);
            this.gbMain.Name = "gbMain";
            this.gbMain.Size = new System.Drawing.Size(860, 477);
            this.gbMain.TabIndex = 2;
            this.gbMain.TabStop = false;
            this.gbMain.Text = "Team # Infomation";
            // 
            // btnRemove
            // 
            this.btnRemove.Font = new System.Drawing.Font("Rockwell", 16F);
            this.btnRemove.Location = new System.Drawing.Point(13, 416);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(109, 48);
            this.btnRemove.TabIndex = 14;
            this.btnRemove.Text = "Remove";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Rockwell", 12F);
            this.label2.Location = new System.Drawing.Point(604, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(243, 19);
            this.label2.TabIndex = 13;
            this.label2.Text = "(Double click cell to add player)";
            // 
            // btnAddTeam
            // 
            this.btnAddTeam.Font = new System.Drawing.Font("Rockwell", 16F);
            this.btnAddTeam.Location = new System.Drawing.Point(319, 419);
            this.btnAddTeam.Name = "btnAddTeam";
            this.btnAddTeam.Size = new System.Drawing.Size(222, 48);
            this.btnAddTeam.TabIndex = 12;
            this.btnAddTeam.Text = "Add Team";
            this.btnAddTeam.UseVisualStyleBackColor = true;
            this.btnAddTeam.Click += new System.EventHandler(this.btnAddTeam_Click);
            // 
            // playerHistoryGrid
            // 
            this.playerHistoryGrid.AllowUserToAddRows = false;
            this.playerHistoryGrid.AllowUserToDeleteRows = false;
            this.playerHistoryGrid.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Rockwell", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.playerHistoryGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.playerHistoryGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.playerHistoryGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Weeks,
            this.sQB,
            this.bQB,
            this.sRB,
            this.bRB,
            this.sWR,
            this.bWR});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Rockwell", 14F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.playerHistoryGrid.DefaultCellStyle = dataGridViewCellStyle2;
            this.playerHistoryGrid.Location = new System.Drawing.Point(13, 87);
            this.playerHistoryGrid.MinimumSize = new System.Drawing.Size(0, 30);
            this.playerHistoryGrid.MultiSelect = false;
            this.playerHistoryGrid.Name = "playerHistoryGrid";
            this.playerHistoryGrid.RowHeadersVisible = false;
            this.playerHistoryGrid.RowHeadersWidth = 50;
            this.playerHistoryGrid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.playerHistoryGrid.RowTemplate.Height = 24;
            this.playerHistoryGrid.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.playerHistoryGrid.Size = new System.Drawing.Size(834, 323);
            this.playerHistoryGrid.TabIndex = 11;
            this.playerHistoryGrid.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.playerHistoryGrid_CellDoubleClick);
            this.playerHistoryGrid.KeyDown += new System.Windows.Forms.KeyEventHandler(this.playerHistoryGrid_KeyDown);
            this.playerHistoryGrid.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.playerHistoryGrid_KeyPress);
            this.playerHistoryGrid.KeyUp += new System.Windows.Forms.KeyEventHandler(this.playerHistoryGrid_KeyUp);
            // 
            // Weeks
            // 
            this.Weeks.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Weeks.HeaderText = "Week";
            this.Weeks.Name = "Weeks";
            this.Weeks.ReadOnly = true;
            // 
            // sQB
            // 
            this.sQB.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.sQB.HeaderText = "Starting QB";
            this.sQB.Name = "sQB";
            // 
            // bQB
            // 
            this.bQB.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.bQB.HeaderText = "Backup QB";
            this.bQB.Name = "bQB";
            // 
            // sRB
            // 
            this.sRB.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.sRB.HeaderText = "Starting RB";
            this.sRB.Name = "sRB";
            // 
            // bRB
            // 
            this.bRB.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.bRB.HeaderText = "Backup RB";
            this.bRB.Name = "bRB";
            // 
            // sWR
            // 
            this.sWR.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.sWR.HeaderText = "Starting WR";
            this.sWR.Name = "sWR";
            // 
            // bWR
            // 
            this.bWR.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.bWR.HeaderText = "Backup WR";
            this.bWR.Name = "bWR";
            // 
            // txtTeamName
            // 
            this.txtTeamName.Font = new System.Drawing.Font("Rockwell", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTeamName.Location = new System.Drawing.Point(216, 38);
            this.txtTeamName.Name = "txtTeamName";
            this.txtTeamName.Size = new System.Drawing.Size(350, 36);
            this.txtTeamName.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Rockwell", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(58, 41);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(152, 27);
            this.label4.TabIndex = 9;
            this.label4.Text = "Team Name:";
            // 
            // AddTeams
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 561);
            this.Controls.Add(this.gbMain);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Rockwell", 12F);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "AddTeams";
            this.Text = "AddTeams";
            this.Load += new System.EventHandler(this.AddTeams_Load);
            this.gbMain.ResumeLayout(false);
            this.gbMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.playerHistoryGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox gbMain;
        private System.Windows.Forms.TextBox txtTeamName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView playerHistoryGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn Weeks;
        private System.Windows.Forms.DataGridViewTextBoxColumn sQB;
        private System.Windows.Forms.DataGridViewTextBoxColumn bQB;
        private System.Windows.Forms.DataGridViewTextBoxColumn sRB;
        private System.Windows.Forms.DataGridViewTextBoxColumn bRB;
        private System.Windows.Forms.DataGridViewTextBoxColumn sWR;
        private System.Windows.Forms.DataGridViewTextBoxColumn bWR;
        private System.Windows.Forms.Button btnAddTeam;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnRemove;
    }
}