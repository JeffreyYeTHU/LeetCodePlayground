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

    }
}