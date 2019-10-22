﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TownHallSimulation
{
    public partial class Form1 : Form
    {
        private Town_Hall TheHall;
        Image image;
        Rectangle rect;
        public Form1()
        {
            InitializeComponent();
            TheHall = new Town_Hall();
            image = TownHallSimulation.Properties.Resources.d;
            rect = new Rectangle(20, 20, 70, 70);
        }

        //Test if random creating objects works. Prints every Person in List and corresponding enum type.
        private void timer1_Tick(object sender, EventArgs e)
        {
            foreach ( Person p in TheHall.RandomSpawnPersons())
            {
                Console.WriteLine("The type of appointment is: {0} + ID: {1}", p.GetAppointment, p.GetPersonId());
            }
            rect.X += 3;
            rect.Y += 3;
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
            // Create rectangle.
            Rectangle rect = new Rectangle(0, 0, 200, 200);
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
            image = TownHallSimulation.Properties.Resources.d;
            rect = new Rectangle(20, 20, 70, 70);
            SpawnTimer.Start();
        }

        private void BtnStop_Click(object sender, EventArgs e)
        {
            SpawnTimer.Stop();
        }
    }
}
