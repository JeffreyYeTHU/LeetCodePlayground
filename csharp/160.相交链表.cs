/*
 * @lc app=leetcode.cn id=160 lang=csharp
 *
 * [160] 相交链表
 */

// @lc code=start
/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) { val = x; }
 * }
 */
public class Solution
{
    public ListNode GetIntersectionNode(ListNode headA, ListNode headB)
    {
        // Solution: using set
        // if (headA == null || headB == null)
        //     return null;
        // var set = new HashSet<ListNode>();
        // var pa = headA;
        // while (pa != null)
        // {
        //     set.Add(pa);
        //     pa = pa.next;
        // }
        // var pb = headB;
        // while (pb != null)
        // {
        //     if (set.Contains(pb))
        //         return pb;
        //     pb = pb.next;
        // }
        // return null;

        // Solution2: using 2 pointer
        if (headA == null || headB == null)
            return null;
        var pa = headA;
        var pb = headB;
        while (pa != pb)
        {
            pa = (pa == null) ? headB : pa.next;
            pb = (pb == null) ? headA : pb.next;
        }
        return pa;
    }
}
// @lc code=end

