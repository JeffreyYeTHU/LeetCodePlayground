/*
 * @lc app=leetcode.cn id=1032 lang=csharp
 *
 * [1032] 字符流
 */

// @lc code=start
public class StreamChecker
{
    private Node root = new Node();
    private StringBuilder sb = new StringBuilder();  // to store the stream
    private int maxLen = 0;  // this is to control the length of sb

    public StreamChecker(string[] words)
    {
        foreach (var word in words)
            Insert(word);
    }

    public bool Query(char letter)
    {
        // build stream
        sb.Insert(0, letter);
        if (sb.Length > maxLen)
            sb.Remove(sb.Length - 1, 1);

        // evaluate
        Node temp = root;
        for (int i = 0; i < sb.Length; i++)
        {
            int idx = sb[i] - 'a';
            if (temp.Children[idx] == null)
                return false;
            if (temp.Children[idx].IsLeaf)
                return true;
            temp = temp.Children[idx];
        }
        return temp.IsLeaf;
    }

    private void Insert(string word)
    {
        maxLen = Math.Max(maxLen, word.Length);

        // reverse set up the dic
        Node temp = root;
        for (int i = word.Length - 1; i >= 0; i--)
        {
            int idx = word[i] - 'a';
            if (temp.Children[idx] == null)
                temp.Children[idx] = new Node();
            temp = temp.Children[idx];
        }
        temp.IsLeaf = true;
    }

    class Node
    {
        public bool IsLeaf { get; set; }
        public Node[] Children { get; set; }
        public Node()
        {
            IsLeaf = false;
            Children = new Node[26];
        }
    }
}

/**
 * Your StreamChecker object will be instantiated and called as such:
 * StreamChecker obj = new StreamChecker(words);
 * bool param_1 = obj.Query(letter);
 */
// @lc code=end

