using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TownHallSimulation;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTestPerson
    {
        [TestMethod]
        public void TestMethodGetPersonId()
        {
            Person p = new Person(Appointment.AddressChange);
            int id = p.GetPersonId();
            Assert.AreEqual(1,id);
        }
    }
}
