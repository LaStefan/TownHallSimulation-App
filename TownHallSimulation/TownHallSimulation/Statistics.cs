using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TownHallSimulation
{
    public class Statistics
    {
        //Fields
        private Simulator sim;
        //Properties
        public int TotalNrPeople { get; private set; }
        public int TotalNrOfCounters { get; private set; }
        public int TotalNrOfCountersOpened { get; private set; }
        public double AverageWaitingTime { get; private set; }
        public double Time { get; set; }
        public double avgWaitingTime { get; set; }
        


        public Statistics(Simulator simulator)
        {
            sim = simulator;
            TotalNrPeople = sim.GetTotalPeopleList().Count();
            TotalNrOfCounters = 10;
            TotalNrOfCountersOpened = GetTotalNrOfCountersOpened();
            Time = simulator.Time;
            avgWaitingTime = CalculateAvgWaitingTime();
        }
        public double CalculateAvgWaitingTime()
        {
            double totalWaitingTime = 0;
            int temp = 0;
            foreach (Counter item in sim.GetAddressChangeCounterList())
            {
                foreach (double d in item.GetQueueTimeList())
                {
                   totalWaitingTime += d;
                   temp++;
                }
            }
            foreach (Counter item in sim.GetPermitRequestCountersList())
            {
                foreach (double d in item.GetQueueTimeList())
                {
                    totalWaitingTime += d;
                    temp++;
                }
            }
            foreach (Counter item in sim.GetPropertySaleCountersList())
            {
                foreach (double d in item.GetQueueTimeList())
                {
                    totalWaitingTime += d;
                    temp++;
                }
            }

            AverageWaitingTime = totalWaitingTime / sim.GetTotalPeopleList().Count(); ;
            return AverageWaitingTime;
        }

        public int GetTotalNrOfCountersOpened()
        {
            int num = 0;
            foreach (Counter C in sim.GetAddressChangeCounterList())
            {
                if (C.IsOpened)
                {
                    num++;
                }
            }
            foreach (Counter b in sim.GetPermitRequestCountersList())
            {
                if (b.IsOpened)
                {
                    num++;
                }
            }
            foreach (Counter c in sim.GetPropertySaleCountersList())
            {
                if (c.IsOpened)
                {
                    num++;
                }
            }
            return num;
        }

        public void UpdateTotalNumPeopl()
        {
            TotalNrPeople = sim.GetTotalPeopleList().Count();
        }
    }
}




