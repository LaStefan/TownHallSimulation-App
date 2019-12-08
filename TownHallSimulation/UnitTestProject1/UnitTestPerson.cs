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

        [TestMethod]
        public void TestMethodGoToCounter_CheckLocationEqualsToDestinationPoint()
        {
            Person p = new Person(Appointment.AddressChange);
            p.Location = new Point(20, 20);
            p.destinationPoint = new Point(20,20);
            bool result = p.GoToCounter();
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void TestMethodGoToCounter_CheckLocationEqualsToCountaWithPositionUp_CheckResult()
        {
            Person p = new Person(Appointment.AddressChange);
            p.Counta = new Counter(new Point(20, 10), Appointment.AddressChange);
            p.Location = new Point(20, 20);
            p.Counta.CounterPosition = Position.UP;
            bool result = p.GoToCounter();
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void TestMethodGoToCounter_CheckLocationEqualsToCountaWithPositionUp_CheckPoint()
        {
            Person p = new Person(Appointment.AddressChange);
            p.Counta = new Counter(new Point(20, 10), Appointment.AddressChange);
            p.Location = new Point(20, 20);
            p.Counta.CounterPosition = Position.UP;
            bool result = p.GoToCounter();
            Point expectlocation = new Point(20,19);
            Point resultlocation = p.Location;
            Assert.AreEqual(expectlocation, resultlocation);
        }

        [TestMethod]
        public void TestMethodGoToCounter_CheckLocationEqualsToCountaWithOtherPosition_CheckResult()
        {
            Person p = new Person(Appointment.AddressChange);
            p.Counta = new Counter(new Point(20, 10), Appointment.AddressChange);
            p.Location = new Point(20, 20);
            p.Counta.CounterPosition = Position.LEFT;
            bool result = p.GoToCounter();
            Assert.AreEqual(false, result);
        }

        //左边位置和右边位置的代码还没有完成，没法测试
        //[TestMethod]
        //public void TestMethodGoToCounter_CheckLocationEqualsToCountaWithOtherPosition_CheckPoint()
        //{
        //    Person p = new Person(Appointment.AddressChange);
        //    p.Counta = new Counter(new Point(20, 10), Appointment.AddressChange);
        //    p.Location = new Point(20, 20);
        //    p.Counta.CounterPosition = Position.LEFT;
        //    bool result = p.GoToCounter();
        //    Point expectlocation = new Point(19, 20);
        //    Point resultlocation = p.Location;
        //    Assert.AreEqual(expectlocation, resultlocation);
        //}

        [TestMethod]
        public void TestMethodGoToCounter_CheckLocationNotEqualToCounta_CheckResult()
        {
            Person p = new Person(Appointment.AddressChange);
            p.Counta = new Counter(new Point(20, 10), Appointment.AddressChange);
            p.Location = new Point(30, 20);
            bool result = p.GoToCounter();
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void TestMethodGoToCounter_CheckLocationNotEqualToCounta_CheckPoint()
        {
            Person p = new Person(Appointment.AddressChange);
            p.Counta = new Counter(new Point(20, 10), Appointment.AddressChange);
            p.Location = new Point(30, 20);
            bool result = p.GoToCounter();
            Point expectlocation = new Point(29, 20);
            Point resultlocation = p.Location;
            Assert.AreEqual(expectlocation, resultlocation);
        }

        [TestMethod]
        public void TestMethodStartMoving_CheckEnabled()
        {
            Person p = new Person(Appointment.AddressChange);
            p.StartMoving();
            bool enabled = p.personMove.Enabled;
            Assert.AreEqual(true,enabled);
        }

        [TestMethod]
        public void TestMethodStartMoving_CheckInterval()
        {
            Person p = new Person(Appointment.AddressChange);
            p.StartMoving();
            int interval = p.personMove.Interval;
            Assert.AreEqual(30, interval);
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
        public void TestMethodSetInitialPosition_CheckInitialPoint()
        {
            Person p = new Person(Appointment.AddressChange);
            Point point = new Point(20,20);
            p.SetInitialPosition(point,3);
            Assert.AreEqual(point,p.initialPoint);
        }

        [TestMethod]
        public void TestMethodSetInitialPosition_CheckLocation()
        {
            Person p = new Person(Appointment.AddressChange);
            Point point = new Point(20, 20);
            p.SetInitialPosition(point, 3);
            Assert.AreEqual(point, p.Location);
        }

        [TestMethod]
        public void TestMethodSetDestination_CheckDestinationPoint()
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
        }

        [TestMethod]
        public void TestMethodSetDestination_CheckDestinations()
        {
            Person p = new Person(Appointment.AddressChange);
            Point point = new Point(20, 20);
            Point poin = new Point(15, 15);
            Point poi = new Point(10, 10);
            Point po = new Point(5, 5);
            List<Point> f = new List<Point>();
            f.Add(point);
            f.Add(poin);
            f.Add(poi);
            f.Add(po);
            List<int> y = new List<int>();
            y.Add(1);
            y.Add(2);
            y.Add(3);
            p.SetDestination(point, f, y);
            CollectionAssert.AreEqual(f, p.destinations);
        }

        [TestMethod]
        public void TestMethodSetDestination_CheckdestintationsNumbers()
        {
            Person p = new Person(Appointment.AddressChange);
            Point point = new Point(20, 20);
            Point poin = new Point(15, 15);
            Point poi = new Point(10, 10);
            Point po = new Point(5, 5);
            List<Point> f = new List<Point>();
            f.Add(point);
            f.Add(poin);
            f.Add(poi);
            f.Add(po);
            List<int> y = new List<int>();
            y.Add(1);
            y.Add(2);
            y.Add(3);
            p.SetDestination(point, f, y);
            CollectionAssert.AreEqual(y, p.destintationsNumbers);
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
