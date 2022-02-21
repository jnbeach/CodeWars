using System;
using System.Collections.Generic;

namespace SudokuSolutionValidator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        public static bool ValidateSolution(int[][] board)
        {
            int size = board[0].Length;
            //First check all of the rows
            List<int> numberList = new List<int>();
            for (int i = 0; i < size; i++)
            {
                foreach (int num in board[i])
                {
                    if (numberList.Contains(num)) return false;
                    else if (num < 1 || num > 9) return false;
                    else numberList.Add(num);
                }
                numberList.Clear();
            }
            //Now check all of the columns.
            for (int j = 0; j < size; j++)
            {
                for (int i = 0; i < size; i++)
                {
                    if (numberList.Contains(board[i][j])) return false;
                    else if (board[i][j] < 1 || board[i][j] > 9) return false;
                    else numberList.Add(board[i][j]);
                }
                numberList.Clear();
            }
            //Now check each of the 3x3 squares.
            for (int m = 0; m < size; m += 3)
            {
                for (int k = 0; k < size; k += 3)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        for (int j = 0; j < 3; j++)
                        {
                            if (numberList.Contains(board[i + k][j + m])) return false;
                            else if (board[i + k][j + m] < 1 || board[i + k][j + m] > 9) return false;
                            else numberList.Add(board[i + k][j + m]);
                        }
                    }
                    numberList.Clear();
                }
            }
            return true;
        }
    }
}
