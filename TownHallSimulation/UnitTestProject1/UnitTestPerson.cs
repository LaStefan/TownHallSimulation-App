using Microsoft.VisualStudio.TestTools.UnitTesting;
using TownHallSimulation;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTestPerson
    {
        [TestMethod]
        public void TestMethodGetPersonId()
        {
            Person p = new Person(Appointment.AddressChange);
            int id = p.id;
            int result = p.GetPersonId();
            Assert.AreEqual(id,result);
        }

        //need to fix later
        //[TestMethod]
        //public void TestMethodGoToCounter()
        //{
        //    Person p = new Person(Appointment.AddressChange);
        //    Counter c = new Counter(new Point(20, 20), Appointment.AddressChange);
        //    p.Location = new Point(20, 20);
        //    bool result = p.GoToCounter();
        //    Assert.AreEqual(true, result);
        //}

        [TestMethod]
        public void TestMethodStartMoving()
        {
            Person p = new Person(Appointment.AddressChange);
            p.StartMoving();
            bool enabled = p.personMove.Enabled;
            int interval = p.personMove.Interval;
            Assert.AreEqual(true,enabled);
            Assert.AreEqual(30,interval);
        }

        [TestMethod]
        public void TestMethodStopMoving()
        {
            Person p = new Person(Appointment.AddressChange);
            p.StopMoving();
            bool enabled = p.personMove.Enabled;
            Assert.AreEqual(false, enabled);
        }

        [TestMethod]
        public void TestMethodSetInitialPosition()
        {
            Person p = new Person(Appointment.AddressChange);
            Point point = new Point(20,20);
            p.SetInitialPosition(point,3);
            Assert.AreEqual(point,p.initialPoint);
            Assert.AreEqual(point,p.Location);
        }

        [TestMethod]
        public void TestMethodSetDestination()
        {
            Person p = new Person(Appointment.AddressChange);
            Point point = new Point(20, 20);
            Point poin = new Point(15,15);
            Point poi = new Point(10,10);
            Point po = new Point(5,5);
            List<Point> f = new List<Point>();
            f.Add(point);
            f.Add(poin);
            f.Add(poi);
            f.Add(po);
            List<int> y = new List<int>();
            y.Add(1);
            y.Add(2);
            y.Add(3);
            p.SetDestination(point,f,y);
            Assert.AreEqual(point, p.destinationPoint);
            CollectionAssert.AreEqual(f,p.destinations);
            CollectionAssert.AreEqual(y,p.destintationsNumbers);
        }

        [TestMethod]
        public void TestMethodSetDestinationPoint()
        {
            Person p = new Person(Appointment.AddressChange);
            Point point = new Point(20, 20);
            p.SetDestinationPoint(point);
            Assert.AreEqual(point, p.destinationPoint);
        }

        [TestMethod]
        public void TestMethodLocationX()
        {
            Person p = new Person(Appointment.AddressChange);
            double point = p.Location.X;
            int result = p.LocationX();
            Assert.AreEqual(point, result);
        }

        [TestMethod]
        public void TestMethodLocationY()
        {
            Person p = new Person(Appointment.AddressChange);
            double point = p.Location.Y;
            int result = p.LocationY();
            Assert.AreEqual(point, result);
        }
    }
}
