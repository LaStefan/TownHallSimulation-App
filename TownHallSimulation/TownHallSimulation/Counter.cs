using System;
using System.Timers;
using System.Drawing;
using System.Collections.Generic;

namespace TownHallSimulation
{
    public class Counter
    { // fields and properties of the class
        private static int _id;
        //we use the location of the counter so the person can know where to go
        public Point Location { get; set; }
        //checking if the counters are opened and occupied 
        public bool IsOpened { get; set; }
        public bool IsOccupied { get; set; }
        private Appointment _appointmentToProcess;
        //checking if the person is on the position of the counter
        public Position CounterPosition;
        public Queue<Person> QueueList { get; private set; }
        public List<double> queueTime = new List<double>();
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
        //method of the class to check if the counter is busy
        public void UpdateStatus()
        {
            IsOccupied = !IsOccupied;
        }

        //I make it to be public only for unit test
        public void FIFO()
        {
            if (QueueList.Count > 0)
            {
                QueueList.Peek().sw.Stop();
                queueTime.Add(QueueList.Peek().sw.ElapsedMilliseconds);
                QueueList.Dequeue();
            }  
            UpdateStatus();
        }
        //What is used for??
        public void SetTimer()
        {
            t.Elapsed += OnTick;
            t.AutoReset = false;
            t.Enabled = true;
        }
        //Jean explain the method what is used for???
        private void OnTick(Object source, ElapsedEventArgs e)
        {
            FIFO();
        }
        //for moving to a specific counter
       

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
            if (QueueList.Count >= 1 )
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
