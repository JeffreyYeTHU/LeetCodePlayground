/*
 * @lc app=leetcode.cn id=203 lang=csharp
 *
 * [203] 移除链表元素
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
    public ListNode RemoveElements(ListNode head, int val)
    {
        // Solution 1: use a virtual head node to handle the first node
        // var h = new ListNode(-1);
        // h.next = head;
        // var pre = h;
        // var curr = head;
        // while (curr != null)
        // {
        //     if (curr.val == val)
        //     {
        //         curr = curr.next;
        //         pre.next = curr;
        //     }
        //     else
        //     {
        //         pre = curr;
        //         curr = curr.next;
        //     }
        // }
        // return h.next;

        // solution 2: direct handle the first node
        var p = head;
        while (p != null && p.val == val)
            p = p.next;
        var newHead = p;
        var pre = p;
        var curr = p;
        while (curr != null)
        {
            if (curr.val == val)
            {
                curr = curr.next;
                pre.next = curr;
            }
            else
            {
                pre = curr;
                curr = curr.next;
            }
        }
        return newHead;
    }
}
// @lc code=end

