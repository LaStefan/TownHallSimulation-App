using System;
using System.Timers;
using System.Drawing;
using System.Windows.Forms.VisualStyles;

namespace TownHallSimulation
{
    class Counter
    { // fields and properties of the class
        private int id;
        public Point location { get; set; }
        public bool isOpened { get; set; }
        public bool isOccupied { get; set; }
        private string currentAppointment { get; set; }

        private Timer t;
        // class constructor 
        public Counter(int id, Point loc)
        {
            this.id = id;
            location = loc;
            isOccupied = false;
            t = new Timer();
            t.Elapsed += OnTick;
        }
        // methods of the class
        public void OpenCounter()
        {
            isOpened = true;
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

        //Processes the appointment of the person with this assigned counter. Will be called when person reaches assigned counter.
        public void ProcessAppointment(Person p)
        {
            Appointment current = p.GetAppointment;
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
            this.UpdateStatus();
            Console.WriteLine("Counter {0} is now occupied with {1}", id, current);
            SetTimer();
        }

        public void SetTimer()
        {
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
