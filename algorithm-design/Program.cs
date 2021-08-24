using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode
{
    class Program
    {
        static List<IList<string>> result = new List<IList<string>>();
        static void Main(string[] args)
        {
            var r = SolveNQueens(4);

            IList<IList<string>> SolveNQueens(int n)
            {
                Backtrack(new List<int>(), 0, n);
                return result;
            }

            void Backtrack(List<int> queenPos, int row, int n)
            {
                if (queenPos.Count == n)
                    result.Add(GetResStr(queenPos, n));

                for (int j = 0; j < n; j++)
                {
                    if (IsValidPos(queenPos, row, j, n))
                    {
                        queenPos.Add(j);
                        Backtrack(queenPos, row + 1, n);
                        queenPos.RemoveAt(queenPos.Count - 1);
                    }
                }
            }

            // queenPos is formated as row by row, so only record the col idx
            List<string> GetResStr(List<int> queenPos, int n)
            {
                var res = new List<string>();
                foreach (var pos in queenPos)
                {
                    var s = new string('.', n);
                    var sq = s.Remove(pos, 1).Insert(pos, "Q");
                    res.Add(sq);
                }
                return res;
            }

            bool IsValidPos(List<int> queenPos, int row, int col, int n)
            {
                for (int i = row - 1, j = col - 1; i >= 0 && j >= 0; i--, j--)
                {
                    if (queenPos[i] == j)
                        return false;
                }

                for (int i = row - 1; i >= 0; i--)
                {
                    if (queenPos[i] == col)
                        return false;
                }

                for (int i = row - 1, j = col + 1; i >= 0 && j < n; i--, j++)
                {
                    if (queenPos[i] == j)
                        return false;
                }

                return true;
            }
        }
    }

    public class Codec
    {
        // Encodes a tree to a single string.
        public string serialize(TreeNode root)
        {
            SeriHelper(root);
            Console.WriteLine(res);
            return res;
        }

        string res = "";
        void SeriHelper(TreeNode root)
        {
            if (root == null)
            {
                res += "#,";
                return;
            }

            res += root.val + ",";
            SeriHelper(root.left);
            SeriHelper(root.right);
        }

        // Decodes your encoded data to tree.
        public TreeNode deserialize(string data)
        {
            string[] dataArr = data.Split(",");
            var dataList = new List<string>(dataArr);
            return DeseriHelper(dataList);
        }

        TreeNode DeseriHelper(List<string> dataList)
        {
            if (dataList[0] == "#")
            {
                dataList.RemoveAt(0);
                return null;
            }
            var root = new TreeNode(int.Parse(dataList[0]));
            dataList.RemoveAt(0);
            root.left = DeseriHelper(dataList);
            root.right = DeseriHelper(dataList);
            return root;
        }
    }
}
