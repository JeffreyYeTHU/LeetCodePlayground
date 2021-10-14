/*
 * @lc app=leetcode.cn id=71 lang=csharp
 *
 * [71] 简化路径
 */

// @lc code=start
public class Solution
{
    public string SimplifyPath(string path)
    {
        int len = path.Length;
        if (len <= 1)
            return "/";

        // Solution 1 use 2 pointer
        // var res = new List<string>();
        // res.Add("/");
        // int slow = 0;
        // int fast = 1;
        // while (slow < len && fast < len)
        // {
        //     // skip connective /
        //     while (fast < len && path[fast] == '/')
        //     {
        //         fast++;
        //         slow++;
        //     }

        //     // fast pointer forward to next /
        //     while (fast < len && path[fast] != '/')
        //         fast++;

        //     // check current dir
        //     string currDir = path.Substring(slow + 1, fast - slow - 1);
        //     if (currDir == "" || currDir == ".")
        //     {
        //         // do nothing
        //     }
        //     else if (currDir == "..")
        //     {
        //         res = ToParent(res);
        //     }
        //     else
        //     {
        //         if (res.Count != 1)
        //             res.Add("/");
        //         res.Add(currDir);
        //     }

        //     slow = fast;
        //     fast++;
        // }
        // string simple = "";
        // foreach (var dir in res)
        // {
        //     simple += dir;
        // }
        // return simple;

        // Solution 2: split string
        var res = new List<string>();
        res.Add("/");
        string[] dirs = path.Split('/');
        foreach (var dir in dirs)
        {
            if (dir == "" || dir == ".")
                continue;
            else if (dir == "..")
                res = ToParent(res);
            else
            {
                if (res.Count != 1)
                    res.Add("/");
                res.Add(dir);
            }
        }
        string simple = "";
        foreach (var dir in res)
        {
            simple += dir;
        }
        return simple;
    }

    List<string> ToParent(List<string> path)
    {
        if (path.Count == 1)
            return path;
        else if (path.Count == 2)
        {
            path.RemoveAt(1);
            return path;
        }
        else
        {
            path.RemoveAt(path.Count - 1);
            path.RemoveAt(path.Count - 1);
            return path;
        }
    }
}
// @lc code=end

