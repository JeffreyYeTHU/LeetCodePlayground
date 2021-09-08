/*
 * @lc app=leetcode.cn id=1024 lang=csharp
 *
 * [1024] 视频拼接
 */

// @lc code=start
public class Solution
{
    public int VideoStitching(int[][] clips, int time)
    {
        var query = clips
            .Select(c => new { Start = c[0], End = c[1] })
            .OrderBy(c => c.Start)
            .ToList();
        var first = query.First();
        if (first.Start > 0)
            return -1;
        int currEnd = first.End;
        var candidates = new List<int>();
        int cnt = 1;
        for (int i = 1; i < query.Count && currEnd < time;)
        {
            while (i < query.Count && query[i].Start <= currEnd)
            {
                if (query[i].End >= currEnd)
                    candidates.Add(query[i].End);
                i++;
            }
            if (candidates.Count == 0)
                return -1;
            else
            {
                currEnd = candidates.Max();
                candidates.Clear();
                cnt++;
            }
        }
        if (currEnd >= time)
            return cnt;
        else
            return -1;
    }
}
// @lc code=end

