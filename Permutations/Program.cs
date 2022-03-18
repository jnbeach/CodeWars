// https://www.codewars.com/kata/5254ca2719453dcc0b00027d/train/csharp
var ListOfPermutations = SinglePermutations("rain");

Console.WriteLine($"The list with no repeats is:");

foreach (string s in ListOfPermutations)
{
    Console.WriteLine(s);
}

static List<string> SinglePermutations(string s)
{
    var ListOfAnswers = new List<string>();
    permute(s, "", ref ListOfAnswers);
    return ListOfAnswers;
}

static void permute(String s, String answer, ref List<string> ListOfAnswers)
{
    if (s.Length == 0)
    {
        // Console.WriteLine(answer);
        if (!ListOfAnswers.Contains(answer)) ListOfAnswers.Add(answer);
        return;
    }

    for (int i = 0; i < s.Length; i++)
    {
        char ch = s[i];
        String leftString = s.Substring(0, i);
        String rightString = s.Substring(i + 1);
        String restOfTheString = leftString + rightString;
        permute(restOfTheString, answer + ch, ref ListOfAnswers);
    }
}