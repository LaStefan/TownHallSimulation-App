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

    public enum Position
    {
        UP, LEFT, RIGHT
    }

    //Class Person
    public class Person
    {   //Fields and Properties
        public int id;
        public Point initialPoint, destinationPoint;
        public Timer personMove;
        private Timer personStop;
        private bool xNow, yNow;
        private bool firstLocation;
        private Position direction;

        public List<Point> destinations;
        public List<int> destintationsNumbers;

        public Bitmap Image { get; private set; }
        public int PersonId { get; private set; }
        public TimeSpan Timer { get; set; }
        public Point Location { get; set; }
        public Point[] PathToFollow { get; set; }
        public Counter Counter { get; set; }
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
        }
        //constructor 2
        public Person(Point location, Bitmap image, Appointment type)
        {
            Location = location;
            Image = new Bitmap(TownHallSimulation.Properties.Resources.d, new Size(10, 10));
            personMove = new Timer();
            personStop = new Timer();
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

        //public bool GoToCounter()
        //{
        //    if (Location == Counter.Location)
        //    {
        //        return true;
        //    }

        //    Point pathStarting = PathToFollow[0];

        //    if (Location.X == Counter.Location.X)
        //    {
        //        switch (Counter.CounterPosition)
        //        {
        //            case Position.UP:
        //                Location = new Point(Location.X, Location.Y - 1);
        //                break;
        //                //case Position.DOWN:
        //                //    Location = new Point(Location.X, Location.Y + 1);
        //                //    break;
        //        }
        //    }
        //    else if (pathStarting.Y > Location.Y)
        //    {
        //        Location = new Point(Location.X, Location.Y + 1);
        //    }
        //    else if (pathStarting.Y < Location.Y)
        //    {
        //        Location = new Point(Location.X, Location.Y - 1);
        //    }
        //    else
        //    {
        //        Location = new Point(Location.X - 1, Location.Y);
        //    }

        //    return false;
        //}
        public void SetDestination(Point r, List<Point> f, List<int> y)
        {
            //where the person goes 
            destinationPoint = r;

            //list of destination 
            destinations = f;

            //check the location of the person with the method SetInitialPosition
            destintationsNumbers = y;
        }

        public void SetDestinationPoint(Point y)
        {
            y = new Point(195);
        }

        public int LocationX()
        {
            return Location.X;
        }
        public int LocationY()
        {
            return Location.Y;
        }

        public void StartMoving()
        {
            //person.BringToFront();
            personMove.Interval = 15;
            personMove.Enabled = true;
           // personMove.Tick += personMove_Tick;
        }
    }
}
