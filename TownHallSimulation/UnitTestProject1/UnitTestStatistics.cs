using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TownHallSimulation;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTestStatistics
    {
        [TestMethod]
        public void TestMethodCalculateAvgWaitingTime()
        {
            Simulator sim = new Simulator(new Form1());
            Statistics s = new Statistics(sim);
            sim.InitializeCounters();
            double totalWaitingTIme = 0;
            int totalNum = 0;
            foreach (Counter a in sim.AddressChangeCountersList)
            {
                a.FIFO();
                foreach (double item in a.queueTime)
                {
                    totalWaitingTIme += item;
                    totalNum++;
                }
            }
            foreach (Counter b in sim.PermitRequestCountersList)
            {
                b.FIFO();
                foreach (double item in b.queueTime)
                {
                    totalWaitingTIme += item;
                    totalNum++;
                }
            }
            foreach (Counter c in sim.PropertySaleCountersList)
            {
                c.FIFO();
                foreach (double item in c.queueTime)
                {
                    totalWaitingTIme += item;
                    totalNum++;
                }
            }
            double expect = totalWaitingTIme / totalNum;
            double result = s.CalculateAvgWaitingTime();
            Assert.AreEqual(expect,result);
        }

        [TestMethod]
        public void TestMethodGetTotalNrOfCountersOpened()
        {
            Simulator sim = new Simulator(new Form1());
            Statistics s = new Statistics(sim);
            int result = s.GetTotalNrOfCountersOpened();
            Assert.AreEqual(6, result);
        }

        [TestMethod]
        public void TestMethodUpdateTotalNumPeopl()
        {
            Simulator sim = new Simulator(new Form1());
            Statistics s = new Statistics(sim);
            s.UpdateTotalNumPeopl(50);
            int expect = 50;
            int result = s.TotalNrPeople;
            Assert.AreEqual(expect, result);
        }
    }
}
