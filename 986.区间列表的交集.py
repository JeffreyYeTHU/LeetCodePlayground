#
# @lc app=leetcode.cn id=986 lang=python
#
# [986] 区间列表的交集
#

# @lc code=start
class Solution(object):
    def intervalIntersection(self, firstList, secondList):
        """
        :type firstList: List[List[int]]
        :type secondList: List[List[int]]
        :rtype: List[List[int]]
        """
        i,j = 0,0
        res = []
        while i < len(firstList) and j < len(secondList):
            a1, a2 = firstList[i][0], firstList[i][1]
            b1, b2 = secondList[j][0], secondList[j][1]
            if not (a2 < b1 or b2 < a1):
                res.append([max(a1, b1), min(a2, b2)])
            if a2 < b2: 
                i += 1
            else:
                j += 1
        return res
# @lc code=end

