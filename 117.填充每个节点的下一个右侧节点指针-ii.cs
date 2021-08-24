/*
 * @lc app=leetcode.cn id=117 lang=csharp
 *
 * [117] 填充每个节点的下一个右侧节点指针 II
 */

// @lc code=start
/*
// Definition for a Node.
public class Node {
    public int val;
    public Node left;
    public Node right;
    public Node next;

    public Node() {}

    public Node(int _val) {
        val = _val;
    }

    public Node(int _val, Node _left, Node _right, Node _next) {
        val = _val;
        left = _left;
        right = _right;
        next = _next;
    }
}
*/

public class Solution
{
    public Node Connect(Node root)
    {
        // solution 1: BFS
        if (root == null) return null;
        var q = new List<Node>();
        q.Add(root);
        while (q.Count != 0)
        {
            // connect
            int cnt = q.Count;
            for (int i = 0; i < cnt; i++)
            {
                if (i != cnt - 1)
                    q[i].next = q[i + 1];
                if (q[i].left != null)
                    q.Add(q[i].left);
                if (q[i].right != null)
                    q.Add(q[i].right);
            }

            // remove
            for (int i = 0; i < cnt; i++)
                q.RemoveAt(0);
        }
        return root;
    }
}
// @lc code=end

