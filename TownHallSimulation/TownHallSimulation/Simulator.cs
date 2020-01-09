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
        //Fields
        
        public List<Counter> AddressChangeCountersList;
        public List<Counter> PropertySaleCountersList;
        public List<Counter> PermitRequestCountersList;
        bool printed;
        Form1 form;
        public Counter counter1, counter2, counter3, counter4, counter5, counter6, counter7, counter8, counter9, counter10;
        Random rnd;
        private Random spawnRandom = new Random();
        private List<Statistics> stats;
        //Properties
        public double Time { get; private set; }
        public List<Person> TotalPeopleList { get; private set; }

        public Simulator(Form1 f1)
        {
            TotalPeopleList = new List<Person>();
            AddressChangeCountersList = new List<Counter>();
            PropertySaleCountersList = new List<Counter>();
            PermitRequestCountersList = new List<Counter>();
            stats = new List<Statistics>();
            Time = 8;
            this.form = f1;
            InitializeCounters();
            printed = false;
            //counter4.OnCounterReach();
            rnd = new Random();
        }
        //return lists methods
        public List<Person> GetTotalPeopleList()
        {
            return TotalPeopleList;
        }
        public List<Counter> GetAddressChangeCounterList()
        {
            return AddressChangeCountersList;
        }
        public List<Counter> GetPropertySaleCountersList()
        {
            return PropertySaleCountersList;
        }
        public List<Counter> GetPermitRequestCountersList()
        {
            return PermitRequestCountersList;
        }

        //Creates an instance of Person with a random Appointment value each time and adds to the list.
        public void SpawnPeople()
        {
            int x = rnd.Next(350, 595);
            int y = rnd.Next(437, 457);
            Point point = new Point(x, y);
            Bitmap image = Resources.PropertySale;

            if (Time < 18)
            {
                Time += 0.25;
                if (Time < 16)
                {

                    // var numberToSpawn = Time >= 12 && Time <= 16 ? spawnRandom.Next(1, 1) : spawnRandom.Next(1, 1);
                   // var numberToSpawn = 1;
                    var types = Enum.GetValues(typeof(Appointment));
                    //for (int i = 0; i <= numberToSpawn; i++)
                    //{
                        Appointment currentType = (Appointment)types.GetValue(spawnRandom.Next(types.Length));
                        Person p = new Person(point, image, currentType, this);
                        TotalPeopleList.Add(p);
                        //counter4.OnCounterReach(); //to test processing
                    //}
                }
                
                if (Time % 1 == 0)
                {
                    Statistics st = new Statistics(this);
                    st.UpdateTotalNumPeopl();
                    st.CalculateAvgWaitingTime();
                    stats.Add(st);

                    foreach (Counter item in AddressChangeCountersList)
                    {
                        Appointment currentType = (Appointment)types.GetValue(spawnRandom.Next(types.Length));
                        Person p = new Person(point, image, currentType, this);
                        TotalPeopleList.Add(p);
                        //counter4.OnCounterReach(); //to test processing
                    }
                }
                    if (Time % 1 == 0)
                    {
                        Statistics st = new Statistics(this);
                        st.UpdateTotalNumPeopl();
                        st.CalculateAvgWaitingTime();
                        stats.Add(st);
                        foreach (Counter item in AddressChangeCountersList)
                        {
                            item.GetQueueTimeList().Clear();
                        }
                        foreach (Counter item in PermitRequestCountersList)
                        {
                            item.GetQueueTimeList().Clear();
                        }
                        foreach (Counter item in PropertySaleCountersList)
                        {
                            item.GetQueueTimeList().Clear();
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
                                doc.Add(new iTextSharp.text.Paragraph($"Time:{item.Time}\n "+
                                    $"  Total number of people: {item.TotalNrPeople} \n " +
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
                           text+=($"Time:{item.Time}\n " +
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
            counter1 = new Counter(new Point(275, 180), Appointment.AddressChange,this); counter1.IsOpened = true;
            // to check if it assigns to shortest queue
            counter1.IsOpened = true; //counter1.QueueList.Enqueue(new Person(Appointment.AddressChange)); counter1.QueueList.Enqueue(new Person(Appointment.AddressChange));
            counter2 = new Counter(new Point(340, 132), Appointment.PermitRequest,this); counter2.IsOpened = true;
            counter3 = new Counter(new Point(500, 132), Appointment.PropertySale,this); counter3.IsOpened = true;
            counter4 = new Counter(new Point(633, 132), Appointment.AddressChange,this); //+40 for y to make sure it stops before the counter //-170 for x to make sure it stops before the counter
            // to check if it assigns to shortest queue
            counter4.IsOpened = true; 
            counter5 = new Counter(new Point(760, 132), Appointment.PermitRequest, this); counter5.IsOpened = true;
            counter6 = new Counter(new Point(815, 180), Appointment.PropertySale, this); counter6.IsOpened = true;
            counter7 = new Counter(new Point(815, 260), Appointment.AddressChange, this);
            // to check if it assigns to shortest queue
            counter7.IsOpened = false; //counter7.QueueList.Enqueue(new Person(Appointment.AddressChange)); counter7.QueueList.Enqueue(new Person(Appointment.AddressChange));
            counter8 = new Counter(new Point(815, 350), Appointment.PermitRequest, this); counter8.IsOpened = false;
            counter9 = new Counter(new Point(275, 350), Appointment.PropertySale, this); counter9.IsOpened = false;
            counter10 = new Counter(new Point(275, 260), Appointment.AddressChange, this);
            //to check if it assigns to shortest queue
            counter10.IsOpened = false;
            AddressChangeCountersList.AddRange(new Counter[] { counter1, counter4, counter7, counter10 });
            PermitRequestCountersList.AddRange(new Counter[] { counter2, counter5, counter8 });
            PropertySaleCountersList.AddRange(new Counter[] { counter3, counter6, counter9 });
        }
        //matching the counter with the person
        public void AssignCounter(List<Person> people)
        {
            people.RemoveAll(item => item == null);
            foreach (Person p in people)
           {
                if (p.CenterWasReached && p.IsAssigned == false)
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
                                    p.DestinationPoint = c.Location;//or should it be c.CounterPosition??
                                    c.QueueList.Enqueue(p);
                                    //starts the stop watch to get total process time
                                    //p.sw.Start();
                                    //for testing purposes
                                    //c.OnCounterReach();
                                    p.IsAssigned = true;
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
                                    p.DestinationPoint = c.Location;//or should it be c.CounterPosition??
                                    c.QueueList.Enqueue(p);
                                    //starts the stop watch to get total process time
                                    //p.sw.Start();
                                    //for testing purposes
                                    //c.OnCounterReach();
                                    p.IsAssigned = true;
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
                                    p.DestinationPoint = c.Location;//or should it be c.CounterPosition??
                                    c.QueueList.Enqueue(p);
                                    //starts the stop watch to get total process time
                                    //p.sw.Start();
                                    //for testing purposes
                                    //c.OnCounterReach();
                                    p.IsAssigned = true;
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
            Person p = new Person(first, image, Appointment.AddressChange, this);
            TotalPeopleList.Add(p);
            //AssignCounter(p);//assigns person to a counter on spawning
            //counter4.OnCounterReach();
        }

        public void Start()
        {
            TotalPeopleList.RemoveAll(item => item == null);
            foreach (Person p in TotalPeopleList.ToList())
            {
                p.StartMoving();
            }
        }

        public void Stop()
        {
            TotalPeopleList.RemoveAll(item => item == null);
            form.SpawnTimer.Enabled = false;
            foreach (Person p in TotalPeopleList)
            {
                p.StopPerson();
            }
        }

        public void reset()
        {
            foreach (Person item in TotalPeopleList)
            {
                item.Image.Dispose();

            }
            TotalPeopleList = new List<Person>();
            AddressChangeCountersList = new List<Counter>();
            PropertySaleCountersList = new List<Counter>();
            PermitRequestCountersList = new List<Counter>();
            stats = new List<Statistics>();
            Time = 8;
            InitializeCounters();
            printed = false;
            //counter4.OnCounterReach();
            rnd = new Random();
        }

        public void Draw(Graphics gr)
        {
            //TotalPeopleList.RemoveAll(item => item == null);
            foreach (Person p in TotalPeopleList.ToList())
                {
                    p.DrawPerson(gr);
                }
                
        }

        
    }
}
