
namespace FantasyFootballManager
{
    partial class FindPlayer
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnSelPlayer = new System.Windows.Forms.Button();
            this.allPlayersGrid = new System.Windows.Forms.DataGridView();
            this.pName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cTeam = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.yearsInLeague = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtPlayerName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.allPlayersGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Rockwell", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(192, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(500, 46);
            this.label1.TabIndex = 2;
            this.label1.Text = "Fantasy Football Manager";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Controls.Add(this.btnSelPlayer);
            this.groupBox1.Controls.Add(this.allPlayersGrid);
            this.groupBox1.Controls.Add(this.txtPlayerName);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Font = new System.Drawing.Font("Rockwell", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 72);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(860, 477);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Find Player";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(630, 37);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(168, 42);
            this.btnSearch.TabIndex = 11;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnSelPlayer
            // 
            this.btnSelPlayer.Font = new System.Drawing.Font("Rockwell", 18F);
            this.btnSelPlayer.Location = new System.Drawing.Point(319, 419);
            this.btnSelPlayer.Name = "btnSelPlayer";
            this.btnSelPlayer.Size = new System.Drawing.Size(222, 48);
            this.btnSelPlayer.TabIndex = 12;
            this.btnSelPlayer.Text = "Select Player";
            this.btnSelPlayer.UseVisualStyleBackColor = true;
            this.btnSelPlayer.Click += new System.EventHandler(this.btnSelPlayer_Click);
            // 
            // allPlayersGrid
            // 
            this.allPlayersGrid.AllowUserToAddRows = false;
            this.allPlayersGrid.AllowUserToDeleteRows = false;
            this.allPlayersGrid.AllowUserToResizeColumns = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Rockwell", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.allPlayersGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.allPlayersGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.allPlayersGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.pName,
            this.cTeam,
            this.yearsInLeague});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Rockwell", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.allPlayersGrid.DefaultCellStyle = dataGridViewCellStyle2;
            this.allPlayersGrid.Location = new System.Drawing.Point(13, 87);
            this.allPlayersGrid.MultiSelect = false;
            this.allPlayersGrid.Name = "allPlayersGrid";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Rockwell", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.allPlayersGrid.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.allPlayersGrid.RowHeadersVisible = false;
            this.allPlayersGrid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.allPlayersGrid.RowTemplate.Height = 24;
            this.allPlayersGrid.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.allPlayersGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.allPlayersGrid.Size = new System.Drawing.Size(834, 323);
            this.allPlayersGrid.TabIndex = 11;
            // 
            // pName
            // 
            this.pName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.pName.HeaderText = "Player Name";
            this.pName.Name = "pName";
            this.pName.ReadOnly = true;
            // 
            // cTeam
            // 
            this.cTeam.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.cTeam.HeaderText = "Current Team";
            this.cTeam.Name = "cTeam";
            this.cTeam.ReadOnly = true;
            // 
            // yearsInLeague
            // 
            this.yearsInLeague.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.yearsInLeague.HeaderText = "Years In League";
            this.yearsInLeague.Name = "yearsInLeague";
            this.yearsInLeague.ReadOnly = true;
            // 
            // txtPlayerName
            // 
            this.txtPlayerName.Font = new System.Drawing.Font("Rockwell", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPlayerName.Location = new System.Drawing.Point(211, 38);
            this.txtPlayerName.Name = "txtPlayerName";
            this.txtPlayerName.Size = new System.Drawing.Size(350, 36);
            this.txtPlayerName.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Rockwell", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(53, 41);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(162, 27);
            this.label4.TabIndex = 9;
            this.label4.Text = "Player Name:";
            // 
            // FindPlayer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 561);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Rockwell", 12F);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FindPlayer";
            this.Text = "FindPlayer";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.allPlayersGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnSelPlayer;
        private System.Windows.Forms.DataGridView allPlayersGrid;
        private System.Windows.Forms.TextBox txtPlayerName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DataGridViewTextBoxColumn pName;
        private System.Windows.Forms.DataGridViewTextBoxColumn cTeam;
        private System.Windows.Forms.DataGridViewTextBoxColumn yearsInLeague;
    }
}