/*
 * @lc app=leetcode.cn id=15 lang=csharp
 *
 * [15] 三数之和
 */

// @lc code=start
public class Solution
{
    public IList<IList<int>> ThreeSum(int[] nums)
    {
        Array.Sort(nums);
        return NSum(nums, 3, 0, 0);
    }

    // nums must be sorted.
    private IList<IList<int>> NSum(int[] nums, int n, int start, int target)
    {
        var res = new List<IList<int>>();
        int len = nums.Length;
        if (n < 2 || n > len)
            return res;

        if (n == 2)
        {
            // 2 sum
            int low = start;
            int high = len - 1;
            while (low < high)
            {
                int left = nums[low];
                int right = nums[high];
                if (left + right < target)
                {
                    low++;
                }
                else if (left + right > target)
                {
                    high--;
                }
                else
                {
                    res.Add(new List<int>() { left, right });
                    while (low < high && nums[low] == left) low++;
                    while (low < high && nums[high] == right) high--;
                }
            }
        }
        else
        {
            // reduce to n-1 sum
            for (int i = start; i < len; i++)
            {
                var sub = NSum(nums, n - 1, i + 1, target - nums[i]);
                foreach (var s in sub)
                {
                    s.Add(nums[i]);
                    res.Add(s);
                }
                while (i < len - 1 && nums[i] == nums[i + 1]) i++;
            }
        }

        return res;
    }
}
// @lc code=end

