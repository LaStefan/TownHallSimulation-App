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
        bool visitedCenter = false;
        Counter counter1, counter2, counter3, counter4, counter5, counter6, counter7, counter8, counter9, counter10;
        List<Counter> theCounters = new List<Counter>();
        public Form1()
        {
            InitializeComponent();
            TheHall = new Town_Hall(this);
            image = TownHallSimulation.Properties.Resources.d;
            setCounters();
        }

        //Test if random creating objects works. Prints every Person in List and corresponding enum type.
        private void timer1_Tick(object sender, EventArgs e)
        {
            foreach (Person p in TheHall.RandomSpawnPersons())
            {
                Console.WriteLine("The type of appointment is: {0} + ID: {1}", p.GetAppointment, p.GetPersonId());
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
            MovingTimer.Start();
            SpawnTimer.Start();
            btnStart.Enabled = false;
            TheHall.Process(theCounters);
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

        private void MovingTimer_Tick(object sender, EventArgs e)
        {
            if (rect.Y > 130)
            {
                if (visitedCenter)
                {
                    rect.X -= Convert.ToInt32(1.35);
                    rect.Y -= 3;
                    updateLabels();
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
                    
                }
                

                Invalidate();
            }
        }

        public void setCounters()
        {
            counter1 = new Counter(1);
            theCounters.Add(counter1);
            counter1.OpenCounter();
            lblCounter1.Text = "0 people \n waiting";
            counter2 = new Counter(2);
            theCounters.Add(counter2);
            counter2.OpenCounter();
            lblCounter2.Text = "0 people \n waiting";
            counter3 = new Counter(3);
            theCounters.Add(counter3);
            counter3.OpenCounter();
            lblCounter3.Text = "0 people \n waiting";
            counter4 = new Counter(4);
            theCounters.Add(counter4);
            counter4.OpenCounter();
            lblCounter4.Text = "0 people \n waiting";
            counter5 = new Counter(5);
            theCounters.Add(counter5);
            counter5.OpenCounter();
            lblCounter5.Text = "0 people \n waiting";
            counter6 = new Counter(6);
            theCounters.Add(counter6);
            //counter6.OpenCounter();
            lblCounter6.Text = "0 people \n waiting";
            counter7 = new Counter(7);
            theCounters.Add(counter7);
            lblCounter7.Text = "0 people \n waiting";
            counter8 = new Counter(8);
            theCounters.Add(counter8);
            lblCounter8.Text = "0 people \n waiting";
            counter9 = new Counter(9);
            theCounters.Add(counter9);
            lblCounter9.Text = "0 people \n waiting";
            counter10 = new Counter(10);
            theCounters.Add(counter10);
            lblCounter10.Text = "0 people \n waiting";
        }

        public void updateLabels()
        {
            lblCounter1.Text = counter1.peopleWaiting + " people \n waiting";
            lblCounter2.Text = counter2.peopleWaiting + " people \n waiting";
            lblCounter3.Text = counter3.peopleWaiting + " people \n waiting";
            lblCounter4.Text = counter4.peopleWaiting + " people \n waiting";
            lblCounter5.Text = counter5.peopleWaiting + " people \n waiting";
            lblCounter6.Text = counter6.peopleWaiting + " people \n waiting";
            lblCounter7.Text = counter7.peopleWaiting + " people \n waiting";
            lblCounter8.Text = counter8.peopleWaiting + " people \n waiting";
            lblCounter9.Text = counter9.peopleWaiting + " people \n waiting";
            lblCounter10.Text = counter10.peopleWaiting + " people \n waiting";
        }
    }
}
