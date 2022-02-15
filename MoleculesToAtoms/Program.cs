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
            Console.WriteLine("Please give me any molecule (e.g. H2O, C(OH)4)");
            // string inputMolecule = Console.ReadLine();
            string inputMolecule = "K4[ON(SO3)2]2";
            // string inputMolecule = "{((H)2)[O]}";
            Console.WriteLine($"{inputMolecule}");

            Dictionary<string, int> atomList = ParseMolecule(inputMolecule);
            foreach (KeyValuePair<string, int> kvp in atomList)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value}");

            }
            int[] bracketMults = BracketMultFinder(inputMolecule);
            Console.Write($"\n[ ");
            foreach (int mult in bracketMults)
            {
                Console.Write($"{mult} ");
            }
            Console.Write($"]\n");
        }
        public static Dictionary<string, int> ParseMolecule(string formula)
        {
            //dictOfAtoms will store our answer.
            Dictionary<string, int> dictOfAtoms = new Dictionary<string, int>();

            //First, find all of the parentheses, brackets, and their corresponding bracketMults. See the BracketFinder method
            int[] bracketMults = BracketMultFinder(formula);

            //Now count all of the Atoms present in the string using a while loop.
            int index = 0; //This is the current index in the string.
            int startingIndex; //Used to hold info on where we start each While loop iteration for the bracketMult info.
            char ch; // This is the current character in the string that we are accessing.
            string element = ""; // This will store the current element to be added to 'dictOfAtoms'.
            string countString = ""; // The current multiple for each element (right after the element)
            int elementCount = 1; // Used to convert the string to an integer.

            while (index < formula.Length)
            {
                startingIndex = index;
                ch = formula[index];
                //If the character is uppercase, move to the next character.
                if (char.IsUpper(ch))
                {
                    element += ch; //Save the character to the current element.
                    index++;
                    if (index < formula.Length) ch = formula[index];
                    //If the next character is lowercase, check if there is a number next to it.
                    if (char.IsLower(ch) && index < formula.Length)
                    {
                        element += ch; //Save the character to the current element.
                        index++;
                        if (index < formula.Length) ch = formula[index];
                        while (char.IsLower(ch) && index < formula.Length)
                        {
                            element += ch; //Save the character to the current element.
                            index++;
                            if (index < formula.Length) ch = formula[index];
                        }
                        while (char.IsDigit(ch) && index < formula.Length)
                        {
                            countString += ch;
                            index++;
                            if (index < formula.Length) ch = formula[index];
                        }
                        if (countString != "") elementCount = Int32.Parse(countString);
                        //If the dictionary DOES NOT already contain the element, then add it.
                        if (!dictOfAtoms.ContainsKey(element))
                        {
                            dictOfAtoms.Add(element, elementCount * bracketMults[startingIndex]);
                        }
                        else //otherwise, just add to the existing value.
                        {
                            dictOfAtoms[element] += elementCount * bracketMults[startingIndex];
                        }
                    }
                    //If the next character IS NOT lowercase and we are still in the bounds of the array,
                    // then check if there is a number next to it.
                    else if (index < formula.Length)
                    {
                        while (char.IsDigit(ch) && index < formula.Length)
                        {
                            countString += ch;
                            index++;
                            if (index < formula.Length) ch = formula[index];
                        }
                        if (countString != "") elementCount = Int32.Parse(countString);
                        //If the dictionary DOES NOT already contain the element, then add it.
                        if (!dictOfAtoms.ContainsKey(element))
                        {
                            dictOfAtoms.Add(element, elementCount * bracketMults[startingIndex]);
                        }
                        else //otherwise, just add to the existing value.
                        {
                            dictOfAtoms[element] += elementCount * bracketMults[startingIndex];
                        }
                    }
                    //Finally, if it is just capital by itself or the last character in the array,
                    // then just add it by itself.
                    else
                    {
                        //If the dictionary DOES NOT already contain the element, then add it.
                        if (!dictOfAtoms.ContainsKey(element))
                        {
                            dictOfAtoms.Add(element, 1);
                        }
                        else //otherwise, just add to the existing value.
                        {
                            dictOfAtoms[element] += 1;
                        }
                    }
                    // Reset variables before the next loop.
                    element = "";
                    countString = "";
                    elementCount = 1;
                }
                else index++;
            }

            return dictOfAtoms;
        }

        public static int[] BracketMultFinder(string formula)
        {
            int[] bracketMults = new int[formula.Length];
            for (int i = 0; i < bracketMults.Length; i++)
            {
                bracketMults[i] = 1;
            }

            string bracketMultString = "";
            int bracketMult = 1;
            // These two ints will store the locations of the brackets that we find.
            // We'll initialize at the beginning and the end.
            int leftIndex = 0;
            int rightIndex = formula.Length - 1;
            for (int i = 0; i < formula.Length; i++)
            {
                if (formula[i] == '(' || formula[i] == '[' || formula[i] == '{')
                {
                    leftIndex = i;
                    //Search from right to left for the closing brackets.
                    if (formula[i] == '(')
                    {
                        // Need to count how many other opening brackets are encountered while searching
                        // for the corresponding closing bracket
                        // int ignoreCounter = 0;
                        // int counter = 1;
                        // while (formula[i + counter] != ')' || ignoreCounter >= 0)
                        // {
                        //     if (formula[i + counter] == '(')
                        //     {
                        //         ignoreCounter++;
                        //     }
                        //     else if (formula[i + counter] == ')')
                        //     {
                        //         ignoreCounter--;
                        //     }
                        //     counter++;
                        // }
                        // rightIndex = i + counter;
                        rightIndex = formula.IndexOf(')', i);
                    }
                    if (formula[i] == '[')
                    {
                        rightIndex = formula.IndexOf(']', i);
                    }
                    if (formula[i] == '{')
                    {
                        rightIndex = formula.IndexOf('}', i);
                    }

                    int digitCounter = 0;
                    if (rightIndex + 1 < formula.Length)
                    {
                        while (char.IsDigit(formula[rightIndex + digitCounter + 1]))
                        {
                            bracketMultString += formula[rightIndex + digitCounter + 1];
                            digitCounter++;
                            if (rightIndex + 1 + digitCounter >= formula.Length) break;
                        }
                    }
                    // If digits were found, then save the multiplier and reset bracketMultString.
                    if (digitCounter > 0)
                    {
                        bracketMult = Int32.Parse(bracketMultString);
                        bracketMultString = "";
                    }
                    for (int j = leftIndex; j < rightIndex; j++)
                    {
                        bracketMults[j] *= bracketMult;
                    }
                }
            }

            return bracketMults;
        }

    }
}
