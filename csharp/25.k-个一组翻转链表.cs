/*
 * @lc app=leetcode.cn id=25 lang=csharp
 *
 * [25] K 个一组翻转链表
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
    public ListNode ReverseKGroup(ListNode head, int k)
    {
        // // solution 1: iterative
        // if (head == null || head.next == null || k == 1)
        //     return head;

        // // get cnt
        // int cnt = 0;
        // var p = head;
        // while (p != null)
        // {
        //     cnt++;
        //     p = p.next;
        // }

        // // reverse
        // var (newHead, newRear, remainHead) = ReverseFirstN(head, k);
        // var currHead = newHead;
        // var currRear = newRear;
        // var currRemainHead = remainHead;
        // int groupCnt = cnt / k;
        // for (int i = 1; i < groupCnt; i++)
        // {
        //     var (nextHead, nextRear, nextRemainHead) = ReverseFirstN(currRemainHead, k);
        //     currRear.next = nextHead;
        //     currRemainHead = nextRemainHead;
        //     currRear = nextRear;
        // }
        // return newHead;

        // solution 2: recursive
        if (head == null)
            return null;
        var a = head;
        var b = head;
        for (int i = 0; i < k; i++)
        {
            if (b == null)
                return head;
            b = b.next;
        }
        var newHead = Reverse(a, b);
        a.next = ReverseKGroup(b, k);
        return newHead;
    }

    // Remain unchanged if n is lareger than the list
    (ListNode GroupHead, ListNode GroupRear, ListNode RemainHead) ReverseFirstN(ListNode head, int n)
    {
        if (head == null || head.next == null || n == 1)
            return (head, null, null);

        int i = 0;
        var p = head;
        while (p != null && i < n)
        {
            p = p.next;
            i++;
        }
        if (i < n - 1)
            return (head, null, null);
        var oldHead = head;
        ListNode pre = null;
        ListNode curr = head;
        int cnt = n;
        while (curr != null && cnt > 0)
        {
            var temp = curr.next;
            curr.next = pre;
            pre = curr;
            curr = temp;
            cnt--;
        }
        oldHead.next = curr;
        return (pre, oldHead, curr);
    }

    // reverse [a, b)
    ListNode Reverse(ListNode a, ListNode b)
    {
        ListNode pre = null;
        var curr = a;
        while (curr != b)
        {
            var temp = curr.next;
            curr.next = pre;
            pre = curr;
            curr = temp;
        }
        return pre;
    }
}
// @lc code=end

