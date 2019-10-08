using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TownHallSimulation
{
    class Town_Hall
    {
        public String name = "Town Hall Eindhoven";
        private Simulator sim;
        //Used for generating random number of people each x amount of time.
        private Random random = new Random();
        private Statistics statistics;
        public int Time { get; private set; }
        public Town_Hall()
        {
            //intiliaze vars
            sim = new Simulator();
            Time = 9;
        }

        //Different number of people are created, added to a list and then it is returned.
        public List<Person> RandomSpawnPersons()
        {
            sim.PeopleList.Clear();
            var current = random.Next(0, 16);         
            for (int i = 0; i < current; i++)
            {
                sim.CreatePerson();
                statistics.UpdateTotalNrOfPeople(1);
            }
            return sim.PeopleList;
        }
        public void UpdateCurrentTime()
        {
            if (Time < 17 && Time > 8)
            {
                Time++;
            }
        }
    }
}
