/*
 * @lc app=leetcode.cn id=208 lang=csharp
 *
 * [208] 实现 Trie (前缀树)
 */

// @lc code=start
public class Trie
{

    private Node root;
    public Trie()
    {
        root = new Node();
    }

    public void Insert(string word)
    {
        var node = root;
        for (int i = 0; i < word.Length; i++)
        {
            int idx = word[i] - 'a';
            if (node.Children[idx] == null)
                node.Children[idx] = new Node();
            node = node.Children[idx];
        }
        node.IsEnd = true;
    }

    public bool Search(string word)
    {
        var node = root;
        for (int i = 0; i < word.Length; i++)
        {
            int idx = word[i] - 'a';
            if (node.Children[idx] == null)
                return false;
            else
                node = node.Children[idx];
        }
        return node.IsEnd;
    }

    public bool StartsWith(string prefix)
    {
        var node = root;
        for (int i = 0; i < prefix.Length; i++)
        {
            int idx = prefix[i] - 'a';
            if (node.Children[idx] == null)
                return false;
            else
                node = node.Children[idx];
        }
        return true;
    }

    class Node
    {
        public bool IsEnd { get; set; }
        public Node[] Children { get; }

        public Node()
        {
            IsEnd = false;
            Children = new Node[26];
        }
    }
}

/**
 * Your Trie object will be instantiated and called as such:
 * Trie obj = new Trie();
 * obj.Insert(word);
 * bool param_2 = obj.Search(word);
 * bool param_3 = obj.StartsWith(prefix);
 */
// @lc code=end

