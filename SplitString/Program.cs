
Console.WriteLine($"Input a string to pairify!");

string input = Console.ReadLine();
string[] result = Solution(input);
foreach (string str in result)
{
    Console.WriteLine(str);
}


static string[] Solution(string str)
{
    if (str.Length % 2 != 0)
    {
        str += "_";
    }

    string[] pairs = new string[str.Length / 2];

    for (int i = 0; i < str.Length / 2; i++)
    {
        pairs[i] = str.Substring((2 * i), 2);
    }
    return pairs;
}