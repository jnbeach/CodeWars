Console.WriteLine("Backspaces In String");
string input = Console.ReadLine();
Console.WriteLine(CleanString(input));
/*
"abc#d##c"      ==>  "ac"
"abc##d######"  ==>  ""
"#######"       ==>  ""
""              ==>  ""
*/
static string CleanString(string s)
{
    int deleteIndex;
    string newString = s;
    foreach (char ch in s)
    {
        if (ch == '#')
        {
            // Checks to see if the backspace will go past the beginning of the string.
            // If it is greater than zero delete the previous character and the # character.
            // Otherwise just delete the # character.
            deleteIndex = s.IndexOf('#') - 1;
            if (deleteIndex >= 0)
            {
                s = s.Remove(deleteIndex, 2);
            }
            else
            {
                s = s.Remove(s.IndexOf('#'), 1);
            }
        }
    }
    return s;
}