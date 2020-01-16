using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
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
            Counter countera = new Counter(new Point(275, 180), Appointment.AddressChange, s); countera.IsOpened = true;
            Counter counterb = new Counter(new Point(633, 132), Appointment.AddressChange, s);
            Counter counterc = new Counter(new Point(815, 260), Appointment.AddressChange, s);
            Counter counterd = new Counter(new Point(275, 260), Appointment.AddressChange, s);
            expect.AddRange(new Counter[] { countera,counterb,counterc,counterd });
            List<Counter> result = s.GetAddressChangeCounterList();
            for (int i = 0; i < expect.Count; i++)
            {
                Assert.AreEqual(true,CheckCounter(expect[i],result[i]));
            }
        }

        private bool CheckCounter(Counter a, Counter b)
        {
            if((a.Location == b.Location)&&(a._appointmentToProcess == b._appointmentToProcess)&&(a.sim == b.sim))
            {
                return true;

            }
            return false;
        }

        [TestMethod]
        public void TestMethodPermitRequestCountersList()
        {
            Form1 f = new Form1();
            Simulator s = new Simulator(f);
            List<Counter> expect = new List<Counter>();
            Counter countera = new Counter(new Point(340, 132), Appointment.PermitRequest, s); countera.IsOpened = true;
            Counter counterb = new Counter(new Point(760, 132), Appointment.PermitRequest, s); counterb.IsOpened = true;
            Counter counterc = new Counter(new Point(815, 350), Appointment.PermitRequest, s);
            expect.AddRange(new Counter[] { countera, counterb, counterc });
            List<Counter> result = s.GetPermitRequestCountersList();
            for (int i = 0; i < expect.Count; i++)
            {
                Assert.AreEqual(true, CheckCounter(expect[i], result[i]));
            }
        }

        [TestMethod]
        public void TestMethodPropertySaleCountersList()
        {
            Form1 f = new Form1();
            Simulator s = new Simulator(f);
            List<Counter> expect = new List<Counter>();
            Counter countera = new Counter(new Point(500, 132), Appointment.PropertySale, s); countera.IsOpened = true;
            Counter counterb = new Counter(new Point(815, 180), Appointment.PropertySale, s); counterb.IsOpened = true;
            Counter counterc = new Counter(new Point(275, 350), Appointment.PropertySale, s);
            expect.AddRange(new Counter[] { countera, counterb, counterc });
            List<Counter> result = s.GetPropertySaleCountersList();
            for (int i = 0; i < expect.Count; i++)
            {
                Assert.AreEqual(true, CheckCounter(expect[i], result[i]));
            }
        }

        [TestMethod]
        public void TestMethodSpawnPeople_TimeSmallerThan18_check()
        {
            Form1 f = new Form1();
            Simulator s = new Simulator(f);
            s.Time = 17;
            s.SpawnPeople();
            Assert.AreEqual(17.25,s.Time);
        }

        [TestMethod]
        public void TestMethodSpawnPeople_TimeBiggerSmallerThan12BiggerThan14_check()
        {
            Form1 f = new Form1();
            Simulator s = new Simulator(f);
            s.Time = 13;
            s.SpawnPeople();
            Random expect = new Random();
            expect.Next(4,6);
            Assert.AreEqual(expect.ToString(), s.spawnRandom.ToString());
        }

        [TestMethod]
        public void TestMethodSpawnPeople_TimeBiggerThan14SmallerThan16_check()
        {
            Form1 f = new Form1();
            Simulator s = new Simulator(f);
            s.Time = 15;
            s.SpawnPeople();
            Random expect = new Random();
            expect.Next(0, 3);
            Assert.AreEqual(expect.ToString(), s.spawnRandom.ToString());
        }

        [TestMethod]
        public void TestMethodSpawnPeople_TimeCanDividedBy1_check_UpdateTotalNumPeopl()
        {
            Form1 f = new Form1();
            Simulator sim = new Simulator(f);
            int expect = sim.GetTotalPeopleList().Count;
            Statistics s = new Statistics(sim);
            sim.SpawnPeople();
            int result = s.TotalNrPeople;
            Assert.AreEqual(expect, result);
        }

        [TestMethod]
        public void TestMethodSpawnPeople_TimeCanDividedBy1_check_CalculateAvgWaitingTime_Test2()
        {
            Form1 f = new Form1();
            Simulator sim = new Simulator(f);
            Statistics s = new Statistics(sim);
            sim.AddressChangeCountersList[0].queueTime.Add(5.0);
            sim.PropertySaleCountersList[0].queueTime.Add(7.0);
            sim.PermitRequestCountersList[0].queueTime.Add(10.0);
            sim.TotalPeopleList.Add(new Person(Appointment.PermitRequest));
            sim.TotalPeopleList.Add(new Person(Appointment.AddressChange));
            double expect = 11;
            double result = s.CalculateAvgWaitingTime();
            Assert.AreEqual(expect, result);
        }

        [TestMethod]
        public void TestMethodSpawnPeople_TimeCanDividedBy1_check_AddressChangeCountersList()
        {
            Form1 f = new Form1();
            Simulator s = new Simulator(f);
            s.SpawnPeople();
            for (int i = 0; i < s.AddressChangeCountersList.Count; i++)
            {
                Assert.AreEqual(0,s.AddressChangeCountersList[i].queueTime.Count);
            }
        }

        [TestMethod]
        public void TestMethodSpawnPeople_TimeCanDividedBy1_check_PermitRequestCountersList()
        {
            Form1 f = new Form1();
            Simulator s = new Simulator(f);
            s.SpawnPeople();
            for (int i = 0; i < s.PermitRequestCountersList.Count; i++)
            {
                Assert.AreEqual(0, s.PermitRequestCountersList[i].queueTime.Count);
            }
        }

        [TestMethod]
        public void TestMethodSpawnPeople_TimeCanDividedBy1_check_PropertySaleCountersList()
        {
            Form1 f = new Form1();
            Simulator s = new Simulator(f);
            s.SpawnPeople();
            for (int i = 0; i < s.PropertySaleCountersList.Count; i++)
            {
                Assert.AreEqual(0, s.PropertySaleCountersList[i].queueTime.Count);
            }
        }

        public List<Person> GetTempPerson(Simulator s)
        {
            List<Person> templist = new List<Person>();
            Person person1 = new Person(new Point(275, 180), null, Appointment.AddressChange, s);
            person1.IsAssigned = false;
            person1.ReachesCounter();
            s.AddressChangeCountersList[1].QueueList.Enqueue(person1);
            Person person11 = new Person(new Point(275, 180), null, Appointment.AddressChange, s);
            person1.IsAssigned = false;
            person1.ReachesCounter();
            s.AddressChangeCountersList[1].QueueList.Enqueue(person11);
            Person person12 = new Person(new Point(275, 180), null, Appointment.AddressChange, s);
            person1.IsAssigned = false;
            person1.ReachesCounter();
            s.AddressChangeCountersList[0].QueueList.Enqueue(person12);
            Person person2 = new Person(new Point(340, 132), null, Appointment.PermitRequest, s);
            person2.IsAssigned = false;
            person2.ReachesCounter();
            Person person3 = new Person(new Point(340, 132), null, Appointment.PermitRequest, s);
            person3.IsAssigned = false;
            person3.ReachesCounter();
            Person person4 = new Person(new Point(500, 132), null, Appointment.PropertySale, s);
            person4.IsAssigned = false;
            person4.ReachesCounter();
            Person person5 = new Person(new Point(500, 132), null, Appointment.PropertySale, s);
            person5.IsAssigned = false;
            person5.ReachesCounter();
            Person person6 = new Person(new Point(500, 132), null, Appointment.PropertySale, s);
            person6.IsAssigned = false;
            person6.ReachesCounter();
            templist.AddRange(new Person[] { person1, person2, person3, person4, person5, person6 });
            return templist;
        }

        [TestMethod]
        public void TestMethodAssignCounter_AddressChange_check()
        {
            Form1 f = new Form1();
            Simulator s = new Simulator(f);
            List<Person> templist = new List<Person>();
            Person person1 = new Person(new Point(275, 180), null, Appointment.AddressChange, s);
            person1.IsAssigned = false;
            person1.ReachesCounter();
            s.AddressChangeCountersList[1].QueueList.Enqueue(person1);
            Person person2 = new Person(new Point(275, 180), null, Appointment.AddressChange, s);
            person2.IsAssigned = false;
            person2.ReachesCounter();
            s.AddressChangeCountersList[1].QueueList.Enqueue(person2);
            Person person3 = new Person(new Point(275, 180), null, Appointment.AddressChange, s);
            person3.IsAssigned = false;
            person3.ReachesCounter();
            s.AddressChangeCountersList[0].QueueList.Enqueue(person3);
            person3.CenterWasReached = true;
            templist.AddRange(new Person[] { person1, person2, person3 });
            s.AssignCounter(templist);
            Assert.AreEqual(true, person3.IsAssigned);
        }

        [TestMethod]
        public void TestMethodAssignCounter_PermitRequest_check()
        {
            Form1 f = new Form1();
            Simulator s = new Simulator(f);
            List<Person> templist = new List<Person>();
            Person person1 = new Person(new Point(340, 132), null, Appointment.PermitRequest, s);
            person1.IsAssigned = false;
            person1.ReachesCounter();
            s.AddressChangeCountersList[1].QueueList.Enqueue(person1);
            Person person2 = new Person(new Point(340, 132), null, Appointment.PermitRequest, s);
            person2.IsAssigned = false;
            person2.ReachesCounter();
            s.AddressChangeCountersList[1].QueueList.Enqueue(person2);
            Person person3 = new Person(new Point(340, 132), null, Appointment.PermitRequest, s);
            person3.IsAssigned = false;
            person3.ReachesCounter();
            s.AddressChangeCountersList[0].QueueList.Enqueue(person3);
            person3.CenterWasReached = true;
            templist.AddRange(new Person[] { person1, person2, person3 });
            s.AssignCounter(templist);
            Assert.AreEqual(true, person3.IsAssigned);
        }

        [TestMethod]
        public void TestMethodAssignCounter_PropertySale_check()
        {
            Form1 f = new Form1();
            Simulator s = new Simulator(f);
            List<Person> templist = new List<Person>();
            Person person1 = new Person(new Point(500, 132), null, Appointment.PropertySale, s);
            person1.IsAssigned = false;
            person1.ReachesCounter();
            s.AddressChangeCountersList[1].QueueList.Enqueue(person1);
            Person person2 = new Person(new Point(500, 132), null, Appointment.PropertySale, s);
            person2.IsAssigned = false;
            person2.ReachesCounter();
            s.AddressChangeCountersList[1].QueueList.Enqueue(person2);
            Person person3 = new Person(new Point(500, 132), null, Appointment.PropertySale, s);
            person3.IsAssigned = false;
            person3.ReachesCounter();
            s.AddressChangeCountersList[0].QueueList.Enqueue(person3);
            person3.CenterWasReached = true;
            templist.AddRange(new Person[] { person1, person2, person3 });
            s.AssignCounter(templist);
            Assert.AreEqual(true, person3.IsAssigned);
        }

        //if you want to run the test please only run this one at a time
        //as there is a dialog will be opened,so if run all the test it will catch an exception.
        //[TestMethod]
        //public void TestMethodSpawnPeople_TimeBiggerThan18Print_check()
        //{
        //    Form1 f = new Form1();
        //    Simulator s = new Simulator(f);
        //    s.Time = 19;
        //    s.SpawnPeople();
        //    Assert.AreEqual(true, s.printed);
        //}

        [TestMethod]
        public void TestMethodInitializeCounters_counter1_check()
        {
            Form1 f = new Form1();
            Simulator s = new Simulator(f);
            Counter c1 = new Counter(new Point(275, 180), Appointment.AddressChange, s); c1.IsOpened = true;
            s.InitializeCounters();
            Assert.AreEqual(true,CheckCounter(c1,s.counter1));
        }

        [TestMethod]
        public void TestMethodInitializeCounters_counter2_check()
        {
            Form1 f = new Form1();
            Simulator s = new Simulator(f);
            Counter c2 = new Counter(new Point(340, 132), Appointment.PermitRequest, s); c2.IsOpened = true;
            s.InitializeCounters();
            Assert.AreEqual(true, CheckCounter(c2, s.counter2));
        }

        [TestMethod]
        public void TestMethodInitializeCounters_counter3_check()
        {
            Form1 f = new Form1();
            Simulator s = new Simulator(f);
            Counter c3 = new Counter(new Point(500, 132), Appointment.PropertySale, s); c3.IsOpened = true;
            s.InitializeCounters();
            Assert.AreEqual(true, CheckCounter(c3, s.counter3));
        }

        [TestMethod]
        public void TestMethodInitializeCounters_counter4_check()
        {
            Form1 f = new Form1();
            Simulator s = new Simulator(f);
            Counter c4 = new Counter(new Point(633, 132), Appointment.AddressChange, s); c4.IsOpened = true;
            s.InitializeCounters();
            Assert.AreEqual(true, CheckCounter(c4, s.counter4));
        }

        [TestMethod]
        public void TestMethodInitializeCounters_counter5_check()
        {
            Form1 f = new Form1();
            Simulator s = new Simulator(f);
            Counter c5 = new Counter(new Point(760, 132), Appointment.PermitRequest, s); c5.IsOpened = true;
            s.InitializeCounters();
            Assert.AreEqual(true, CheckCounter(c5, s.counter5));
        }

        [TestMethod]
        public void TestMethodInitializeCounters_counter6_check()
        {
            Form1 f = new Form1();
            Simulator s = new Simulator(f);
            Counter c6 = new Counter(new Point(815, 180), Appointment.PropertySale, s); c6.IsOpened = true;
            s.InitializeCounters();
            Assert.AreEqual(true, CheckCounter(c6, s.counter6));
        }

        [TestMethod]
        public void TestMethodInitializeCounters_counter7_check()
        {
            Form1 f = new Form1();
            Simulator s = new Simulator(f);
            Counter c7 = new Counter(new Point(815, 260), Appointment.AddressChange, s);
            s.InitializeCounters();
            Assert.AreEqual(true, CheckCounter(c7, s.counter7));
        }

        [TestMethod]
        public void TestMethodInitializeCounters_counter8_check()
        {
            Form1 f = new Form1();
            Simulator s = new Simulator(f);
            Counter c8 = new Counter(new Point(815, 350), Appointment.PermitRequest, s);
            s.InitializeCounters();
            Assert.AreEqual(true, CheckCounter(c8, s.counter8));
        }

        [TestMethod]
        public void TestMethodInitializeCounters_counter9_check()
        {
            Form1 f = new Form1();
            Simulator s = new Simulator(f);
            Counter c9 = new Counter(new Point(275, 350), Appointment.PropertySale, s);
            s.InitializeCounters();
            Assert.AreEqual(true, CheckCounter(c9, s.counter9));
        }

        [TestMethod]
        public void TestMethodInitializeCounters_counter10_check()
        {
            Form1 f = new Form1();
            Simulator s = new Simulator(f);
            Counter c10 = new Counter(new Point(275, 260), Appointment.AddressChange, s);
            s.InitializeCounters();
            Assert.AreEqual(true, CheckCounter(c10, s.counter10));
        }

        [TestMethod]
        public void TestMethodInitializeCounters_GetAddressChangeCounterList()
        {
            Form1 f = new Form1();
            Simulator s = new Simulator(f);
            List<Counter> expect = new List<Counter>();
            Counter countera = new Counter(new Point(275, 180), Appointment.AddressChange, s); countera.IsOpened = true;
            Counter counterb = new Counter(new Point(633, 132), Appointment.AddressChange, s);
            Counter counterc = new Counter(new Point(815, 260), Appointment.AddressChange, s);
            Counter counterd = new Counter(new Point(275, 260), Appointment.AddressChange, s);
            expect.AddRange(new Counter[] { countera, counterb, counterc, counterd });
            List<Counter> result = s.GetAddressChangeCounterList();
            for (int i = 0; i < expect.Count; i++)
            {
                Assert.AreEqual(true, CheckCounter(expect[i], result[i]));
            }
        }

        [TestMethod]
        public void TestMethodInitializeCounters_PermitRequestCountersList()
        {
            Form1 f = new Form1();
            Simulator s = new Simulator(f);
            List<Counter> expect = new List<Counter>();
            Counter countera = new Counter(new Point(340, 132), Appointment.PermitRequest, s); countera.IsOpened = true;
            Counter counterb = new Counter(new Point(760, 132), Appointment.PermitRequest, s); counterb.IsOpened = true;
            Counter counterc = new Counter(new Point(815, 350), Appointment.PermitRequest, s);
            expect.AddRange(new Counter[] { countera, counterb, counterc });
            List<Counter> result = s.GetPermitRequestCountersList();
            for (int i = 0; i < expect.Count; i++)
            {
                Assert.AreEqual(true, CheckCounter(expect[i], result[i]));
            }
        }

        [TestMethod]
        public void TestMethodInitializeCounters_PropertySaleCountersList()
        {
            Form1 f = new Form1();
            Simulator s = new Simulator(f);
            List<Counter> expect = new List<Counter>();
            Counter countera = new Counter(new Point(500, 132), Appointment.PropertySale, s); countera.IsOpened = true;
            Counter counterb = new Counter(new Point(815, 180), Appointment.PropertySale, s); counterb.IsOpened = true;
            Counter counterc = new Counter(new Point(275, 350), Appointment.PropertySale, s);
            expect.AddRange(new Counter[] { countera, counterb, counterc });
            List<Counter> result = s.GetPropertySaleCountersList();
            for (int i = 0; i < expect.Count; i++)
            {
                Assert.AreEqual(true, CheckCounter(expect[i], result[i]));
            }
        }

        [TestMethod]
        public void TestMethodUpdateLabels_check_Counter1()
        {
            Form1 f = new Form1();
            Simulator s = new Simulator(f);
            s.UpdateLabels();
            string expect = "People waiting: \n" + s.counter1.QueueList.Count;
            Assert.AreEqual(expect, f.lblCounter1.Text);
        }

        [TestMethod]
        public void TestMethodUpdateLabels_check_Counter2()
        {
            Form1 f = new Form1();
            Simulator s = new Simulator(f);
            s.UpdateLabels();
            string expect = "People waiting: \n" + s.counter2.QueueList.Count;
            Assert.AreEqual(expect, f.lblCounter1.Text);
        }

        [TestMethod]
        public void TestMethodUpdateLabels_check_Counter3()
        {
            Form1 f = new Form1();
            Simulator s = new Simulator(f);
            s.UpdateLabels();
            string expect = "People waiting: \n" + s.counter3.QueueList.Count;
            Assert.AreEqual(expect, f.lblCounter1.Text);
        }

        [TestMethod]
        public void TestMethodUpdateLabels_check_Counter4()
        {
            Form1 f = new Form1();
            Simulator s = new Simulator(f);
            s.UpdateLabels();
            string expect = "People waiting: \n" + s.counter4.QueueList.Count;
            Assert.AreEqual(expect, f.lblCounter1.Text);
        }

        [TestMethod]
        public void TestMethodUpdateLabels_check_Counter5()
        {
            Form1 f = new Form1();
            Simulator s = new Simulator(f);
            s.UpdateLabels();
            string expect = "People waiting: \n" + s.counter5.QueueList.Count;
            Assert.AreEqual(expect, f.lblCounter1.Text);
        }

        [TestMethod]
        public void TestMethodUpdateLabels_check_Counter6()
        {
            Form1 f = new Form1();
            Simulator s = new Simulator(f);
            s.UpdateLabels();
            string expect = "People waiting: \n" + s.counter6.QueueList.Count;
            Assert.AreEqual(expect, f.lblCounter1.Text);
        }

        [TestMethod]
        public void TestMethodUpdateLabels_check_Counter7()
        {
            Form1 f = new Form1();
            Simulator s = new Simulator(f);
            s.UpdateLabels();
            string expect = "People waiting: \n" + s.counter7.QueueList.Count;
            Assert.AreEqual(expect, f.lblCounter1.Text);
        }

        [TestMethod]
        public void TestMethodUpdateLabels_check_Counter8()
        {
            Form1 f = new Form1();
            Simulator s = new Simulator(f);
            s.UpdateLabels();
            string expect = "People waiting: \n" + s.counter8.QueueList.Count;
            Assert.AreEqual(expect, f.lblCounter1.Text);
        }

        [TestMethod]
        public void TestMethodUpdateLabels_check_Counter9()
        {
            Form1 f = new Form1();
            Simulator s = new Simulator(f);
            s.UpdateLabels();
            string expect = "People waiting: \n" + s.counter9.QueueList.Count;
            Assert.AreEqual(expect, f.lblCounter1.Text);
        }

        [TestMethod]
        public void TestMethodUpdateLabels_check_Counter10()
        {
            Form1 f = new Form1();
            Simulator s = new Simulator(f);
            s.UpdateLabels();
            string expect = "People waiting: \n" + s.counter10.QueueList.Count;
            Assert.AreEqual(expect, f.lblCounter1.Text);
        }

        [TestMethod]
        public void TestMethodStart_check_NullValue()
        {
            Form1 f = new Form1();
            Simulator s = new Simulator(f);
            s.TotalPeopleList.Add(null);
            Person p = new Person(Appointment.AddressChange);
            s.TotalPeopleList.Add(p);
            List<Person> expect = new List<Person>();
            expect.Add(p);
            s.Start();
            CollectionAssert.AreEqual(expect, s.TotalPeopleList);
        }

        [TestMethod]
        public void TestMethodStart_check_Interval()
        {
            Form1 f = new Form1();
            Simulator s = new Simulator(f);
            s.TotalPeopleList.Add(null);
            Person p = new Person(Appointment.AddressChange);
            s.TotalPeopleList.Add(p);
            List<Person> expect = new List<Person>();
            expect.Add(p);
            s.Start();
            Assert.AreEqual(10, p.personMove.Interval);
        }

        [TestMethod]
        public void TestMethodStart_check_Enabled()
        {
            Form1 f = new Form1();
            Simulator s = new Simulator(f);
            s.TotalPeopleList.Add(null);
            Person p = new Person(Appointment.AddressChange);
            s.TotalPeopleList.Add(p);
            List<Person> expect = new List<Person>();
            expect.Add(p);
            s.Start();
            Assert.AreEqual(true, p.personMove.Enabled);
        }

        [TestMethod]
        public void TestMethodStop_check_NullValue()
        {
            Form1 f = new Form1();
            Simulator s = new Simulator(f);
            s.TotalPeopleList.Add(null);
            Person p = new Person(Appointment.AddressChange);
            s.TotalPeopleList.Add(p);
            List<Person> expect = new List<Person>();
            expect.Add(p);
            s.Stop();
            CollectionAssert.AreEqual(expect, s.TotalPeopleList);
        }

        [TestMethod]
        public void TestMethodStop_check_SpawnTimer()
        {
            Form1 f = new Form1();
            Simulator s = new Simulator(f);
            s.Stop();
            bool result = f.SpawnTimer.Enabled;
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void TestMethodStop_check_Enabled()
        {
            Form1 f = new Form1();
            Simulator s = new Simulator(f);
            s.TotalPeopleList.Add(null);
            Person p = new Person(Appointment.AddressChange);
            s.TotalPeopleList.Add(p);
            List<Person> expect = new List<Person>();
            expect.Add(p);
            s.Stop();
            Assert.AreEqual(false, p.personMove.Enabled);
        }

        [TestMethod]
        public void TestMethodreset_check_TotalPeopleList()
        {
            Form1 f = new Form1();
            Simulator s = new Simulator(f);
            s.reset();
            List<Person> expect = new List<Person>();
            CollectionAssert.AreEqual(expect, s.TotalPeopleList);
        }

        [TestMethod]
        public void TestMethodreset_check_AddressChangeCountersList()
        {
            Form1 f = new Form1();
            Simulator s = new Simulator(f);
            List<Counter> expect = new List<Counter>();
            s.reset();
            Counter countera = new Counter(new Point(275, 180), Appointment.AddressChange, s); countera.IsOpened = true;
            Counter counterb = new Counter(new Point(633, 132), Appointment.AddressChange, s);
            Counter counterc = new Counter(new Point(815, 260), Appointment.AddressChange, s);
            Counter counterd = new Counter(new Point(275, 260), Appointment.AddressChange, s);
            expect.AddRange(new Counter[] { countera, counterb, counterc, counterd });
            List<Counter> result = s.GetAddressChangeCounterList();
            for (int i = 0; i < expect.Count; i++)
            {
                Assert.AreEqual(true, CheckCounter(expect[i], result[i]));
            }
        }

        [TestMethod]
        public void TestMethodreset_check_PropertySaleCountersList()
        {
            Form1 f = new Form1();
            Simulator s = new Simulator(f);
            List<Counter> expect = new List<Counter>();
            s.reset();
            Counter countera = new Counter(new Point(500, 132), Appointment.PropertySale, s); countera.IsOpened = true;
            Counter counterb = new Counter(new Point(815, 180), Appointment.PropertySale, s); counterb.IsOpened = true;
            Counter counterc = new Counter(new Point(275, 350), Appointment.PropertySale, s);
            expect.AddRange(new Counter[] { countera, counterb, counterc });
            List<Counter> result = s.GetPropertySaleCountersList();
            for (int i = 0; i < expect.Count; i++)
            {
                Assert.AreEqual(true, CheckCounter(expect[i], result[i]));
            }
        }

        [TestMethod]
        public void TestMethodreset_check_PermitRequestCountersList()
        {
            Form1 f = new Form1();
            Simulator s = new Simulator(f);
            List<Counter> expect = new List<Counter>();
            Counter countera = new Counter(new Point(340, 132), Appointment.PermitRequest, s); countera.IsOpened = true;
            Counter counterb = new Counter(new Point(760, 132), Appointment.PermitRequest, s); counterb.IsOpened = true;
            Counter counterc = new Counter(new Point(815, 350), Appointment.PermitRequest, s);
            expect.AddRange(new Counter[] { countera, counterb, counterc });
            List<Counter> result = s.GetPermitRequestCountersList();
            for (int i = 0; i < expect.Count; i++)
            {
                Assert.AreEqual(true, CheckCounter(expect[i], result[i]));
            }
        }

        [TestMethod]
        public void TestMethodreset_check_stats()
        {
            Form1 f = new Form1();
            Simulator s = new Simulator(f);
            s.reset();
            List<Statistics> expect = new List<Statistics>();
            CollectionAssert.AreEqual(expect, s.stats);
        }

        [TestMethod]
        public void TestMethodreset_check_Time()
        {
            Form1 f = new Form1();
            Simulator s = new Simulator(f);
            s.reset();
            Assert.AreEqual(8, s.Time);
        }

        [TestMethod]
        public void TestMethodreset_check_printed()
        {
            Form1 f = new Form1();
            Simulator s = new Simulator(f);
            s.reset();
            Assert.AreEqual(false, s.printed);
        }

        [TestMethod]
        public void TestMethodreset_check_rnd()
        {
            Form1 f = new Form1();
            Simulator s = new Simulator(f);
            s.reset();
            Random expect = new Random();
            Assert.AreEqual(expect.ToString(), s.rnd.ToString());
        }
    }
}

