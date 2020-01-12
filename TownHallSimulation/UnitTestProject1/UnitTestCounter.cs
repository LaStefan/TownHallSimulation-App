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
            Form1 f = new Form1();
            Simulator s = new Simulator(f);
            Counter c = new Counter(new Point(20, 20), Appointment.AddressChange,s);
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
            Form1 f = new Form1();
            Simulator s = new Simulator(f);
            Counter c = new Counter(new Point(20, 20), Appointment.AddressChange,s);
            Form1 f1 = new Form1();
            Simulator s1 = new Simulator(f);
            c.GetSimulator(s1);
            Simulator expect = s1;
            Simulator result = c.sim;
            Assert.AreSame(expect, result);
        }

        [TestMethod]
        public void TestMethodcounterLocations()
        {
            Form1 f = new Form1();
            Simulator s = new Simulator(f);
            Counter c = new Counter(new Point(20, 20), Appointment.AddressChange,s);
            Point expect = new Point(310,75);
            Point result = c.counterLocations();
            Assert.AreEqual(expect, result);
        }

        [TestMethod]
        public void TestMethodUpdateIsOpened()
        {
            Form1 f = new Form1();
            Simulator s = new Simulator(f);
            Counter c = new Counter(new Point(20, 20), Appointment.AddressChange,s);
            bool expect = c.IsOpened;
            c.UpdateIsOpened();
            bool result = c.IsOpened;
            Assert.AreEqual(!expect, result);
        }

        [TestMethod]
        public void TestMethodUpdateStatus()
        {
            Form1 f = new Form1();
            Simulator s = new Simulator(f);
            Counter c = new Counter(new Point(20, 20), Appointment.AddressChange,s);
            c.UpdateStatus();
            bool result = c.IsOccupied;
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void TestMethodFIFO_findAndRemve_check()
        {
            Form1 f = new Form1();
            Simulator s = new Simulator(f);
            Counter c = new Counter(new Point(20, 20), Appointment.AddressChange,s);
            Person p1 = new Person(Appointment.AddressChange);
            Person p2 = new Person(Appointment.PermitRequest);
            Person p3 = new Person(Appointment.PropertySale);
            c.QueueList.Enqueue(p1);
            c.QueueList.Enqueue(p2);
            c.QueueList.Enqueue(p3);
            c.IsOccupied = true;
            c.sim.TotalPeopleList.Add(p1);
            c.sim.TotalPeopleList.Add(p3);
            c.FIFO();
            List<Person> expect = new List<Person>();
            expect.Add(p3);
            CollectionAssert.AreEqual(expect,c.sim.TotalPeopleList);
        }

        [TestMethod]
        public void TestMethodFIFO_QueueList_check()
        {
            Form1 f = new Form1();
            Simulator s = new Simulator(f);
            Counter c = new Counter(new Point(20, 20), Appointment.AddressChange, s);
            Person p1 = new Person(Appointment.AddressChange);
            Person p2 = new Person(Appointment.PermitRequest);
            Person p3 = new Person(Appointment.PropertySale);
            c.QueueList.Enqueue(p1);
            c.QueueList.Enqueue(p2);
            c.QueueList.Enqueue(p3);
            c.IsOccupied = true;
            c.FIFO();
            List<Person> expect = new List<Person>();
            expect.Add(p2);
            expect.Add(p3);
            CollectionAssert.AreEqual(expect, c.QueueList);
        }

        [TestMethod]
        public void TestMethodFIFO_UpdateStatus()
        {
            Form1 f = new Form1();
            Simulator s = new Simulator(f);
            Counter c = new Counter(new Point(20, 20), Appointment.AddressChange,s);
            Person p1 = new Person(Appointment.AddressChange);
            Person p2 = new Person(Appointment.PermitRequest);
            Person p3 = new Person(Appointment.PropertySale);
            c.QueueList.Enqueue(p1);
            c.QueueList.Enqueue(p2);
            c.QueueList.Enqueue(p3);
            c.IsOccupied = true;
            c.FIFO();
            bool result = c.IsOccupied;
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void TestMethodfindAndRemve()
        {
            Form1 f = new Form1();
            Simulator s = new Simulator(f);
            Counter c = new Counter(new Point(20, 20), Appointment.AddressChange, s);
            Person p1 = new Person(Appointment.AddressChange);
            Person p2 = new Person(Appointment.PermitRequest);
            Person p3 = new Person(Appointment.PropertySale);
            c.sim.TotalPeopleList.Add(p1);
            c.sim.TotalPeopleList.Add(p2);
            c.sim.TotalPeopleList.Add(p3);
            c.findAndRemve(p2);
            List<Person> expect = new List<Person>();
            expect.Add(p1);
            expect.Add(p3);
            CollectionAssert.AreEqual(expect, c.sim.TotalPeopleList);
        }

        [TestMethod]
        public void TestMethodSetTimer_CheckAutoReset()
        {
            Form1 f = new Form1();
            Simulator s = new Simulator(f);
            Counter c = new Counter(new Point(20, 20), Appointment.AddressChange,s);
            c.SetTimer();
            bool autoreset = c.t.AutoReset;
            Assert.AreEqual(false, autoreset);
        }

        [TestMethod]
        public void TestMethodSetTimer_CheckEnabled()
        {
            Form1 f = new Form1();
            Simulator s = new Simulator(f);
            Counter c = new Counter(new Point(20, 20), Appointment.AddressChange,s);
            c.SetTimer();
            bool enabled = c.t.Enabled;
            Assert.AreEqual(true, enabled);
        }

        [TestMethod]
        public void TestMethodSetInterval_CheckAddressChange()
        {
            Form1 f = new Form1();
            Simulator s = new Simulator(f);
            Counter c = new Counter(new Point(20, 20), Appointment.AddressChange,s);
            c._appointmentToProcess = Appointment.AddressChange;
            c.SetInterval();
            double temp = 300;
            Assert.AreEqual(temp, c.t.Interval);
        }

        [TestMethod]
        public void TestMethodSetInterval_CheckPermitRequest()
        {
            Form1 f = new Form1();
            Simulator s = new Simulator(f);
            Counter c = new Counter(new Point(20, 20), Appointment.PermitRequest,s);
            c._appointmentToProcess = Appointment.PermitRequest;
            c.SetInterval();
            double temp = 500;
            Assert.AreEqual(temp, c.t.Interval);
        }

        [TestMethod]
        public void TestMethodSetInterval_CheckPropertySale()
        {
            Form1 f = new Form1();
            Simulator s = new Simulator(f);
            Counter c = new Counter(new Point(20, 20), Appointment.PropertySale,s);
            c._appointmentToProcess = Appointment.PropertySale;
            c.SetInterval();
            double temp = 800;
            Assert.AreEqual(temp, c.t.Interval);
        }

        [TestMethod]
        public void TestMethodOnCounterReach_EqualOrBiggerThenOne_CheckAutoReset()
        {
            Form1 f = new Form1();
            Simulator s = new Simulator(f);
            Counter c = new Counter(new Point(20, 20), Appointment.AddressChange,s);
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
            Form1 f = new Form1();
            Simulator s = new Simulator(f);
            Counter c = new Counter(new Point(20, 20), Appointment.AddressChange,s);
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
