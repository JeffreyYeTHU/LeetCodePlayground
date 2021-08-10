/*
 * @lc app=leetcode.cn id=1288 lang=csharp
 *
 * [1288] 删除被覆盖区间
 */

// @lc code=start
public class Solution
{
    public int RemoveCoveredIntervals(int[][] intervals)
    {
        int n = intervals.Length;
        var listOfInterval = intervals
            .Select(v => new Interval { Start = v[0], End = v[1] })
            .OrderBy(itv => itv.Start).ThenByDescending(itv => itv.End)
            .ToList();
        var stack = new Stack<int>();
        foreach (var itv in listOfInterval)
        {
            // Console.WriteLine($"start={itv.Start}, end={itv.End}");
            while (stack.Count != 0 && stack.Peek() < itv.End)
            {
                stack.Pop();
            }
            if (stack.Count != 0)
                n--;
            stack.Push(itv.End);
        }
        return n;
    }

    public class Interval
    {
        public int Start { get; set; }
        public int End { get; set; }
    }
}
// @lc code=end

