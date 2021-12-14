using System.Collections.Generic;

Console.WriteLine("----------------------------------");
Console.WriteLine("Find the Odd Int");
Console.WriteLine("----------------------------------");
Console.WriteLine("This will find the first integer that appears an odd number of times.");
Console.WriteLine("Give me a list of numbers:");
Console.WriteLine("How many numbers would you like to provide?");
int arraySize = Int32.Parse(Console.ReadLine());
Console.WriteLine("How many numbers would you like to provide?");
List<int> numList = new List<int>();
int tempNum = 0;
for (int i = 0; i < arraySize; i++)
{
    Console.WriteLine("Please provide your number below:");
    tempNum = Int32.Parse(Console.ReadLine());
    numList.Add(tempNum);
}
Console.WriteLine("Your list is as follows:");
Console.Write("\n[ ");
foreach (int num in numList)
{
    Console.Write($"{num} ");
}
Console.Write("]\n");
int[] numListArray = numList.ToArray();
int result = findOddInt(numListArray);
if (result != -1)
{
    Console.WriteLine($"{result} was the first number found that appears an odd amount of times.");
}
else
{
    Console.WriteLine($"There weren't any numbers that appeared an odd number of times.");
}



static int findOddInt(int[] seq)
{
    int numListLength = seq.Length;
    int numCount;
    for (int i = 0; i < numListLength; i++)
    {
        numCount = 1;
        for (int j = 0; j < numListLength; j++)
        {
            if (i != j)
            {
                if (seq[i] == seq[j])
                {
                    numCount++;
                }
            }
        }
        if (numCount % 2 == 1)
        {
            return seq[i];
        }
    }
    return -1;
}