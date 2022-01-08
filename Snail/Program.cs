Console.WriteLine("Snail");
Console.WriteLine("----------");
Console.WriteLine("Input a size for the array");
int size = Convert.ToInt32(Console.ReadLine());

int[][] inputArray = GenerateArray(size);
PrintArray(inputArray);

int[] answer = Snail(inputArray);

Console.WriteLine("The snail array is: \n");
Console.Write($"[");
foreach (int answerNum in answer)
{
    Console.Write($"{answerNum} ");
}
Console.WriteLine($"]\n--------------------");


static int[] Snail(int[][] array)
{
    int size = array.Length;
    if (size == 0) return new int[] { };
    int[] answer = new int[size * size];
    //A spiral is one complete 'loop' around the array.
    int totalSpirals = (int)Math.Ceiling(array.Length / 2.0);
    int answerCounter = 0;
    for (int spiral = 0; spiral < totalSpirals; spiral++)
    {
        //Each row and column gets smaller on each spiral.
        int rowLength = size - 2 * spiral;
        int columnLength = rowLength - 2;
        //Iterate through the top row of the spiral.
        for (int i = 0; i < rowLength; i++)
        {
            answer[answerCounter] = array[spiral][i + spiral];
            answerCounter++;
        }
        //Iterate through the middle of the right column.
        for (int i = 0; i < columnLength; i++)
        {
            answer[answerCounter] = array[i + spiral + 1][size - 1 - spiral];
            answerCounter++;
        }
        //Iterate through the bottom row of the spiral. (Must be reversed)
        for (int i = 0; i < rowLength; i++)
        {
            if (rowLength == 1) break;
            answer[answerCounter] = array[size - 1 - spiral][size - 1 - spiral - i];
            answerCounter++;
        }
        //Iterate through the middle of the left column. (Must be reversed)
        for (int i = 0; i < columnLength; i++)
        {
            answer[answerCounter] = array[size - 2 - spiral - i][spiral];
            answerCounter++;
        }
    }
    return answer;
}

static int[][] GenerateArray(int size)
{
    int[][] newArray = new int[size][];
    var Rand = new Random();
    for (int i = 0; i < size; i++)
    {
        newArray[i] = new int[size];
        for (int j = 0; j < size; j++)
        {
            newArray[i][j] = Rand.Next(30);
        }
    }
    return newArray;
}

static void PrintArray(int[][] input)
{
    Console.WriteLine($"Your array is:");
    foreach (int[] row in input)
    {
        Console.Write("\n[ ");
        foreach (int num in row)
        {
            Console.Write($"{num}\t");
        }
        Console.Write("]");
    }
    Console.Write("\n\n");
}