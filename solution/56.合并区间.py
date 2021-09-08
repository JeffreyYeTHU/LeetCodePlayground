#
# @lc app=leetcode.cn id=56 lang=python
#
# [56] 合并区间
#

# @lc code=start
class Solution(object):
    def merge(self, intervals):
        """
        :type intervals: List[List[int]]
        :rtype: List[List[int]]
        """
        intervals.sort(key=lambda ivt:ivt[0])
        res = []
        res.append(intervals[0])
        for i in range(1, len(intervals)):
            curr = intervals[i]
            last = res[-1]
            if curr[0] <= last[1]:
                last[1] = max(curr[1], last[1])
            else:
                res.append(curr)
        return res
# @lc code=end

