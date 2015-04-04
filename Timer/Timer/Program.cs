using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Timer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Clear();
            Console.Title = "Timer";
            Console.SetWindowSize(49, 10);

            Console.WriteLine("TTTTTTT IIIII MM    MM EEEEEEE RRRRRR");
            Console.WriteLine("  TTT    III  MMM  MMM EE      RR   RR");
            Console.WriteLine("  TTT    III  MM MM MM EEEEE   RRRRRR");
            Console.WriteLine("  TTT    III  MM    MM EE      RR  RR");
            Console.WriteLine("  TTT   IIIII MM    MM EEEEEEE RR   RR");

            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("Please enter the time to countdown from (HHMMSS):");
            string timerInput = Console.ReadLine();

            int timerDigits = 0;

            if (!Int32.TryParse(timerInput, out timerDigits) || timerInput.Length != 6)
            {
                Console.WriteLine("Input not understood. Please retry");
                Console.ReadLine();
                Main(args);
            }

            if (timerDigits > 235959 || (timerDigits > 000059 && timerDigits < 000100) || (timerDigits > 005900 && timerDigits < 010000))
            {
                Console.WriteLine("Input not understood. Please retry");
                Console.ReadLine();
                Main(args);
            }

            int HH = Convert.ToInt32(timerInput.Substring(0, 2));
            int MM = Convert.ToInt32(timerInput.Substring(2, 2));
            int SS = Convert.ToInt32(timerInput.Substring(4, 2));

            DateTime zerothHour = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, HH, MM, SS);

            Console.Clear();
            
            while (true)
            {
                if (zerothHour.Hour == 0 && zerothHour.Minute == 0 && zerothHour.Second == 0)
                {
                    Console.Clear();
                    Console.WriteLine("00:00.00");
                    Console.Beep();
                    Console.Beep();
                    Console.Beep();
                    break;
                }

                System.Threading.Thread.Sleep(1000);

                Console.SetCursorPosition(0, 0);
                Console.WriteLine(String.Format("Hours:   {0:00}\r\nMinutes: {1:00}\r\nSeconds: {2:00}", zerothHour.Hour, zerothHour.Minute, zerothHour.Second));
                Console.WriteLine();
                zerothHour = zerothHour.AddSeconds(-1.0);
            }
        }
    }
}
