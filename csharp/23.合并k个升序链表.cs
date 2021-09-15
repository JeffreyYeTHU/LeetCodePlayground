/*
 * @lc app=leetcode.cn id=23 lang=csharp
 *
 * [23] 合并K个升序链表
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
    public ListNode MergeKLists(ListNode[] lists)
    {
        // // Solution 1: connect all data and then sort
        // var data = new List<int>();
        // int m = lists.Length;
        // if (m == 0) return null;
        // foreach (var list in lists)
        // {
        //     var curr = list;
        //     while (curr != null)
        //     {
        //         data.Add(curr.val);
        //         curr = curr.next;
        //     }
        // }
        // var dummy = new ListNode(-1);
        // var p = dummy;
        // foreach (var val in data.OrderBy(v => v))
        // {
        //     p.next = new ListNode(val);
        //     p = p.next;
        // }
        // return dummy.next;

        // Solution 2: merge 2 list each time
        int m = lists.Length;
        if (m == 0) return null;
        var res = lists[0];
        for (int i = 1; i < m; i++)
        {
            res = MergeTwo(res, lists[i]);
        }
        return res;
    }

    // In place merge of two list
    ListNode MergeTwo(ListNode one, ListNode two)
    {
        var dummy = new ListNode(-1);
        var curr = dummy;
        while (one != null || two != null)
        {
            if (one == null)
            {
                curr.next = two;
                break;
            }
            else if (two == null)
            {
                curr.next = one;
                break;
            }
            else
            {
                if (one.val <= two.val)
                {
                    curr.next = one;
                    curr = curr.next;
                    one = one.next;
                }
                else
                {
                    curr.next = two;
                    curr = curr.next;
                    two = two.next;
                }
            }
        }
        return dummy.next;
    }

    void Print(ListNode head)
    {
        while (head != null)
        {
            Console.Write(head.val + ", ");
            head = head.next;
        }
    }
}
// @lc code=end

