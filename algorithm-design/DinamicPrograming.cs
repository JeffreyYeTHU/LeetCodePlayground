namespace LeetCode
{
    public class DinamicPrograming
    {
        // 509
        public int Fib(int n)
        {
            int pre = 0;
            int curr = 1;
            if (n == 0) return 0;
            if (n == 1) return 1;
            int res = 0;
            for (int i = 2; i <= n; i++)
            {
                res = pre + curr;
                curr = res;
                pre = curr;
            }
            return res;
        }

    }
}