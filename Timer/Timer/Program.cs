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

            if (Console.CapsLock)
            {
                Console.WriteLine("Please restart the program and turn off caps lock...");
                Console.ReadLine();
                return;
            }

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

            string loopBreak = "";
            int i = 0;

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



                if (i != 1)
                {
                    Console.SetCursorPosition(0, 3);
                    Console.WriteLine("Press caps lock to stop the timer...");
                }

                if (Console.CapsLock)
                {
                    while (true)
                    {
                        Console.SetCursorPosition(0, 3);
                        Console.WriteLine("Press caps lock then enter to start the timer...");
                        Console.SetCursorPosition(0, 4);
                        Console.WriteLine("Press caps lock, Q then enter to quit");
                        loopBreak = Console.ReadLine();

                        if (!Console.CapsLock)
                        {
                            Console.Clear();
                            break;
                        }
                    }
                }

                if (i == 1)
                {
                    break;
                }

                if (loopBreak.ToUpper() == "Q")
                {
                    i++;
                }

                if (i != 1)
                {
                    System.Threading.Thread.Sleep(1000);
                }
                
                Console.SetCursorPosition(0, 0);
                Console.WriteLine(String.Format("{0:00}:{1:00}.{2:00}", zerothHour.Hour, zerothHour.Minute, zerothHour.Second));
                Console.WriteLine();
                zerothHour = zerothHour.AddSeconds(-1.0);
            }


            Console.SetCursorPosition(0, 2);
            Console.WriteLine();
            Console.WriteLine("Press enter to quit, or type 'r' or 'restart' to restart");
            Console.WriteLine("(make sure you turn off caps lock)");
            string input = Console.ReadLine().ToUpper();
            if (input == "R" || input == "RESTART")
            {
                Main(args);
            }
            else
            {
                return;
            }
        }
    }
}
