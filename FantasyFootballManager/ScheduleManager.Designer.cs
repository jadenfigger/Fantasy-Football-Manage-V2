
namespace FantasyFootballManager
{
    partial class ScheduleManager
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnFinSchedule = new System.Windows.Forms.Button();
            this.btnNextWeek = new System.Windows.Forms.Button();
            this.scheduleGrid = new System.Windows.Forms.DataGridView();
            this.opponentOne = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.vs = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.opponentTwo = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.btnViewLeague = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scheduleGrid)).BeginInit();
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
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.btnViewLeague);
            this.groupBox1.Font = new System.Drawing.Font("Rockwell", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 72);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(860, 477);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Schedule Manager";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnFinSchedule);
            this.groupBox2.Controls.Add(this.btnNextWeek);
            this.groupBox2.Controls.Add(this.scheduleGrid);
            this.groupBox2.Location = new System.Drawing.Point(14, 113);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(831, 350);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Week #";
            // 
            // btnFinSchedule
            // 
            this.btnFinSchedule.Location = new System.Drawing.Point(688, 195);
            this.btnFinSchedule.Name = "btnFinSchedule";
            this.btnFinSchedule.Size = new System.Drawing.Size(130, 134);
            this.btnFinSchedule.TabIndex = 14;
            this.btnFinSchedule.Text = "Finish Schedule";
            this.btnFinSchedule.UseVisualStyleBackColor = true;
            this.btnFinSchedule.Click += new System.EventHandler(this.btnFinSchedule_Click);
            // 
            // btnNextWeek
            // 
            this.btnNextWeek.Location = new System.Drawing.Point(688, 42);
            this.btnNextWeek.Name = "btnNextWeek";
            this.btnNextWeek.Size = new System.Drawing.Size(130, 134);
            this.btnNextWeek.TabIndex = 13;
            this.btnNextWeek.Text = "Next Week";
            this.btnNextWeek.UseVisualStyleBackColor = true;
            this.btnNextWeek.Visible = false;
            // 
            // scheduleGrid
            // 
            this.scheduleGrid.AllowUserToAddRows = false;
            this.scheduleGrid.AllowUserToDeleteRows = false;
            this.scheduleGrid.AllowUserToResizeColumns = false;
            this.scheduleGrid.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Rockwell", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.scheduleGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.scheduleGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.scheduleGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.opponentOne,
            this.vs,
            this.opponentTwo});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Rockwell", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.scheduleGrid.DefaultCellStyle = dataGridViewCellStyle2;
            this.scheduleGrid.Location = new System.Drawing.Point(16, 33);
            this.scheduleGrid.Name = "scheduleGrid";
            this.scheduleGrid.ReadOnly = true;
            this.scheduleGrid.RowHeadersVisible = false;
            this.scheduleGrid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.scheduleGrid.RowTemplate.Height = 24;
            this.scheduleGrid.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.scheduleGrid.Size = new System.Drawing.Size(659, 300);
            this.scheduleGrid.TabIndex = 12;
            // 
            // opponentOne
            // 
            this.opponentOne.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.opponentOne.HeaderText = "Opponent One";
            this.opponentOne.Name = "opponentOne";
            this.opponentOne.ReadOnly = true;
            // 
            // vs
            // 
            this.vs.HeaderText = "  vs";
            this.vs.Name = "vs";
            this.vs.ReadOnly = true;
            this.vs.Width = 101;
            // 
            // opponentTwo
            // 
            this.opponentTwo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.opponentTwo.HeaderText = "Opponent Two";
            this.opponentTwo.Name = "opponentTwo";
            this.opponentTwo.ReadOnly = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(414, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 27);
            this.label2.TabIndex = 7;
            this.label2.Text = "or";
            // 
            // btnViewLeague
            // 
            this.btnViewLeague.Font = new System.Drawing.Font("Rockwell", 16F);
            this.btnViewLeague.Location = new System.Drawing.Point(251, 35);
            this.btnViewLeague.Name = "btnViewLeague";
            this.btnViewLeague.Size = new System.Drawing.Size(358, 48);
            this.btnViewLeague.TabIndex = 6;
            this.btnViewLeague.Text = "Generate Random Schedule";
            this.btnViewLeague.UseVisualStyleBackColor = true;
            this.btnViewLeague.Click += new System.EventHandler(this.btnViewLeague_Click);
            // 
            // ScheduleManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 561);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "ScheduleManager";
            this.Text = "ScheduleManager";
            this.Load += new System.EventHandler(this.ScheduleManager_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scheduleGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnViewLeague;
        private System.Windows.Forms.DataGridView scheduleGrid;
        private System.Windows.Forms.Button btnFinSchedule;
        private System.Windows.Forms.Button btnNextWeek;
        private System.Windows.Forms.DataGridViewComboBoxColumn opponentOne;
        private System.Windows.Forms.DataGridViewTextBoxColumn vs;
        private System.Windows.Forms.DataGridViewComboBoxColumn opponentTwo;
    }
}