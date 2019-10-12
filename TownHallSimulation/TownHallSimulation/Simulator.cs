using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TownHallSimulation
{
    class Simulator
    {
        public List<Person> PeopleList;
        public List<Counter> CounterList;
        //counter for test
        private Counter c;
        private Random random = new Random();

        public Simulator()
        {
            PeopleList = new List<Person>();
            CounterList = new List<Counter>();
            c = new Counter(2, Point.Empty);
        }

        //Creates an instantce of Person with a random Appointment value each time and adds to the list.
        //Used by Spawn method in town hall class.
        public void CreatePerson()
        {
            var types = Enum.GetValues(typeof(Appointment));
            Appointment currentType = (Appointment)types.GetValue(random.Next(types.Length));
            Person anotherOne = new Person(currentType);
            PeopleList.Add(anotherOne);
        }
        //When a visitor reaches assigned counter and it's free processing starts. Still need to implement synchronization.
        public void ProcessAndRemove(Person p)
        {
            if (!c.isOccupied && PeopleList.Contains(p))
            {
                c.ProcessAppointment(p);
                PeopleList.Remove(p);
                Console.WriteLine("Person p removed.");
            }
        }

        public void MakeCounter()
        {
            //...
        }
    }
}
