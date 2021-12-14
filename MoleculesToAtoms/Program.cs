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

        }
        public static Dictionary<string, int> ParseMolecule(string formula)
        {
            Dictionary<string, int> dictOfAtoms = new Dictionary<string, int>();
            List<int> indexList = new List<int>();
            string upperFormula = formula.ToUpper();
            string lowerFormula = formula.ToLower();
            for (int i = 0; i < formula.Length; i++)
            {
                if (formula[i] == upperFormula[i])
                {
                    indexList.Add(i);
                }
            }
            foreach (int index in indexList)
            {
                if (index + 1 >= formula.Length)
                {
                    dictOfAtoms.Add(formula[index], 1);
                    break;
                }
                if (formula[index + 1])
                {
                }
            }

            // Do your science here :)
        }
    }
}
