package leetcode;

public class ReverseList {
    ListNode successor = null; // for reverseN

    public ListNode reverseBetween(ListNode head, int m, int n) {
        if (m == 1) {
            return reverseN(head, n);
        }
        head.next = reverseBetween(head.next, m - 1, n - 1);
        return head;
    }

    public ListNode reverseN(ListNode head, int n) {
        if (n == 1) {
            successor = head.next;
            return head;
        }
        ListNode last = reverseN(head.next, n - 1);
        head.next.next = head;
        head.next = successor;
        return last;
    }

    // reverse [a, b)
    public ListNode reverse(ListNode a, ListNode b) {
        ListNode pre = null;
        ListNode curr = a;
        while (curr != b) {
            // save next
            ListNode next = curr.next;

            // reverse
            curr.next = pre;

            // shift pointer
            pre = curr;
            curr = next;
        }
        return pre;
    }

    public ListNode reverseBetweenIterative(ListNode head, int left, int right) {
        if (left == right) {
            return head;
        }

        ListNode curr = head;
        ListNode pre = null;
        ListNode preLeftNode = null;
        ListNode leftNode = null;
        ListNode rightNode = null;
        int index = 1;
        while (index <= right) {
            ListNode next = curr.next;
            if (index < left) {
                // do nothing
            } else if (index == left) {
                // left boundary
                preLeftNode = pre;
                leftNode = curr;
            } else if (index > left && index < right) {
                // reverse
                curr.next = pre;
            } else {
                // right boundary
                rightNode = curr;
                curr.next = pre;
                leftNode.next = next;
                if (preLeftNode != null)
                    preLeftNode.next = curr;
            }

            // increment
            pre = curr;
            curr = next;
            index++;
        }

        if (left > 1) {
            return head;
        } else {
            return rightNode;
        }
    }

    public ListNode reverseKGroup(ListNode head, int k) {
        // base case
        if (head == null)
            return null;
        ListNode a = head;
        ListNode b = head;
        for (int i = 0; i < k; i++) {
            // less than k, return directly
            if (b == null)
                return head;
            b = b.next;
        }

        // reverse [head, b), then do it recursively
        // be aware that b is the (k+1) element
        ListNode newHead = reverse(a, b);
        a.next = reverseKGroup(b, k);
        return newHead;
    }
}
