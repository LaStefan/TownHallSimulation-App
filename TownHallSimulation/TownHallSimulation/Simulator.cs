using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TownHallSimulation
{
    class Simulator
    {
        public List<Person> PeopleList;
        public List<Counter> CounterList;
        private Random random = new Random();

        public Simulator()
        {
            PeopleList = new List<Person>();
            CounterList = new List<Counter>();
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

        public void RemoveFromList(Person p)
        {
            //...
        }

        public void MakeCounter()
        {
            //...
        }
    }
}
