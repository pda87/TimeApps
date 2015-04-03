using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Stopwatch
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Clear();
            Console.Title = "Stopwatch";
            Console.SetWindowSize(74, 9);
            Console.CursorVisible = false;
            Console.WriteLine(" SSSSS  TTTTTTT  OOOOO  PPPPPP  WW      WW   AAA   TTTTTTT  CCCCC  HH   HH");
            Console.WriteLine("SS        TTT   OO   OO PP   PP WW      WW  AAAAA    TTT   CC    C HH   HH");
            Console.WriteLine(" SSSSS    TTT   OO   OO PPPPPP  WW   W  WW AA   AA   TTT   CC      HHHHHHH");
            Console.WriteLine("     SS   TTT   OO   OO PP       WW WWW WW AAAAAAA   TTT   CC    C HH   HH");
            Console.WriteLine(" SSSSS    TTT    OOOO0  PP        WW   WW  AA   AA   TTT    CCCCC  HH   HH");
            Console.WriteLine();
            Console.WriteLine();
            
            if (Console.CapsLock)
            {
                Console.WriteLine("Please restart the program and turn off caps lock...");
                Console.ReadLine();
                return;
            }

            Console.WriteLine("Press enter to start stopwatch...");
            Console.ReadLine();
            Console.Clear();

            DateTime currentDateTime = DateTime.Now;
            DateTime newTime = DateTime.Now;
            
            TimeSpan elapsedTime;

            string loopBreak = "";
            int i = 0;

            while (true)
            {
                Console.SetCursorPosition(0, 0);
                System.Threading.Thread.Sleep(1);

                if (i != 1)
                {
                    newTime = newTime.AddMilliseconds(1.0);  
                }
                
                elapsedTime = newTime - currentDateTime;
                Console.WriteLine(String.Format("{0:00}:{1:00}:{2:00}.{3:000}",
                    elapsedTime.TotalHours, elapsedTime.Minutes, elapsedTime.Seconds, elapsedTime.Milliseconds));
                Console.WriteLine();

                if (i != 1)
                {
                    Console.SetCursorPosition(0, 3);
                    Console.WriteLine("Press caps lock to stop the stopwatch...");
                }
                
                if (Console.CapsLock)
                {
                    while (true)
                    {
                        Console.SetCursorPosition(0, 3);
                        Console.WriteLine("Press caps lock then enter to start the stopwatch...");
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
                
                if (loopBreak.ToUpper() ==  "Q")
                {
                    i++;
                }
            }

            Console.SetCursorPosition(0, 2);
            Console.WriteLine();
            Console.WriteLine(String.Format("Total elapsed time is {0:00} h {1:00} m {2:0}.{3:00}s",
                elapsedTime.TotalHours, elapsedTime.Minutes, elapsedTime.Seconds, elapsedTime.Milliseconds));
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
