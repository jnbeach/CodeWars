Console.WriteLine("Bouncing Balls");
double height = 3;
double bounce = .66;
double windowHeight = 1.5; // Result is -1
Console.WriteLine($"{bouncingBall(height, bounce, windowHeight)}");

static int bouncingBall(double h, double bounce, double window)
{
    if (h <= 0 || bounce < 0 || bounce >= 1 || window >= h) return -1;
    int counter = 0;
    while (h > window)
    {
        counter++;
        h = bounce * h;
        if (h > window) counter++;
    }

    return counter;
}