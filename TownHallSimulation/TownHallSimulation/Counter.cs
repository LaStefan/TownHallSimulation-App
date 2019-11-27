using System;
using System.Timers;
using System.Drawing;
using System.Collections.Generic;

namespace TownHallSimulation
{
    public class Counter
    { // fields and properties of the class
        private int id;
        public Point Location { get; set; }
        public bool isOpened { get; set; }
        public bool isOccupied { get; set; }
        private string currentAppointment { get; set; }

        public Position CounterPosition;
        public Appointment appointment;
        public const double SIZE = 50;
        public List<Person> AllPeople { get; private set; }
        public List<Person> CurrentPerson { get; private set; }
        public bool selected { get; set; }

        private Timer t;

        // class constructor 
        public Counter(int id)
        {
            this.id = id;
            isOccupied = false;
            t = new Timer();
        }


        //Constructor 2 for testing front end
        public Counter(Point location, Appointment app, Position position)
        {
            this.Location = location;
            this.appointment = app;
            CounterPosition = position;
            AllPeople = new List<Person>();
            CurrentPerson = new List<Person>();
        }
        // methods of the class
        public void OpenCounter()
        {
            isOpened = true;
        }

        public Counter GetFreeCounter()
        {
            return null;
        }
        public void CloseCounter()
        {
            isOpened = false;
        }
        public void UpdateStatus()
        {
            if (isOccupied == false)
            {
                isOccupied = true;
            }
            else
            {
                isOccupied = false;
            }
        }

        public void AddPersontoList(Person p)
        {
            AllPeople.Add(p);
            CurrentPerson.Add(p);
        }

        //Processes the appointment of the person with this assigned counter. Will be called when person reaches assigned counter.
        public void ProcessAppointment(Person p)
        {
            Appointment current = p.GetAppointment;
            this.UpdateStatus();
            Console.WriteLine("Counter {0} is now occupied with {1}", id, current);
            if (current == Appointment.AddressChange)
            {
                currentAppointment = "Address Change";
                t.Interval = 3000;
            }
            else if (current == Appointment.PermitRequest)
            {
                currentAppointment = "Permit Request";
                t.Interval = 5000;
            }
            else
            {
                currentAppointment = "Property Sale";
                t.Interval = 8000;
            }
            SetTimer();
        }

        public void SetTimer()
        {
            t.Elapsed += OnTick;
            t.AutoReset = false;
            t.Enabled = true;
        }

        public void OnTick(Object source, ElapsedEventArgs e)
        {
            UpdateStatus();
            Console.WriteLine("Counter {0} isOccupied: {1}. Task finished: {2} for {3}ms", id, isOccupied, currentAppointment, t.Interval);
        }


    }
}
