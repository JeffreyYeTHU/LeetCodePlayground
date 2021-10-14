/*
 * @lc app=leetcode.cn id=75 lang=csharp
 *
 * [75] 颜色分类
 */

// @lc code=start
public class Solution
{
    public void SortColors(int[] nums)
    {
        // // solution 1: tow run
        // // count
        // int[] count = new int[3];  // red, white, blue
        // for (int i = 0; i < nums.Length; i++)
        // {
        //     if (nums[i] == 0)
        //         count[0]++;
        //     else if (nums[i] == 1)
        //         count[1]++;
        //     else
        //         count[2]++;
        // }

        // // set
        // int k = 0;
        // for (int i = 0; i < count[0]; i++, k++)
        // {
        //     nums[k] = 0;
        // }
        // for (int i = 0; i < count[1]; i++, k++)
        // {
        //     nums[k] = 1;
        // }
        // for (int i = 0; i < count[2]; i++, k++)
        // {
        //     nums[k] = 2;
        // }

        // solution 2: one run: use 2 pointer, front pointer put 0, rear pointer put 2
        // after 0,2 put, set 1;
        int p0 = 0;
        int p1 = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] == 1)
            {
                Swap(nums, i, p1);
                p1++;
            }
            else if (nums[i] == 0)
            {
                Swap(nums, i, p0);
                if (p0 < p1)
                    Swap(nums, i, p1);
                p0++;
                p1++;
            }
        }
    }

    void Swap(int[] nums, int i, int j)
    {
        int temp = nums[i];
        nums[i] = nums[j];
        nums[j] = temp;
    }
}
// @lc code=end

