using System.Collections.Generic;

namespace LeetCode
{
    public class BFS
    {
        // 111
        public int MinDepth(TreeNode root)
        {
            if (root == null) return 0;
            var q = new Queue<TreeNode>();
            q.Enqueue(root);
            int depth = 1;
            while (q.Count != 0)
            {
                int cnt = q.Count;
                for (int i = 0; i < cnt; i++)
                {
                    var curr = q.Dequeue();
                    if (curr.left == null && curr.right == null)
                        return depth;
                    if (curr.left != null)
                        q.Enqueue(curr.left);
                    if (curr.right != null)
                        q.Enqueue(curr.right);
                }
                depth++;
            }
            return depth;
        }
    }

}