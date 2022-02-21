using System;
using System.Collections.Generic;

namespace SumByFactors
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public class SumOfDivided
        {

            public static string sumOfDivided(int[] lst)
            {
                string answer = "";
                var factorSums = new SortedDictionary<int, int>();
                int posNum;
                foreach (int num in lst)
                {
                    if (num < 0) posNum = num * -1;
                    else posNum = num;
                    int sqrtNum = (int)Math.Sqrt(posNum);
                    if (posNum % 2 == 0 && !factorSums.ContainsKey(2))
                    {
                        factorSums.Add(2, num);
                    }
                    else if (posNum % 2 == 0 && factorSums.ContainsKey(2))
                    {
                        factorSums[2] += num;
                    }
                    for (int i = 3; i <= posNum; i += 2)
                    {
                        if (posNum % i == 0 && !factorSums.ContainsKey(i))
                        {
                            if (isPrime(i))
                            {
                                factorSums.Add(i, num);
                            }
                        }
                        else if (posNum % i == 0 && factorSums.ContainsKey(i))
                        {
                            factorSums[i] += num;
                        }
                    }
                }
                foreach (KeyValuePair<int, int> kvp in factorSums)
                {
                    answer += $"({kvp.Key} {kvp.Value})";
                }
                Console.WriteLine(answer);
                return answer;
            }
            public static bool isPrime(int num)
            {
                int sqrtNum = (int)Math.Sqrt(num);
                if (num % 2 == 0) return false;
                for (int i = 3; i <= sqrtNum; i += 2)
                {
                    if (num % i == 0) return false;
                }
                //     Console.WriteLine($"{num} is prime");
                return true;
            }
        }
    }
}
