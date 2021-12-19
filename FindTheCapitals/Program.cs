using System.Collections.Generic;

Console.WriteLine("Find the Capitals");
Console.WriteLine("Give me a string:");
string inputWord = Console.ReadLine();
int[] answer = Capitals(inputWord);
foreach (int num in answer)
{
    Console.WriteLine($"{num}");
}

static int[] Capitals(string word)
{
    string upperWord = word.ToUpper();
    List<int> answer = new List<int>();

    for (int i = 0; i < word.Length; i++)
    {
        if (word[i] == upperWord[i]) answer.Add(i);
    }
    return answer.ToArray();
}