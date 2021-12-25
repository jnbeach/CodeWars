Console.WriteLine("Buy a Car");
// Console.WriteLine($"{nbMonths(12000, 8000, 1000, 1.5)[0]} {nbMonths(12000, 8000, 1000, 1.5)[1]}"); // Should return [0, 4000]
// Console.WriteLine($"{nbMonths(8000, 8000, 1000, 1.5)[0]} {nbMonths(8000, 8000, 1000, 1.5)[1]}"); // Should return [0, 0]
int[] answer = nbMonths(2000, 8000, 1000, 1.5);
Console.WriteLine($"{answer[0]} {answer[1]}"); // Should return [6, 766]
/*
Let us begin with an example:

A man has a rather old car being worth $2000. He saw a secondhand car being worth $8000. He wants to keep his old car until he can buy the secondhand one.

He thinks he can save $1000 each month but the prices of his old car and of the new one decrease of 1.5 percent per month. Furthermore this percent of loss increases of 0.5 percent at the end of every two months. Our man finds it difficult to make all these calculations.

Can you help him?

How many months will it take him to save up enough money to buy the car he wants, and how much money will he have left over?
*/
static int[] nbMonths(int startPriceOld, int startPriceNew, int savingPerMonth, double percentLossByMonth)
{
    int[] answer = new int[2];
    int months = 0;
    int cash = 0;
    double oldCarPrice = startPriceOld;
    double newCarPrice = startPriceNew;
    while (cash + oldCarPrice < newCarPrice)
    {
        cash += savingPerMonth;
        newCarPrice *= (1 - (double)percentLossByMonth / 100);
        oldCarPrice *= (1 - (double)percentLossByMonth / 100);
        if (months % 2 == 0) percentLossByMonth += .5;
        months++;
        Console.WriteLine($"Available: {cash + oldCarPrice - newCarPrice}");

    }
    cash -= (int)Math.Round(newCarPrice - oldCarPrice);
    answer[0] = months;
    answer[1] = cash;
    return answer;
}