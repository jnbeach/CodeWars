using System;

namespace MaxProduct
{
    class Program
    {
        //Given an array of integers , Find the maximum product obtained from multiplying 2 adjacent numbers in the array.
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        public static int AdjacentElementsProduct(int[] array)
        {
            int tempNum;
            int maxProduct = array[0] * array[1];
            //Do Some Magic
            for (int i = 1; i < array.Length - 1; i++)
            {
                tempNum = array[i] * array[i + 1];
                if (tempNum > maxProduct)
                {
                    maxProduct = tempNum;
                }
            }
            return maxProduct;
        }
    }
}
