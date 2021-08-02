namespace LeetCode
{
    // 141. 环形链表  https://leetcode-cn.com/problems/linked-list-cycle/
    public class TwoPointer
    {
        public bool HasCycle(ListNode head)
        {
            var slow = head;
            var fast = head;
            while (fast != null && fast.next != null)
            {
                slow = slow.next;
                fast = fast.next.next;
                if (fast == slow) return true;
            }
            return false;
        }
        }
    }
}