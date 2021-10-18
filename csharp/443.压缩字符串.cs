using System.Runtime.InteropServices;
/*
 * @lc app=leetcode.cn id=443 lang=csharp
 *
 * [443] 压缩字符串
 */

// @lc code=start
public class Solution {
    public int Compress(char[] chars) {
        int p = 0;
        char currChar = chars[0];
        int cnt = 0;
        for(int i=0; i<chars.Length;){
            while(i<chars.Length && chars[i] == currChar)
            {
                cnt++;
                i++;
            }

            // write restult
            chars[p] = currChar;
            p++;
            if(cnt > 1){
                var cntChars = cnt.ToString().ToCharArray();
                for(int j=0; j < cntChars.Length; j++)
                {
                    chars[p] = cntChars[j];
                    p++;
                }
            }
        
            // update curr char
            cnt = 0;
            if(i < chars.Length)
                currChar = chars[i];
        }
        return p;
    }
}
// @lc code=end

