using System.Collections.Generic;
using System;
/*
 * @lc app=leetcode.cn id=869 lang=csharp
 *
 * [869] 重新排序得到 2 的幂
 */

// @lc code=start
public class Solution {
    public bool ReorderedPowerOf2(int n) {
        // get digits of n
        int cnt = 0;
        var digits = GetDigits(n);
        foreach(var key in digits.Keys)
            cnt += digits[key];

        // depend on how many digit of n, try the power of n
        int pow2 = 1;
        int low = (int)Math.Pow(10, cnt - 1);
        int high = (int)Math.Pow(10, cnt);
        while(pow2 < low){
            pow2 *= 2;
        }
        while(pow2 < high){
            var expect = GetDigits(pow2);
            if(TwoDicEqual(digits, expect))
                return true;
            pow2 *= 2;
        }
        return false;
    }

    Dictionary<int, int> GetDigits(int n){
        var digits = new Dictionary<int, int>();
        int quo = n;
        while(quo > 0){
            int digit = quo % 10;
            if(!digits.ContainsKey(digit))
                digits.Add(digit, 0);
            digits[digit]++;
            quo /= 10;
        }
        return digits;
    }

    bool TwoDicEqual(Dictionary<int, int> one, Dictionary<int, int> another){
        foreach(var key in one.Keys){
            if(!another.ContainsKey(key) || another[key] != one[key])
                return false;
        }
        return true;
    }
}
// @lc code=end

