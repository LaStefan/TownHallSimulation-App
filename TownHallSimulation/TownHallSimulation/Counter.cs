using System;
using System.Drawing;
using System.Threading;
using System.Timers;
using System.Windows.Forms;
using Timer = System.Timers.Timer;

namespace TownHallSimulation
{

    public class Counter
    { // fields and properties of the class
        public int id;
        public Point location { get; set; }
        public bool isOpened { get; set; }
        public bool isOccupied { get; set; }
        public Appointment appointmentType { get; set; }
        public int peopleWaiting { get; set; }
        private Timer t;
        Form1 form;
        // class constructor 
        public Counter(int id, Point loc, Form1 f1, Appointment appointmentType)
        {
            this.id = id;
            location = loc;
            isOccupied = false;
            this.appointmentType = appointmentType;
            this.form = f1;
            t = new Timer();
            peopleWaiting = 0;
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
            var current = p.GetAppointment;
            this.UpdateStatus();
            switch (current)
            {
                case Appointment.AddressChange:
                    t.Interval = 3000;
                   // form.lbLog.Items.Add($"Counter {id} is now occupied with {p.GetAppointment}");
                    break;
                case Appointment.PermitRequest:
                    t.Interval = 5000;
                  //  form.lbLog.Items.Add($"Counter {id} is now occupied with {p.GetAppointment}");
                    break;
                default:
                    t.Interval = 7000;
                  //  form.lbLog.Items.Add($"Counter {id} is now occupied with {p.GetAppointment}");
                    break;
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
            form.Invoke(new MethodInvoker(delegate
            {
              //  form.lbLog.Items.Add(
            //$"Counter {id} has finished processing after {t.Interval} ms.");
            }));
            t.Elapsed -= OnTick;
        }
    }
}
