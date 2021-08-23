/*
 * @lc app=leetcode.cn id=1093 lang=csharp
 *
 * [1093] 大样本统计
 */

// @lc code=start
public class Solution {
    // min, max, avg, median, mode
    public double[] SampleStats(int[] count) {
        long total = count.Sum();
        long half = total / 2;
        bool totalIsEven = total % 2 == 0;
        int min = 256;
        int max = -1;
        long sum = 0;
        int mode = 0;
        long cnt = 0;
        double med1 = -1;
        double med2 = -1;
        for (int i = 0; i < count.Length; i++)
        {
            if(count[i] == 0)
                continue;
            if(count[i] > count[mode])
            {
                mode = i;
            }
            sum += count[i] * i;
            if (i > max)
                max = i;
            if (i < min)
                min = i;
            cnt += count[i];
            if (totalIsEven){
                if(cnt == half)
                {
                    med1 = i;
                }
                else if (cnt > half){
                    if(med1 < 0)
                        med1 = i;
                    if(med2 < 0)
                        med2 = i;
                }
            }
            else
            {
                // odd cnt
                if(cnt >= half +1 && med1 < 0)
                {
                    med1 = i;
                    med2 = i;
                }
            }
        }
        double avg = (double)sum / (double)total;
        return new double[]{min, max, avg, (med1 + med2) / 2.0, mode};
    }
}
// @lc code=end

