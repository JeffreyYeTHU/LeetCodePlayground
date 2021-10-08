using System.Reflection;
using System.Collections.Generic;
using System;
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
        return Dp(values, 0, values.Length -1);
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

    // Dp(i, j) : min score of form by values[i] to values[j]
    Dictionary<(int ,int), int> memo = new Dictionary<(int, int), int>();
    int Dp(int[] values, int i, int j){
        // base case
        if(j - i == 2){
            return values[i] * values[i+1] * values[i+2];
        }

        if(memo.ContainsKey((i,j)))
            return memo[(i,j)];
        int minScore = int.MaxValue;
        for(int k = i+1; k < j; k++){
            int secletTriangle = values[i] * values[k] * values[j];
            int currScore;
            if(k == i+1)
                currScore = secletTriangle + Dp(values, k, j);
            else if (k == j -1)
                currScore = secletTriangle + Dp(values, i, k);
            else
                currScore = secletTriangle + Dp(values, i, k) + Dp(values, k, j);
            minScore = Math.Min(minScore, currScore);
        }
        memo.Add((i,j), minScore);
        return minScore;
    }
}
// @lc code=end

