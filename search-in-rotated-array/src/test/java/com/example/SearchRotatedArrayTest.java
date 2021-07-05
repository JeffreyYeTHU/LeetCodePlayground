package com.example;

import static org.junit.Assert.assertEquals;
import org.junit.Test;

/**
 * Unit test
 */
public class SearchRotatedArrayTest {

    @Test
    public void arrayHasTarget() {
        int[] nums = new int[] { 5, 6, 1, 2, 3 };
        int target = 2;
        int idx = SearchRotatedArray.search(nums, target);
        assertEquals(3, idx);
    }

    @Test
    public void arrayHasTargetSecond() {
        int[] nums = new int[] { 4, 5, 6, 7, 0, 1, 2 };
        int target = 0;
        int idx = SearchRotatedArray.search(nums, target);
        assertEquals(4, idx);
    }

    @Test
    public void arrayDonotHaveTarget() {
        int[] nums = new int[] { 5, 7, 1, 3 };
        int target = 2;
        int idx = SearchRotatedArray.search(nums, target);
        assertEquals(-1, idx);
    }
}
