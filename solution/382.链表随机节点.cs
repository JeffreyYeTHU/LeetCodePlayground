/*
 * @lc app=leetcode.cn id=382 lang=csharp
 *
 * [382] 链表随机节点
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

    /** @param head The linked list's head.
        Note that the head is guaranteed to be not null, so it contains at least one node. */
    public Solution(ListNode head)
    {
        ListNode p = head;
        while (p != null)
        {
            length++;
            p = p.next;
        }
        nodes = new int[length];
        p = head;
        int i = 0;
        while (p != null)
        {
            nodes[i] = p.val;
            p = p.next;
            i++;
        }
        rnd = new Random();
    }

    /** Returns a random node's value. */
    int[] nodes;
    int length = 0;
    Random rnd;
    public int GetRandom()
    {
        int n = rnd.Next(length);
        return nodes[n];
    }
}

/**
 * Your Solution object will be instantiated and called as such:
 * Solution obj = new Solution(head);
 * int param_1 = obj.GetRandom();
 */
// @lc code=end

