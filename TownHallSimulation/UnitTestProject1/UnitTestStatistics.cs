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
        public void TestMethodCalculateAvgWaitingTime_Test1()
        {
            Form1 f = new Form1();
            Simulator sim = new Simulator(f);
            Statistics s = new Statistics(sim);
            sim.AddressChangeCountersList[0].queueTime.Add(5.0);
            sim.PropertySaleCountersList[0].queueTime.Add(6.0);
            sim.PermitRequestCountersList[0].queueTime.Add(10.0);
            sim.TotalPeopleList.Add(new Person(Appointment.PermitRequest));
            double expect = 21;
            double result = s.CalculateAvgWaitingTime();
            Assert.AreEqual(expect, result);
        }

        [TestMethod]
        public void TestMethodCalculateAvgWaitingTime_Test2()
        {
            Form1 f = new Form1();
            Simulator sim = new Simulator(f);
            Statistics s = new Statistics(sim);
            sim.AddressChangeCountersList[0].queueTime.Add(5.0);
            sim.PropertySaleCountersList[0].queueTime.Add(7.0);
            sim.PermitRequestCountersList[0].queueTime.Add(10.0);
            sim.TotalPeopleList.Add(new Person(Appointment.PermitRequest));
            sim.TotalPeopleList.Add(new Person(Appointment.AddressChange));
            double expect = 11;
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
