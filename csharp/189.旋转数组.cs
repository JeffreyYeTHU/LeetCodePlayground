/*
 * @lc app=leetcode.cn id=189 lang=csharp
 *
 * [189] 旋转数组
 */

// @lc code=start
public class Solution {
    public void Rotate(int[] nums, int k) {
        int n = nums.Length;
        k = k % n;
        if (k == 0)
            return;
        int[] temp = new int[k];
        for(int i = n-k; i<n; i++){
            temp[i-(n-k)] = nums[i];
        }
        for(int i = n - 1; i >= k; i--){
            nums[i] = nums[i-k];
        }
        for(int i=0; i<k; i++){
            nums[i] = temp[i];
        }
    }
}
// @lc code=end

