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
    {   //Fields 
        public int id;
        public Timer personMove;
        private Timer personStop;
        private int arrayCounter;
        public List<Point> destinations;
        public List<int> destintationsNumbers;
        private Point centerDesk = new Point(525, 360);


        //Properties
        public Point DestinationPoint { get; set; }
        public Point InitialPoint { get; set; }
        public bool IsAssigned { get; set; } = false;
        public bool CenterWasReached { get; set; } = false;
       // public Bitmap Image { get; set; }
        public PictureBox Image { get; set; }
        public int PersonId { get; private set; }
        public TimeSpan Timer { get; set; }
        public Point Location { get; set; }
        public Point[] PathToFollow { get; set; }
        public DateTime StartNavigate { get; set; }
        public Stopwatch sw { get; set; }
        public Appointment TypeOfAppointment { get; set; }
        public Simulator sim;

        //Constructor 1
        public Person(Appointment type)
        {
            //Image = new Bitmap(Properties.Resources.d, new Size(10,10));

            Image = new PictureBox
            {
                Name = PersonId.ToString(),
                Size = new Size(16, 16),
                Location = Location,
                Image = Properties.Resources.d,
                BackColor = Color.Black,

            };
            personMove = new Timer();
            personStop = new Timer();
            TypeOfAppointment = type;
            sw = new Stopwatch();
            sw.Start();
        }
        //constructor 2
        public Person(Point location, Bitmap image, Appointment type, Simulator sim)
        {
            Location = location;
            // Image = new Bitmap(TownHallSimulation.Properties.Resources.d, new Size(10, 10));

            Image = new PictureBox
            {
                Name = PersonId.ToString(),
                Size = new Size(16, 16),
                Location = Location,
                Image = Properties.Resources.d,
                BackColor = Color.Black,

            };
            personMove = new Timer();
            personStop = new Timer();
            TypeOfAppointment = type;
            this.sim = sim;
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
            //if (this.Image != null)
            //{
            //    gr.DrawImage(Image, Location);
            //}
            if (Image != null)
            {
                Image.Location = Location;
                Image.Refresh();
            }
           
        }
        public void ChangeColor()
        {
            if (Image != null)
            {
                switch (TypeOfAppointment)
                {
                    case Appointment.AddressChange:
                        Image.BackColor = Color.Red;
                        break;
                    case Appointment.PropertySale:
                        Image.BackColor = Color.RoyalBlue;
                        break;
                    case Appointment.PermitRequest:
                        Image.BackColor = Color.Green;
                        break;
                    default:
                        Image.BackColor = Color.Black;
                        break;
                }
            }
            
        }



        public void personMove_Tick(object sender, EventArgs e)
        {
            if (CenterWasReached)
            {
                ChangeColor();
            }
                if (CenterWasReached == false)
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
                            CenterWasReached = true;
                        }
                }
                else
                {
                if (arrayCounter < destinations.Count)
                {
                    if (this.Location.Y > DestinationPoint.Y)
                    {
                        this.Location 
                            = new Point((this.Location.X), (this.Location.Y) - 1);
                    }
                    else if (this.Location.Y < DestinationPoint.Y)
                    {
                        this.Location = new Point((this.Location.X), (this.Location.Y) + 1);
                    }
                    else if (this.Location.Y == DestinationPoint.Y)
                    {
                        if (this.Location.X < DestinationPoint.X)
                        {
                            this.Location = new Point((this.Location.X) + 1, (this.Location.Y));
                        }
                        else if (this.Location.X > DestinationPoint.X)
                        {
                            this.Location = new Point((this.Location.X) - 1, (this.Location.Y));
                        }
                    }
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
                    if (Location == DestinationPoint)
                    {
                        //Location = new Point(1000, 1000);
                    }
                }
        }
        public void SetDestination(Point r, List<Point> f, List<int> y)
        {
            //where the person starts 
            DestinationPoint = r;

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
            personMove.Interval = 50;
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

        public void ReachesCounter()
        {
            switch (this.TypeOfAppointment.ToString())
            {
                case "AddressChange":
                    foreach (Counter c in sim.GetAddressChangeCounterList())
                    {
                        Console.WriteLine("counter location:" + c.Location);
                        Console.WriteLine("Person location:" + this.Location);
                        if (c.Location == this.Location)
                        {
                            c.IsOccupied = true;
                            c.OnCounterReach();
                            break;
                        }
                    }
                    break;

                case "PropertySale":
                    foreach (Counter c in sim.GetPropertySaleCountersList())
                    {
                        if (c.Location == this.Location)
                        {
                            c.IsOccupied = true;
                            c.OnCounterReach();
                            break;
                        }
                    }
                    break;

                case "PermitRequest":
                    foreach (Counter c in sim.GetPermitRequestCountersList())
            {
                if (c.Location == this.Location)
                {
                    c.IsOccupied = true;
                    c.OnCounterReach();
                    break;
                }
            }
            break;
        }
    }
    }
}
