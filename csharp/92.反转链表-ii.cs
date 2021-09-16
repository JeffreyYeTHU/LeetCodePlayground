/*
 * @lc app=leetcode.cn id=92 lang=csharp
 *
 * [92] 反转链表 II
 */

// @lc code=start
/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int val=0, ListNode next=null) {
 *         this.val = val;
 *         this.next = next;
 *     }
 * }
 */
public class Solution
{
    public ListNode ReverseBetween(ListNode head, int left, int right)
    {
        // // solution 1: iterative
        // if (left == right)
        //     return head;
        // int cnt = 1;
        // ListNode pre = null;
        // var curr = head;
        // while (cnt < left)
        // {
        //     cnt++;
        //     pre = curr;
        //     curr = curr.next;
        // }

        // // save for later use
        // var first = curr;
        // var preFirst = pre;

        // // set up for reverse
        // pre = curr;
        // curr = curr.next;
        // while (cnt < right)
        // {
        //     var temp = curr.next;
        //     curr.next = pre;
        //     pre = curr;
        //     curr = temp;
        //     cnt++;
        // }
        // if (preFirst == null)
        // {
        //     first.next = curr;
        //     return pre;
        // }
        // else
        // {
        //     preFirst.next = pre;
        //     first.next = curr;
        //     return head;
        // }

        // solution 2: recursive
        if (left == 1)
            return ReverseFirstN(head, right);
        head.next = ReverseBetween(head.next, left - 1, right - 1);
        return head;
    }

    ListNode ReverseFirstN(ListNode head, int n)
    {
        if (head == null || head.next == null || n == 1)
            return head;
        var newHead = ReverseFirstN(head.next, n - 1);
        var temp = head.next.next;
        head.next.next = head;
        head.next = temp;
        return newHead;
    }
}
// @lc code=end

