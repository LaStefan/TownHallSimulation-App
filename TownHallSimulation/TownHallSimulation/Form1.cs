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
        System.Drawing.Image image;
        System.Drawing.Rectangle rect;
        private bool visitedCenter;
        private Simulator sim;
        public Form1()
        {
            InitializeComponent();
            image = TownHallSimulation.Properties.Resources.d;
            sim = new Simulator(this);
            //sim.CreateOne(); // to test if it assigns to shortest queue
        }

        //Test if random creating objects works. Prints every Person in List and corresponding enum type.
        private void timer1_Tick(object sender, EventArgs e)
        {
            sim.SpawnPeople();
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
            Graphics g = e.Graphics;
            g.DrawImage(image, rect);
        }

        private void BtnStart_Click(object sender, EventArgs e)
        {

            image = Properties.Resources.d;
            rect = new System.Drawing.Rectangle(520, 350, 20, 20);
            MovingTimer.Start();
            SpawnTimer.Start();
            btnStart.Enabled = false;
        }

        private void BtnStop_Click(object sender, EventArgs e)
        {
            SpawnTimer.Stop();
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

        private void MovingTimer_Tick(object sender, EventArgs e)
        {
            sim.UpdateLabels();
            if (rect.Y > 130)
            {
                if (visitedCenter)
                {
                    rect.X -= Convert.ToInt32(1.35);
                    rect.Y -= 3;
                }
                else
                {
                    rect.X += 0;
                    rect.Y -= 3;
                }
               
                if (rect.Y > 305 && rect.Y < 310)
                {
                    MovingTimer.Stop();

                    Thread.Sleep(1000);

                    MovingTimer.Start();
                    visitedCenter=true;
                    sim.AssignCounter(sim.TotalPeopleList);
                }
                

                Invalidate();
            }
        }
    }
}
