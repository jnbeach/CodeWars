using System.Collections.Generic;
using System.Linq;
using System;
//Write a function that takes in a string of one or more words, and returns the same string, but with all five or more letter words reversed (Just like the name of this Kata). Strings passed in will consist of only letters and spaces. Spaces will be included only when more than one word is present.

//Examples: spinWords("Hey fellow warriors") => returns "Hey wollef sroirraw" spinWords("This is a test") => returns "This is a test" spinWords("This is another test")=> returns "This is rehtona test"
namespace StopSpinningMyWords
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Give me a sentence:");
            string userInput = Console.ReadLine();
            string spunUserInput = Kata.SpinWords(userInput);
            Console.WriteLine("If a word was longer than 5 letters, it should have been flipped.");
            Console.WriteLine(spunUserInput);
        }
    }
    public class Kata
    {
        public static string SpinWords(string sentence)
        {
            int wordLength = 0;
            string part1;
            string part2;
            string part3;
            int tempIndex = 0;
            string tempWord;
            List<int> spacePostions = new List<int>();

            for (int i = 0; i < sentence.Length; i++)
            {
                if (!Char.IsLetter(sentence[i]) || (Char.IsLetter(sentence[i]) && i == sentence.Length - 1))
                {
                    spacePostions.Add(i);
                }
            }
            Console.WriteLine("This is a list of all of the space positions.");
            foreach (int spacePos in spacePostions)
            {
                if (spacePos != sentence.Length - 1 || !Char.IsLetter(sentence[spacePos]))
                {
                    tempWord = sentence.Substring(tempIndex, spacePos - tempIndex);
                    wordLength = tempWord.Length;
                }
                else // If space pos is the last character of the last word, then just go to the end of the sentence.
                {
                    tempWord = sentence.Substring(tempIndex);
                    wordLength = tempWord.Length;
                }
                Console.WriteLine($"Space position: {spacePos}\t{tempWord}\t\tWordLength: {wordLength}");
                if (wordLength >= 5)
                {
                    Console.WriteLine($"Flipping {tempWord} and reassembling strings.");


                    //If the space position is not the last character in the sentence, then flip part 2, grab the rest of the sentence into a 3rd part and concatenate the 3 parts into 1 string.
                    if (spacePos != sentence.Length - 1 || !Char.IsLetter(sentence[spacePos]))
                    {
                        part1 = sentence.Substring(0, spacePos - wordLength);
                        part2 = sentence.Substring(spacePos - wordLength, wordLength);
                        part2 = new string(part2.Reverse().ToArray());
                        part3 = sentence.Substring(spacePos);
                        sentence = part1 + part2 + part3;
                    }
                    else //If space pos IS the last character in the string (i.e. this is the last word of the sentence with no punctuation mark at the end), then we only need part 2 to be a substring going to the end of the sentence. This will be flipped. Part 3 not required.
                    {
                        //Have to add 1 to the substring length for part1 and the starting position for part2 because spacePos goes to the last character of the word rather than the space after it.
                        part1 = sentence.Substring(0, spacePos - wordLength + 1);
                        part2 = sentence.Substring(spacePos - wordLength + 1);
                        part2 = new string(part2.Reverse().ToArray());
                        sentence = part1 + part2;
                    }
                    Console.WriteLine("This is the new sentence");
                    Console.WriteLine(sentence);

                }
                tempIndex = spacePos + 1;
            }
            return sentence;
        }
    }
}
