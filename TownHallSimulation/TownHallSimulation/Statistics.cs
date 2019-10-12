using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TownHallSimulation
{
    class Statistics
    {
        public int TotalNrPeople { get; private set; }
        public int TotalNrOfPeopleWaiting { get; private set; }
        public int TotalNrOfCounters { get; private set; }
        private Simulator sim;


        public Statistics(Simulator simulator)
        {
            TotalNrPeople = 0;
            TotalNrOfPeopleWaiting = 0;
            sim = simulator;
            TotalNrOfCounters = 9;
        }

        //public string ToString()
        //{

        //}

        public void UpdateTotalNrOfPeople(int total)
        {
            TotalNrPeople += total;
            //Every time x amount of people is spawned they get added to the total count. You get the number of the people from the random generator in the town hall class.

        }
        
        public int GetTotalNrOfPeopleWaiting()
        {
            return TotalNrPeople - TotalNrOfPeopleWaiting;
        }

        public int GetTotalNrOfCountersOpened()
        {
            int num = 0;
            foreach (Counter C in sim.CounterList)
            {
                if (C.isOpened)
                {
                    num++;
                }
            }
            return num;
        }

        public int GetTotalNrOfCountersOccupied()
        {
            int num = 0;
            foreach (Counter C in sim.CounterList)
            {
                if (C.isOccupied)
                {
                    num++;
                }
            }
            return num;
        }

        public int GetTotalNrOfCountersFree()
        {
            int num = 0;
            foreach (Counter C in sim.CounterList)
            {
                if (!C.isOccupied && C.isOpened)
                {
                    num++;
                }
            }
            return num;
        }
    }
}
