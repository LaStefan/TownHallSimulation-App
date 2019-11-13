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
            this.button1.Location = new System.Drawing.Point(464, 122);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 28);
            this.button1.TabIndex = 0;
            this.button1.Text = "Start";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lbLog
            // 
            this.lbLog.FormattingEnabled = true;
            this.lbLog.ItemHeight = 16;
            this.lbLog.Location = new System.Drawing.Point(12, 241);
            this.lbLog.Name = "lbLog";
            this.lbLog.Size = new System.Drawing.Size(779, 148);
            this.lbLog.TabIndex = 1;
            // 
            // lBStatistics
            // 
            this.lBStatistics.FormattingEnabled = true;
            this.lBStatistics.ItemHeight = 16;
            this.lBStatistics.Location = new System.Drawing.Point(12, 12);
            this.lBStatistics.Name = "lBStatistics";
            this.lBStatistics.Size = new System.Drawing.Size(367, 180);
            this.lBStatistics.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(803, 492);
            this.Controls.Add(this.lBStatistics);
            this.Controls.Add(this.lbLog);
            this.Controls.Add(this.button1);
            this.Margin = new System.Windows.Forms.Padding(4);
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

