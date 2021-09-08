/*
 * @lc app=leetcode.cn id=659 lang=csharp
 *
 * [659] 分割数组为连续子序列
 */

// @lc code=start
public class Solution
{
    public bool IsPossible(int[] nums)
    {
        var valToCnt = new Dictionary<int, int>();
        var seqEnds = new Dictionary<int, int>();
        foreach (var n in nums)
        {
            if (!valToCnt.ContainsKey(n))
                valToCnt.Add(n, 1);
            else
                valToCnt[n]++;
        }
        foreach (var n in nums)
        {
            if (valToCnt[n] >= 1)
            {
                if (seqEnds.ContainsKey(n - 1) && seqEnds[n - 1] >= 1)
                {
                    valToCnt[n]--;
                    seqEnds[n - 1]--;
                    if (seqEnds.ContainsKey(n))
                        seqEnds[n]++;
                    else
                        seqEnds.Add(n, 1);
                }
                else
                {
                    if (valToCnt.ContainsKey(n + 1) &&
                        valToCnt.ContainsKey(n + 2) &&
                        valToCnt[n + 1] >= 1 && valToCnt[n + 2] >= 1)
                    {
                        valToCnt[n]--;
                        valToCnt[n + 1]--;
                        valToCnt[n + 2]--;
                        if (seqEnds.ContainsKey(n + 2))
                            seqEnds[n + 2]++;
                        else
                            seqEnds.Add(n + 2, 1);
                    }
                    else
                        return false;
                }
            }
        }
        return true;
    }
}
// @lc code=end

