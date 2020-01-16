using System;
using System.Collections.Generic;
using System.Drawing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TownHallSimulation;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTestSimulator
    {
        //how to create an object with form parameter?
        //need to ask what it exactly for
        [TestMethod]
        public void TestMethodGetTotalPeopleList()
        {
            Form1 f = new Form1();
            Simulator s = new Simulator(f);
            Person p = new Person(Appointment.AddressChange);
            Person p2 = new Person(Appointment.PermitRequest);
            s.TotalPeopleList.Add(p);
            s.TotalPeopleList.Add(p2);
            List<Person> expect = new List<Person>();
            expect.Add(p);
            expect.Add(p2);
            CollectionAssert.AreEqual(expect, s.GetTotalPeopleList());
        }

        [TestMethod]
        public void TestMethodGetAddressChangeCounterList()
        {
            Form1 f = new Form1();
            Simulator s = new Simulator(f);
            List<Counter> expect = new List<Counter>();
            Counter counter1 = new Counter(new Point(275, 180), Appointment.AddressChange, s);
            Counter counter4 = new Counter(new Point(633, 132), Appointment.AddressChange, s);
            Counter counter7 = new Counter(new Point(815, 260), Appointment.AddressChange, s);
            Counter counter10 = new Counter(new Point(275, 260), Appointment.AddressChange, s);
            expect.Add(counter1);
            expect.Add(counter4);
            expect.Add(counter7);
            expect.Add(counter10);
            Form1 f1 = new Form1();
            Simulator s1 = new Simulator(f1);
            List<Counter> result = s1.GetAddressChangeCounterList();
            for (int i = 0; i < expect.Count; i++)
            {
                Assert.AreEqual(expect[i], result[i]);
            }
        }

        ////[TestMethod]
        ////public void TestMethodGetPropertySaleCountersList()
        ////{
        ////    Form1 f = new Form1();
        ////    Simulator s = new Simulator(f);
        ////    Counter c = new Counter(new Point(20, 20), Appointment.PropertySale, s);
        ////    Counter c1 = new Counter(new Point(40, 40), Appointment.PropertySale, s);
        ////    s.AddressChangeCountersList.Add(c);
        ////    s.AddressChangeCountersList.Add(c1);
        ////    List<Counter> expect = new List<Counter>();
        ////    expect.Add(c);
        ////    expect.Add(c1);
        ////    CollectionAssert.AreEqual(expect, s.GetPropertySaleCountersList());
        ////}

        ////[TestMethod]
        ////public void TestMethodGetPermitRequestCountersList()
        ////{
        ////    Form1 f = new Form1();
        ////    Simulator s = new Simulator(f);
        ////    Counter c = new Counter(new Point(20, 20), Appointment.PermitRequest, s);
        ////    Counter c1 = new Counter(new Point(40, 40), Appointment.PermitRequest, s);
        ////    s.AddressChangeCountersList.Add(c);
        ////    s.AddressChangeCountersList.Add(c1);
        ////    List<Counter> expect = new List<Counter>();
        ////    expect.Add(c);
        ////    expect.Add(c1);
        ////    CollectionAssert.AreEqual(expect, s.GetPermitRequestCountersList());
        ////}

        ////no code in simulator class for now
        //[TestMethod]
        //public void TestMethodProcessAndRemove()
        //{
        //    Form1 f = new Form1();
        //    Simulator s = new Simulator(f);

        //}

        ////create file
        //[TestMethod]
        //public void TestMethodPrintStats()
        //{
        //    Form1 f = new Form1();
        //    Simulator s = new Simulator(f);

        //}

        //[TestMethod]
        //public void TestMethodShowStats()
        //{
        //    Form1 f = new Form1();
        //    Simulator s = new Simulator(f);

        //}

        //[TestMethod]
        //public void TestMethodMakeStats()
        //{
        //    Form1 f = new Form1();
        //    Simulator s = new Simulator(f);

        //}

        //[TestMethod]
        //public void TestMethodInitializeCounters()
        //{
        //    Form1 f = new Form1();
        //    Simulator s = new Simulator(f);

        //}

        //[TestMethod]
        //public void TestMethodAssignCounter()
        //{
        //    Form1 f = new Form1();
        //    Simulator s = new Simulator(f);

        //}

        //[TestMethod]
        //public void TestMethodUpdateLabels()
        //{
        //    Form1 f = new Form1();
        //    Simulator s = new Simulator(f);

        //}

        ////[TestMethod]
        ////public void TestMethodCreateOne()
        ////{
        ////    Form1 f = new Form1();
        ////    Simulator s = new Simulator(f);
        ////    Person p = new Person(Appointment.AddressChange);
        ////    s.TotalPeopleList.Add(p);
        ////    List<Person> temp = new List<Person>();
        ////    temp.Add(p);
        ////    CollectionAssert.AreEqual(temp,s.TotalPeopleList);
        ////}

        //////what means lock?
        ////[TestMethod]
        ////public void TestMethodNavigatePerson()
        ////{
        ////    Form1 f = new Form1();
        ////    Simulator s = new Simulator(f);
        ////}

        ////[TestMethod]
        ////public void TestMethodGetListofSpawnedPeople()
        ////{
        ////    Form1 f = new Form1();
        ////    Simulator s = new Simulator(f);
        ////    List<Person> temp = s.TotalPeopleList;
        ////    List<Person> result = s.GetListofSpawnedPeople();
        ////    CollectionAssert.AreEqual(temp,result);
        ////}
    }
}

