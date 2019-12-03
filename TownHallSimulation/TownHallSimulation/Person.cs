using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace TownHallSimulation
{
    //Types of appointments... 
    public enum Appointment
    {
        AddressChange,
        PropertySale,
        PermitRequest
    }
    //Position of the counter and person
    public enum Position
    {
        UP, LEFT, RIGHT
    }

    //Class Person
    public class Person
    {   //Fields and Properties
        public int id;
        private static int counter = 0;
        public Point initialPoint, destinationPoint;
        public Timer personMove;
        private Timer personStop;
        public List<Point> destinations;
        public List<int> destintationsNumbers;
        public Bitmap Image { get; private set; }
        public int PersonId { get; private set; }
        public TimeSpan Timer { get; set; }
        //location of the person
        public Point Location { get; set; }
        //path the person should follow
        public Point[] PathToFollow { get; set; }
        public bool Discharged { get; set; }
        public bool Critical { get; set; }
        public Counter Counta;
        public bool Managed { get; set; }
        public DateTime StartNavigate { get; set; }
        public Appointment TypeOfAppointment { get; set; }

        //Constructor 1
        public Person(Appointment type)
        {
            counter++;
            Location = new Point(744, 550);
            //Image = new Bitmap(TownHallSimulation.Properties.Resources.d);
            personMove = new Timer();
            personStop = new Timer();
            TypeOfAppointment = type;
        }
        //Constructor 2, Used in simulator to create objects before location and image are used.
        //public Person(Appointment appointment)
        //{
        //    counter++;
        //    id = counter;
        //    TypeOfAppointment = appointment;
        //    personMove = new Timer();//for unit test
        //}

        //Methods of the class 
        public int GetPersonId()
        {
            return id;
        }

        public void DrawPerson(Graphics gr)
        {
            gr.DrawImage(Image, Location);
        }

        public bool GoToCounter()
        {
            if (Location == destinationPoint)
            {
                return true;
            }

            // Point pathStarting = PathToFollow[0];

            if (Location.X == Counta.Location.X)
            {
                switch (Counta.CounterPosition)
                {
                    case Position.UP:
                        Location = new Point(Location.X, Location.Y - 1);
                        break;
                        //case Position.DOWN:
                        //    Location = new Point(Location.X, Location.Y + 1);
                        //    break;
                }
            }
            else if (pathStarting.Y > Location.Y)
            {
                Location = new Point(Location.X, Location.Y + 1);
            }
            else if (pathStarting.Y < Location.Y)
            {
                Location = new Point(Location.X, Location.Y - 1);
            }
            else
            {
                Location = new Point(Location.X - 1, Location.Y);
            }

            return false;
        }

        public void StartMoving()
        {
            personMove.Enabled = true;
            personMove.Interval = 30;

        }

        public void StopMoving()
        {
            personMove.Enabled = false;
        }

        public void SetInitialPosition(Point x, int startPosition)
        {
            initialPoint = x;
            Location = x;

        }

        public void SetDestination(Point r, List<Point> f, List<int> y)
        {
            //where the car starts 
            destinationPoint = r;

            //list of destination 
            destinations = f;

            //check the location of the car with the method SetInitialPosition
            destintationsNumbers = y;
        }

        public void SetDestinationPoint(Point y)
        {
            this.destinationPoint = y;
        }

        public int LocationX()
        {
            return Location.X;
        }
        public int LocationY()
        {
            return Location.Y;
        }
    }
}
