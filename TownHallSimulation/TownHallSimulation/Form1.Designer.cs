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
            this.SpawnTimer = new System.Windows.Forms.Timer(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.lbLog = new System.Windows.Forms.ListBox();
            this.lBStatistics = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // SpawnTimer
            // 
            this.SpawnTimer.Interval = 5000;
            this.SpawnTimer.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(348, 99);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Start";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lbLog
            // 
            this.lbLog.FormattingEnabled = true;
            this.lbLog.Location = new System.Drawing.Point(9, 196);
            this.lbLog.Margin = new System.Windows.Forms.Padding(2);
            this.lbLog.Name = "lbLog";
            this.lbLog.Size = new System.Drawing.Size(585, 121);
            this.lbLog.TabIndex = 1;
            // 
            // lBStatistics
            // 
            this.lBStatistics.FormattingEnabled = true;
            this.lBStatistics.Location = new System.Drawing.Point(9, 10);
            this.lBStatistics.Margin = new System.Windows.Forms.Padding(2);
            this.lBStatistics.Name = "lBStatistics";
            this.lBStatistics.Size = new System.Drawing.Size(276, 147);
            this.lBStatistics.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(602, 400);
            this.Controls.Add(this.lBStatistics);
            this.Controls.Add(this.lbLog);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer SpawnTimer;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListBox lBStatistics;
        public System.Windows.Forms.ListBox lbLog;
    }
}

