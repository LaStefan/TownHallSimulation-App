﻿using System;
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

    public enum Position
    {
        UP, LEFT, RIGHT
    }

    //Class Person
    public class Person
    {   //Fields and Properties
        private int id;

        public const int SIZE = 5;
        private static int counter = 0;
        private Point initialPoint, destinationPoint;
        private Timer personMove;
        private Timer personStop;
        private List<Point> destinations;
        private List<int> destintationsNumbers;
        public Bitmap Image { get; private set; }
        public int PersonId { get; private set; }
        public TimeSpan Timer { get; set; }
        public Point Location { get; private set; }
        public Point[] PathToFollow { get; set; }
        public bool Discharged { get; set; }
        public bool Critical { get; set; }
        public Counter Counta { get; set; }

        public bool Managed { get; set; }

        public DateTime StartNavigate { get; set; }

        //Constructor 1
        public Person(Point location, Bitmap image)
        {
            counter++;
            Location = location;
            Image = new Bitmap(TownHallSimulation.Properties.Resources.d);
            personMove = new Timer();
            personStop = new Timer();
        }
        //Constructor 2, Used in simulator to create objects before location and image are used.
        public Person(Appointment appointment)
        {
            counter++;
            id = counter;
            GetAppointment = appointment;
        }
        public Appointment GetAppointment { get; }

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
            if (Location == Counta.Location)
            {
                return true;
            }

            Point pathStarting = PathToFollow[0];

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
