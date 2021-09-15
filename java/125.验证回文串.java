/*
 * @lc app=leetcode.cn id=125 lang=java
 *
 * [125] 验证回文串
 */

// @lc code=start
class Solution {
    public boolean isPalindrome(String s) {
        int n = s.length();
        if (n == 0)
            return true;
        int i = 0, j = n - 1;
        while (i < n && j >= 0 && i < j) {
            while (i < n && !Character.isLetterOrDigit(s.charAt(i))) {
                i++;
            }
            while (j >= 0 && !Character.isLetterOrDigit(s.charAt(j))) {
                j--;
            }
            if (i < n && j >= 0 && lower(s.charAt(i)) != lower(s.charAt(j))) {
                return false;
            }
            i++;
            j--;
        }
        return true;
    }

    boolean isDigit(char c) {
        return c >= '0' && c <= '9';
    }

    boolean isAlfabet(char c) {
        char low = lower(c);
        return low >= 'a' && low <= 'z';
    }

    char lower(char c) {
        return (char) (c | ' ');
    }
}
// @lc code=end
