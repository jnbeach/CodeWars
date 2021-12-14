using System;

namespace Maskify
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Mask a string except for the last 4 characters.");
            Console.WriteLine("Type a string below:");
            string input = Console.ReadLine();
            string result = Maskify(input);
            Console.WriteLine(result);

            static string Maskify(string cc)
            {
                if (cc.Length > 4)
                {
                    string string1 = cc.Substring(0, cc.Length - 4);
                    string string2 = cc.Substring(cc.Length - 4);
                    char[] string1chars = string1.ToCharArray();
                    int pos = 0;
                    foreach (char ch in string1chars)
                    {
                        string1chars[pos] = '#';
                        pos++;
                    }
                    string1 = string.Join("", string1chars);
                    string newString = string1 + string2;
                    return newString;
                }
                else
                {
                    return cc;
                }
            }
        }
    }
}
