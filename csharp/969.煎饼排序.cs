/*
 * @lc app=leetcode.cn id=969 lang=csharp
 *
 * [969] 煎饼排序
 */

// @lc code=start
public class Solution
{
    public IList<int> PancakeSort(int[] arr)
    {
        Psort(arr, arr.Length);
        return res;
    }

    // sort arr[0..k-1]
    List<int> res = new List<int>();
    void Psort(int[] arr, int k)
    {
        if (k <= 1) return;

        // move k to the right position
        int idx = Array.IndexOf<int>(arr, k);
        if (idx == 0)
        {
            Reverse(arr, k);
            res.Add(k);
        }
        else if (idx < k - 1)
        {
            Reverse(arr, idx + 1);
            Reverse(arr, k);
            res.Add(idx + 1);
            res.Add(k);
        }

        Psort(arr, k - 1);
    }

    void Reverse(int[] arr, int k)
    {
        if (k > arr.Length || k <= 0)
            return;
        int low = 0;
        int high = k - 1;
        while (low < high)
        {
            int temp = arr[low];
            arr[low] = arr[high];
            arr[high] = temp;
            low++;
            high--;
        }
    }
}
// @lc code=end

