using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace TownHallSimulation
{
    //Types of appointments... 
    public enum Appointment
    {
        AddressChange,
        PropertySale,
        PermitRequest
    }
    //Class Person
    public class Person
    {   //Fields and Properties
        private static int counter = 0;
        private int id = 0;
        public Point Location { get; private set; }
        public Point[] PathToFollow { get; private set; }
        public Bitmap Image { get; private set; }
        //Constructor
        public Person(Appointment appointment, Point location, Bitmap image)
        {
            counter++;
            this.GetAppointment = appointment;
            this.Location = location;
            this.Image = image;
        }
        public Appointment GetAppointment { get; }
        
        //Methods of the class 
        public int GetPersonId()
        {
            return this.id;
        }

        public void DrawPerson(Graphics gr)
        {
            gr.DrawImage(Image, Location);
        }

       // public bool GoToCounter()
       //{
            
       // }




    }
}
