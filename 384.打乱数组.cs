/*
 * @lc app=leetcode.cn id=384 lang=csharp
 *
 * [384] 打乱数组
 */

// @lc code=start
public class Solution
{

    private readonly int[] _nums;
    Random rnd = new Random();
    public Solution(int[] nums)
    {
        _nums = nums;
    }

    /** Resets the array to its original configuration and return it. */
    public int[] Reset()
    {
        return _nums;
    }

    /** Returns a random shuffling of the array. */
    public int[] Shuffle()
    {
        int n = _nums.Length;
        var temp = new int[n];
        Array.Copy(_nums, temp, n);
        for (int i = 0; i < n; i++)
        {
            int r = rnd.Next(i, n);
            int t = temp[i];
            temp[i] = temp[r];
            temp[r] = t;
        }
        return temp;
    }
}

/**
 * Your Solution object will be instantiated and called as such:
 * Solution obj = new Solution(nums);
 * int[] param_1 = obj.Reset();
 * int[] param_2 = obj.Shuffle();
 */
// @lc code=end

