using System;
using System.Collections.Generic;

namespace WhereMyAnagramsAt
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("---------------------");
            Console.WriteLine("Anagram Checker");
            Console.WriteLine("---------------------");
            Console.WriteLine("Please input a string:");
            string orignalWord = Console.ReadLine().ToLower();
            List<string> possAnagrams = new List<string>();
            Console.WriteLine("Give me some words and I will give you the anagrams from the list. (Type 0 to exit):");

            string possAnagram = "Initialized";
            while (possAnagram != "0")
            {
                possAnagram = Console.ReadLine().ToLower();
                if (possAnagram != "0")
                {
                    possAnagrams.Add(possAnagram);
                }
            }

            List<string> output = Anagrams(orignalWord, possAnagrams);
            Console.WriteLine("Your list of anagrams is as follows:\n");
            foreach (string word in output)
            {
                Console.WriteLine($"{word}");
            }
            Console.WriteLine("All possible anagrams are:");
            printAnagrams(orignalWord, 0);

            Console.WriteLine("\n");
            Console.WriteLine("------------END OF PROGRAM-------------");
        }
        static List<string> Anagrams(string word, List<string> words)
        {
            //First count all of the characters in the word. Store this into a dictionary with each char and the total count.
            Dictionary<char, int> wordCharCount = charCount(word);

            //Declare a list to store all of the valid anagrams from the given list of words.
            List<string> answerList = new List<string>();

            //Now go through all of the potential words and make word counts for them as well. Compare each char count to the wordCharCount. If the possible Anagram contains the same count, then it is an anagram.
            foreach (string possAnagram in words)
            {
                Dictionary<char, int> possAnagramCharCount = charCount(possAnagram);
                bool isAnagram = true; //Assume the word is an anagram unless proven false by the foreach loop below.
                foreach (KeyValuePair<char, int> kvp in possAnagramCharCount)
                {
                    if (!wordCharCount.ContainsKey(kvp.Key)) //If the original word doesn't contain a char in possAnagram, then it can't be an Anagram. Break out of this loop.
                    {
                        isAnagram = false;
                        break;
                    }
                    else if (possAnagram.Length != word.Length)//If the possAnagram is not the same length as the original word, then it can't be an Anagram.
                    {
                        isAnagram = false;
                        break;
                    }
                    else if (kvp.Value != wordCharCount[kvp.Key]) //If the potential word has a different count for any given char in the original word, then it can't be an Anagram. Break out of this loop.
                    {
                        isAnagram = false;
                        break;
                    }
                }
                if (isAnagram)
                {
                    answerList.Add(possAnagram);
                }
            }
            return answerList;
        }

        static Dictionary<char, int> charCount(string word)
        {
            Dictionary<char, int> wordCharCount = new Dictionary<char, int>();
            foreach (char ch in word)
            {
                if (!wordCharCount.ContainsKey(ch)) // If the Dictionary doesn't already have the character in it as a key, add it, and set the count to 1.
                {
                    wordCharCount.Add(ch, 1);
                }
                else //If the Dictionary does have the key, increment the count by one.
                {
                    wordCharCount[ch]++;
                }
            }
            return wordCharCount;
        }


        // The most elegant solution on CodeWars. Uses Linq:
        // var pattern = word.OrderBy(p => p).ToArray();
        // return words.Where(item => item.OrderBy(p => p).SequenceEqual(pattern)).ToList();

        // Worked on a way to print all possible anagrams.

        // Best explanation I could find for this was here:
        //https://www.geeksforgeeks.org/write-a-c-program-to-print-all-permutations-of-a-given-string/
        //The below method recursively iterates through every permutation of a given string.
        private static void printAnagrams(string word, int startIndex)
        {
            int endIndex = word.Length - 1;
            if (startIndex == endIndex)
                Console.Write($"{word}, ");
            else
            {
                for (int i = startIndex; i <= endIndex; i++)
                {
                    word = swapLetter(word, startIndex, i);
                    printAnagrams(word, startIndex + 1);
                }
            }
        }
        public static string swapLetter(string word, int index1, int index2)
        {
            char temp;
            char[] charArray = word.ToCharArray();
            temp = charArray[index1];
            charArray[index1] = charArray[index2];
            charArray[index2] = temp;
            string newWord = new string(charArray);
            return newWord;
        }
    }
}
