/*
 * @lc app=leetcode.cn id=1039 lang=csharp
 *
 * [1039] 多边形三角剖分的最低得分
 */

// @lc code=start
public class Solution {
    public int MinScoreTriangulation(int[] values) {
        // // backtrack: cannot optimize, very slow
        // BackTrack(values.ToList(), 0);
        // return minScore;

        // A different definition of recursive function
        
    }

    // int minScore = int.MaxValue;
    // void BackTrack(List<int> options, int pathScore){
    //     // base case
    //     if(options.Count < 3){
    //         minScore = Math.Min(pathScore, minScore);
    //         return;
    //     }

    //     // do backtrack
    //     int cnt = options.Count;
    //     for(int i=0; i < cnt; i++){
    //         // make choice 
    //         int addedScore = options[(i-1+cnt) % cnt] * options[i % cnt] * options[(i+1) % cnt];
    //         int curr = options[i];
    //         options.RemoveAt(i);
    //         BackTrack(options, pathScore + addedScore);

    //         // undo choice
    //         options.Insert(i, curr);
    //     }
    // }
}
// @lc code=end

