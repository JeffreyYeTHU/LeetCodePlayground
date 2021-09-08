/*
 * @lc app=leetcode.cn id=773 lang=csharp
 *
 * [773] 滑动谜题
 */

// @lc code=start
public class Solution
{
    public int SlidingPuzzle(int[][] board)
    {
        string start = "";
        for (int i = 0; i < 2; i++)
        {
            for (int j = 0; j < 3; j++)
                start += board[i][j];
        }
        string target = "123450";
        var visited = new HashSet<string>();
        var q = new Queue<string>();
        q.Enqueue(start);
        visited.Add(start);
        int step = 0;
        while (q.Count != 0)
        {
            int cnt = q.Count;
            for (int i = 0; i < cnt; i++)
            {
                string curr = q.Dequeue();
                if (curr == target)
                    return step;

                // add adjacent
                foreach (var adj in Permute(curr))
                {
                    if (!visited.Contains(adj))
                    {
                        q.Enqueue(adj);
                        visited.Add(adj);
                    }
                }
            }
            step++;
        }
        return -1;
    }

    List<string> Permute(string s)
    {
        var res = new List<string>();
        int idx = s.IndexOf('0');
        if (idx % 3 == 0)
        {
            res.Add(new string(Swap(s.ToCharArray(), idx, idx + 1)));
            res.Add(new string(Swap(s.ToCharArray(), 0, 3)));
        }
        else if (idx % 3 == 1)
        {
            res.Add(new string(Swap(s.ToCharArray(), idx, idx - 1)));
            res.Add(new string(Swap(s.ToCharArray(), idx, idx + 1)));
            res.Add(new string(Swap(s.ToCharArray(), 1, 4)));
        }
        else
        {
            res.Add(new string(Swap(s.ToCharArray(), idx, idx - 1)));
            res.Add(new string(Swap(s.ToCharArray(), 2, 5)));
        }
        return res;
    }

    char[] Swap(char[] arr, int i, int j)
    {
        char tmp = arr[i];
        arr[i] = arr[j];
        arr[j] = tmp;
        return arr;
    }
}
// @lc code=end

