/*
 * @lc app=leetcode.cn id=133 lang=csharp
 *
 * [133] 克隆图
 */

// @lc code=start
/*
// Definition for a Node.
public class Node {
    public int val;
    public IList<Node> neighbors;

    public Node() {
        val = 0;
        neighbors = new List<Node>();
    }

    public Node(int _val) {
        val = _val;
        neighbors = new List<Node>();
    }

    public Node(int _val, List<Node> _neighbors) {
        val = _val;
        neighbors = _neighbors;
    }
}
*/

public class Solution
{
    Dictionary<Node, Node> map = new Dictionary<Node, Node>();
    public Node CloneGraph(Node node)
    {
        // // DFS
        // if (node == null)
        //     return null;

        // if (map.ContainsKey(node))
        //     return map[node];
        // var cloneNode = new Node(node.val, new List<Node>());
        // map.Add(node, cloneNode);
        // foreach (var child in node.neighbors)
        // {
        //     cloneNode.neighbors.Add(CloneGraph(child));
        // }
        // return cloneNode;

        // BFS
        if (node == null)
            return null;
        var q = new Queue<Node>();
        q.Enqueue(node);
        map.Add(node, new Node(node.val, new List<Node>()));
        while (q.Count != 0)
        {
            var curr = q.Dequeue();
            foreach (var child in curr.neighbors)
            {
                if (!map.ContainsKey(child))
                {
                    map.Add(child, new Node(child.val, new List<Node>()));
                    q.Enqueue(child);
                }
                map[curr].neighbors.Add(map[child]);
            }
        }
        return map[node];
    }
}
// @lc code=end

