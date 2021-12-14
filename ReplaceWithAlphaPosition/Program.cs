using System;
using System.Collections.Generic;

Console.WriteLine("----------------------------------");
Console.WriteLine("Alphabet Position Converter");
Console.WriteLine("----------------------------------");
Console.WriteLine("Input a string below and I will convert all of the letters into numbers based on their alphabetic position.");
string text = Console.ReadLine();
string result = AlphabetPosition(text);
Console.WriteLine($"{result}");

// using lists
static string AlphabetPosition(string text)
{
    char[] textCharArray = text.ToLower().ToCharArray();
    List<int> lettersToNums = new List<int>();
    string result = "";
    foreach (char letter in textCharArray)
    {
        if (Char.IsLetter(letter))
        {
            lettersToNums.Add((int)letter - 96);
        }
    }

    foreach (int num in lettersToNums)
    {
        string numString = Convert.ToString(num);
        result = result + numString + " ";
    }
    result = result.Trim();
    return result;
}

//Using arrays
// static string AlphabetPosition(string text)
// {
//     char[] textCharArray = text.ToLower().ToCharArray();
//     int[] lettersToNums = new int[0];
//     int[] lettersToNumsResized = new int[0];
//     string result = "";
//     int arrayPos = 0;
//     foreach (char letter in textCharArray)
//     {
//         if (Char.IsLetter(letter))
//         {
//             Array.Resize(ref lettersToNums, lettersToNums.Length + 1);
//             lettersToNums[arrayPos] = (int)letter - 96;
//             arrayPos++;
//         }
//     }

//     foreach (int num in lettersToNums)
//     {
//         string numString = Convert.ToString(num);
//         result = result + numString + " ";
//     }
//     result = result.Trim();
//     return result;
// }