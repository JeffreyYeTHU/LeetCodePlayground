/*
 * @lc app=leetcode.cn id=206 lang=csharp
 *
 * [206] 反转链表
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
    public ListNode ReverseList(ListNode head)
    {
        // solution 1: iterative
        if (head == null) return null;
        ListNode pre = null;
        var curr = head;
        while (curr != null)
        {
            var temp = curr.next;
            curr.next = pre;
            pre = curr;
            curr = temp;
        }
        return pre;

        // // solution 2: recursive
        // if (head == null || head.next == null)
        //     return head;
        // var newHead = ReverseList(head.next);
        // head.next.next = head;
        // head.next = null;
        // return newHead;
    }
}
// @lc code=end

