/*
 * @lc app=leetcode.cn id=83 lang=csharp
 *
 * [83] 删除排序链表中的重复元素
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
    public ListNode DeleteDuplicates(ListNode head)
    {
        if (head == null) return null;
        var s = head;
        var f = head;
        while (f != null)
        {
            if (s.val != f.val)
            {
                s = s.next;
                s.val = f.val;
            }
            f = f.next;
        }
        s.next = null;
        return head;
    }
}
// @lc code=end

