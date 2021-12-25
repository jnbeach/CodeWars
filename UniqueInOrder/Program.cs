// See https://aka.ms/new-console-template for more information
Console.WriteLine("Unique in Order");

string[] example1 = new string[] {
    "asdf",
    "sdfg",
    "dfgh",
    "asdf",
    "jkl"
};
List<int> example2 = new List<int>() {
    2, 3, 4, 5, 6, 7, 8, 9, 2, 5
};
List<string> example3 = new List<string>() {
    "asdf",
    "sdfg",
    "dfgh",
    "asdf",
    "jkl"
};


static IEnumerable<T> UniqueInOrder<T>(IEnumerable<T> iterable)
{
    //Implement the function unique_in_order which takes a sequence and returns a list of items without any elements with the same value next to each other and preserving the original order of elements.

    //uniqueInOrder("AAAABBBCCDAABBB") == {'A', 'B', 'C', 'D', 'A', 'B'}
    //uniqueInOrder("ABBCcAD") == { 'A', 'B', 'C', 'c', 'A', 'D'}
    //uniqueInOrder([1, 2, 2, 3, 3])       == { 1,2,3}
    List<T> result = new List<T>(iterable);
    for (int i = 1; i < result.Count(); i++)
    {
        while (result[i] == result[i - 1])
        {

        }
    }
    return result;
}