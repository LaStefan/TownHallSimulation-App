using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace TownHallSimulation
{
    public class Simulator
    {
        public List<Person> TotalPeopleList;
        public List<Counter> AddressChangeCountersList;
        public List<Counter> PropertySaleCountersList;
        public List<Counter> PermitRequestCountersList;
        private double time;
        private Random spawnRandom = new Random();
        private Statistics stats;
        Form1 form;
        Counter counter1, counter2, counter3, counter4, counter5, counter6, counter7, counter8, counter9, counter10;

        public Simulator(Form1 f1)
        {
            TotalPeopleList = new List<Person>();
            AddressChangeCountersList = new List<Counter>();
            PropertySaleCountersList = new List<Counter>();
            PermitRequestCountersList = new List<Counter>();
            time = 8;
            this.form = f1;
            InitializeCounters();
            //counter1.OnCounterReach(); //to test the processing
        }

        //Creates an instance of Person with a random Appointment value each time and adds to the list.
        public void SpawnPeople()
        {
            if (time < 18)
            {
                time += 0.25;
                var numberToSpawn = time >= 12 && time <= 16 ? spawnRandom.Next(10, 11) : spawnRandom.Next(0, 2);
                var types = Enum.GetValues(typeof(Appointment));
                for (int i = 0; i <= numberToSpawn; i++)
                {
                    Appointment currentType = (Appointment)types.GetValue(spawnRandom.Next(types.Length));
                    TotalPeopleList.Add(new Person(currentType));
                }
            }
        }

        //When a visitor reaches assigned counter and it's free processing starts. Still need to implement synchronization.
        public void ProcessAndRemove(Person p)
        {
        }

        public void MakeStats()
        {

        }
        public void InitializeCounters()
        {
            counter1 = new Counter(new Point(260, 187), Appointment.AddressChange); counter1.IsOpened = true;
            // to check if it assigns to shortest queue
            counter1.IsOpened = true; counter1.QueueList.Enqueue(new Person(Appointment.AddressChange)); counter1.QueueList.Enqueue(new Person(Appointment.AddressChange));
            counter2 = new Counter(new Point(413, 92), Appointment.PermitRequest); counter2.IsOpened = true;
            counter3 = new Counter(new Point(620, 92), Appointment.PropertySale); counter3.IsOpened = true;
            counter4 = new Counter(new Point(803, 92), Appointment.AddressChange);
            // to check if it assigns to shortest queue
            counter4.IsOpened = true; 
            counter8 = new Counter(new Point(1103, 404), Appointment.PermitRequest);
            counter5 = new Counter(new Point(971, 92), Appointment.PermitRequest);
            counter6 = new Counter(new Point(1103, 187), Appointment.PropertySale); 
            counter7 = new Counter(new Point(1103, 293), Appointment.AddressChange);
            // to check if it assigns to shortest queue
            counter7.IsOpened = true; counter7.QueueList.Enqueue(new Person(Appointment.AddressChange)); counter7.QueueList.Enqueue(new Person(Appointment.AddressChange));
            counter8 = new Counter(new Point(1103, 404), Appointment.PermitRequest);
            counter9 = new Counter(new Point(260, 404), Appointment.PropertySale); 
            counter10 = new Counter(new Point(260, 297), Appointment.AddressChange);
            //to check if it assigns to shortest queue
            counter10.IsOpened = true;
            counter8 = new Counter(new Point(1103, 404), Appointment.PermitRequest);
            AddressChangeCountersList.AddRange(new Counter[] { counter1, counter4, counter7, counter10 });
            PermitRequestCountersList.AddRange(new Counter[] { counter2, counter5, counter8 });
            PropertySaleCountersList.AddRange(new Counter[] { counter3, counter6, counter9 });
        }
        public void AssignCounter(List<Person> people)
        {
            foreach (Person p in people)
            {
                switch (p.TypeOfAppointment.ToString())
                {
                    case "AddressChange":
                        //gets the shortest queue out of all counters in the list that are opened
                        int shortestQueueAC = AddressChangeCountersList.FindAll(c => c.IsOpened).Min(a => a.QueueList.Count);
                        foreach (Counter c in AddressChangeCountersList)
                        {
                            if (c.IsOpened && c.QueueList.Count == shortestQueueAC) //this is used to assign the people to the shortest queue
                            {
                                p.destinationPoint = c.Location;//or should it be c.CounterPosition??
                                c.QueueList.Enqueue(p);
                                break; //to assure it's only assigned to 1 counter if the queues are the same length
                            }
                        }
                        break;

                    case "PropertySale":
                        int shortestQueuePS = PropertySaleCountersList.FindAll(c => c.IsOpened).Min(a => a.QueueList.Count);
                        foreach (Counter c in PropertySaleCountersList)
                        {
                            if (c.IsOpened && c.QueueList.Count == shortestQueuePS)
                            {
                                p.destinationPoint = c.Location;//or should it be c.CounterPosition??
                                c.QueueList.Enqueue(p);
                                break; //to assure it's only assigned to 1 counter if the queues are the same length
                            }
                        }
                        break;

                    case "PermitRequest":
                        int shortestQueuePR = PropertySaleCountersList.FindAll(c => c.IsOpened).Min(a => a.QueueList.Count);
                        foreach (Counter c in PermitRequestCountersList)
                        {
                            if (c.IsOpened && c.QueueList.Count == shortestQueuePR) 
                            {
                                p.destinationPoint = c.Location;//or should it be c.CounterPosition??
                                c.QueueList.Enqueue(p);
                                break; //to assure it's only assigned to 1 counter if the queues are the same length
                            }
                        }
                        break;
                }
            }
        }

        public void UpdateLabels()
        {
            form.lblCounter1.Text = "People waiting: \n" + counter1.QueueList.Count;
            form.lblCounter2.Text = "People waiting: \n" + counter2.QueueList.Count;
            form.lblCounter3.Text = "People waiting: \n" + counter3.QueueList.Count;
            form.lblCounter4.Text = "People waiting: \n" + counter4.QueueList.Count;
            form.lblCounter5.Text = "People waiting: \n" + counter5.QueueList.Count;
            form.lblCounter6.Text = "People waiting: \n" + counter6.QueueList.Count;
            form.lblCounter7.Text = "People waiting: \n" + counter7.QueueList.Count;
            form.lblCounter8.Text = "People waiting: \n" + counter8.QueueList.Count;
            form.lblCounter9.Text = "People waiting: \n" + counter9.QueueList.Count;
            form.lblCounter10.Text = "People waiting: \n" + counter10.QueueList.Count;
        }

        //method to test the shortest queue; can be deleted later
        public void CreateOne()
        {
            Person p = new Person(Appointment.AddressChange);
            TotalPeopleList.Add(p);
        }
    }
}
