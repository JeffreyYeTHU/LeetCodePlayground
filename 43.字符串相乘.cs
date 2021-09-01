/*
 * @lc app=leetcode.cn id=43 lang=csharp
 *
 * [43] 字符串相乘
 */

// @lc code=start
public class Solution
{
    public string Multiply(string num1, string num2)
    {
        // solution 1:
        // if (num1 == "0" || num2 == "0")
        //     return "0";
        // int n = num2.Length;
        // int j = n - 1;
        // int weight = 0;
        // string res = "";
        // while (j >= 0)
        // {
        //     string s = MulChar(num1, num2[j]);
        //     string curr = AppendZeros(s, weight);
        //     res = Add(res, curr);
        //     // Console.WriteLine($"when j={j}, s={s}, curr={curr}, res={res}");
        //     j--;
        //     weight++;
        // }
        // return res;

        // solution 2:
        int m = num1.Length;
        int n = num2.Length;
        int[] res = new int[m + n];
        for (int i = m - 1; i >= 0; i--)
        {
            for (int j = n - 1; j >= 0; j--)
            {
                int mul = (num1[i] - '0') * (num2[j] - '0');
                int p1 = i + j;
                int p2 = i + j + 1;
                int sum = mul + res[p2];
                res[p2] = sum % 10;
                res[p1] += sum / 10;
            }
        }

        int k = 0;
        while (k < res.Length && res[k] == 0)
            k++;
        string str = "";
        while (k < res.Length)
        {
            str += res[k];
            k++;
        }
        return str.Length == 0 ? "0" : str;
    }

    string AppendZeros(string s, int z)
    {
        if (z == 0) return s;
        char[] zeros = new char[z];
        Array.Fill(zeros, '0');
        string zero = new string(zeros);
        return s + zero;
    }

    string Add(string a, string b)
    {
        int i = a.Length - 1;
        int j = b.Length - 1;
        int carry = 0;
        string res = "";
        while (i >= 0 || j >= 0)
        {
            int abit = (i >= 0) ? a[i] - '0' : 0;
            int bbit = (j >= 0) ? b[j] - '0' : 0;
            int sum = abit + bbit + carry;
            int newBit = sum % 10;
            carry = sum / 10;
            res = res.Insert(0, newBit.ToString());
            i--;
            j--;
        }
        if (carry >= 1)
            return res.Insert(0, carry.ToString());
        else
            return res;
    }

    string MulChar(string a, char c)
    {
        string res = "";
        int carry = 0;
        int cint = c - '0';
        int i = a.Length - 1;
        while (i >= 0)
        {
            int m = cint * (a[i] - '0') + carry;
            int newBit = m % 10;
            carry = m / 10;
            res = res.Insert(0, newBit.ToString());
            i--;
        }
        if (carry >= 1)
            return res.Insert(0, carry.ToString());
        else
            return res;
    }
}
// @lc code=end

