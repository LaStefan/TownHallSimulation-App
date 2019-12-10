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
        public int TotalNrPeople { get; private set; }
        public int TotalNrOfCounters { get; private set; }
        public int TotalNrOfCountersOpened { get; private set; }
        public double AverageWaitingTime { get; private set; }
        public double time { get; set; }
        private Simulator sim;


        public Statistics(Simulator simulator)
        {
            TotalNrPeople = 0;
            sim = simulator;
            TotalNrOfCounters = 10;
            TotalNrOfCountersOpened = GetTotalNrOfCountersOpened();
            time = simulator.time;
        }
        public double CalculateAvgWaitingTime()
        {
            double totalWaitingTIme =0;
            foreach (Counter item in sim.AddressChangeCountersList)
            {
                item.OnCounterReach();
                foreach (double d in item.queueTime)
                {
                   totalWaitingTIme += d;
                }
            }
            foreach (Counter item in sim.PermitRequestCountersList)
            {
                item.OnCounterReach();

                foreach (double d in item.queueTime)
                {
                    totalWaitingTIme += d;
                }
            }
            foreach (Counter item in sim.PropertySaleCountersList)
            {
                item.OnCounterReach();

                foreach (double d in item.queueTime)
                {
                    totalWaitingTIme += d;
                }
            }

            AverageWaitingTime = totalWaitingTIme / sim.TotalPeopleList.Count(); ;
            return AverageWaitingTime;
        }

        public override string ToString()
        {
            return "";
        }

      
        public int GetTotalNrOfCountersOpened()
        {
            int num = 0;
            foreach (Counter C in sim.AddressChangeCountersList)
            {
                if (C.IsOpened)
                {
                    num++;
                }
            }
            foreach (Counter b in sim.PermitRequestCountersList)
            {
                if (b.IsOpened)
                {
                    num++;
                }
            }
            foreach (Counter c in sim.PropertySaleCountersList)
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
            TotalNrPeople = sim.TotalPeopleList.Count();
        }

      


    }
}




