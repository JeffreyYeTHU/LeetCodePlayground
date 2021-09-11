/*
 * @lc app=leetcode.cn id=392 lang=csharp
 *
 * [392] 判断子序列
 */

// @lc code=start
public class Solution {
    public bool IsSubsequence(string s, string t) {
        int i =0;
        int j=0;
        while(i < s.Length && j < t.Length){
            if(s[i] == t[j]){
                i++;
                j++;
            }
            else
                j++;
        }
        return i >= s.Length;
    }
}
// @lc code=end

