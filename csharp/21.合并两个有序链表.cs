/*
 * @lc app=leetcode.cn id=21 lang=csharp
 *
 * [21] 合并两个有序链表
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
    public ListNode MergeTwoLists(ListNode l1, ListNode l2)
    {
        var dummy = new ListNode(-1);
        var curr = dummy;
        while (l1 != null || l2 != null)
        {
            if (l1 == null)
            {
                curr.next = new ListNode(l2.val);
                l2 = l2.next;
                curr = curr.next;
            }
            else if (l2 == null)
            {
                curr.next = new ListNode(l1.val);
                l1 = l1.next;
                curr = curr.next;
            }
            else if (l1 != null && l2 != null)
            {
                if (l1.val <= l2.val)
                {
                    curr.next = new ListNode(l1.val);
                    l1 = l1.next;
                    curr = curr.next;
                }
                else
                {
                    curr.next = new ListNode(l2.val);
                    l2 = l2.next;
                    curr = curr.next;
                }
            }
        }
        return dummy.next;
    }
}
// @lc code=end

