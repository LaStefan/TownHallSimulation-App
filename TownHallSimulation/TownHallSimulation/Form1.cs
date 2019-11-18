using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TownHallSimulation
{
    public partial class Form1 : Form
    {
        private Town_Hall TheHall;
        public Form1()
        {
            InitializeComponent();
            TheHall = new Town_Hall(this);
        }

        //Test if random creating objects works. Prints every Person in List and corresponding enum type.
        private void timer1_Tick(object sender, EventArgs e)
        {
            foreach ( Person p in TheHall.RandomSpawnPersons())
            {
                lbLog.Items.Add($"The type of appointment is: {p.GetAppointment} + ID: {p.GetPersonId()}");
            }
        }
       
        //Test button for processig requests.
        private void button1_Click(object sender, EventArgs e)
        {
            TheHall.Process();
            showStats();
        }
<<<<<<< Updated upstream
=======

        private void button2_Click(object sender, EventArgs e)
        {

        }
        private void showStats()
        {
            lBStatistics.Items.Add($"The total number of free counters are: {TheHall.statistics.GetTotalNrOfCountersFree()}");
            lBStatistics.Items.Add($"The total number of occupied counters are: {TheHall.statistics.GetTotalNrOfCountersOccupied()}");
            lBStatistics.Items.Add($"The total number of open counters are: {TheHall.statistics.GetTotalNrOfCountersOpened()}");
            lBStatistics.Items.Add($"The total number of poeple waiting counters are: {TheHall.statistics.GetTotalNrOfPeopleWaiting()}");
            lBStatistics.Items.Add($"The total number of people curently at the city hall is: {TheHall.statistics.TotalNrPeople}");

        }
>>>>>>> Stashed changes
    }
}
