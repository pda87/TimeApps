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
            Console.SetWindowSize(100, 10);
            Console.CursorVisible = false;

            Console.WriteLine(" CCCCC  LL       OOOOO   CCCCC  KK  KK");
            Console.WriteLine("CC    C LL      OO   OO CC    C KK KK"); 
            Console.WriteLine("CC      LL      OO   OO CC      KKKK");
            Console.WriteLine("CC    C LL      OO   OO CC    C KK KK");
            Console.WriteLine(" CCCCC  LLLLLLL  OOOO0   CCCCC  KK  KK");
                                       
            Console.WriteLine();
            Console.WriteLine();

            if (Console.CapsLock)
            {
                Console.WriteLine("Please restart the program and turn off caps lock...");
                Console.ReadLine();
                return;
            }


            Console.WriteLine("Press enter to start clock...");
            Console.ReadLine();
            Console.Clear();



            DateTime currentDateTime = DateTime.Now;
            
            Console.WriteLine("Current date and time");
            while (true)
            {
                Console.SetCursorPosition(0, 2);
                System.Threading.Thread.Sleep(1000);
                currentDateTime = currentDateTime.AddSeconds(1.0);
                Console.WriteLine(String.Format("{0} {1} {2:00}:{3:00}:{4:00}",
                    currentDateTime.DayOfWeek, currentDateTime.Date.ToShortDateString(), currentDateTime.Hour, currentDateTime.Minute, currentDateTime.Second));
                Console.WriteLine();
                Console.WriteLine("Press caps lock to stop the clock...");

                if (Console.CapsLock)
                {
                    break;
                }
            }

            Console.SetCursorPosition(0, 3);
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
