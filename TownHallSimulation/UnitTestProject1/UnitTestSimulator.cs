using System;
using System.Collections.Generic;
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
        public void TestMethodSpawnPeople()
        {
            Form1 f = new Form1();
            Simulator s = new Simulator(f);

        }

        //no code in simulator class for now
        [TestMethod]
        public void TestMethodProcessAndRemove()
        {
            Form1 f = new Form1();
            Simulator s = new Simulator(f);

        }

        //create file
        [TestMethod]
        public void TestMethodPrintStats()
        {
            Form1 f = new Form1();
            Simulator s = new Simulator(f);

        }

        [TestMethod]
        public void TestMethodShowStats()
        {
            Form1 f = new Form1();
            Simulator s = new Simulator(f);

        }

        [TestMethod]
        public void TestMethodMakeStats()
        {
            Form1 f = new Form1();
            Simulator s = new Simulator(f);

        }

        [TestMethod]
        public void TestMethodInitializeCounters()
        {
            Form1 f = new Form1();
            Simulator s = new Simulator(f);

        }

        [TestMethod]
        public void TestMethodAssignCounter()
        {
            Form1 f = new Form1();
            Simulator s = new Simulator(f);

        }

        [TestMethod]
        public void TestMethodUpdateLabels()
        {
            Form1 f = new Form1();
            Simulator s = new Simulator(f);

        }

        //[TestMethod]
        //public void TestMethodCreateOne()
        //{
        //    Form1 f = new Form1();
        //    Simulator s = new Simulator(f);
        //    Person p = new Person(Appointment.AddressChange);
        //    s.TotalPeopleList.Add(p);
        //    List<Person> temp = new List<Person>();
        //    temp.Add(p);
        //    CollectionAssert.AreEqual(temp,s.TotalPeopleList);
        //}

        ////what means lock?
        //[TestMethod]
        //public void TestMethodNavigatePerson()
        //{
        //    Form1 f = new Form1();
        //    Simulator s = new Simulator(f);
        //}

        //[TestMethod]
        //public void TestMethodGetListofSpawnedPeople()
        //{
        //    Form1 f = new Form1();
        //    Simulator s = new Simulator(f);
        //    List<Person> temp = s.TotalPeopleList;
        //    List<Person> result = s.GetListofSpawnedPeople();
        //    CollectionAssert.AreEqual(temp,result);
        //}
    }
}
