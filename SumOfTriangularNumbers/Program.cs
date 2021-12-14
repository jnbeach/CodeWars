using System;

namespace SumOfTriangularNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            //[01]
            // 02[03]
            // 04 05[06]
            // 07 08 09[10]
            // 11 12 13 14[15]
            // 16 17 18 19 20[21]
            Console.WriteLine("---------------------------");
            Console.WriteLine("Sum of Triangular Numbers");
            Console.WriteLine("---------------------------");
            Console.WriteLine("Please give me a non negative integer:");
            int input = int.Parse(Console.ReadLine());
            int triNumInput = TriangularNumber(input);
            Console.WriteLine($"The triangular number of {input} is {triNumInput}.");
            int triNumSum = SumTriangularNumbers(input);
            Console.WriteLine($"The sum of all triangular numbers up to {input} is {triNumSum}.");
        }
        public static int SumTriangularNumbers(int n)
        {
            if (n <= 0)
            {
                return 0;
            }
            else
            {
                return TriangularNumber(n) + SumTriangularNumbers(n - 1);
            }
        }
        public static int TriangularNumber(int num)
        {
            if (num <= 0)
            {
                return 0;
            }
            else
            {
                return TriangularNumber(num - 1) + num;
            }
        }
    }
}
