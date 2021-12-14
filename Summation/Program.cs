using System;

namespace Summation
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("-------------------------");
            Console.WriteLine("Summation");
            Console.WriteLine("-------------------------");
            Console.WriteLine("Please give me an integer and I will give you a summation of all integers from 0 to that number:");
            int result = summation(int.Parse(Console.ReadLine()));
            Console.WriteLine($"The result was: {result}");
        }
        public static int summation(int num)
        {
            int tempResult = 0;
            for (int i = 1; i <= num; i++)
            {
                tempResult += i;
            }
            return tempResult;
        }
    }
}
