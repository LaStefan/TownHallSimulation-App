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
       // class simulator did not finished so cannot fully testing
        [TestMethod]
        public void TestMethodCalculateAvgWaitingTime()
        {
            Simulator sim = new Simulator(new Form1());
            Statistics s = new Statistics(sim);
            Person p1 = new Person(Appointment.AddressChange);
            Person p2 = new Person(Appointment.PermitRequest);
            Person p3 = new Person(Appointment.PropertySale);
            Person p4 = new Person(Appointment.AddressChange);
            Person p5 = new Person(Appointment.AddressChange);
            Person p6 = new Person(Appointment.PermitRequest);
            List<Person> tempperson = new List<Person>();
            tempperson.Add(p1);
            tempperson.Add(p2);
            tempperson.Add(p3);
            tempperson.Add(p4);
            tempperson.Add(p5);
            tempperson.Add(p6);
            double totalWaitingTIme = 0;
            int totalNum = 0;
            foreach (Person p in tempperson)
            {
                p.sw.Start();
                Thread.Sleep(1000);
                p.sw.Stop();
                totalWaitingTIme += p.sw.ElapsedMilliseconds;
                totalNum++;
            }
            double expect = totalWaitingTIme / totalNum;
            int result = s.GetTotalNrOfCountersOpened();
            Assert.AreEqual(expect, result);
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
            int expect = 50;
            int result = s.TotalNrPeople;
            Assert.AreEqual(expect, result);
        }
    }
}
