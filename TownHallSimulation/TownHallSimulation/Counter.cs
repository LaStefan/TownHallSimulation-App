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
            QueueList.Peek().sw.Stop();
            queueTime.Add(QueueList.Peek().sw.ElapsedMilliseconds);
            QueueList.Dequeue();
           
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
        public void OnTick(Object source, ElapsedEventArgs e)
        {
            FIFO();
        }
        //for moving to a specific counter
        public Point GetCounterLocation()
        {
            Point counter1 = new Point(260, 187);
            Point counter2 = new Point(413, 92);
            Point counter3 = new Point(620, 92);
            Point counter4 = new Point(803, 92);
            Point counter5 = new Point(971, 92);
            Point counter6 = new Point(1103, 187);
            Point counter7 = new Point(1103, 293);
            Point counter8 = new Point(1103, 404);
            Point counter9 = new Point(260, 404);
            Point counter10 = new Point(260, 297);
            return counter1;
            //if (Location == counter1)
            //    return counter1;
            //if (Location == counter2)
            //    return counter2;
            //if (Location == counter3)
            //    return counter3;
            //if (Location == counter4)
            //    return counter4;
            //if (Location == counter5)
            //    return counter5;
            //if (Location == counter6)
            //    return counter6;
            //if (Location == counter7)
            //    return counter7;
            //if (Location == counter8)
            //    return counter8;
            //if (Location == counter9)
            //    return counter9;
            //else
            //{
            //    return counter10;
            //}
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
