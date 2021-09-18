/*
 * @lc app=leetcode.cn id=744 lang=csharp
 *
 * [744] 寻找比目标字母大的最小字母
 */

// @lc code=start
public class Solution
{
    public char NextGreatestLetter(char[] letters, char target)
    {
        // binary search: find right bound
        int n = letters.Length;
        int left = 0;
        int right = n - 1;
        while (left <= right)
        {
            int mid = left + (right - left) / 2;
            if (letters[mid] == target)
                left = mid + 1;
            else if (letters[mid] > target)
                right = mid - 1;
            else if (letters[mid] < target)
                left = mid + 1;
        }
        if (right < 0)
            return letters[0];
        else
            return letters[(right + 1) % n];
    }
}
// @lc code=end

