/*
 * @lc app=leetcode.cn id=752 lang=csharp
 *
 * [752] 打开转盘锁
 */

// @lc code=start
public class Solution
{
    public int OpenLock(string[] deadends, string target)
    {
        string start = "0000";
        var deads = deadends.ToHashSet();
        if (deads.Contains(start))
            return -1;
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
                for (int j = 0; j < 4; j++)
                {
                    string up = DileUp(curr, j);
                    string down = DileDown(curr, j);
                    if (!visited.Contains(up) && !deads.Contains(up))
                    {
                        q.Enqueue(up);
                        visited.Add(up);
                    }
                    if (!visited.Contains(down) && !deads.Contains(down))
                    {
                        q.Enqueue(down);
                        visited.Add(down);
                    }
                }
            }
            step++;
        }
        return -1;
    }

    string DileUp(string s, int idx)
    {
        var carr = s.ToCharArray();
        if (carr[idx] == '9')
            carr[idx] = '0';
        else
            carr[idx]++;
        return new string(carr);
    }

    string DileDown(string s, int idx)
    {
        var carr = s.ToCharArray();
        if (carr[idx] == '0')
            carr[idx] = '9';
        else
            carr[idx]--;
        return new string(carr);
    }
}
// @lc code=end

