package leetcode;

public final class Palindrome {

    // First solution: use recursion
    private ListNode left;

    public boolean isPalindrome(ListNode head) {
        if (head == null)
            return false;
        left = head;
        return postTraverse(head);
    }

    private boolean postTraverse(ListNode right) {
        // base case
        if (right == null)
            return true;

        boolean res = postTraverse(right.next);
        res = res && (left.val == right.val);
        left = left.next;
        return res;
    }

    // second solution, use slow/fast pointer
    public boolean isPalindromeUsePointer(ListNode head) {
        // find middle
        ListNode slow = head;
        ListNode fast = head;
        while (fast != null && fast.next != null) {
            slow = slow.next;
            fast = fast.next.next;
        }

        // when total is odd, need advance slow one more
        if (fast != null)
            slow = slow.next;

        // revere the second half
        ListNode right = reverse(slow);

        // do comparison
        ListNode left = head;
        while (right != null) {
            if (left.val != right.val)
                return false;
            left = left.next;
            right = right.next;
        }
        return true;
    }

    private ListNode reverse(ListNode head) {
        ListNode pre = null;
        ListNode curr = head;
        while (curr != null) {
            ListNode next = curr.next;
            curr.next = pre;
            pre = curr;
            curr = next;
        }
        return pre;
    }
}