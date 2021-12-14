using System;

namespace Tribonacci
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("------------------------");
            Console.WriteLine("Tribonacci Sequence");
            Console.WriteLine("------------------------");
            Console.WriteLine("This works basically like a Fibonacci, but summing the last 3 (instead of 2) numbers of the sequence to generate the next.");
            Console.WriteLine("Give me 3 numbers as a signature/starting point to the sequence:");
            double[] starter = new double[3];
            for (int i = 0; i < 3; i++)
            {
                starter[i] = double.Parse(Console.ReadLine());
            }
            Console.WriteLine("How many numbers in the sequence would you like to calculate?");
            int maxNumber = int.Parse(Console.ReadLine());
            double[] tribonacciArr = Tribonacci(starter, maxNumber);
            Console.WriteLine("The resulting array is:");
            Console.Write("\n[ ");
            foreach (double num in tribonacciArr)
            {
                Console.Write($"{num} ");
            }
            Console.Write("]\n\n");
        }
        public static double[] Tribonacci(double[] signature, int n)
        {
            double[] result = new double[n];
            if (n == 0)
            {
                return result;
            }
            else if (n < 4)
            {
                for (int i = 0; i < n; i++)
                {
                    result[i] = signature[i];
                }
                return result;
            }
            for (int i = 0; i < 3; i++)
            {
                result[i] = signature[i];
            }
            for (int i = 3; i < n; i++)
            {
                result[i] = result[i - 3] + result[i - 2] + result[i - 1];
            }
            return result;
        }
    }
}
