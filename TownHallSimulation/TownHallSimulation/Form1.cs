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
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
