using System.Text;
using System.Collections.Generic;

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
Console.WriteLine(AlphabetPosition("Hello World"));

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