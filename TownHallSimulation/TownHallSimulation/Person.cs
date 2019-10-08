using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TownHallSimulation
{
    public class Person
    {
        private static int counter = 0;

        public Person(Appointment appointment)
        {
            counter++;
            this.GetAppointment = appointment;
        }
        public Appointment GetAppointment { get; }
        public int GetId { get; } = counter;
    }

    //Types of appointments... to be discussed.
    public enum Appointment
    {
        AddressChange,
        PropertySale,
        PermitRequest
    }
}
