using System.Collections.Generic;

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

        // 167. 两数之和 II - 输入有序数组
        public int[] TwoSum(int[] numbers, int target)
        {
            int left = 0;
            int right = numbers.Length - 1;
            while (left < right)
            {
                int sum = numbers[left] + numbers[right];
                if (sum == target)
                {
                    return new int[] { left + 1, right + 1 };
                }
                else if (sum < target)
                {
                    left++;
                }
                else if (sum > target)
                {
                    right--;
                }
            }
            return new int[] { -1, -1 };
        }

        public int[] TwoSum2(int[] numbers, int target)
        {
            var valToIdx = new Dictionary<int, int>();
            for (int i = 0; i < numbers.Length; i++)
            {
                if (!valToIdx.ContainsKey(numbers[i]))
                    valToIdx.Add(numbers[i], i);
                else if (target == numbers[i - 1] + numbers[i])
                    return new int[] { i, i + 1 };
            }
            for (int i = 0; i < numbers.Length; i++)
            {
                int match = target - numbers[i];
                if (match != numbers[i] && valToIdx.ContainsKey(match))
                {
                    int matchIdx = valToIdx[match];
                    return new int[] { i + 1, matchIdx + 1 };
                }
            }
            return new int[] { -1, -1 };
        }

        // 344. 反转字符串
        public void ReverseString(char[] s)
        {
            int left = 0;
            int right = s.Length - 1;
            while (left < right)
            {
                char temp = s[left];
                s[left] = s[right];
                s[right] = temp;
                left++;
                right--;
            }
        }
    }
}