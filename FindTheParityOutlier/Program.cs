using System;
using System.Collections.Generic;

namespace FindTheParityOutlier
{
    class Program
    {
        static void Main(string[] args)
        {
            //You are given an array (which will have a length of at least 3, but could be very large) containing integers. The array is either entirely comprised of odd integers or entirely comprised of even integers except for a single integer N. Write a method that takes the array as an argument and returns this "outlier" N.
            Console.WriteLine("Odd or Even Finder");
            Console.WriteLine("Give me a list of numbers:");
            Console.WriteLine("How many numbers would you like to provide?");
            int arraySize = Int32.Parse(Console.ReadLine());
            List<int> numList = new List<int>();
            for (int i = 0; i < arraySize; i++)
            {
                Console.WriteLine("Please provide your number below:");
                numList.Add(Int32.Parse(Console.ReadLine()));
            }
            Console.WriteLine("Your list is as follows:");
            Console.Write("\n[ ");
            foreach (int num in numList)
            {
                Console.Write($"{num} ");
            }
            Console.Write("]\n");
            int[] numListArray = numList.ToArray();
            int result = Find(numListArray);
            Console.WriteLine($"The outlier integer is {result}.");
        }
        public static int Find(int[] integers)
        {
            int counter = 0;
            int evenCount = 0;
            int oddCount = 0;
            while (evenCount < 2 && oddCount < 2)
            {
                if (integers[counter] % 2 == 0)
                {
                    evenCount++;
                }
                else
                {
                    oddCount++;
                }
                counter++;
            }
            if (evenCount > 1)
            {
                foreach (int num in integers)
                {
                    if (num % 2 == 1)
                    {
                        return num;
                    }
                }
            }
            else
            {
                foreach (int num in integers)
                {
                    if (num % 2 == 0)
                    {
                        return num;
                    }
                }
            }
            return -1;
        }
    }
}
