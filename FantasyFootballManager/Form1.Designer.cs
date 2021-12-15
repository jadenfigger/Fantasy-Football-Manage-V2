
namespace FantasyFootballManager
{
    partial class Form1
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
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnCreateLeague = new System.Windows.Forms.Button();
            this.sEndWeek = new System.Windows.Forms.TrackBar();
            this.sStartWeek = new System.Windows.Forms.TrackBar();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtNumOfTeams = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtLName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnViewLeague = new System.Windows.Forms.Button();
            this.lbAllLeagues = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sEndWeek)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sStartWeek)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Rockwell", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(192, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(500, 46);
            this.label1.TabIndex = 0;
            this.label1.Text = "Fantasy Football Manager";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.btnCreateLeague);
            this.groupBox1.Controls.Add(this.sEndWeek);
            this.groupBox1.Controls.Add(this.sStartWeek);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtNumOfTeams);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtLName);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(448, 58);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(424, 491);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // btnCreateLeague
            // 
            this.btnCreateLeague.Font = new System.Drawing.Font("Rockwell", 16F);
            this.btnCreateLeague.Location = new System.Drawing.Point(101, 429);
            this.btnCreateLeague.Name = "btnCreateLeague";
            this.btnCreateLeague.Size = new System.Drawing.Size(222, 48);
            this.btnCreateLeague.TabIndex = 6;
            this.btnCreateLeague.Text = "Create League";
            this.btnCreateLeague.UseVisualStyleBackColor = true;
            this.btnCreateLeague.Click += new System.EventHandler(this.btnCreateLeague_Click);
            // 
            // sEndWeek
            // 
            this.sEndWeek.Location = new System.Drawing.Point(167, 321);
            this.sEndWeek.Maximum = 17;
            this.sEndWeek.Minimum = 2;
            this.sEndWeek.Name = "sEndWeek";
            this.sEndWeek.Size = new System.Drawing.Size(244, 45);
            this.sEndWeek.TabIndex = 16;
            this.sEndWeek.Value = 13;
            // 
            // sStartWeek
            // 
            this.sStartWeek.Location = new System.Drawing.Point(167, 253);
            this.sStartWeek.Maximum = 16;
            this.sStartWeek.Minimum = 1;
            this.sStartWeek.Name = "sStartWeek";
            this.sStartWeek.Size = new System.Drawing.Size(244, 45);
            this.sStartWeek.TabIndex = 15;
            this.sStartWeek.Value = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Rockwell", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(13, 321);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(116, 23);
            this.label7.TabIndex = 13;
            this.label7.Text = "End Week:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Rockwell", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(13, 253);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(121, 23);
            this.label6.TabIndex = 11;
            this.label6.Text = "Start Week:";
            // 
            // txtNumOfTeams
            // 
            this.txtNumOfTeams.Font = new System.Drawing.Font("Rockwell", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNumOfTeams.Location = new System.Drawing.Point(167, 185);
            this.txtNumOfTeams.Name = "txtNumOfTeams";
            this.txtNumOfTeams.Size = new System.Drawing.Size(244, 32);
            this.txtNumOfTeams.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Rockwell", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(13, 188);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(162, 23);
            this.label5.TabIndex = 9;
            this.label5.Text = "Num Of Teams: ";
            // 
            // txtLName
            // 
            this.txtLName.Font = new System.Drawing.Font("Rockwell", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLName.Location = new System.Drawing.Point(167, 124);
            this.txtLName.Name = "txtLName";
            this.txtLName.Size = new System.Drawing.Size(244, 32);
            this.txtLName.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Rockwell", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(13, 127);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(148, 23);
            this.label4.TabIndex = 7;
            this.label4.Text = "League Name:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Rockwell", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(64, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(296, 36);
            this.label3.TabIndex = 6;
            this.label3.Text = "Create New League";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnViewLeague);
            this.groupBox2.Controls.Add(this.lbAllLeagues);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(12, 58);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(430, 491);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            // 
            // btnViewLeague
            // 
            this.btnViewLeague.Font = new System.Drawing.Font("Rockwell", 16F);
            this.btnViewLeague.Location = new System.Drawing.Point(104, 429);
            this.btnViewLeague.Name = "btnViewLeague";
            this.btnViewLeague.Size = new System.Drawing.Size(222, 48);
            this.btnViewLeague.TabIndex = 5;
            this.btnViewLeague.Text = "View League";
            this.btnViewLeague.UseVisualStyleBackColor = true;
            // 
            // lbAllLeagues
            // 
            this.lbAllLeagues.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.lbAllLeagues.Font = new System.Drawing.Font("Rockwell", 16F, System.Drawing.FontStyle.Bold);
            this.lbAllLeagues.FormattingEnabled = true;
            this.lbAllLeagues.ItemHeight = 19;
            this.lbAllLeagues.Location = new System.Drawing.Point(16, 71);
            this.lbAllLeagues.Name = "lbAllLeagues";
            this.lbAllLeagues.Size = new System.Drawing.Size(396, 327);
            this.lbAllLeagues.TabIndex = 4;
            this.lbAllLeagues.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.lbAllLeagues_DrawItem);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Rockwell", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(105, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(213, 36);
            this.label2.TabIndex = 3;
            this.label2.Text = "Select League";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Rockwell", 10F);
            this.label8.Location = new System.Drawing.Point(38, 211);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(105, 17);
            this.label8.TabIndex = 17;
            this.label8.Text = "(Must be even)";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 561);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sEndWeek)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sStartWeek)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnViewLeague;
        private System.Windows.Forms.ListBox lbAllLeagues;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnCreateLeague;
        private System.Windows.Forms.TrackBar sEndWeek;
        private System.Windows.Forms.TrackBar sStartWeek;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtNumOfTeams;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtLName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label8;
    }
}

