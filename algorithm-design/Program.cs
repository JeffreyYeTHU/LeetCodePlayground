using System;

namespace LeetCode
{
    class Program
    {
        static void Main(string[] args)
        {
            var window = new SlideWindow();
            var res = window.MaxSlidingWindow(new int[] { 1, 3, -1, -3, 5, 3, 6, 7 }, 3);
        }
    }
}
