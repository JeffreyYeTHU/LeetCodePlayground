/*
 * @lc app=leetcode.cn id=391 lang=csharp
 *
 * [391] 完美矩形
 */

// @lc code=start
public class Solution
{
    public bool IsRectangleCover(int[][] rectangles)
    {
        var vertice = new HashSet<(int, int)>();
        int minX = int.MaxValue;
        int minY = int.MaxValue;
        int maxX = int.MinValue;
        int maxY = int.MinValue;
        int actualArea = 0;
        foreach (var rec in rectangles)
        {
            actualArea += (rec[2] - rec[0]) * (rec[3] - rec[1]);
            minX = Math.Min(minX, rec[0]);
            minY = Math.Min(minY, rec[1]);
            maxX = Math.Max(maxX, rec[2]);
            maxY = Math.Max(maxY, rec[3]);
            var p1 = (rec[0], rec[1]);
            var p2 = (rec[0], rec[3]);
            var p3 = (rec[2], rec[1]);
            var p4 = (rec[2], rec[3]);
            foreach (var p in new List<(int, int)> { p1, p2, p3, p4 })
            {
                if (vertice.Contains(p))
                    vertice.Remove(p);
                else
                    vertice.Add(p);
            }
        }

        int expectArea = (maxX - minX) * (maxY - minY);
        if (actualArea != expectArea) return false;
        if (vertice.Count != 4) return false;
        if (!vertice.Contains((minX, minY))) return false;
        if (!vertice.Contains((minX, maxY))) return false;
        if (!vertice.Contains((maxX, minY))) return false;
        if (!vertice.Contains((maxX, maxY))) return false;
        return true;
    }
}
// @lc code=end

