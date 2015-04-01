using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BinaryClock
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.CursorVisible = false;
            Console.SetWindowSize(35, 10);
            Console.Title = "BinaryClock";


            DateTime currentDateTime = DateTime.Now;

            while (true)
            {
                currentDateTime = clock(currentDateTime);
                binaryClock(currentDateTime);
                Thread.Sleep(50);
            }
        }

        private static void binaryClock(DateTime currentDateTime)
        {
            Console.SetCursorPosition(0, 4);
            Console.WriteLine("Binary clock: ");
            int hour = getBinary(currentDateTime.Hour);
            int minute = getBinary(currentDateTime.Minute);
            int second = getBinary(currentDateTime.Second);
            Console.WriteLine("Hour:   {0:000000}", hour);
            Console.WriteLine("Minute: {0:000000}", minute);
            Console.WriteLine("Second: {0:000000}", second);
        }

        private static DateTime clock(DateTime currentDateTime)
        {
            Console.SetCursorPosition(0, 0);
            Console.WriteLine("Current date and time:");
            currentDateTime = DateTime.Now;
            Console.SetCursorPosition(0, 1);
            Console.WriteLine(String.Format("{0} {1} {2:00}:{3:00}:{4:00}.{5:000}",
                currentDateTime.DayOfWeek, currentDateTime.Date.ToShortDateString(), currentDateTime.Hour, currentDateTime.Minute, currentDateTime.Second, currentDateTime.Millisecond));
            Console.WriteLine();
            return currentDateTime;
        }
        
        private static int getBinary(int timeElement)
        {
            int output = 0;
            output = Convert.ToInt32(Convert.ToString(timeElement, 2));
            return output;
        }
    }
}
