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
            c.QueueList.Add(p1);
            c.QueueList.Add(p2);
            c.QueueList.Add(p3);
            c.FIFO();
            List<Person> temp = new List<Person>();
            temp.Add(p2);
            temp.Add(p3);
            CollectionAssert.AreEqual(temp,c.QueueList);
        }

        [TestMethod]
        public void TestMethodSetTimer()
        {
            Counter c = new Counter(new Point(20, 20), Appointment.AddressChange);
            c.SetTimer();
            bool autoreset = c.t.AutoReset;
            bool enabled = c.t.Enabled;
            Assert.AreEqual(false, autoreset);
            Assert.AreEqual(true,enabled);
        }

        [TestMethod]
        public void TestMethodProcessAppointment()
        {
            Counter c = new Counter(new Point(20, 20), Appointment.AddressChange);
            Person p1 = new Person(Appointment.AddressChange);
            Person p2 = new Person(Appointment.PermitRequest);
            Person p3 = new Person(Appointment.PropertySale);
            c.QueueList.Add(p1);
            c.QueueList.Add(p2);
            c.QueueList.Add(p3);
            c.ProcessAppointment();
            double interval = c.t.Interval;
            bool autoreset = c.t.AutoReset;
            bool enabled = c.t.Enabled;
            Assert.AreEqual(3000,interval);
            Assert.AreEqual(false, autoreset);
            Assert.AreEqual(true, enabled);
        }
    }
}
