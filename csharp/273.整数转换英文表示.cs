/*
 * @lc app=leetcode.cn id=273 lang=csharp
 *
 * [273] 整数转换英文表示
 */

// @lc code=start
public class Solution
{
    string[] dicUnder20 = new string[]{"One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Eleven",
                                "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen"};
    string[] dicTens = new string[] { "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" };
    public string NumberToWords(int num)
    {
        if (num == 0)
            return "Zero";
        int bil = num / 1_000_000_000;
        List<string> res = new();
        if (bil > 0)
        {
            res.Add(HundredsToString(bil));
            res.Add("Billion");
            num %= 1_000_000_000;
        }
        int mil = num / 1_000_000;
        if (mil > 0)
        {
            res.Add(HundredsToString(mil));
            res.Add("Million");
            num %= 1_000_000;
        }
        int th = num / 1000;
        if (th > 0)
        {
            res.Add(HundredsToString(th));
            res.Add("Thousand");
            num %= 1000;
        }
        if (num > 0)
            res.Add(HundredsToString(num));

        string str = res[0];
        for (int i = 1; i < res.Count; i++)
            str += " " + res[i];
        return str;
    }

    // 0 < n < 1000
    string HundredsToString(int n)
    {
        List<string> res = new();
        int h = n / 100;
        if (h > 0)
        {
            res.Add(dicUnder20[h - 1]);
            res.Add("Hundred");
        }
        n = n % 100;
        if (n >= 20)
        {
            int t = n / 10;
            res.Add(dicTens[t - 2]);
            n = n % 10;
        }
        if (n > 0)
            res.Add(dicUnder20[n - 1]);

        string str = res[0];
        for (int i = 1; i < res.Count; i++)
            str += " " + res[i];
        return str;
    }
}
// @lc code=end

