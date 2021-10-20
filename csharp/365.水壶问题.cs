/*
 * @lc app=leetcode.cn id=365 lang=csharp
 *
 * [365] 水壶问题
 */

// @lc code=start
public class Solution
{
    public bool CanMeasureWater(int jug1Capacity, int jug2Capacity, int targetCapacity)
    {
        Stack<(int r1, int r2)> stk = new();
        HashSet<(int, int)> seen = new();
        stk.Push((0, 0));
        while (stk.Count != 0)
        {
            if (seen.Contains(stk.Peek()))
            {
                stk.Pop();
                continue;
            }

            (int r1, int r2) = stk.Pop();
            seen.Add((r1, r2));
            if (r1 == targetCapacity || r2 == targetCapacity || r1 + r2 == targetCapacity)
                return true;
            stk.Push((jug1Capacity, r2));
            stk.Push((r1, jug2Capacity));
            stk.Push((0, r2));
            stk.Push((r1, 0));
            stk.Push((Math.Max(0, r1 + r2 - jug2Capacity), Math.Min(jug2Capacity, r1 + r2)));
            stk.Push((Math.Min(jug1Capacity, r1 + r2), Math.Max(0, r1 + r2 - jug1Capacity)));
        }
        return false;
    }
}
// @lc code=end

