using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TownHallSimulation
{
    public class Statistics
    {
        //storing total nr of people in the town hall
        public int TotalNrPeople { get; private set; }
        //storing total nr of people waiting to be processed 
        public int TotalNrOfPeopleWaiting { get; private set; }
        //storing total number of counters
        public int TotalNrOfCounters { get; private set; }
        //storing variable of simulator class to use in the statistics class
        private Simulator sim;

        // constructor of the class
        public Statistics(Simulator simulator)
        {
            TotalNrPeople = 0;
            TotalNrOfPeopleWaiting = 0;
            sim = simulator;
            TotalNrOfCounters = 9;
        }
        //???????????
        public override string ToString()
        {
            return "";
        }
        // method for storing the number of people
        public void UpdateTotalNrOfPeople(int total)
        {
            TotalNrPeople += total;


        }
        //method to return total number of people waiting 
        public int GetTotalNrOfPeopleWaiting()
        {
            return TotalNrPeople - TotalNrOfPeopleWaiting;
        }

        //public int GetTotalNrOfCountersOpened()
        //{
        //    int num = 0;
        //    foreach (Counter C in sim.CountersList)
        //    {
        //        if (C.IsOpened)
        //        {
        //            num++;
        //        }
        //    }
        //    return num;
        //}

        //public int GetTotalNrOfCountersOccupied()
        //{
        //    //int num = 0;
        //    //foreach (Counter C in sim.CountersList)
        //    //{
        //    //    if (C.IsOccupied)
        //    //    {
        //    //        num++;
        //    //    }
        //    //}
        //    //return num;
        //}

        //public int GetTotalNrOfCountersFree()
        //{
        //    //int num = 0;
        //    //foreach (Counter C in sim.CountersList)
        //    //{
        //    //    if (!C.IsOccupied && C.IsOpened)
        //    //    {
        //    //        num++;
        //    //    }
        //    //}
        //    //return num;
        //}
        
            // method to print out pdf file of the statistics 
        public bool PrintStats()
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
                        doc.Add(new iTextSharp.text.Paragraph("CASE Management of Technology The PEOPLES Bank(A bank for all the people”) is one of the smaller banks of the Netherlands, but a bank with a rich history. The bank is now facing some new challenges, especially for the IT department.The bank uses a legacy system on a mainframe, which is actually a mix of legacy systems due to a" +
                            "merger with 2 other banks 10 years ago.The system is used for the customer administration on " +
                            "the loans, payment and savings accounts that the bank offers. All transaction of customers are processed real" +
                            " - time as far as possible.This includes transaction of customers at the bank’s ATM, credit card and transactions and " +
                            "updates done by the desk clerk when"));
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
            return false;



        }
    }
}
