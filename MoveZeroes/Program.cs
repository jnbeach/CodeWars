using System;
using System.Collections.Generic;

namespace MoveZeroes
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("------------------");
            Console.WriteLine("Move Zeroes");
            Console.WriteLine("------------------");
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
            Console.WriteLine("I will now move all of the zeroes to the right.");
            int[] newNumArr = MoveZeroes(numListArray);
            Console.WriteLine("Your new list is as follows:");
            Console.Write("\n[ ");
            foreach (int num in newNumArr)
            {
                Console.Write($"{num} ");
            }
            Console.Write("]\n\n");
            Console.Write("-----------------------");
            Console.Write("End of Program");
            Console.Write("-----------------------");
        }
        public static int[] MoveZeroes(int[] arr)
        {
            int[] newArr = new int[arr.Length];
            int zeroCount = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == 0)
                {
                    zeroCount++;
                    //Because we made a new array, those values are already zero. No need to assign a zero there.
                }
                else
                {
                    newArr[i - zeroCount] = arr[i];
                }
            }
            return newArr;
        }
    }
}
