using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Traffic.Business;

namespace Traffic.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            int speed;
            System.Console.Write("Speed: ");
            string rawSpeed = System.Console.ReadLine();
            bool goodSpeed = int.TryParse(rawSpeed, out speed);

            int[] intervals = null;
            System.Console.Write("Traffic light times:");
            string rawIntervals = System.Console.ReadLine();
            bool goodIntervals = true;
            try
            {
                intervals = Array.ConvertAll(rawIntervals.Split(','), s => int.Parse(s));
            }
            catch (FormatException)
            {
                goodIntervals = false;
            }

            if (goodIntervals && goodSpeed)
            {
                try
                {
                    Trip trip = new Trip(speed, intervals);
                    System.Console.WriteLine("Time: {0}", trip.GetTime());
                }
                catch (ArgumentException ex)
                {
                    System.Console.WriteLine(ex.Message);
                }
            }
            else
            {
                System.Console.WriteLine("Invalid input");
            }

            System.Console.WriteLine("Return to end");
            System.Console.ReadLine();
        }
    }
}
