using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode
{
    class Program
    {
        static void Main(string[] args)
        {
            string num1 = "2";
            string num2 = "3";
            int m = num1.Length;
            int n = num2.Length;
            int[] res = new int[m + n];
            for (int i = m - 1; i >= 0; i--)
            {
                for (int j = n - 1; j > -0; j--)
                {
                    int mul = (num1[i] - '0') * (num2[j] - '0');
                    int p1 = i + j;
                    int p2 = i + j + 1;
                    int sum = mul + res[p2];
                    res[p2] = sum % 10;
                    res[p1] += sum / 10;
                }
            }

            int k = 0;
            while (k < res.Length && res[k] == 0)
                k++;
            string str = "";
            while (k < res.Length)
                str += res[k];
            Console.WriteLine(str);
        }

        static string Add(string a, string b)
        {
            int i = a.Length - 1;
            int j = b.Length - 1;
            int carry = 0;
            string res = "";
            while (i >= 0 || j >= 0)
            {
                int abit = (i >= 0) ? (int)a[i] - (int)'0' : 0;
                int bbit = (j >= 0) ? (int)b[j] - (int)'0' : 0;
                int sum = abit + bbit + carry;
                int newBit = sum % 10;
                carry = sum / 10;
                res = res.Insert(0, newBit.ToString());
                i--;
                j--;
            }
            return res;
        }
    }

    public class Sudoku
    {
        public void SolveSudoku(char[][] board)
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (board[i][j] == '.')
                        posToSolve.Add((i, j));
                }
            }
            Backtrack(board, 0);
            board = res;
        }

        List<(int, int)> posToSolve = new List<(int, int)>();
        char[][] res = new char[9][];
        void Backtrack(char[][] board, int idx)
        {
            if (idx >= posToSolve.Count)
            {
                CopyTo(board, res);
                return;
            }

            int row = posToSolve[idx].Item1;
            int col = posToSolve[idx].Item2;
            for (char c = '1'; c <= '9'; c++)
            {
                if (IsValid(board, row, col, c))
                {
                    // make choice
                    board[row][col] = c;
                    Backtrack(board, idx + 1);

                    // undo choice
                    board[row][col] = '.';
                }
            }
        }

        bool IsValid(char[][] board, int row, int col, char c)
        {
            int corRow = (row / 3) * 3;
            int corCol = (col / 3) * 3;
            for (int i = 0; i < 9; i++)
            {
                if (board[row][i] == c)
                    return false;
                if (board[i][col] == c)
                    return false;
                if (board[corRow + i / 3][corCol + i % 3] == c)
                    return false;
            }

            return true;
        }

        void CopyTo(char[][] source, char[][] target)
        {
            for (int i = 0; i < 9; i++)
            {
                target[i] = new char[9];
                Array.Copy(source[i], target[i], 9);
            }
        }
    }
}
