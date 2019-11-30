using System;
using System.Collections.Generic;
using System.Drawing;

namespace TownHallSimulation
{
    public class Simulator
    {
        public List<Person> TotalPeopleList;
        public List<Counter> AddressChangeCountersList;
        public List<Counter> PropertySaleCountersList;
        public List<Counter> PermitRequestCountersList;
        private double time;
        private Random spawnRandom = new Random();
        private Statistics stats;

        public Simulator()
        {
            TotalPeopleList = new List<Person>();
            AddressChangeCountersList = new List<Counter>();
            PropertySaleCountersList = new List<Counter>();
            PermitRequestCountersList = new List<Counter>();
            time = 8;
        }

        //Creates an instance of Person with a random Appointment value each time and adds to the list.
        public void SpawnPeople()
        {
            if (time < 18)
            {
                time += 0.25;
                var numberToSpawn = time >= 12 && time <= 16 ? spawnRandom.Next(10, 11) : spawnRandom.Next(0, 2);
                var types = Enum.GetValues(typeof(Appointment));
                for (int i = 0; i <= numberToSpawn; i++)
                {
                    Appointment currentType = (Appointment)types.GetValue(spawnRandom.Next(types.Length));
                    TotalPeopleList.Add(new Person(currentType));
                }
            }
        }

        //When a visitor reaches assigned counter and it's free processing starts. Still need to implement synchronization.
        public void ProcessAndRemove(Person p)
        {
        }

        public void MakeStats()
        {

        }
        public void InitializeCounters()
        {

        }
    }
}
