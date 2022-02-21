using System;

namespace RomanNumeralHelper
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"{ToRoman(1666)}");
            Console.WriteLine($"{FromRoman("MDCLXVI")}");
        }
        public static string ToRoman(int n)
        {
            int[] nums = { 1000, 900, 500, 400, 100, 90, 50, 40, 10, 9, 5, 4, 1 };

            string[] romans = { "M", "CM", "D", "CD", "C", "XC", "L", "XL", "X", "IX", "V", "IV", "I" };

            string result = "";

            for (int i = 0; i < nums.Length && n != 0; i++)
            {
                while (n >= nums[i])
                {
                    n -= nums[i];
                    result += romans[i];
                }
            }
            return result;
        }

        public static int FromRoman(string romanNumeral)
        {
            int[] nums = { 1000, 900, 500, 400, 100, 90, 50, 40, 10, 9, 5, 4, 1 };

            string[] romans = { "M", "CM", "D", "CD", "C", "XC", "L", "XL", "X", "IX", "V", "IV", "I" };

            int result = 0;

            for (int i = 0; i < romans.Length; i++)
            {
                if (romans[i].Length <= romanNumeral.Length)
                {
                    while (romanNumeral.Substring(0, romans[i].Length) == romans[i])
                    {
                        romanNumeral = romanNumeral.Remove(0, romans[i].Length);
                        result += nums[i];
                        if (romans[i].Length > romanNumeral.Length) break;
                    }
                }
            }
            return result;
        }
    }
}
