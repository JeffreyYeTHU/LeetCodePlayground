/*
 * @lc app=leetcode.cn id=165 lang=csharp
 *
 * [165] 比较版本号
 */

// @lc code=start
public class Solution
{
    public int CompareVersion(string version1, string version2)
    {
        var v1 = version1.Split('.');
        var v2 = version2.Split('.');
        int cnt = Math.Min(v1.Length, v2.Length);
        for (int i = 0; i < cnt; i++)
        {
            int a = int.Parse(v1[i]);
            int b = int.Parse(v2[i]);
            if (a < b)
                return -1;
            else if (a > b)
                return 1;
        }
        if (v1.Length > v2.Length)
        {
            for (int i = cnt; i < v1.Length; i++)
            {
                int a = int.Parse(v1[i]);
                if (a > 0)
                    return 1;
            }
        }
        if (v1.Length < v2.Length)
        {
            for (int i = cnt; i < v2.Length; i++)
            {
                int b = int.Parse(v2[i]);
                if (b > 0)
                    return -1;
            }
        }

        return 0;
    }
}
// @lc code=end

