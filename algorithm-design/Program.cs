using System;

namespace LeetCode
{
    class Program
    {
        static void Main(string[] args)
        {
            var c = new Course4();
            var pre = new int[1][];
            var qureies = new int[2][];
            pre[0] = new int[]{1, 0};
            qureies[0] = new int[]{0, 1};
            qureies[1] = new int[]{1, 0};
            var res = c.CheckIfPrerequisite(2, pre, qureies);
        }
    }
}
