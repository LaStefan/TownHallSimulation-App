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

    public enum Position
    {
        UP, LEFT, RIGHT
    }

    //Class Person
    public class Person
    {   //Fields and Properties
        private int id;
        private static int counter = 0;
        public Point Location { get; private set; }
        public Point[] PathToFollow { get; private set; }
        public Bitmap Image { get; private set; }
        //Constructor 1
        public Person(Appointment appointment, Point location, Bitmap image)
        {
            counter++;
            GetAppointment = appointment;
            Location = location;
            Image = image;
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

        // public bool GoToCounter()
        //{

        // }




    }
}
