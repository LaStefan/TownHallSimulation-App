using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TownHallSimulation;
using System.Drawing;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTestCounter
    {
        [TestMethod]
        public void TestMethodUpdateIsOpened()
        {
            Counter c = new Counter(new Point(20,20),Appointment.AddressChange);
            bool before = c.IsOpened;
            c.UpdateIsOpened();
            bool after = c.IsOpened;
            Assert.AreEqual(!before,after);
        }

        [TestMethod]
        public void TestMethodUpdateStatus()
        {
            Counter c = new Counter(new Point(20, 20), Appointment.AddressChange);
            c.UpdateStatus();
            bool result = c.IsOccupied;
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void TestMethodFIFO()
        {
            Counter c = new Counter(new Point(20, 20), Appointment.AddressChange);
            Person p1 = new Person(Appointment.AddressChange);
            Person p2 = new Person(Appointment.PermitRequest);
            Person p3 = new Person(Appointment.PropertySale);
            c.QueueList.Enqueue(p1);
            c.QueueList.Enqueue(p2);
            c.QueueList.Enqueue(p3);
            c.FIFO();
            Queue<Person> temp = new Queue<Person>();
            temp.Enqueue(p2);
            temp.Enqueue(p3);
            CollectionAssert.AreEqual(temp, c.QueueList);

            bool result = c.IsOccupied;
            Assert.AreEqual(true, result);
        }

        //[TestMethod]
        //public void TestMethodFIFO_UpdateStatus()
        //{
        //    Counter c = new Counter(new Point(20, 20), Appointment.AddressChange);
        //    Person p1 = new Person(Appointment.AddressChange);
        //    Person p2 = new Person(Appointment.PermitRequest);
        //    Person p3 = new Person(Appointment.PropertySale);
        //    c.QueueList.Enqueue(p1);
        //    c.QueueList.Enqueue(p2);
        //    c.QueueList.Enqueue(p3);
        //    c.FIFO();
        //    bool result = c.IsOccupied;
        //    Assert.AreEqual(true, result);
        //}

        [TestMethod]
        public void TestMethodSetTimer()
        {
            Counter c = new Counter(new Point(20, 20), Appointment.AddressChange);
            c.SetTimer();
            bool autoreset = c.t.AutoReset;
            Assert.AreEqual(false, autoreset);

            bool enabled = c.t.Enabled;
            Assert.AreEqual(true,enabled);
        }

        [TestMethod]
        public void TestMethodGetCounterLocation()
        {
            Counter c = new Counter(new Point(20, 20), Appointment.AddressChange);
            Point expect = new Point(260, 187);
            Point actual = c.GetCounterLocation();
            Assert.AreEqual(expect, actual);
        }

        [TestMethod]
        public void TestMethodSetInterval()
        {
            Counter c = new Counter(new Point(20, 20), Appointment.AddressChange);
            double temp = 3000;
            Assert.AreEqual(temp,c.t.Interval);

            Counter c1 = new Counter(new Point(20, 20), Appointment.PermitRequest);
            double tem = 5000;
            Assert.AreEqual(tem, c1.t.Interval);

            Counter c2 = new Counter(new Point(20, 20), Appointment.PropertySale);
            double te = 8000;
            Assert.AreEqual(te, c2.t.Interval);
        }

        [TestMethod]
        public void TestMethodOnCounterReach_BiggerThenOne()
        {
            Counter c = new Counter(new Point(20, 20), Appointment.AddressChange);
            Person p1 = new Person(Appointment.AddressChange);
            Person p2 = new Person(Appointment.PermitRequest);
            Person p3 = new Person(Appointment.PropertySale);
            c.QueueList.Enqueue(p1);
            c.QueueList.Enqueue(p2);
            c.QueueList.Enqueue(p3);
            c.OnCounterReach();
            bool autoreset = c.t.AutoReset;
            Assert.AreEqual(true, autoreset);

            bool enabled = c.t.Enabled;
            Assert.AreEqual(true, enabled);
        }

        [TestMethod]
        public void TestMethodOnCounterReach_EqualToOne()
        {
            Counter c = new Counter(new Point(20, 20), Appointment.AddressChange);
            Person p1 = new Person(Appointment.AddressChange);
            c.QueueList.Enqueue(p1);
            c.OnCounterReach();

            bool autor = c.t.AutoReset;
            Assert.AreEqual(false, autor);

            bool enabl = c.t.Enabled;
            Assert.AreEqual(true, enabl);
        }
    }
}
