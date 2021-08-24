/*
 * @lc app=leetcode.cn id=116 lang=csharp
 *
 * [116] 填充每个节点的下一个右侧节点指针
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
        // solution 1: traverse
        // if (root == null) return null;
        // Connect(root.left, root.right);
        // return root;

        // solution 2: BFS
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
                {
                    q.Add(q[i].left);
                    q.Add(q[i].right);
                }
            }

            // remove
            for (int i = 0; i < cnt; i++)
                q.RemoveAt(0);
        }
        return root;
    }

    // void Connect(Node node1, Node node2)
    // {
    //     if (node1 == null || node2 == null)
    //         return;

    //     node1.next = node2;
    //     Connect(node1.left, node1.right);
    //     Connect(node1.right, node2.left);
    //     Connect(node2.left, node2.right);
    // }
}
// @lc code=end

