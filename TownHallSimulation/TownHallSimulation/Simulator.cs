using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Linq;
using System.Threading;
using TownHallSimulation.Properties;

namespace TownHallSimulation
{
    public class Simulator
    {
        public List<Person> TotalPeopleList;
        public List<Counter> AddressChangeCountersList;
        public List<Counter> PropertySaleCountersList;
        public List<Counter> PermitRequestCountersList;

        public double time { get; private set; }
        bool printed;
        private Random spawnRandom = new Random();
        private List<Statistics> stats ;
        Form1 form;
        Counter counter1, counter2, counter3, counter4, counter5, counter6, counter7, counter8, counter9, counter10;
        Random rnd;

        public List<Person> PersonToNavigate { get; private set; }

        public Simulator(Form1 f1)
        {
            TotalPeopleList = new List<Person>();
            AddressChangeCountersList = new List<Counter>();
            PropertySaleCountersList = new List<Counter>();
            PermitRequestCountersList = new List<Counter>();
            stats = new List<Statistics>();
            time = 8;
            this.form = f1;
            InitializeCounters();
            printed = false;
            //counter4.OnCounterReach();
            rnd = new Random();
        }

        //Creates an instance of Person with a random Appointment value each time and adds to the list.
        public void SpawnPeople()
        {
            int x = rnd.Next(350, 595);
            int y = rnd.Next(437, 457);
            Point point = new Point(x, y);
            Bitmap image = Resources.PropertySale;

            if (time < 18)
            {
                time += 0.25;
                var numberToSpawn = time >= 12 && time <= 16 ? spawnRandom.Next(10, 11) : spawnRandom.Next(0, 5);
                var types = Enum.GetValues(typeof(Appointment));
                for (int i = 0; i <= numberToSpawn; i++)
                {
                    Appointment currentType = (Appointment)types.GetValue(spawnRandom.Next(types.Length));
                    Person p = new Person(point, image, currentType);
                    TotalPeopleList.Add(p);
                    //counter4.OnCounterReach(); //to test processing
                }
                if (time % 1 == 0)
                {
                    Statistics st = new Statistics(this);
                    st.UpdateTotalNumPeopl();
                    st.CalculateAvgWaitingTime();
                    stats.Add(st);
                    foreach (Counter item in AddressChangeCountersList)
                    {
                        item.queueTime.Clear();
                    }
                    foreach (Counter item in PermitRequestCountersList)
                    {
                        item.queueTime.Clear();
                    }
                    foreach (Counter item in PropertySaleCountersList)
                    {
                        item.queueTime.Clear();
                    }
                }
            }
            else if(!printed)
            {
                printed = true;
                PrintStats();
                
            }
        }

        public bool PrintStats()
        {
            if (Microsoft.VisualBasic.Interaction.InputBox("Type \"T\" if you want to save today's stats.", "Save Dialog", "Do you want to save?") == "T")
            {
                using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "PDF file|*.pdf", ValidateNames = true })
                {
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        iTextSharp.text.Document doc = new iTextSharp.text.Document(PageSize.A4.Rotate());
                        try
                        {
                            PdfWriter.GetInstance(doc, new FileStream(sfd.FileName, FileMode.Create));
                            doc.Open();
                            foreach (Statistics item in stats)
                            {
                                doc.Add(new iTextSharp.text.Paragraph($"Total number of people: {item.TotalNrPeople} \n " +
                                    $"                                  Total number of counters open: {item.TotalNrOfCountersOpened} / {item.TotalNrOfCounters}" +
                                    $"                                           Average waiting time: {item.AverageWaitingTime}"));

                            }

                            return true;

                        }
                        catch (Exception)
                        {
                            return false;


                        }
                        finally
                        {
                            doc.Close();
                        }
                    }
                }
            }


            return false;
        }

        public void ShowStats()
        {
            string text = "";
            
                        foreach (Statistics item in stats)
                        {
                           text+=($"Time:{item.time}\n " +
                                 $"Total number of people: {item.TotalNrPeople} \n " +
                                $"Total number of counters open: {item.TotalNrOfCountersOpened} / {item.TotalNrOfCounters}" +
                                $"\nAverage waiting time: {item.CalculateAvgWaitingTime():00}" +
                                $"\n_____________________________________________________________________\n");

                        }

            MessageBox.Show(text);
        }

        //make the counters
        public void InitializeCounters()
        {
            counter1 = new Counter(new Point(275, 180), Appointment.AddressChange); counter1.IsOpened = true;
            // to check if it assigns to shortest queue
            counter1.IsOpened = true; //counter1.QueueList.Enqueue(new Person(Appointment.AddressChange)); counter1.QueueList.Enqueue(new Person(Appointment.AddressChange));
            counter2 = new Counter(new Point(340, 132), Appointment.PermitRequest); counter2.IsOpened = true;
            counter3 = new Counter(new Point(500, 132), Appointment.PropertySale); counter3.IsOpened = true;
            counter4 = new Counter(new Point(633, 132), Appointment.AddressChange); //+40 for y to make sure it stops before the counter //-170 for x to make sure it stops before the counter
            // to check if it assigns to shortest queue
            counter4.IsOpened = true; 
            counter5 = new Counter(new Point(760, 132), Appointment.PermitRequest); counter5.IsOpened = true;
            counter6 = new Counter(new Point(815, 180), Appointment.PropertySale); counter6.IsOpened = true;
            counter7 = new Counter(new Point(815, 260), Appointment.AddressChange);
            // to check if it assigns to shortest queue
            counter7.IsOpened = true; //counter7.QueueList.Enqueue(new Person(Appointment.AddressChange)); counter7.QueueList.Enqueue(new Person(Appointment.AddressChange));
            counter8 = new Counter(new Point(815, 350), Appointment.PermitRequest); counter8.IsOpened = true;
            counter9 = new Counter(new Point(275, 350), Appointment.PropertySale); counter9.IsOpened = true;
            counter10 = new Counter(new Point(275, 260), Appointment.AddressChange);
            //to check if it assigns to shortest queue
            counter10.IsOpened = true;
            AddressChangeCountersList.AddRange(new Counter[] { counter1, counter4, counter7, counter10 });
            PermitRequestCountersList.AddRange(new Counter[] { counter2, counter5, counter8 });
            PropertySaleCountersList.AddRange(new Counter[] { counter3, counter6, counter9 });
        }
        //matching the counter with the person
        public void AssignCounter(List<Person> people)
        {
            foreach (Person p in people)
           {
                if (p.centerWasReached && p.isAssigned == false)
                {
                    switch (p.TypeOfAppointment.ToString())
                    {
                        case "AddressChange":
                            //gets the shortest queue out of all counters in the list that are opened
                            int shortestQueueAC = AddressChangeCountersList.FindAll(c => c.IsOpened).Min(a => a.QueueList.Count);
                            foreach (Counter c in AddressChangeCountersList)
                            {
                                if (c.QueueList.Count == shortestQueueAC) //this is used to assign the people to the shortest queue
                                {
                                    p.destinationPoint = c.Location;//or should it be c.CounterPosition??
                                    c.QueueList.Enqueue(p);
                                    //starts the stop watch to get total process time
                                    //p.sw.Start();
                                    //for testing purposes
                                    //c.OnCounterReach();
                                    p.isAssigned = true;
                                    break; //to assure it's only assigned to 1 counter if the queues are the same length
                                }
                            }
                            break;

                        case "PropertySale":
                            int shortestQueuePS = PropertySaleCountersList.FindAll(c => c.IsOpened).Min(a => a.QueueList.Count);
                            foreach (Counter c in PropertySaleCountersList)
                            {
                                if (c.QueueList.Count == shortestQueuePS)
                                {
                                    p.destinationPoint = c.Location;//or should it be c.CounterPosition??
                                    c.QueueList.Enqueue(p);
                                    //starts the stop watch to get total process time
                                    //p.sw.Start();
                                    //for testing purposes
                                    //c.OnCounterReach();
                                    p.isAssigned = true;
                                    break; //to assure it's only assigned to 1 counter if the queues are the same length
                                }
                            }
                            break;

                        case "PermitRequest":
                            int shortestQueuePR = PermitRequestCountersList.FindAll(c => c.IsOpened).Min(a => a.QueueList.Count);
                            foreach (Counter c in PermitRequestCountersList)
                            {
                                if (c.QueueList.Count == shortestQueuePR)
                                {
                                    p.destinationPoint = c.Location;//or should it be c.CounterPosition??
                                    c.QueueList.Enqueue(p);
                                    //starts the stop watch to get total process time
                                    //p.sw.Start();
                                    //for testing purposes
                                    //c.OnCounterReach();
                                    p.isAssigned = true;
                                    break; //to assure it's only assigned to 1 counter if the queues are the same length
                                }
                            }
                            break;
                    }
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
            Point first = new Point(476, 450);
            //int x = rnd.Next(350, 595);
            //int y = rnd.Next(437, 457);
            //Point point = new Point(x, y);
            Bitmap image = Resources.PropertySale;
            Person p = new Person(first, image, Appointment.AddressChange);
            TotalPeopleList.Add(p);
            //AssignCounter(p);//assigns person to a counter on spawning
            //counter4.OnCounterReach();
        }

        public void Start()
        {
            foreach (Person p in TotalPeopleList)
            {
                p.StartMoving();
            }
        }

        public void Stop()
        {
            foreach (Person p in TotalPeopleList)
            {
                p.StopPerson();
            }
        }

        public void Draw(Graphics gr)
        {
                foreach (Person p in TotalPeopleList)
                {
                    p.DrawPerson(gr);
                }
        }
    }
}
