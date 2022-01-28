
Console.WriteLine("Population Growth");
Console.WriteLine($"Give an initial population:");
int p0 = Convert.ToInt32(Console.ReadLine());
Console.WriteLine($"Give a percentage growth rate:");
double percent = Convert.ToDouble(Console.ReadLine());
Console.WriteLine($"Give a constant augmentation per year:");
int aug = Convert.ToInt32(Console.ReadLine());
Console.WriteLine($"Give a target population:");
int p = Convert.ToInt32(Console.ReadLine());
Console.WriteLine($"Population will reach target in:");
Console.WriteLine($"{NbYear(p0, percent, aug, p)} years");


//How many years will it take for population p0 to grow to population p?
static int NbYear(int p0, double percent, int aug, int p)
{
    double population = p0;
    int counter = 0;
    double convertedPercent = percent / 100.0;
    while (population < p)
    {
        Console.WriteLine($"{population}, {percent}, {aug}, {p}");
        population *= (1 + convertedPercent);
        population += aug;
        counter++;
        population = Math.Floor(population);
        Console.WriteLine($"{population}");

    }
    return counter;
}