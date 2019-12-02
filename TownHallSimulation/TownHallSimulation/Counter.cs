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
        public Queue<Person> QueueList { get; private set; }
        public Timer t;

        // class constructor 
        public Counter(Point location, Appointment appointmentToProcess)
        {
            _id++;
            Location = location;
            IsOccupied = false;
            _appointmentToProcess = appointmentToProcess;
            t = new Timer();
            SetInterval();
            QueueList = new Queue<Person>();//for unit test
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

        //I make it to be public only for unit test
        public void FIFO()
        {
            QueueList.Dequeue();
            UpdateStatus();
        }

        public void SetTimer()
        {
            t.Elapsed += OnTick;
            t.AutoReset = false;
            t.Enabled = true;
        }

        public void OnTick(Object source, ElapsedEventArgs e)
        {
            FIFO();
        }

        public void SetInterval()
        {
            if (_appointmentToProcess == Appointment.AddressChange)
            {
                t.Interval = 3000;
            }
            else if (_appointmentToProcess == Appointment.PermitRequest)
            {
                t.Interval = 5000;
            }
            else
            {
                t.Interval = 8000;
            }
        }

        public void OnCounterReach()
        {
            if (QueueList.Count == 1 )
            {
                SetTimer();
            }
            else if(QueueList.Count == 0)
            {
                return;
            }
            else
            {
                t.AutoReset = true;
                t.Enabled = true;
            }
        }
    }
}
