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
            double totalWaitingTIme = 0;
            int totalNum = 0;
            foreach (Counter C in sim.AddressChangeCountersList)
            {
                foreach (double item in C.queueTime)
                {
                    totalWaitingTIme+=item;
                    totalNum++;
                }  
            }
            foreach (Counter b in sim.PermitRequestCountersList)
            {

                foreach (double item in b.queueTime)
                {
                    totalWaitingTIme += item;
                    totalNum++;
                }
            }
            foreach (Counter c in sim.PropertySaleCountersList)
            {

                foreach (double item in c.queueTime)
                {
                    totalWaitingTIme += item;
                    totalNum++;
                }
            }
            AverageWaitingTime = totalWaitingTIme / totalNum;
            return AverageWaitingTime;
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
       
        public void UpdateTotalNumPeopl(int n)
        {
            TotalNrPeople = n;
        }
    }
}




