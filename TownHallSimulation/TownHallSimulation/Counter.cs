using System;
using System.Timers;
using System.Drawing;

namespace TownHallSimulation
{
  
    class Counter
    { // fields and properties of the class
        private int id;
        public Point location { get; set; }
        public bool isOpened { get; set; }
        public bool isOccupied { get; set; }
        private string currentAppointment { get; set; }
        private string status;
        Form1 form;

        private Timer t;
        // class constructor 
        public Counter(int id, Point loc, Form1 f1)
        {
            this.id = id;
            location = loc;
            isOccupied = false;
            t = new Timer();
            this.form = f1;
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
            this.UpdateStatus();
            form.lbLog.Items.Add($"Counter {id} is now occupied with {current}");
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
        
        public string GetInfo()
        {
            return status;
        }
        public void OnTick(Object source, ElapsedEventArgs e)
        {
            UpdateStatus();
            GetInfo();


        }
        

        
    }
}
