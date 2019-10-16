namespace TownHallSimulation
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
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
            this.circularButton1 = new TownHallSimulation.CircularButton();
            this.circularButton2 = new TownHallSimulation.CircularButton();
            this.circularButton3 = new TownHallSimulation.CircularButton();
            this.circularButton4 = new TownHallSimulation.CircularButton();
            this.circularButton5 = new TownHallSimulation.CircularButton();
            this.circularButton6 = new TownHallSimulation.CircularButton();
            this.circularButton7 = new TownHallSimulation.CircularButton();
            this.circularButton8 = new TownHallSimulation.CircularButton();
            this.circularButton9 = new TownHallSimulation.CircularButton();
            this.circularButton10 = new TownHallSimulation.CircularButton();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // SpawnTimer
            // 
            this.SpawnTimer.Enabled = true;
            this.SpawnTimer.Interval = 5000;
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
            this.panel1.Size = new System.Drawing.Size(843, 50);
            this.panel1.TabIndex = 3;
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.DarkCyan;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.ForeColor = System.Drawing.Color.White;
            this.btnExit.Location = new System.Drawing.Point(796, 7);
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
            this.panel2.Size = new System.Drawing.Size(97, 374);
            this.panel2.TabIndex = 20;
            // 
            // btnStatistics
            // 
            this.btnStatistics.BackColor = System.Drawing.Color.White;
            this.btnStatistics.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStatistics.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStatistics.ForeColor = System.Drawing.Color.DarkCyan;
            this.btnStatistics.Location = new System.Drawing.Point(3, 309);
            this.btnStatistics.Name = "btnStatistics";
            this.btnStatistics.Size = new System.Drawing.Size(99, 66);
            this.btnStatistics.TabIndex = 21;
            this.btnStatistics.Text = "Statistics";
            this.btnStatistics.UseVisualStyleBackColor = false;
            // 
            // btnResume
            // 
            this.btnResume.BackColor = System.Drawing.Color.White;
            this.btnResume.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnResume.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnResume.ForeColor = System.Drawing.Color.DarkCyan;
            this.btnResume.Location = new System.Drawing.Point(3, 237);
            this.btnResume.Name = "btnResume";
            this.btnResume.Size = new System.Drawing.Size(97, 66);
            this.btnResume.TabIndex = 6;
            this.btnResume.Text = "Resume";
            this.btnResume.UseVisualStyleBackColor = false;
            // 
            // btnPause
            // 
            this.btnPause.BackColor = System.Drawing.Color.White;
            this.btnPause.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPause.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPause.ForeColor = System.Drawing.Color.DarkCyan;
            this.btnPause.Location = new System.Drawing.Point(3, 165);
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(97, 66);
            this.btnPause.TabIndex = 5;
            this.btnPause.Text = "Pause";
            this.btnPause.UseVisualStyleBackColor = false;
            // 
            // btnStop
            // 
            this.btnStop.BackColor = System.Drawing.Color.White;
            this.btnStop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStop.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStop.ForeColor = System.Drawing.Color.DarkCyan;
            this.btnStop.Location = new System.Drawing.Point(3, 93);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(97, 66);
            this.btnStop.TabIndex = 4;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = false;
            // 
            // btnStart
            // 
            this.btnStart.BackColor = System.Drawing.Color.White;
            this.btnStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStart.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStart.ForeColor = System.Drawing.Color.DarkCyan;
            this.btnStart.Location = new System.Drawing.Point(3, 21);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(97, 66);
            this.btnStart.TabIndex = 3;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = false;
            // 
            // roundButton
            // 
            this.roundButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.roundButton.Location = new System.Drawing.Point(410, 236);
            this.roundButton.Name = "roundButton";
            this.roundButton.Size = new System.Drawing.Size(151, 21);
            this.roundButton.TabIndex = 21;
            this.roundButton.UseVisualStyleBackColor = true;
            this.roundButton.Click += new System.EventHandler(this.RoundButton_Click);
            this.roundButton.Paint += new System.Windows.Forms.PaintEventHandler(this.RoundButton_Paint);
            // 
            // circularButton1
            // 
            this.circularButton1.BackColor = System.Drawing.Color.DarkSlateGray;
            this.circularButton1.Enabled = false;
            this.circularButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.circularButton1.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.circularButton1.ForeColor = System.Drawing.Color.White;
            this.circularButton1.Location = new System.Drawing.Point(681, 163);
            this.circularButton1.Name = "circularButton1";
            this.circularButton1.Size = new System.Drawing.Size(79, 57);
            this.circularButton1.TabIndex = 19;
            this.circularButton1.Text = "circularButton1";
            this.circularButton1.UseVisualStyleBackColor = false;
            this.circularButton1.Click += new System.EventHandler(this.CircularButton1_Click);
            // 
            // circularButton2
            // 
            this.circularButton2.BackColor = System.Drawing.Color.DarkCyan;
            this.circularButton2.Enabled = false;
            this.circularButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.circularButton2.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.circularButton2.ForeColor = System.Drawing.Color.White;
            this.circularButton2.Location = new System.Drawing.Point(681, 75);
            this.circularButton2.Name = "circularButton2";
            this.circularButton2.Size = new System.Drawing.Size(75, 57);
            this.circularButton2.TabIndex = 18;
            this.circularButton2.Text = "circularButton2";
            this.circularButton2.UseVisualStyleBackColor = false;
            // 
            // circularButton3
            // 
            this.circularButton3.BackColor = System.Drawing.Color.DarkSlateGray;
            this.circularButton3.Enabled = false;
            this.circularButton3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.circularButton3.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.circularButton3.ForeColor = System.Drawing.Color.White;
            this.circularButton3.Location = new System.Drawing.Point(681, 276);
            this.circularButton3.Name = "circularButton3";
            this.circularButton3.Size = new System.Drawing.Size(75, 57);
            this.circularButton3.TabIndex = 17;
            this.circularButton3.Text = "circularButton3";
            this.circularButton3.UseVisualStyleBackColor = false;
            // 
            // circularButton4
            // 
            this.circularButton4.BackColor = System.Drawing.Color.DarkSlateGray;
            this.circularButton4.Enabled = false;
            this.circularButton4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.circularButton4.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.circularButton4.ForeColor = System.Drawing.Color.White;
            this.circularButton4.Location = new System.Drawing.Point(202, 276);
            this.circularButton4.Name = "circularButton4";
            this.circularButton4.Size = new System.Drawing.Size(75, 57);
            this.circularButton4.TabIndex = 16;
            this.circularButton4.Text = "circularButton4";
            this.circularButton4.UseVisualStyleBackColor = false;
            // 
            // circularButton5
            // 
            this.circularButton5.BackColor = System.Drawing.Color.DarkSlateGray;
            this.circularButton5.Enabled = false;
            this.circularButton5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.circularButton5.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.circularButton5.ForeColor = System.Drawing.Color.White;
            this.circularButton5.Location = new System.Drawing.Point(202, 173);
            this.circularButton5.Name = "circularButton5";
            this.circularButton5.Size = new System.Drawing.Size(75, 57);
            this.circularButton5.TabIndex = 15;
            this.circularButton5.Text = "circularButton5";
            this.circularButton5.UseVisualStyleBackColor = false;
            // 
            // circularButton6
            // 
            this.circularButton6.BackColor = System.Drawing.Color.DarkCyan;
            this.circularButton6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.circularButton6.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.circularButton6.ForeColor = System.Drawing.Color.White;
            this.circularButton6.Location = new System.Drawing.Point(590, 75);
            this.circularButton6.Name = "circularButton6";
            this.circularButton6.Size = new System.Drawing.Size(75, 57);
            this.circularButton6.TabIndex = 14;
            this.circularButton6.Text = "circularButton6";
            this.circularButton6.UseVisualStyleBackColor = false;
            // 
            // circularButton7
            // 
            this.circularButton7.BackColor = System.Drawing.Color.DarkCyan;
            this.circularButton7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.circularButton7.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.circularButton7.ForeColor = System.Drawing.Color.White;
            this.circularButton7.Location = new System.Drawing.Point(496, 75);
            this.circularButton7.Name = "circularButton7";
            this.circularButton7.Size = new System.Drawing.Size(75, 57);
            this.circularButton7.TabIndex = 13;
            this.circularButton7.Text = "circularButton7";
            this.circularButton7.UseVisualStyleBackColor = false;
            // 
            // circularButton8
            // 
            this.circularButton8.BackColor = System.Drawing.Color.DarkCyan;
            this.circularButton8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.circularButton8.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.circularButton8.ForeColor = System.Drawing.Color.White;
            this.circularButton8.Location = new System.Drawing.Point(399, 75);
            this.circularButton8.Name = "circularButton8";
            this.circularButton8.Size = new System.Drawing.Size(75, 57);
            this.circularButton8.TabIndex = 12;
            this.circularButton8.Text = "circularButton8";
            this.circularButton8.UseVisualStyleBackColor = false;
            // 
            // circularButton9
            // 
            this.circularButton9.BackColor = System.Drawing.Color.DarkCyan;
            this.circularButton9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.circularButton9.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.circularButton9.ForeColor = System.Drawing.Color.White;
            this.circularButton9.Location = new System.Drawing.Point(303, 75);
            this.circularButton9.Name = "circularButton9";
            this.circularButton9.Size = new System.Drawing.Size(75, 57);
            this.circularButton9.TabIndex = 11;
            this.circularButton9.Text = "circularButton9";
            this.circularButton9.UseVisualStyleBackColor = false;
            // 
            // circularButton10
            // 
            this.circularButton10.BackColor = System.Drawing.Color.DarkCyan;
            this.circularButton10.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.circularButton10.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.circularButton10.ForeColor = System.Drawing.Color.White;
            this.circularButton10.Location = new System.Drawing.Point(202, 75);
            this.circularButton10.Name = "circularButton10";
            this.circularButton10.Size = new System.Drawing.Size(75, 57);
            this.circularButton10.TabIndex = 10;
            this.circularButton10.Text = "circularButton10";
            this.circularButton10.UseVisualStyleBackColor = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(462, 375);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(32, 30);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 22;
            this.pictureBox2.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(843, 439);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.roundButton);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.circularButton1);
            this.Controls.Add(this.circularButton2);
            this.Controls.Add(this.circularButton3);
            this.Controls.Add(this.circularButton4);
            this.Controls.Add(this.circularButton5);
            this.Controls.Add(this.circularButton6);
            this.Controls.Add(this.circularButton7);
            this.Controls.Add(this.circularButton8);
            this.Controls.Add(this.circularButton9);
            this.Controls.Add(this.circularButton10);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer SpawnTimer;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private CircularButton circularButton1;
        private CircularButton circularButton2;
        private CircularButton circularButton3;
        private CircularButton circularButton4;
        private CircularButton circularButton5;
        private CircularButton circularButton6;
        private CircularButton circularButton7;
        private CircularButton circularButton8;
        private CircularButton circularButton9;
        private CircularButton circularButton10;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnResume;
        private System.Windows.Forms.Button btnPause;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnStatistics;
        private System.Windows.Forms.Button roundButton;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}

