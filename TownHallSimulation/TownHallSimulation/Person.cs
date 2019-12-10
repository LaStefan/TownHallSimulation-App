using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;

namespace TownHallSimulation
{
    //Types of appointments... 
    public enum Appointment
    {
        AddressChange,
        PropertySale,
        PermitRequest
    }

    //Class Person
    public class Person
    {   //Fields and Properties
        public int id;
        public Point initialPoint, destinationPoint;
        public Timer personMove;
        private Timer personStop;
        private int arrayCounter;
        private bool xNow, yNow;

        public List<Point> destinations;
        public List<int> destintationsNumbers;
        public Point centerDesk = new Point(525, 360);
        public bool centerWasReached = false;

        public Bitmap Image { get; private set; }
        public int PersonId { get; private set; }
        public TimeSpan Timer { get; set; }
        public Point Location { get; set; }
        public Point[] PathToFollow { get; set; }
        public DateTime StartNavigate { get; set; }
        public Stopwatch sw { get; set; }
        public Appointment TypeOfAppointment { get; set; }

        //Constructor 1
        public Person(Appointment type)
        {
            Image = new Bitmap(Properties.Resources.d, new Size(10,10));
            personMove = new Timer();
            personStop = new Timer();
            TypeOfAppointment = type;
            sw = new Stopwatch();
            sw.Start();
        }
        //constructor 2
        public Person(Point location, Bitmap image, Appointment type)
        {
            Location = location;
            Image = new Bitmap(TownHallSimulation.Properties.Resources.d, new Size(10, 10));
            personMove = new Timer();
            personStop = new Timer();
            TypeOfAppointment = type;
            sw = new Stopwatch();
            sw.Start();
            destinations = new List<Point>()
            {
                new Point(413,92),
                new Point(620,92),
                new Point(803,92),
                new Point(1103,404),
                new Point(971,92),
                new Point(1103,187),
                new Point(1103,293),
                new Point(1103,404),
                new Point(260,404),
                new Point(260,297),
            };
        }

        //Methods of the class 
        public int GetPersonId()
        {
            return id;
        }

        public void DrawPerson(Graphics gr)
        {
            gr.DrawImage(Image, Location);
        }

        private void SetXNowAndYNow(int c)
        {
            if (c == 0)
            {
                xNow = true;
                yNow = false;
            }
            else if (c == 1)
            {
                yNow = true;
                xNow = false;
            }
            else if (c == 2)
            {
                xNow = true;
                yNow = false;
            }
            else
            {
                yNow = true;
                xNow = false;
            }
        }

        private void personMove_Tick(object sender, EventArgs e)
        {
                if (centerWasReached == false)
                {
                        if (this.Location.Y != centerDesk.Y)
                        {
                            this.Location = new Point((this.Location.X), (this.Location.Y) - 1);
                        }
                        else if (this.Location.X < centerDesk.X)
                        {
                            this.Location = new Point((this.Location.X) + 1, (this.Location.Y));
                        }
                        else if(this.Location.X > centerDesk.X)
                        {
                            this.Location = new Point((this.Location.X) - 1, (this.Location.Y));

                        }
                        if(this.Location == centerDesk)
                        {
                            centerWasReached = true;
                        }
                }
                else
                {
                if (arrayCounter < destinations.Count)
                {
                    //if (yNow)

                    if (this.Location.Y > destinationPoint.Y)
                    {
                        this.Location = new Point((this.Location.X), (this.Location.Y) - 1);
                    }
                    else if (this.Location.Y < destinationPoint.Y)
                    {
                        this.Location = new Point((this.Location.X), (this.Location.Y) + 1);
                    }
                    else if (this.Location.Y == destinationPoint.Y)
                    {
                        if (this.Location.X < destinationPoint.X)
                        {
                            this.Location = new Point((this.Location.X) + 1, (this.Location.Y));
                        }
                        else if (this.Location.X > destinationPoint.X)
                        {
                            this.Location = new Point((this.Location.X) - 1, (this.Location.Y));
                        }
                    }

                    //if (Location == destinations[arrayCounter])
                    //    {
                    //        arrayCounter++;
                    //        if (arrayCounter < destintationsNumbers.Count)
                    //        {
                    //            SetXNowAndYNow(destintationsNumbers[arrayCounter]);
                    //        }

                    //    }


                    //}
                }

                }

                if (destinations.Count > 0)
                {
                    if (Location == destinations[destinations.Count - 1])
                    {
                        //Location = new Point(1000, 1000);
                    }
                }
                else
                {
                    if (Location == destinationPoint)
                    {
                        //Location = new Point(1000, 1000);
                    }
                }
        }
        public void SetDestination(Point r, List<Point> f, List<int> y)
        {
            //where the person starts 
            destinationPoint = r;

            //list of destination 
            destinations = f;

            //check the location of the person with the method SetInitialPosition
            destintationsNumbers = y;
        }
        

        public Point FirstDestination(Point y)
        {
            y = new Point(480,300);
            return y;
        }

        public void StartMoving()
        {
            personMove.Interval = 15;
            personMove.Enabled = true;
            personMove.Tick += personMove_Tick;
        }

        public void MovePerson()
        {
            personMove.Enabled = true;
            personMove.Start();
        }

        public void StopPerson()
        {
            personMove.Stop();
            personMove.Enabled = false;
        }
    }
}
