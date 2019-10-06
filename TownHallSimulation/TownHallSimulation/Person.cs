using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TownHallSimulation
{
    public class Person
    {
        private static int id = 0;

        public Person(Appointment appointment)
        {
            id++;
            this.GetAppointment = appointment;
        }
        public Appointment GetAppointment { get; }
    }

    //Types of appointments... to be discussed.
    public enum Appointment
    {
        AddressChange,
        PropertySale,
        PermitRequest
    }
}
