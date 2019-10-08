using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace TownHallSimulation
{
    class Counter
    { // fields and properties of the class
        private int id;
        public Point location { get; set; }
        public bool isOpened { get; set; }
        public bool isOccupied { get; set; }
        // class constructor 
        public Counter(int id,Point loc)
        {
            this.id = id;
            this.location = loc;
            this.isOccupied = false;
        }
        // methods of the class
        public void OpenCounter()
        {
            isOpened = true;
        }
        public void CloseCounter()
        {
            isOpened = false;
        }
        public void UpdateStatus()
        {
            if (isOccupied == false)
            {
                isOccupied = true;
            }
            else
            {
                isOccupied = false;
            }
        }
    }
}
