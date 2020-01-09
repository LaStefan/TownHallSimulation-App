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
            Form1 f = new Form1();
            Simulator sim = new Simulator(f);
            Statistics s = new Statistics(sim);
            sim.InitializeCounters();
            double totalWaitingTIme = 0;
            int totalNum = 0;
            foreach (Counter a in sim.GetAddressChangeCounterList())
            {
                a.FIFO();
                foreach (double item in a.queueTime)
                {
                    totalWaitingTIme += item;
                    totalNum++;
                }
            }
            foreach (Counter b in sim.GetPermitRequestCountersList())
            {
                b.FIFO();
                foreach (double item in b.queueTime)
                {
                    totalWaitingTIme += item;
                    totalNum++;
                }
            }
            foreach (Counter c in sim.GetPropertySaleCountersList())
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
            Assert.AreEqual(expect, result);
        }

        [TestMethod]
        public void TestMethodGetTotalNrOfCountersOpened()
        {
            Form1 f = new Form1();
            Simulator sim = new Simulator(f);
            Statistics s = new Statistics(sim);
            int result = s.GetTotalNrOfCountersOpened();
            Assert.AreEqual(6, result);
        }

        [TestMethod]
        public void TestMethodUpdateTotalNumPeopl()
        {
            Form1 f = new Form1();
            Simulator sim = new Simulator(f);
            Statistics s = new Statistics(sim);
            int expect = sim.GetTotalPeopleList().Count;
            s.UpdateTotalNumPeopl();
            int result = s.TotalNrPeople;
            Assert.AreEqual(expect, result);
        }
    }
}
