using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode
{
    class Program
    {
        static void Main(string[] args)
        {
            var sudoku = new Sudoku();
            char[,] board = new char[,]{
                { '5', '3', '.', '.', '7', '.', '.', '.', '.' },
                { '6','.','.','1','9','5','.','.','.'},
                { '.','9','8','.','.','.','.','6','.'},
                { '8','.','.','.','6','.','.','.','3'},
                { '4','.','.','8','.','3','.','.','1'},
                { '7','.','.','.','2','.','.','.','6'},
                { '.','6','.','.','.','.','2','8','.'},
                { '.','.','.','4','1','9','.','.','5'},
                { '.','.','.','.','8','.','.','7','9'}};

            sudoku.SolveSudoku(board);
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
