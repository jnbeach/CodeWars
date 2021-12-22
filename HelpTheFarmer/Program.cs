// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
Dictionary<string, int> answer = get_animals_count(34, 11, 6);
foreach (KeyValuePair<string, int> kvp in answer)
{
    Console.WriteLine($"{kvp.Key}: {kvp.Value}");
}

static Dictionary<string, int> get_animals_count(int legs_number, int heads_number, int horns_number)
{
    Dictionary<string, int> answer = new Dictionary<string, int>();

    int cows = 0;
    int rabbits = 0;
    int chickens = 0;

    //Add the number of cows divided by 2 (2 horns per cow).
    cows += horns_number / 2;
    //Subtract all of the heads and legs for the cows that we just added.
    heads_number -= cows;
    legs_number -= cows * 4;

    rabbits = (legs_number - 2 * heads_number) / 2;
    chickens = heads_number - rabbits;

    // //Now figure out how many rabbits there are.
    // //First assume that there are the max number of rabbits.
    // //And min number of chickens.
    // rabbits += legs_number / 4;
    // chickens += (legs_number % 4) / 2;
    // //Now increment rabbits down and chickens up until the heads and legs match.
    // while (rabbits + chickens != heads_number)
    // {
    //     rabbits--;
    //     chickens += 2;
    // }

    answer.Add("rabbits", rabbits);
    answer.Add("chickens", chickens);
    answer.Add("cows", cows);
    return answer;
}