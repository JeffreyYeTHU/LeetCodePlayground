/*
 * @lc app=leetcode.cn id=445 lang=csharp
 *
 * [445] 两数相加 II
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
public class Solution {
    public ListNode AddTwoNumbers(ListNode l1, ListNode l2) {
        var num1 = new List<int>();
        var num2 = new List<int>();
        while(l1 != null){
            num1.Add(l1.val);
            l1 = l1.next;
        }
        while(l2 != null){
            num2.Add(l2.val);
            l2 = l2.next;
        }
        int carry = 0;
        int i = num1.Count -1;
        int j = num2.Count -1;
        var sum = new List<int>();
        while(i >=0 || j >=0){
            int a = i < 0 ? 0 : num1[i];
            int b = j < 0 ? 0 : num2[j];
            int digitSum = a + b + carry;
            int s = digitSum % 10;
            carry = digitSum / 10;
            sum.Add(s);
            i--;
            j--;
        }
        if(carry != 0)
            sum.Add(carry);
        int len = sum.Count;
        var res = new ListNode(sum[len - 1]);
        var temp = res;
        for(int k= len-2; k>=0; k--){
            var next = new ListNode(sum[k]);
            temp.next = next;
            temp = temp.next;
        }
        return res;
    }
}
// @lc code=end

