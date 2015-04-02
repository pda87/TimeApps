using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace ToDoList
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = ("ToDoList");
            Console.ForegroundColor = ConsoleColor.Green;

            if (!Directory.Exists("C:\\ToDoList"))
            {
                Directory.CreateDirectory("C:\\ToDoList");
                File.WriteAllText("C:\\ToDoList\\list.txt", "");
            }
            
            bool programLoop = true;
            int i = 1;
            List<string> dataList = new List<string>();

            i = readFile(i, ref dataList);

            string input = "";

            while (programLoop)
            {

                Console.WriteLine("****************************");
                Console.WriteLine("****** TODO LIST ***********");
                Console.WriteLine("****************************");
                Console.WriteLine();


                if (dataList.Count == 0)
                {
                    Console.WriteLine("List is empty");
                    Console.WriteLine();
                    Console.WriteLine("press a to add, l to re-load, or q to quit");
                    input = Console.ReadLine();

                    if (input.ToUpper() == "L")
                    {
                        dataList.Clear();
                        Console.Clear();
                        i = readFile(i, ref dataList);
                        input = "";
                        continue;
                    }

                    if (input.ToUpper() == "Q")
                    {
                        programLoop = false;
                    }


                    if (input.ToUpper() == "A")
                    {
                        Console.WriteLine("Enter data:");
                        input = Console.ReadLine();

                        dataList.Add(input);
                        writeFile(dataList);
                        input = "";
                        Console.Clear();
                    }


                    Console.Clear();
                    continue;
                }


                i = 1;
                foreach (string item in dataList)
                {
                    Console.WriteLine(i + " " + item);
                    i++;
                }

                Console.WriteLine();
                Console.WriteLine("enter number to delete, a to add, l to re-load or q to quit");
                input = Console.ReadLine();
                Console.WriteLine();

                if (input.ToUpper() == "Q")
                {
                    programLoop = false;
                }


                if (input.ToUpper() == "A")
                {
                    Console.WriteLine("Enter data:");
                    input = Console.ReadLine();

                    dataList.Add(input);
                    writeFile(dataList);
                    input = "";
                    Console.Clear();
                }


                if (input.ToUpper() == "L")
                {
                    dataList.Clear();
                    Console.Clear();
                    i = readFile(i, ref dataList);
                    input = "";
                    continue;
                }

                if (dataList.Count == 0)
                {
                    Console.Clear();
                    Console.WriteLine("List is empty");
                    input = Console.ReadLine();
                    continue;
                }

                int number = 0;
                if (!Int32.TryParse(input, out number))
                {
                    Console.Clear();
                    continue;
                }

                number = Convert.ToInt32(input);

                if (dataList.Count < (number - 1) || number < 0 || number > dataList.Count || number == 0)
                {
                    Console.Clear();
                    continue;
                }

                dataList.RemoveAt(number - 1);
                Console.WriteLine();
                writeFile(dataList);
                dataList.Clear();
                Console.Clear();
                using (StreamReader reader = new StreamReader(@"C:\ToDoList\list.txt"))
                {
                    string line = "";
                    while ((line = reader.ReadLine()) != null)
                    {
                        dataList.Add(line);
                    }
                }

            }
        }


        private static void writeFile(List<string> dataList)
        {
            using (StreamWriter sw = new StreamWriter(@"C:\ToDoList\list.txt"))
            {
                foreach (var item in dataList)
                {
                    sw.WriteLine(item);
                }
            }
        }

        private static int readFile(int i, ref List<string> dataList)
        {
            using (StreamReader reader = new StreamReader(@"C:\ToDoList\list.txt"))
            {
                string line = "";
                while ((line = reader.ReadLine()) != null)
                {
                    dataList.Add(line);
                    i++;

                }
            }
            return i;
        }
    }
}