﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
<<<<<<< HEAD
=======
using System.Drawing;
>>>>>>> Stefan

namespace TownHallSimulation
{
    class Counter
    {
<<<<<<< HEAD
=======
        private int id;
        public Point location;
        public bool isOpened;
        public bool isOccupied;

        public Counter(Point loc)
        {
            this.location = loc;
        }



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
            if(isOccupied == false)
            {
                isOccupied = true;
            }
            else
            {
                isOccupied = false;
            }
        }

>>>>>>> Stefan
    }
}
