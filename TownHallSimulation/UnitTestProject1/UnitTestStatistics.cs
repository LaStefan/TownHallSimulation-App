using System;
using System.Drawing;
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
            string except = "";
            string result = s.ToString();
            Assert.AreEqual(except, result);
        }

        [TestMethod]
        public void TestMethodToString()
        {
            Simulator sim = new Simulator(new Form1());
            Statistics s = new Statistics(sim);
            string except = "";
            string result = s.ToString();
            Assert.AreEqual(except,result);
        }

        //class simulator did not finished so cannot fully testing
        //[TestMethod]
        //public void TestMethodCalculateAvgWaitingTime()
        //{
        //    Counter c = new Counter(new Point(20, 20),Appointment.AddressChange);
        //    c.IsOpened = true;
        //    Counter c1 = new Counter(new Point(40,40),Appointment.PermitRequest);
        //    c1.IsOpened = true;
        //    Counter c2 = new Counter(new Point(60,60),Appointment.PropertySale);
        //    c2.IsOpened = true;
        //    Counter c3 = new Counter(new Point(80,80),Appointment.AddressChange);
        //    c3.IsOpened = true;
        //    Counter c4 = new Counter(new Point(90, 90),Appointment.AddressChange);
        //    c4.IsOpened = true;
        //    Simulator sim = new Simulator(new Form1());
        //    sim.AddressChangeCountersList.Add(c);
        //    sim.AddressChangeCountersList.Add(c3);
        //    sim.AddressChangeCountersList.Add(c4);
        //    sim.PermitRequestCountersList.Add(c1);
        //    sim.PropertySaleCountersList.Add(c2);
        //    Statistics s = new Statistics(sim);

        //    int result = s.GetTotalNrOfCountersOpened();
        //    Assert.AreEqual(5,result);
        //}

        //[TestMethod]
        //public void TestMethodGetTotalNrOfCountersOpened()
        //{
        //    Counter c = new Counter(new Point(20, 20),Appointment.AddressChange);
        //    c.IsOpened = true;
        //    Counter c1 = new Counter(new Point(40,40),Appointment.PermitRequest);
        //    c1.IsOpened = true;
        //    Counter c2 = new Counter(new Point(60,60),Appointment.PropertySale);
        //    c2.IsOpened = true;
        //    Counter c3 = new Counter(new Point(80,80),Appointment.AddressChange);
        //    c3.IsOpened = true;
        //    Counter c4 = new Counter(new Point(90, 90),Appointment.AddressChange);
        //    c4.IsOpened = true;
        //    Simulator sim = new Simulator(new Form1());
        //    sim.AddressChangeCountersList.Add(c);
        //    sim.AddressChangeCountersList.Add(c3);
        //    sim.AddressChangeCountersList.Add(c4);
        //    sim.PermitRequestCountersList.Add(c1);
        //    sim.PropertySaleCountersList.Add(c2);
        //    Statistics s = new Statistics(sim);

        //    int result = s.GetTotalNrOfCountersOpened();
        //    Assert.AreEqual(5,result);
        //}

        [TestMethod]
        public void TestMethodGetAverageWaitingTime()
        {
            Simulator sim = new Simulator(new Form1());
            Statistics s = new Statistics(sim);
            double result = s.GetAverageWaitingTime();
            Assert.AreEqual(2.3, result);
        }

        [TestMethod]
        public void TestMethodUpdateTotalNumPeopl()
        {
            Simulator sim = new Simulator(new Form1());
            Statistics s = new Statistics(sim);
            s.UpdateTotalNumPeopl(50);
            int except = 50;
            int result = s.TotalNrPeople;
            Assert.AreEqual(except, result);
        }
    }
}
