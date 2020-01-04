﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
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
        ////这个方法被注销了
        ////[TestMethod]
        ////public void TestMethodGoToCounter_CheckLocationEqualsToDestinationPoint()
        ////{
        ////    Person p = new Person(Appointment.AddressChange);
        ////    p.Location = new Point(20, 20);
        ////    p.destinationPoint = new Point(20,20);
        ////    bool result = p.GoToCounter();
        ////    Assert.AreEqual(true, result);
        ////}

        ////[TestMethod]
        ////public void TestMethodGoToCounter_CheckLocationEqualsToCountaWithPositionUp_CheckResult()
        ////{
        ////    Person p = new Person(Appointment.AddressChange);
        ////    p.Counta = new Counter(new Point(20, 10), Appointment.AddressChange);
        ////    p.Location = new Point(20, 20);
        ////    p.Counta.CounterPosition = Position.UP;
        ////    bool result = p.GoToCounter();
        ////    Assert.AreEqual(false, result);
        ////}

        ////[TestMethod]
        ////public void TestMethodGoToCounter_CheckLocationEqualsToCountaWithPositionUp_CheckPoint()
        ////{
        ////    Person p = new Person(Appointment.AddressChange);
        ////    p.Counta = new Counter(new Point(20, 10), Appointment.AddressChange);
        ////    p.Location = new Point(20, 20);
        ////    p.Counta.CounterPosition = Position.UP;
        ////    bool result = p.GoToCounter();
        ////    Point expectlocation = new Point(20,19);
        ////    Point resultlocation = p.Location;
        ////    Assert.AreEqual(expectlocation, resultlocation);
        ////}

        ////[TestMethod]
        ////public void TestMethodGoToCounter_CheckLocationEqualsToCountaWithOtherPosition_CheckResult()
        ////{
        ////    Person p = new Person(Appointment.AddressChange);
        ////    p.Counta = new Counter(new Point(20, 10), Appointment.AddressChange);
        ////    p.Location = new Point(20, 20);
        ////    p.Counta.CounterPosition = Position.LEFT;
        ////    bool result = p.GoToCounter();
        ////    Assert.AreEqual(false, result);
        ////}

        ////左边位置和右边位置的代码还没有完成，没法测试
        ////[TestMethod]
        ////public void TestMethodGoToCounter_CheckLocationEqualsToCountaWithOtherPosition_CheckPoint()
        ////{
        ////    Person p = new Person(Appointment.AddressChange);
        ////    p.Counta = new Counter(new Point(20, 10), Appointment.AddressChange);
        ////    p.Location = new Point(20, 20);
        ////    p.Counta.CounterPosition = Position.LEFT;
        ////    bool result = p.GoToCounter();
        ////    Point expectlocation = new Point(19, 20);
        ////    Point resultlocation = p.Location;
        ////    Assert.AreEqual(expectlocation, resultlocation);
        ////}

        ////[TestMethod]
        ////public void TestMethodGoToCounter_CheckLocationNotEqualToCounta_CheckResult()
        ////{
        ////    Person p = new Person(Appointment.AddressChange);
        ////    p.Counta = new Counter(new Point(20, 10), Appointment.AddressChange);
        ////    p.Location = new Point(30, 20);
        ////    bool result = p.GoToCounter();
        ////    Assert.AreEqual(false, result);
        ////}

        ////[TestMethod]
        ////public void TestMethodGoToCounter_CheckLocationNotEqualToCounta_CheckPoint()
        ////{
        ////    Person p = new Person(Appointment.AddressChange);
        ////    p.Counta = new Counter(new Point(20, 10), Appointment.AddressChange);
        ////    p.Location = new Point(30, 20);
        ////    bool result = p.GoToCounter();
        ////    Point expectlocation = new Point(29, 20);
        ////    Point resultlocation = p.Location;
        ////    Assert.AreEqual(expectlocation, resultlocation);
        ////}

        [TestMethod]
        public void TestMethodSetDestination_CheckDestinationPoint()
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
            Assert.AreEqual(point, p.DestinationPoint);
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

        //[TestMethod]
        //public void TestMethodFirstDestination()
        //{
        //    Person p = new Person(Appointment.AddressChange);
        //    Point y = new Point();
        //    p.FirstDestination(y);
        //    Point expect = new Point(480, 300);
        //    Assert.AreEqual(expect, y);
        //}

        [TestMethod]
        public void TestMethodStartMoving_CheckEnabled()
        {
            Person p = new Person(Appointment.AddressChange);
            p.StartMoving();
            bool enabled = p.personMove.Enabled;
            Assert.AreEqual(true, enabled);
        }

        [TestMethod]
        public void TestMethodStartMoving_CheckInterval()
        {
            Person p = new Person(Appointment.AddressChange);
            p.StartMoving();
            Assert.AreEqual(10, p.personMove.Interval);
        }

        [TestMethod]
        public void TestMethodMovePerson()
        {
            Person p = new Person(Appointment.AddressChange);
            p.MovePerson();
            bool enabled = p.personMove.Enabled;
            Assert.AreEqual(true, enabled);
        }

        [TestMethod]
        public void TestMethodStopPerson()
        {
            Person p = new Person(Appointment.AddressChange);
            p.StopPerson();
            bool enabled = p.personMove.Enabled;
            Assert.AreEqual(false, enabled);
        }

        [TestMethod]
        public void TestMethodReachesCounter_AddressChange_CheckIsOccupied()
        {
            Person p = new Person(Appointment.AddressChange);
            Simulator sim = new Simulator(new Form1());
            List<bool> expect = new List<bool>();
            foreach (Counter c in sim.GetAddressChangeCounterList())
            {
                if (c.Location == p.Location && c.IsOccupied == false)
                {
                    c.IsOccupied = true;
                    expect.Add(c.IsOccupied);
                }
                else
                {
                    expect.Add(c.IsOccupied);
                }
            }
            p.ReachesCounter();
            List<bool> result = new List<bool>();
            foreach (Counter c in sim.GetAddressChangeCounterList())
            {
                result.Add(c.IsOccupied);
            }
            CollectionAssert.AreEqual(expect,result);
        }
    }
}
