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

        //[TestMethod]
        //public void TestMethodSpawnPeople_AddPerson_check()
        //{
        //    Form1 f = new Form1();
        //    Simulator s = new Simulator(f);
        //    s.Time = 14;
        //    s.SpawnPeople();
        //    //int x = s.rnd.Next(350, 595);
        //    //int y = s.rnd.Next(437, 457);
        //    //Point point = new Point(x, y);
        //    Person p = new Person(Appointment.AddressChange);
        //    Assert.AreSame(p, s.TotalPeopleList[s.TotalPeopleList.Count - 1]);
        //}

        [TestMethod]
        public void TestMethodSpawnPeople_TimeCanDividedBy1_check()
        {
            Form1 f = new Form1();
            Simulator sim = new Simulator(f);
            Statistics s = new Statistics(sim);
            foreach (Counter item in sim.AddressChangeCountersList)
            {
                item.queueTime.Clear();
            }
            foreach (Counter item in sim.PermitRequestCountersList)
            {
                item.queueTime.Clear();
            }
            foreach (Counter item in sim.PropertySaleCountersList)
            {
                item.queueTime.Clear();
            }

        }

        [TestMethod]
        public void TestMethodSpawnPeople_TimeBiggerThan18Print_check()
        {
            Form1 f = new Form1();
            Simulator s = new Simulator(f);
            s.Time = 19;
            s.SpawnPeople();
            Assert.AreEqual(true, s.printed);
        }

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

