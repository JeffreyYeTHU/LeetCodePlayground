using System;
namespace LeetCode
{
    public class ReverseList
    {
        public ListNode ReverseBetween(ListNode head, int start, int end)
        {
            var dummy = new ListNode(-1);
            dummy.Next = head;
            int cnt = 0;
            var p = dummy;
            ListNode startNode = null, preStart = null, endNode = null, postEnd = null;
            while(p != null)
            {
                cnt++;
                if (cnt == start - 1)
                {
                    preStart = p;
                    startNode = p.Next;
                }
                else if (cnt == end)
                {
                    endNode = p;
                    postEnd = p.Next;
                    break;
                }
                p = p.Next;
            }

            // do the reverse
            ListNode pre = null;
            ListNode curr = startNode;
            while(curr != endNode)
            {
                var temp = curr.Next;
                curr.Next = pre;
                pre = curr;
                curr = temp;
            }
            preStart.Next = endNode;
            startNode.Next = postEnd;
            return dummy.Next;
        }
    }
}
