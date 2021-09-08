#
# @lc app=leetcode.cn id=18 lang=python
#
# [18] 四数之和
#

# @lc code=start


class Solution(object):
    def fourSum(self, nums, target):
        """
        :type nums: List[int]
        :type target: int
        :rtype: List[List[int]]
        """
        nums.sort()
        return self.n_sum(nums, 4, 0, target)

    def n_sum(self, nums, n, start, target):
        sz = len(nums)
        res = []
        if (n < 2 or n > sz):
            return res
        if (n == 2):
            lo = start
            hi = sz-1
            while(lo < hi):
                left = nums[lo]
                right = nums[hi]
                sum = left + right
                if(sum < target):
                    while(lo < hi and nums[lo] == left):
                        lo += 1
                elif (sum > target):
                    while(lo < hi and nums[hi] == right):
                        hi -= 1
                else:
                    res.append([left, right])
                    while(lo < hi and nums[lo] == left):
                        lo += 1
                    while(lo < hi and nums[hi] == right):
                        hi -= 1
            print("After do 2-sum, res=")
            print(res)
        else:
            for i in range(start, sz):
                sub = self.n_sum(nums, n-1, i+1, target - nums[i])
                for s in sub:
                    s.append(nums[i])
                    res.append(s)
                while(i < sz-1 and nums[i] == nums[i+1]):
                    i += 1

        return res
# @lc code=end
