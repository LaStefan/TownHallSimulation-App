using System;
using System.Timers;
using System.Drawing;
using System.Collections.Generic;

namespace TownHallSimulation
{
    public class Counter
    { // fields and properties of the class
        private static int _id;
        public Point Location { get; set; }
        public bool IsOpened { get; set; }
        public bool IsOccupied { get; set; }
        private Appointment _appointmentToProcess;
        public Position CounterPosition;
        public List<Person> QueueList { get; private set; }
        public Timer t;

        // class constructor 
        public Counter(Point location, Appointment appointmentToProcess)
        {
            _id++;
            Location = location;
            IsOccupied = false;
            _appointmentToProcess = appointmentToProcess;
            t = new Timer();
            QueueList = new List<Person>();//for unit test
        }

        // methods of the class
        public void UpdateIsOpened()
        {
            IsOpened = !IsOpened;
        }

        public void UpdateStatus()
        {
            IsOccupied = !IsOccupied;
        }

        //Processes the appointment of the person with this assigned counter. Will be called when person reaches assigned counter.
        public void ProcessAppointment()
        {
            Person p = QueueList[0];
            Appointment current = p.TypeOfAppointment;
            this.UpdateStatus();
            if (current == Appointment.AddressChange)
            {
                t.Interval = 3000;
            }
            else if (current == Appointment.PermitRequest)
            {
                t.Interval = 5000;
            }
            else
            {
                t.Interval = 8000;
            }
            SetTimer();
        }
        //I make it to be public only for unit test
        public void FIFO()
        {
            QueueList.Remove(QueueList[0]);
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
            FIFO();
        }


    }
}
