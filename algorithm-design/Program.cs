using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode
{
    class Program
    {
        static void Main(string[] args)
        {
            var s = new Stack<TreeNode>();
            var res = new List<int>();
            var root = new TreeNode(1);
            root.right = new TreeNode(2);
            root.right.left = new TreeNode(3);
            TreeNode p = root;
            while (p != null || s.Count != 0){
                if(p != null){
                    s.Push(p);
                    p = p.left;
                } else {
                    var node = s.Pop();
                    res.Add(node.val);
                    p = node.right;
                }
            }
        }
    }
}
