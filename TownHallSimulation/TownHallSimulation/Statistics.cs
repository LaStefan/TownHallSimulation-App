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
        private Simulator sim;


        public Statistics(Simulator simulator)
        {
            TotalNrPeople = 0;
         //   TotalNrOfPeopleWaiting = 0;
            sim = simulator;
            TotalNrOfCounters = 9;
            TotalNrOfCountersOpened = GetTotalNrOfCountersOpened();
        }

        public override string ToString()
        {
            return "";
        }
        
        //public int GetTotalNrOfPeopleWaiting()
        //{
        //    return TotalNrPeople - TotalNrOfPeopleWaiting;
        //}

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
            foreach (Counter  b in sim.PermitRequestCountersList)
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

        //public int GetTotalNrOfCountersOccupied()
        //{
        //    //int num = 0;
        //    //foreach (Counter C in sim.CountersList)
        //    //{
        //    //    if (C.IsOccupied)
        //    //    {
        //    //        num++;
        //    //    }
        //    //}
        //    //return num;
        //}

        //public int GetTotalNrOfCountersFree()
        //{
        //    //int num = 0;
        //    //foreach (Counter C in sim.CountersList)
        //    //{
        //    //    if (!C.IsOccupied && C.IsOpened)
        //    //    {
        //    //        num++;
        //    //    }
        //    //}
        //    //return num;
        //}

       
        }
    }




