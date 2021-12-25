using System.Collections.Generic;

Console.WriteLine("Hello, World!");
Console.WriteLine(Solution(1534));
/*
Create a function taking a positive integer as its parameter and returning a string containing the Roman Numeral representation of that integer.

Modern Roman numerals are written by expressing each digit separately starting with the left most digit and skipping any digit with a value of zero. In Roman numerals 1990 is rendered: 1000=M, 900=CM, 90=XC; resulting in MCMXC. 2008 is written as 2000=MM, 8=VIII; or MMVIII. 1666 uses each Roman symbol in descending order: MDCLXVI.
*/
static string Solution(int n)
{
    string answer = "";
    Dictionary<int, string> numberConverter = new Dictionary<int, string>();
    numberConverter.Add(1000, "M");
    numberConverter.Add(900, "CM");
    numberConverter.Add(500, "D");
    numberConverter.Add(400, "CD");
    numberConverter.Add(100, "C");
    numberConverter.Add(90, "XC");
    numberConverter.Add(50, "L");
    numberConverter.Add(40, "XL");
    numberConverter.Add(10, "X");
    numberConverter.Add(9, "IX");
    numberConverter.Add(5, "V");
    numberConverter.Add(4, "IV");
    numberConverter.Add(1, "I");

    int counter = 0;
    foreach (KeyValuePair<int, string> kvp in numberConverter)
    {
        while (n >= kvp.Key) // Is the number > than the key?
        {
            n -= kvp.Key; // Subtract the key from the input number
            counter++; // Count every time we do this.
        }
        for (int i = 0; i < counter; i++) // Add the 'letter' to the string as many times as we have 'counted' with counter
        {
            answer += kvp.Value;
        }
        counter = 0; //reset the counter for the next dictionary value.
    }

    return answer;
}

static string Romanize(int numToConvert)
{
    int[] nums = { 1000, 900, 500, 400, 100, 90, 50, 40, 10, 9, 5, 4, 1 };

    string[] romans = { "M", "CM", "D", "CD", "C", "XC", "L", "XL", "X", "IX", "V", "IV", "I" };

    string result = "";

    for (int i = 0; i < nums.Length && numToConvert != 0; i++)
    {
        while (numToConvert >= nums[i])
        {
            numToConvert -= nums[i];
            result += romans[i];
        }
    }
    return result;
}