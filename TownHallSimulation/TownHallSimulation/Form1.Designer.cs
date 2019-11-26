﻿namespace TownHallSimulation
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
            this.components = new System.ComponentModel.Container();
            this.SpawnTimer = new System.Windows.Forms.Timer(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnExit = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnStatistics = new System.Windows.Forms.Button();
            this.btnResume = new System.Windows.Forms.Button();
            this.btnPause = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.roundButton = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.lblCounter7 = new System.Windows.Forms.Label();
            this.MovingTimer = new System.Windows.Forms.Timer(this.components);
            this.lblCounter8 = new System.Windows.Forms.Label();
            this.lblCounter9 = new System.Windows.Forms.Label();
            this.lblCounter10 = new System.Windows.Forms.Label();
            this.lblCounter1 = new System.Windows.Forms.Label();
            this.lblCounter2 = new System.Windows.Forms.Label();
            this.lblCounter3 = new System.Windows.Forms.Label();
            this.lblCounter4 = new System.Windows.Forms.Label();
            this.lblCounter5 = new System.Windows.Forms.Label();
            this.lblCounter6 = new System.Windows.Forms.Label();
            this.btnCounter7 = new TownHallSimulation.CircularButton();
            this.btnCounter6 = new TownHallSimulation.CircularButton();
            this.btnCounter8 = new TownHallSimulation.CircularButton();
            this.btnCounter9 = new TownHallSimulation.CircularButton();
            this.btnCounter10 = new TownHallSimulation.CircularButton();
            this.btnCounter5 = new TownHallSimulation.CircularButton();
            this.btnCounter4 = new TownHallSimulation.CircularButton();
            this.btnCounter3 = new TownHallSimulation.CircularButton();
            this.btnCounter2 = new TownHallSimulation.CircularButton();
            this.btnCounter1 = new TownHallSimulation.CircularButton();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // SpawnTimer
            // 
            this.SpawnTimer.Interval = 3000;
            this.SpawnTimer.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.btnExit);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(977, 50);
            this.panel1.TabIndex = 3;
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.DarkCyan;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.ForeColor = System.Drawing.Color.White;
            this.btnExit.Location = new System.Drawing.Point(929, 3);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(41, 36);
            this.btnExit.TabIndex = 2;
            this.btnExit.Text = "x";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.BtnExit_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DarkCyan;
            this.label1.Location = new System.Drawing.Point(252, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(348, 36);
            this.label1.TabIndex = 1;
            this.label1.Text = "TOWN HALL SIMULATION";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::TownHallSimulation.Properties.Resources.Screenshot3;
            this.pictureBox1.Location = new System.Drawing.Point(-2, -2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(130, 50);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.DarkCyan;
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.panel2.Controls.Add(this.btnStatistics);
            this.panel2.Controls.Add(this.btnResume);
            this.panel2.Controls.Add(this.btnPause);
            this.panel2.Controls.Add(this.btnStop);
            this.panel2.Controls.Add(this.btnStart);
            this.panel2.Location = new System.Drawing.Point(28, 54);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(101, 363);
            this.panel2.TabIndex = 20;
            // 
            // btnStatistics
            // 
            this.btnStatistics.BackColor = System.Drawing.Color.White;
            this.btnStatistics.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStatistics.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStatistics.ForeColor = System.Drawing.Color.DarkCyan;
            this.btnStatistics.Location = new System.Drawing.Point(7, 300);
            this.btnStatistics.Name = "btnStatistics";
            this.btnStatistics.Size = new System.Drawing.Size(99, 66);
            this.btnStatistics.TabIndex = 21;
            this.btnStatistics.Text = "Statistics";
            this.btnStatistics.UseVisualStyleBackColor = false;
            this.btnStatistics.Click += new System.EventHandler(this.btnStatistics_Click);
            // 
            // btnResume
            // 
            this.btnResume.BackColor = System.Drawing.Color.White;
            this.btnResume.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnResume.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnResume.ForeColor = System.Drawing.Color.DarkCyan;
            this.btnResume.Location = new System.Drawing.Point(7, 228);
            this.btnResume.Name = "btnResume";
            this.btnResume.Size = new System.Drawing.Size(97, 66);
            this.btnResume.TabIndex = 6;
            this.btnResume.Text = "Resume";
            this.btnResume.UseVisualStyleBackColor = false;
            this.btnResume.Click += new System.EventHandler(this.btnResume_Click);
            // 
            // btnPause
            // 
            this.btnPause.BackColor = System.Drawing.Color.White;
            this.btnPause.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPause.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPause.ForeColor = System.Drawing.Color.DarkCyan;
            this.btnPause.Location = new System.Drawing.Point(7, 156);
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(97, 66);
            this.btnPause.TabIndex = 5;
            this.btnPause.Text = "Pause";
            this.btnPause.UseVisualStyleBackColor = false;
            this.btnPause.Click += new System.EventHandler(this.btnPause_Click);
            // 
            // btnStop
            // 
            this.btnStop.BackColor = System.Drawing.Color.White;
            this.btnStop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStop.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStop.ForeColor = System.Drawing.Color.DarkCyan;
            this.btnStop.Location = new System.Drawing.Point(7, 84);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(97, 66);
            this.btnStop.TabIndex = 4;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = false;
            this.btnStop.Click += new System.EventHandler(this.BtnStop_Click);
            // 
            // btnStart
            // 
            this.btnStart.BackColor = System.Drawing.Color.White;
            this.btnStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStart.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStart.ForeColor = System.Drawing.Color.DarkCyan;
            this.btnStart.Location = new System.Drawing.Point(7, 12);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(97, 66);
            this.btnStart.TabIndex = 3;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = false;
            this.btnStart.Click += new System.EventHandler(this.BtnStart_Click);
            // 
            // roundButton
            // 
            this.roundButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.roundButton.Location = new System.Drawing.Point(483, 354);
            this.roundButton.Name = "roundButton";
            this.roundButton.Size = new System.Drawing.Size(151, 21);
            this.roundButton.TabIndex = 21;
            this.roundButton.UseVisualStyleBackColor = true;
            this.roundButton.Click += new System.EventHandler(this.RoundButton_Click);
            this.roundButton.Paint += new System.Windows.Forms.PaintEventHandler(this.RoundButton_Paint);
            // 
            // lblCounter7
            // 
            this.lblCounter7.AutoSize = true;
            this.lblCounter7.Location = new System.Drawing.Point(897, 282);
            this.lblCounter7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCounter7.Name = "lblCounter7";
            this.lblCounter7.Size = new System.Drawing.Size(60, 13);
            this.lblCounter7.TabIndex = 22;
            this.lblCounter7.Text = "lblCounter7";
            // 
            // MovingTimer
            // 
            this.MovingTimer.Tick += new System.EventHandler(this.MovingTimer_Tick);
            // 
            // lblCounter8
            // 
            this.lblCounter8.AutoSize = true;
            this.lblCounter8.Location = new System.Drawing.Point(897, 372);
            this.lblCounter8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCounter8.Name = "lblCounter8";
            this.lblCounter8.Size = new System.Drawing.Size(60, 13);
            this.lblCounter8.TabIndex = 23;
            this.lblCounter8.Text = "lblCounter8";
            // 
            // lblCounter9
            // 
            this.lblCounter9.AutoSize = true;
            this.lblCounter9.Location = new System.Drawing.Point(257, 384);
            this.lblCounter9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCounter9.Name = "lblCounter9";
            this.lblCounter9.Size = new System.Drawing.Size(60, 13);
            this.lblCounter9.TabIndex = 24;
            this.lblCounter9.Text = "lblCounter9";
            // 
            // lblCounter10
            // 
            this.lblCounter10.AutoSize = true;
            this.lblCounter10.Location = new System.Drawing.Point(257, 301);
            this.lblCounter10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCounter10.Name = "lblCounter10";
            this.lblCounter10.Size = new System.Drawing.Size(66, 13);
            this.lblCounter10.TabIndex = 25;
            this.lblCounter10.Text = "lblCounter10";
            // 
            // lblCounter1
            // 
            this.lblCounter1.AutoSize = true;
            this.lblCounter1.Location = new System.Drawing.Point(257, 210);
            this.lblCounter1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCounter1.Name = "lblCounter1";
            this.lblCounter1.Size = new System.Drawing.Size(60, 13);
            this.lblCounter1.TabIndex = 26;
            this.lblCounter1.Text = "lblCounter1";
            // 
            // lblCounter2
            // 
            this.lblCounter2.AutoSize = true;
            this.lblCounter2.Location = new System.Drawing.Point(257, 66);
            this.lblCounter2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCounter2.Name = "lblCounter2";
            this.lblCounter2.Size = new System.Drawing.Size(60, 13);
            this.lblCounter2.TabIndex = 27;
            this.lblCounter2.Text = "lblCounter2";
            // 
            // lblCounter3
            // 
            this.lblCounter3.AutoSize = true;
            this.lblCounter3.Location = new System.Drawing.Point(419, 59);
            this.lblCounter3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCounter3.Name = "lblCounter3";
            this.lblCounter3.Size = new System.Drawing.Size(60, 13);
            this.lblCounter3.TabIndex = 28;
            this.lblCounter3.Text = "lblCounter3";
            // 
            // lblCounter4
            // 
            this.lblCounter4.AutoSize = true;
            this.lblCounter4.Location = new System.Drawing.Point(556, 59);
            this.lblCounter4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCounter4.Name = "lblCounter4";
            this.lblCounter4.Size = new System.Drawing.Size(60, 13);
            this.lblCounter4.TabIndex = 29;
            this.lblCounter4.Text = "lblCounter4";
            // 
            // lblCounter5
            // 
            this.lblCounter5.AutoSize = true;
            this.lblCounter5.Location = new System.Drawing.Point(792, 59);
            this.lblCounter5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCounter5.Name = "lblCounter5";
            this.lblCounter5.Size = new System.Drawing.Size(60, 13);
            this.lblCounter5.TabIndex = 30;
            this.lblCounter5.Text = "lblCounter5";
            // 
            // lblCounter6
            // 
            this.lblCounter6.AutoSize = true;
            this.lblCounter6.Location = new System.Drawing.Point(888, 210);
            this.lblCounter6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCounter6.Name = "lblCounter6";
            this.lblCounter6.Size = new System.Drawing.Size(60, 13);
            this.lblCounter6.TabIndex = 31;
            this.lblCounter6.Text = "lblCounter6";
            // 
            // btnCounter7
            // 
            this.btnCounter7.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btnCounter7.Enabled = false;
            this.btnCounter7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCounter7.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCounter7.ForeColor = System.Drawing.Color.White;
            this.btnCounter7.Location = new System.Drawing.Point(827, 238);
            this.btnCounter7.Name = "btnCounter7";
            this.btnCounter7.Size = new System.Drawing.Size(75, 57);
            this.btnCounter7.TabIndex = 19;
            this.btnCounter7.Text = "Counter 7";
            this.btnCounter7.UseVisualStyleBackColor = false;
            this.btnCounter7.Click += new System.EventHandler(this.CircularButton1_Click);
            // 
            // btnCounter6
            // 
            this.btnCounter6.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btnCounter6.Enabled = false;
            this.btnCounter6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCounter6.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCounter6.ForeColor = System.Drawing.Color.White;
            this.btnCounter6.Location = new System.Drawing.Point(827, 152);
            this.btnCounter6.Name = "btnCounter6";
            this.btnCounter6.Size = new System.Drawing.Size(75, 57);
            this.btnCounter6.TabIndex = 18;
            this.btnCounter6.Text = "Counter 6";
            this.btnCounter6.UseVisualStyleBackColor = false;
            // 
            // btnCounter8
            // 
            this.btnCounter8.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btnCounter8.Enabled = false;
            this.btnCounter8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCounter8.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCounter8.ForeColor = System.Drawing.Color.White;
            this.btnCounter8.Location = new System.Drawing.Point(827, 328);
            this.btnCounter8.Name = "btnCounter8";
            this.btnCounter8.Size = new System.Drawing.Size(75, 57);
            this.btnCounter8.TabIndex = 17;
            this.btnCounter8.Text = "Counter 8";
            this.btnCounter8.UseVisualStyleBackColor = false;
            // 
            // btnCounter9
            // 
            this.btnCounter9.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btnCounter9.Enabled = false;
            this.btnCounter9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCounter9.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCounter9.ForeColor = System.Drawing.Color.White;
            this.btnCounter9.Location = new System.Drawing.Point(195, 328);
            this.btnCounter9.Name = "btnCounter9";
            this.btnCounter9.Size = new System.Drawing.Size(75, 57);
            this.btnCounter9.TabIndex = 16;
            this.btnCounter9.Text = "Counter 9";
            this.btnCounter9.UseVisualStyleBackColor = false;
            // 
            // btnCounter10
            // 
            this.btnCounter10.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btnCounter10.Enabled = false;
            this.btnCounter10.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCounter10.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCounter10.ForeColor = System.Drawing.Color.White;
            this.btnCounter10.Location = new System.Drawing.Point(195, 241);
            this.btnCounter10.Name = "btnCounter10";
            this.btnCounter10.Size = new System.Drawing.Size(75, 57);
            this.btnCounter10.TabIndex = 15;
            this.btnCounter10.Text = "Counter 10";
            this.btnCounter10.UseVisualStyleBackColor = false;
            // 
            // btnCounter5
            // 
            this.btnCounter5.BackColor = System.Drawing.Color.DarkCyan;
            this.btnCounter5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCounter5.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCounter5.ForeColor = System.Drawing.Color.White;
            this.btnCounter5.Location = new System.Drawing.Point(728, 75);
            this.btnCounter5.Name = "btnCounter5";
            this.btnCounter5.Size = new System.Drawing.Size(75, 57);
            this.btnCounter5.TabIndex = 14;
            this.btnCounter5.Text = "Counter 5";
            this.btnCounter5.UseVisualStyleBackColor = false;
            // 
            // btnCounter4
            // 
            this.btnCounter4.BackColor = System.Drawing.Color.DarkCyan;
            this.btnCounter4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCounter4.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCounter4.ForeColor = System.Drawing.Color.White;
            this.btnCounter4.Location = new System.Drawing.Point(602, 75);
            this.btnCounter4.Name = "btnCounter4";
            this.btnCounter4.Size = new System.Drawing.Size(75, 57);
            this.btnCounter4.TabIndex = 13;
            this.btnCounter4.Text = "Counter 4";
            this.btnCounter4.UseVisualStyleBackColor = false;
            // 
            // btnCounter3
            // 
            this.btnCounter3.BackColor = System.Drawing.Color.DarkCyan;
            this.btnCounter3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCounter3.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCounter3.ForeColor = System.Drawing.Color.White;
            this.btnCounter3.Location = new System.Drawing.Point(465, 75);
            this.btnCounter3.Name = "btnCounter3";
            this.btnCounter3.Size = new System.Drawing.Size(75, 57);
            this.btnCounter3.TabIndex = 12;
            this.btnCounter3.Text = "Counter 3";
            this.btnCounter3.UseVisualStyleBackColor = false;
            // 
            // btnCounter2
            // 
            this.btnCounter2.BackColor = System.Drawing.Color.DarkCyan;
            this.btnCounter2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCounter2.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCounter2.ForeColor = System.Drawing.Color.White;
            this.btnCounter2.Location = new System.Drawing.Point(310, 75);
            this.btnCounter2.Name = "btnCounter2";
            this.btnCounter2.Size = new System.Drawing.Size(75, 57);
            this.btnCounter2.TabIndex = 11;
            this.btnCounter2.Text = "Counter 2";
            this.btnCounter2.UseVisualStyleBackColor = false;
            this.btnCounter2.Click += new System.EventHandler(this.circularButton9_Click);
            // 
            // btnCounter1
            // 
            this.btnCounter1.BackColor = System.Drawing.Color.DarkCyan;
            this.btnCounter1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCounter1.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCounter1.ForeColor = System.Drawing.Color.White;
            this.btnCounter1.Location = new System.Drawing.Point(195, 152);
            this.btnCounter1.Name = "btnCounter1";
            this.btnCounter1.Size = new System.Drawing.Size(75, 57);
            this.btnCounter1.TabIndex = 10;
            this.btnCounter1.Text = "Counter 1";
            this.btnCounter1.UseVisualStyleBackColor = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(977, 485);
            this.Controls.Add(this.lblCounter6);
            this.Controls.Add(this.lblCounter5);
            this.Controls.Add(this.lblCounter4);
            this.Controls.Add(this.lblCounter3);
            this.Controls.Add(this.lblCounter2);
            this.Controls.Add(this.lblCounter1);
            this.Controls.Add(this.lblCounter10);
            this.Controls.Add(this.lblCounter9);
            this.Controls.Add(this.lblCounter8);
            this.Controls.Add(this.lblCounter7);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.btnCounter7);
            this.Controls.Add(this.btnCounter6);
            this.Controls.Add(this.btnCounter8);
            this.Controls.Add(this.btnCounter9);
            this.Controls.Add(this.btnCounter10);
            this.Controls.Add(this.btnCounter5);
            this.Controls.Add(this.btnCounter4);
            this.Controls.Add(this.btnCounter3);
            this.Controls.Add(this.btnCounter2);
            this.Controls.Add(this.btnCounter1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.roundButton);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer SpawnTimer;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private CircularButton btnCounter7;
        private CircularButton btnCounter6;
        private CircularButton btnCounter8;
        private CircularButton btnCounter9;
        private CircularButton btnCounter10;
        private CircularButton btnCounter5;
        private CircularButton btnCounter4;
        private CircularButton btnCounter3;
        private CircularButton btnCounter2;
        private CircularButton btnCounter1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnResume;
        private System.Windows.Forms.Button btnPause;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button roundButton;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button btnStatistics;
        private System.Windows.Forms.Label lblCounter7;
        private System.Windows.Forms.Timer MovingTimer;
        private System.Windows.Forms.Label lblCounter8;
        private System.Windows.Forms.Label lblCounter9;
        private System.Windows.Forms.Label lblCounter10;
        private System.Windows.Forms.Label lblCounter1;
        private System.Windows.Forms.Label lblCounter2;
        private System.Windows.Forms.Label lblCounter3;
        private System.Windows.Forms.Label lblCounter4;
        private System.Windows.Forms.Label lblCounter5;
        private System.Windows.Forms.Label lblCounter6;
    }
}

