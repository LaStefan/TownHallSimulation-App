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
        public void TestMethodGetQueueTimeList()
        {
            Counter c = new Counter(new Point(20, 20), Appointment.AddressChange);
            c.queueTime.Add(0.1);
            c.queueTime.Add(2.3);
            List<double> expect = new List<double>();
            expect.Add(0.1);
            expect.Add(2.3);
            List<double> result = c.GetQueueTimeList();
            CollectionAssert.AreEqual(expect,result);
        }

        [TestMethod]
        public void TestMethodGetSimulator()
        {
            Counter c = new Counter(new Point(20, 20), Appointment.AddressChange);
            Form1 f = new Form1();
            Simulator s = new Simulator(f);
            c.GetSimulator(s);
            Simulator expect = s;
            Simulator result = c.sim;
            Assert.AreSame(expect, result);
        }

        [TestMethod]
        public void TestMethodcounterLocations()
        {
            Counter c = new Counter(new Point(20, 20), Appointment.AddressChange);
            Point expect = new Point(310,75);
            Point result = c.counterLocations();
            Assert.AreEqual(expect, result);
        }

        [TestMethod]
        public void TestMethodUpdateIsOpened()
        {
            Counter c = new Counter(new Point(20, 20), Appointment.AddressChange);
            bool expect = c.IsOpened;
            c.UpdateIsOpened();
            bool result = c.IsOpened;
            Assert.AreEqual(!expect, result);
        }

        [TestMethod]
        public void TestMethodUpdateStatus()
        {
            Counter c = new Counter(new Point(20, 20), Appointment.AddressChange);
            c.UpdateStatus();
            bool result = c.IsOccupied;
            Assert.AreEqual(true, result);
        }

        //[TestMethod]
        //public void TestMethodFIFO_QueueListChanged()
        //{
        //    Counter c = new Counter(new Point(20, 20), Appointment.AddressChange);
        //    Person p1 = new Person(Appointment.AddressChange);
        //    Person p2 = new Person(Appointment.PermitRequest);
        //    Person p3 = new Person(Appointment.PropertySale);
        //    c.QueueList.Enqueue(p1);
        //    c.QueueList.Enqueue(p2);
        //    c.QueueList.Enqueue(p3);
        //    c.FIFO();
        //    Queue<Person> temp = new Queue<Person>();
        //    temp.Enqueue(p2);
        //    temp.Enqueue(p3);
        //    CollectionAssert.AreEqual(temp, c.QueueList);
        //}

        [TestMethod]
        public void TestMethodFIFO_UpdateStatus()
        {
            Counter c = new Counter(new Point(20, 20), Appointment.AddressChange);
            Person p1 = new Person(Appointment.AddressChange);
            Person p2 = new Person(Appointment.PermitRequest);
            Person p3 = new Person(Appointment.PropertySale);
            c.QueueList.Enqueue(p1);
            c.QueueList.Enqueue(p2);
            c.QueueList.Enqueue(p3);
            c.FIFO();
            bool result = c.IsOccupied;
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void TestMethodSetTimer_CheckAutoReset()
        {
            Counter c = new Counter(new Point(20, 20), Appointment.AddressChange);
            c.SetTimer();
            bool autoreset = c.t.AutoReset;
            Assert.AreEqual(false, autoreset);
        }

        [TestMethod]
        public void TestMethodSetTimer_CheckEnabled()
        {
            Counter c = new Counter(new Point(20, 20), Appointment.AddressChange);
            c.SetTimer();
            bool enabled = c.t.Enabled;
            Assert.AreEqual(true, enabled);
        }

        [TestMethod]
        public void TestMethodSetInterval_CheckAddressChange()
        {
            Counter c = new Counter(new Point(20, 20), Appointment.AddressChange);
            double temp = 3000;
            Assert.AreEqual(temp, c.t.Interval);
        }

        [TestMethod]
        public void TestMethodSetInterval_CheckPermitRequest()
        {
            Counter c1 = new Counter(new Point(20, 20), Appointment.PermitRequest);
            double temp = 5000;
            Assert.AreEqual(temp, c1.t.Interval);
        }

        [TestMethod]
        public void TestMethodSetInterval_CheckPropertySale()
        {
            Counter c2 = new Counter(new Point(20, 20), Appointment.PropertySale);
            double temp = 8000;
            Assert.AreEqual(temp, c2.t.Interval);
        }

        [TestMethod]
        public void TestMethodOnCounterReach_EqualOrBiggerThenOne_CheckAutoReset()
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
            Assert.AreEqual(false, autoreset);
        }

        [TestMethod]
        public void TestMethodOnCounterReach_EqualOrBiggerThenOne_CheckEnabled()
        {
            Counter c = new Counter(new Point(20, 20), Appointment.AddressChange);
            Person p1 = new Person(Appointment.AddressChange);
            Person p2 = new Person(Appointment.PermitRequest);
            Person p3 = new Person(Appointment.PropertySale);
            c.QueueList.Enqueue(p1);
            c.QueueList.Enqueue(p2);
            c.QueueList.Enqueue(p3);
            c.OnCounterReach();
            bool enabled = c.t.Enabled;
            Assert.AreEqual(true, enabled);
        }
    }
}
