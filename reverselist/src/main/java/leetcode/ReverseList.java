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
        int count = getListCount(head);
        if (count <= k)
            return head;

        // recursive

    }

    private int getListCount(ListNode head) {
        int count = 1;
        var curr = head;
        while (curr.next != null)
            count++;
        return count;
    }

    private List<ListNode> splitList(ListNode head, int k) {
        firstHead = head;

    }
}
