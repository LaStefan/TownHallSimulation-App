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
        public int Time { get; private set; }


        public Statistics(Simulator sim)
        {
            TotalNrPeople = 0;
            TotalNrOfPeopleWaiting = 0;
            sim =  Simulator;
            Time = 8;
            TotalNrOfCounters = 9;
        }

        //public string ToString()
        //{

        //}

        public void UpdateTotalNrOfPeople(int total)
        {
            TotalNrPeople = total;
            //Not sure what's suppose to do here!
           // totalNrPeople += total;

        }

        //public int GetTotalNrOfPeople()
        //{
        //    return totalNrPeople;
        //}
        
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

        public int GetTotoalNrOfCountersOccupied()
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

        public int GetTotoalNrOfCountersFree()
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

        public void UpdateCurrentTime()
        {
            if (Time<17 && Time >8)
            {
                Time++;
            }
            fjwjrwerwjhrjkw;
        }
    }
}
