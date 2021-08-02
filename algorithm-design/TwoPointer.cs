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

        // 142. 环形链表 II
        public ListNode DetectCycle(ListNode head)
        {
            var slow = head;
            var fast = head;
            while (fast != null && fast.next != null)
            {
                fast = fast.next.next;
                slow = slow.next;
                if (slow == fast) break;
            }
            if (fast == null || fast.next == null)
                return null;
            slow = head;
            while (slow != fast)
            {
                slow = slow.next;
                fast = fast.next;
            }
            return slow;
        }
    }
}