using System;
using System.Collections.Generic;

namespace DirectionsReduction
{
    class Program
    {
        static void Main(string[] args)
        {
            //Display the option menu.
            DirReduction.DisplayMenu();
            //Get Inputs from user and input the resulting array into the direction reducer.
            string[] dirArr = DirReduction.GetInputs();
            //Display the results
            DirReduction.DisplayResults(dirArr);
        }
    }
    public class DirReduction
    {

        public static void DisplayMenu()
        {
            Console.WriteLine("-----------------------");
            Console.WriteLine("Direction Reducer");
            Console.WriteLine("-----------------------");
            Console.WriteLine("Key:");
            Console.WriteLine("Please input a set of directions (Type 1, 2, 3, or 4):");
            Console.WriteLine("1: North");
            Console.WriteLine("2: East");
            Console.WriteLine("3: South");
            Console.WriteLine("4: West");
            Console.WriteLine("0: Type 0 to save your list.");

        }
        public static string[] GetInputs()
        {
            List<string> dirList = new List<string>();
            int userInput;
            do
            {
                userInput = int.Parse(Console.ReadLine());

                switch (userInput)
                {
                    case 1:
                        dirList.Add("NORTH");
                        Console.WriteLine("North added.");
                        Console.WriteLine("Input another direction:");
                        break;
                    case 2:
                        dirList.Add("EAST");
                        Console.WriteLine("East added.");
                        Console.WriteLine("Input another direction:");
                        break;
                    case 3:
                        dirList.Add("SOUTH");
                        Console.WriteLine("South added.");
                        Console.WriteLine("Input another direction:");
                        break;
                    case 4:
                        dirList.Add("WEST");
                        Console.WriteLine("West added.");
                        Console.WriteLine("Input another direction:");
                        break;
                    case 0:
                        Console.WriteLine("Saving inputs now.");
                        Console.WriteLine("Your current array is as follows:");
                        Console.Write("[");
                        foreach (string direction in dirList)
                        {
                            Console.Write($"{direction} ");
                        }
                        Console.Write("]\n");
                        break;
                    default:
                        Console.WriteLine("That was not a valid input.");
                        break;
                }
            } while (userInput != 0);
            return dirList.ToArray();
        }
        public static string[] DirReduc(String[] arr)
        {
            Dictionary<string, string> oppositeOf = new Dictionary<string, string>();
            oppositeOf.Add("NORTH", "SOUTH");
            oppositeOf.Add("EAST", "WEST");
            oppositeOf.Add("SOUTH", "NORTH");
            oppositeOf.Add("WEST", "EAST");

            List<string> newDirList = new List<string>();
            int i = 0;
            bool wasReduced;
            do
            {
                wasReduced = false; // Resets wasReduced to false at the beginning of each array check.
                while (i < arr.Length)
                {
                    if (i == arr.Length - 1)
                    {
                        // Console.WriteLine($"Last item being saved.");
                        newDirList.Add(arr[i]);
                        i++;
                    }
                    else if (arr[i + 1] != oppositeOf[arr[i]])
                    {
                        newDirList.Add(arr[i]);
                        i++;
                    }
                    else
                    {
                        i += 2; // Don't add this direction or the next one.
                        wasReduced = true;
                    }
                }
                if (wasReduced == true)
                {
                    arr = newDirList.ToArray();
                    newDirList.Clear();
                    i = 0;
                }
            } while (wasReduced == true);

            return newDirList.ToArray();
        }
        public static void DisplayResults(string[] inputArr)
        {
            string[] newDirArr = DirReduc(inputArr);
            Console.WriteLine("Your reduced array is as follows:");
            Console.Write("[");
            foreach (string direction in newDirArr)
            {
                Console.Write($"{direction} ");
            }
            Console.Write("]\n");
        }
    }
}
