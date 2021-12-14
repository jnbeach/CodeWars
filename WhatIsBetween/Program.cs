using System;

namespace WhatIsBetween
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Give me two integers and I will give you an array with both of the numbers and all of the numbers between them.");
            int int1 = int.Parse(Console.ReadLine());
            int int2 = int.Parse(Console.ReadLine());
            if (int1 > int2)
            {
                int tempInt = int1;
                int1 = int2;
                int2 = tempInt;
            }
            int[] result = Between(int1, int2);
            Console.Write("You new array is:");
            Console.Write("\n[ ");
            foreach (int num in result)
            {
                Console.Write($"{num} ");
            }
            Console.Write("]\n");

        }
        public static int[] Between(int a, int b)
        {
            int[] result = new int[b - a + 1];
            for (int i = a; i <= b; i++)
            {
                result[i - a] = i;
            }
            return result;
        }
    }

}
