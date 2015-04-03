using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clock
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Clear();
            Console.Title = "Clock";
            Console.SetWindowSize(30, 5);
            Console.CursorVisible = false;

            DateTime currentDateTime = DateTime.Now;

            Console.WriteLine("Current date and time");
            while (true)
            {
                Console.SetCursorPosition(0, 2);
                System.Threading.Thread.Sleep(47);
                currentDateTime = DateTime.Now;
                Console.WriteLine(String.Format("{0} {1} {2:00}:{3:00}:{4:00}.{5:000}",
                    currentDateTime.DayOfWeek, currentDateTime.Date.ToShortDateString(), currentDateTime.Hour, currentDateTime.Minute, currentDateTime.Second, currentDateTime.Millisecond));
                Console.WriteLine();
            }

        }
    }
}
