namespace LeetCode
{
    public class ListNode
    {
        public int Val { get; set; }
        public ListNode Next { get; set; }
        public ListNode(int val, ListNode next = null)
        {
            Val = val;
            Next = next;
        }
    }
}
