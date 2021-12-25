using System;
using System.Collections.Generic;

namespace MoleculesToAtoms
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("MoleculesToAtoms");
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("Please give me any molecule (e.g. H20, C(OH)4");
            string inputMolecule = Console.ReadLine();
            Dictionary<string, int> atomList = ParseMolecule(inputMolecule);
            foreach (KeyValuePair<string, int> kvp in atomList)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value}");

            }
            List<List<int>> listOfBrackets = BracketFinder(inputMolecule);
            foreach (List<int> BracketPair in listOfBrackets)
            {
                Console.WriteLine($"{BracketPair[0]} {BracketPair[1]} Mult:{BracketPair[2]}");
            }
        }
        public static Dictionary<string, int> ParseMolecule(string formula)
        {
            //dictOfAtoms will store our answer.
            Dictionary<string, int> dictOfAtoms = new Dictionary<string, int>();

            //Find all of the parentheses, brackets, and their corresponding multipliers. See the BracketFinder method
            List<List<int>> BracketList = BracketFinder(formula);

            //Now count all of the Atoms present in the string.
            char ch;
            char nextCh;
            for (int i = 0; i < formula.Length; i++)
            {
                ch = formula[i];
                if (i != formula.Length - 1)
                {
                    nextCh = formula[i + 1];
                }
                else
                {
                    nextCh = formula[i];
                }
                //Only do this if the character is Upper and is NOT the last character.
                if (char.IsUpper(ch) && i != formula.Length - 1)
                {
                    //If the next character is lowercase, add the 2 letter atom.
                    if (char.IsLower(nextCh))
                    {
                        if (!dictOfAtoms.ContainsKey(formula.Substring(i, 2)))
                        {
                            dictOfAtoms.Add(formula.Substring(i, 2), 1);
                        }
                    }
                    //If the next character anything else, add the atom.
                    else
                    {
                        if (!dictOfAtoms.ContainsKey(formula.Substring(i, 1)))
                        {
                            dictOfAtoms.Add(formula.Substring(i, 1), 1);
                        }
                    }
                }
                //If i is at the last character and the last character is Uppercase, then add the last character if it's not already contained.
                else if (char.IsUpper(ch) && i == formula.Length - 1)
                {
                    if (!dictOfAtoms.ContainsKey(formula.Substring(i, 1)))
                    {
                        dictOfAtoms.Add(formula.Substring(i, 1), 1);
                    }
                }
            }
            return dictOfAtoms;
        }

        public static List<List<int>> BracketFinder(string formula)
        {
            List<List<int>> listOfBrackets = new List<List<int>>();
            List<int> bracketPair;
            int bracketMult = 1;
            for (int i = 0; i < formula.Length; i++)
            {
                if (formula[i] == '(' || formula[i] == '[' || formula[i] == '{')
                {
                    bracketPair = new List<int>();
                    bracketPair.Add(i);
                    if (formula[i] == '(') bracketPair.Add(formula.IndexOf(')', i));
                    if (formula[i] == '[') bracketPair.Add(formula.IndexOf(']', i));
                    if (formula[i] == '{') bracketPair.Add(formula.IndexOf('}', i));
                    //BracketPair[1] is the index of the closing bracket. If there is a number after the closing bracket, add the multiplying number to the bracket pair info. (also make sure that further than the end of the array is not accessed.)
                    if (bracketPair[1] != formula.Length - 1)
                    {
                        if (char.IsDigit(formula[bracketPair[1] + 1]))
                        {
                            int digitCounter = 1;
                            while (bracketPair[1] + 1 + digitCounter < formula.Length)
                            {
                                if (char.IsDigit(formula[bracketPair[1] + 1 + digitCounter]))
                                {
                                    digitCounter++;
                                }
                            }
                            bracketMult = Convert.ToInt32(formula.Substring(bracketPair[1] + 1, digitCounter));
                            bracketPair.Add(bracketMult);
                        }
                        else
                        {
                            bracketPair.Add(bracketMult);
                        }
                    }
                    listOfBrackets.Add(bracketPair);
                }
            }

            return listOfBrackets;
        }

    }
}
