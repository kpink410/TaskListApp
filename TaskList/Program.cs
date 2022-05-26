using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TaskList
{
    public class Program
    {
        public static string filename = "c:\\Users\\KevinPink-4s\\source\\repos\\TaskListApp\\todo.txt";
        static void Main(string[] args)
        {
            int menuItem = -1;
            while (menuItem != 0)
            {
                menuItem = Menu();
                switch (menuItem)
                {
                    case 1:
                        ShowList();
                        break;
                    case 2:
                        AddItem();
                        break;
                    case 3:
                        RemoveItem();
                        break;
                    case 4:
                        CompletedItem();
                        break;
                    case 5:
                        Quit();
                        break;
                    default:
                        Console.WriteLine("Please use a correct menu number.");
                        break;
                }
            }
        }
        static void Quit()
        {
            Console.WriteLine();
            StreamWriter outfile = File.AppendText(filename);
            //string Item = Console.ReadLine();
            //outFile.WriteLine(Item);
            outfile.Close();
        }
        static void CompletedItem()
        {
            Console.WriteLine("\nCompleted Item\n");
            StreamWriter outFile= File.AppendText(filename);
            Console.WriteLine("Task completed");
            string Item = Console.ReadLine();
            outFile.WriteLine(Item);
            outFile.Close();
        }
        static void AddItem()
        {
            Console.WriteLine("\nAdd Item\n");
            StreamWriter outFile = File.AppendText(filename);
            Console.WriteLine("Enter an item");
            string Item = Console.ReadLine();
            outFile.WriteLine(Item);
            outFile.Close();
        }
        static void RemoveItem()
        {
            int choice;
            ShowList();
            Console.WriteLine("Which item do you want to remove?");
            choice = Convert.ToInt32(Console.ReadLine());
            List<string> items = new List<string>();
            int number = 1;
                string item;
            StreamReader inFile = new StreamReader(filename);
            while (inFile.Peek() != -1)
            {
                item = inFile.ReadLine();
                if (number != choice)
                    items.Add(item);
                ++number;
            }
            inFile.Close();
            StreamWriter outFile = new StreamWriter(filename);
            for (int i = 1; i < items.Count; i++)
            outFile.WriteLine(items[i]);
            outFile.Close();    
        }
        static int Menu()
        {
            int choice;
            //Console.Clear();
            Console.WriteLine("Main Menu\n");
            Console.WriteLine("1. List task");
            Console.WriteLine("2. Add task");
            Console.WriteLine("3. Delete task");
            Console.WriteLine("4. Mark task complete");
            Console.WriteLine("5. Quit");
            Console.WriteLine();
            Console.WriteLine("Enter your choice: ");
            choice = Convert.ToInt32(Console.ReadLine());
            return choice;
        }
        static void ShowList()
        {
            Console.WriteLine("\nTo-do List\n");
            StreamReader inFile = new StreamReader(filename);
            string line;
            int number = 1;
            while (inFile.Peek() != -1)
            {
                line = inFile.ReadLine();
                Console.Write(number + " ");
                Console.WriteLine(line);
                ++number;
            }
            Console.WriteLine();
            inFile.Close();
        }
    }
}
