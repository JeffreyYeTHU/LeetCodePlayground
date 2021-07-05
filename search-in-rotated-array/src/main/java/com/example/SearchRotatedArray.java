package com.example;

public class SearchRotatedArray {
    public static int search(int[] nums, int target) {
        int leftIdx = 0;
        int rightIdx = nums.length - 1;

        while (leftIdx <= rightIdx && possibleHasTarget(nums, leftIdx, rightIdx, target)) {
            // if found, return
            if (nums[leftIdx] == target)
                return leftIdx;
            if (nums[rightIdx] == target)
                return rightIdx;

            // do binary search
            int middleIdx = (leftIdx + rightIdx + 1) / 2;
            if (possibleHasTarget(nums, leftIdx, middleIdx, target)) {
                leftIdx++;
                rightIdx = middleIdx;
            } else if (possibleHasTarget(nums, middleIdx, rightIdx, target)) {
                leftIdx = middleIdx;
                rightIdx--;
            } else {
                return -1;
            }
        }

        // non found
        return -1;
    }

    // leftIdx less than or equal to rightIdx
    private static boolean possibleHasTarget(int[] nums, int leftIdx, int rightIdx, int target) {
        int left = nums[leftIdx];
        int right = nums[rightIdx];
        if (left < right) {
            return target <= right && target >= left;
        } else if (left > right) {
            return target <= right || target >= left;
        } else {
            // left == right
            return left == target;
        }
    }
}
