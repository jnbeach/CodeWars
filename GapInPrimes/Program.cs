using System;
using System.Collections.Generic;

namespace GapInPrimes
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("-----------------------");
            Console.WriteLine("Gap in Primes");
            Console.WriteLine("-----------------------");
            Console.WriteLine("Give me a minimum and maximum number and I will give you all of the prime numbers between it.");
            Console.WriteLine("Minimum integer?");
            int min = int.Parse(Console.ReadLine());
            Console.WriteLine("Maximum integer?");
            int max = int.Parse(Console.ReadLine());
            long[] primeArray = PrimeArray(min, max);
            Console.WriteLine("The resulting array is:");
            Console.Write("\n[ ");
            foreach (long num in primeArray)
            {
                Console.Write($"{num} ");
            }
            Console.Write("]\n\n");
            Console.WriteLine("Now give me a gap, and I will find the first pair of prime numbers with that gap.");
            int gap = int.Parse(Console.ReadLine());
            long[] pairOfPrimes = Gap(gap, min, max);
            Console.WriteLine("The result is:");
            Console.Write("\n[ ");
            foreach (long num in pairOfPrimes)
            {
                Console.Write($"{num} ");
            }
            Console.Write("]\n\n");
        }
        public static long[] Gap(int g, long m, long n)
        {
            long[] gapArray = new long[0];
            long divCheck = 0;
            long prime1 = 0;
            long prime2 = 0;
            bool isPrime;
            for (long num = m; num <= n; num++)
            {
                isPrime = true;
                long rootOfNum = (long)Math.Sqrt(Convert.ToDouble(num));
                for (long divisor = 2; divisor <= rootOfNum; divisor++)
                {
                    divCheck = num % divisor;
                    if (divCheck == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }
                if (isPrime)
                {
                    prime1 = prime2;
                    prime2 = num;
                    if (prime2 - prime1 == g && prime1 != 0)
                    {
                        gapArray = new long[] { prime1, prime2 };
                        return gapArray;
                    }
                }
            }
            return null;
        }

        static long[] PrimeArray(int min, int max)
        {
            bool isPrime;
            List<long> primeList = new List<long>();
            for (int num = min; num <= max; num++)
            {
                isPrime = PrimeNumberChecker(num);
                if (isPrime)
                {
                    primeList.Add(num);
                }
            }
            return primeList.ToArray();
        }
        static bool PrimeNumberChecker(int num)
        {
            int divCheck = 0;
            bool isPrime = true;
            int divisibleBy = 1;
            for (int i = 2; i < num; i++)
            {
                divCheck = num % i;
                if (divCheck == 0)
                {
                    isPrime = false;
                    divisibleBy = i;
                    break;
                }
            }
            return isPrime;
        }
    }
}
