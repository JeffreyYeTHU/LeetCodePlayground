/*
 * @lc app=leetcode.cn id=24 lang=csharp
 *
 * [24] 两两交换链表中的节点
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
    public ListNode SwapPairs(ListNode head)
    {
        if (head == null) return null;
        var dummy = new ListNode(-1);
        dummy.next = head;
        var curr = dummy;
        while (curr.next != null && curr.next.next != null)
        {
            var a = curr.next;
            var b = a.next;
            curr.next = b;
            var temp = b.next;
            b.next = a;
            a.next = temp;
            curr = curr.next.next;
        }
        return dummy.next;
    }
}
// @lc code=end

