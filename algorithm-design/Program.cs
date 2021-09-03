using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode
{
    class Program
    {
        static void Main(string[] args)
        {
            int[][] rectangles = new int[5][];
            rectangles[0] = new int[] { 1, 1, 3, 3 };
            rectangles[1] = new int[] { 3, 1, 4, 2 };
            rectangles[2] = new int[] { 3, 2, 4, 4 };
            rectangles[3] = new int[] { 1, 3, 2, 4 };
            rectangles[4] = new int[] { 2, 3, 3, 4 };
            var vertice = new HashSet<(int, int)>();
            int minX = int.MaxValue;
            int minY = int.MaxValue;
            int maxX = int.MinValue;
            int maxY = int.MinValue;
            int actualArea = 0;
            bool res;
            foreach (var rec in rectangles)
            {
                actualArea += (rec[2] - rec[0]) * (rec[3] - rec[1]);
                minX = Math.Min(minX, rec[0]);
                minY = Math.Min(minY, rec[1]);
                maxX = Math.Max(maxX, rec[2]);
                maxY = Math.Max(maxY, rec[3]);
                if (vertice.Contains((rec[0], rec[1])))
                    vertice.Remove((rec[0], rec[1]));
                else
                    vertice.Add((rec[0], rec[1]));
                if (vertice.Contains((rec[2], rec[3])))
                    vertice.Remove((rec[2], rec[3]));
                else
                    vertice.Add((rec[2], rec[3]));
            }

            int expectArea = (maxX - minX) * (maxY - minY);
            if (actualArea != expectArea) res = false;
            if (vertice.Count != 4) res = false;
            if (!vertice.Contains((minX, minY))) res = false;
            if (!vertice.Contains((minX, maxY))) res = false;
            if (!vertice.Contains((maxX, minY))) res = false;
            if (!vertice.Contains((maxX, maxY))) res = false;
        }
    }
}
