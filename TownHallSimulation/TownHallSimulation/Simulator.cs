using System;
using System.Collections.Generic;
using System.Drawing;

namespace TownHallSimulation
{
    public class Simulator
    {
        public List<Person> TotalPeopleList;
        public List<Counter> CountersList;
        private Random AppointmentRandom = new Random();

        public Simulator()
        {
            TotalPeopleList = new List<Person>();
            CountersList = new List<Counter>();
        }

        //Creates an instance of Person with a random Appointment value each time and adds to the list.
        //Used by Spawn method in town hall class.
        public void CreatePerson()
        {
            var types = Enum.GetValues(typeof(Appointment));
            Appointment currentType = (Appointment)types.GetValue(AppointmentRandom.Next(types.Length));
            Person anotherOne = new Person(currentType);
            TotalPeopleList.Add(anotherOne);
        }
        //When a visitor reaches assigned counter and it's free processing starts. Still need to implement synchronization.
        public void ProcessAndRemove(Person p)
        {
        }

        public void MakeCounter()
        {
            List<Counter> NotSortedCounters = new List<Counter>();
            Counter addressCounter1 = new Counter(new Point(300, 177), Appointment.AddressChange);

            //public void AssignCounter(Person p
            //{
            //    foreach (Counter c in theCounters)
            //    {
            //        if (c.appointmentType == p.GetAppointment && c.isOpened)
            //        {//assigns the person to the counter that is open and has the same appointment type
            //            p.assignedCounter = c.id;
            //            c.peopleWaiting++;
            //        }
            //        else
            //        {
            //            //nothing happens
            //        }
            //    }
            //}
        }
    }
}
