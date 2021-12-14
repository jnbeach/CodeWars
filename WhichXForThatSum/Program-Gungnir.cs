using System;

// Consider the sequence U(n, x) = x + 2x**2 + 3x**3 + ..+nx**n where x is a real number and n a positive integer.

// When n goes to infinity and x has a correct value (ie x is in its domain of convergence D), U(n, x) goes to a finite limit m depending on x.

// Usually given x we try to find m. Here we will try to find x (x real, 0 < x < 1) when m is given (m real, m > 0).

// Let us call solve the function solve(m) which returns x such as U(n, x) goes to m when n goes to infinity.

// Examples:
// solve(2.0) returns 0.5 since U(n, 0.5) goes to 2 when n goes to infinity.

// solve(8.0) returns 0.7034648345913732 since U(n, 0.7034648345913732) goes to 8 when n goes to infinity.

// Note:
// You pass the tests if abs(actual - expected) <= 1e-12

// S = x / (1-x)^2
namespace WhichXForThatSum
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Consider the sequence U(n, x) = x + 2x**2 + 3x**3 + ..+nx**n where x is a real number and n a positive integer.");
            Console.WriteLine("Give me a positive integer for n:");
            int inputN = int.Parse(Console.ReadLine());
            Console.WriteLine("Give me a value between 0 and 1 for x:");
            double inputX = double.Parse(Console.ReadLine());
            decimal result = UCalculate(inputN, inputX);
            Console.WriteLine($"Your result is {result}");
            Console.WriteLine($"What if we have a limit and solve for x as n approaches infinity?");
            Console.WriteLine($"Give me a limit to approach:");
            double inputLimit = double.Parse(Console.ReadLine());
            double solveForX = Solve(inputLimit);
            Console.WriteLine($"Your result is {solveForX}");
        }

        static decimal UCalculate(int n, double x)
        {
            if (n < 1)
            {
                return 0;
            }
            else
            {
                return n * (decimal)Math.Pow(x, (double)n) + UCalculate(n - 1, x);
            }
        }

        public static double Solve(double m)
        {
            decimal trial;
            decimal decM = Convert.ToDecimal(m);
            double result;
            double xTrial;
            for (int i = 1; i < 10000; i++)
            {
                xTrial = i / 10000.0;
                trial = UCalculate(1000, xTrial);
                // Console.WriteLine($"U of 1000 and {xTrial} is {trial}");

                if (trial > decM)
                {
                    result = (i - 1) / 10000.0;
                    return result;
                }
            }
            result = -1;
            return result;
        }
    }
}
