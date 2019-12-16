using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TownHallSimulation
{
    public partial class Form1 : Form
    {
       
        System.Drawing.Rectangle rect;
        private Simulator sim;
        public Form1()
        {
            InitializeComponent();
            sim = new Simulator(this);
            //sim.CreateOne(); // to test if it assigns to shortest queue
        }

        //Test if random creating objects works. Prints every Person in List and corresponding enum type.
        private void timer1_Tick(object sender, EventArgs e)
        {
            double tempTime = sim.Time % 1;
            switch (tempTime)
            {
                case 0.25:
                    lblTime.Text = String.Format("{0:0}:15", sim.Time);
                    break;
                case 0.50:
                    lblTime.Text = String.Format("{0:0}:30", sim.Time);
                    break;
                case 0.75:
                    lblTime.Text = String.Format("{0:0}:45", sim.Time);
                    break;
                default:
                    lblTime.Text = String.Format("{0:0}:00", sim.Time);
                    break;
            }
           
            sim.SpawnPeople();
            sim.AssignCounter(sim.GetTotalPeopleList());
            sim.UpdateLabels();
            lbTotalPeople.Text = sim.GetTotalPeopleList().Count.ToString() + " people";
           // temp = sim.GetListofSpawnedPeople();
            Invalidate();
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Counter6_Click(object sender, EventArgs e)
        {
            this.Enabled = true;
            this.BackColor = Color.DarkCyan;
        }

        private void RoundButton_Click(object sender, EventArgs e)
        {

        }

        private void RoundButton_Paint(object sender, PaintEventArgs e)
        {
            // Create pen.
            Pen blackPen = new Pen(Color.DarkCyan, 10);
            // Draw rectangle to screen.
            e.Graphics.DrawRectangle(blackPen, rect);
        }

        private void CircularButton1_Click(object sender, EventArgs e)
        {
            this.Enabled = true;
            this.BackColor = Color.DarkCyan; 
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            sim.Draw(e.Graphics);
        }

        private void BtnStart_Click(object sender, EventArgs e)
        {
            sim.Start();
            SpawnTimer.Enabled=true;
        }

        private void BtnStop_Click(object sender, EventArgs e)
        {
            sim.Stop();
        }

        private void circularButton9_Click(object sender, EventArgs e)
        {

        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            SpawnTimer.Stop();
        }

        private void btnResume_Click(object sender, EventArgs e)
        {
            SpawnTimer.Start();
        }

        private void btnStatistics_Click(object sender, EventArgs e)
        {
            sim.ShowStats();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
         
        }

        private void MovingTimer_Tick(object sender, EventArgs e)
        {   
            
        }
    }
}
