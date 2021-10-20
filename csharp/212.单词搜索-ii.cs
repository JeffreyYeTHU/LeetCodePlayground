/*
 * @lc app=leetcode.cn id=212 lang=csharp
 *
 * [212] 单词搜索 II
 */

// @lc code=start
public class Solution
{
    char[][] board;
    int m;
    int n;
    public IList<string> FindWords(char[][] board, string[] words)
    {
        this.board = board;
        m = board.Length;
        n = board[0].Length;
        Dictionary<char, List<(int Row, int Col)>> start = new();
        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                char c = board[i][j];
                if (!start.ContainsKey(c))
                    start.Add(c, new List<(int, int)>());
                start[c].Add((i, j));
            }
        }
        Trie trie = new Trie();
        var res = new List<string>();
        foreach (var word in words)
        {
            if (trie.StartsWith(word))
                res.Add(word);
            else if (start.ContainsKey(word[0]))
            {
                foreach (var st in start[word[0]])
                {
                    visited = new bool[m, n];
                    if (Dfs(word, st.Row, st.Col, 0))
                    {
                        res.Add(word);
                        trie.Insert(word);
                        break;
                    }
                }
            }
        }
        return res;
    }

    // Dfs: start at board[row][col], find the word[idx...end]
    bool[,] visited;
    bool Dfs(string word, int row, int col, int idx)
    {
        if (idx >= word.Length)
            return true;
        else if (row < 0 || col < 0 || row >= m || col >= n || visited[row, col] || board[row][col] != word[idx])
            return false;

        visited[row, col] = true;
        var res = Dfs(word, row + 1, col, idx + 1)
            || Dfs(word, row - 1, col, idx + 1)
            || Dfs(word, row, col + 1, idx + 1)
            || Dfs(word, row, col - 1, idx + 1);

        visited[row, col] = false;
        return res;
    }

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
}
// @lc code=end

