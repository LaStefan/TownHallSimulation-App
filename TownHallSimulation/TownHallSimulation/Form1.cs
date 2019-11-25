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
        private Town_Hall TheHall;
        System.Drawing.Image image;
        System.Drawing.Rectangle rect;
        bool state = false;
        Counter counter7;
        public Form1()
        {
            InitializeComponent();
            TheHall = new Town_Hall(this);
            image = TownHallSimulation.Properties.Resources.d;
            counter7 = new Counter(7, new Point(908, 225), this, Appointment.AddressChange);
            lblCounter7.Text = "0 people \n waiting";
        }

        //Test if random creating objects works. Prints every Person in List and corresponding enum type.
        private void timer1_Tick(object sender, EventArgs e)
        {
            foreach (Person p in TheHall.RandomSpawnPersons())
            {
                Console.WriteLine("The type of appointment is: {0} + ID: {1}", p.GetAppointment, p.GetPersonId());
            }

            lblCounter7.Text = counter7.peopleWaiting + " people \n waiting";

            if (rect.Y > 130)
            {
                if (rect.Y > 305 && rect.Y < 310)
                {
                    SpawnTimer.Stop();

                    Thread.Sleep(1000);

                    SpawnTimer.Start();
                }
                rect.X += 0;
                rect.Y -= 3;

                Invalidate();
            }
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
            image = TownHallSimulation.Properties.Resources.d;
            rect = new System.Drawing.Rectangle(520, 350, 20, 20);
            SpawnTimer.Start();
            btnStart.Enabled = false;
            TheHall.Process(counter7);
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
            using(SaveFileDialog sfd = new SaveFileDialog() { Filter="PDF file|*.pdf", ValidateNames = true })
            {
                if (sfd.ShowDialog()==DialogResult.OK)
                {
                    iTextSharp.text.Document doc = new iTextSharp.text.Document(PageSize.A4.Rotate());
                    try
                    {
                        PdfWriter.GetInstance(doc, new FileStream(sfd.FileName, FileMode.Create));
                        doc.Open();
                        doc.Add(new iTextSharp.text.Paragraph("CASE Management of Technology The PEOPLES Bank(A bank for all the people”) is one of the smaller banks of the Netherlands, but a bank with a rich history. The bank is now facing some new challenges, especially for the IT department.The bank uses a legacy system on a mainframe, which is actually a mix of legacy systems due to a" +
                            "merger with 2 other banks 10 years ago.The system is used for the customer administration on " +
                            "the loans, payment and savings accounts that the bank offers. All transaction of customers are processed real" +
                            " - time as far as possible.This includes transaction of customers at the bank’s ATM, credit card and transactions and " +
                            "updates done by the desk clerk when"))   ;


                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show(ex.Message,"Message",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    }
                    finally
                    {
                        doc.Close();
                    }
                }
            }
        }
    }
}
