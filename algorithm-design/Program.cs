using System;

namespace LeetCode
{
    class Program
    {
        static void Main(string[] args)
        {
            int[][] matrix = new int[3][];
            matrix[0] = new int[3] { 1, 2, 3 };
            matrix[1] = new int[3] { 4, 5, 6 };
            matrix[2] = new int[3] { 7, 8, 9 };
            var dp = new DinamicPrograming();
            int min = dp.MinFallingPathSumBt(matrix);
        }
    }
}
