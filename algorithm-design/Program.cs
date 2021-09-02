using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode
{
    class Program
    {
        static HashSet<int> parenPos;
        static Dictionary<int, int> leftParenToRight;
        static void Main(string[] args)
        {
            string s = "1-(3+5-2+(3+19-(3-1-4+(9-4-(4-(1+(3)-2)-5)+8-(3-5)-1)-4)-5)-4+3-9)-4-(3+2-5)-10";
            var sb = new StringBuilder();
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] != ' ')
                    sb.Append(s[i]);
            }
            string sNospace = sb.ToString();

            parenPos = new HashSet<int>();
            leftParenToRight = new Dictionary<int, int>();
            var stk = new Stack<int>();
            for (int i = 0; i < sNospace.Length; i++)
            {
                if (sNospace[i] == '(')
                {
                    parenPos.Add(i);
                    stk.Push(i);
                }
                else if (sNospace[i] == ')')
                {
                    parenPos.Add(i);
                    leftParenToRight.Add(stk.Pop(), i);
                }
            }
            int res = Compute(sNospace, 0, sNospace.Length - 1);
        }

        static int Compute(string s, int i, int j)
        {
            // base case
            if (i > j)
                return 0;

            bool hasParen = RangeContainsParen(s, i, j, out int leftParenPos);
            if (hasParen)
            {
                // open the first level of parenthese
                int res = Compute(s, i, leftParenPos - 2);
                int rightParenPos = 0;
                while (parenPos.Contains(leftParenPos))
                {
                    rightParenPos = leftParenToRight[leftParenPos];
                    if (leftParenPos == i || s[leftParenPos - 1] == '+')
                        res += Compute(s, leftParenPos + 1, rightParenPos - 1);
                    else
                        res -= Compute(s, leftParenPos + 1, rightParenPos - 1);

                    bool stillHasLevelOne = RangeContainsParen(s, rightParenPos + 2, j, out leftParenPos);
                    if (stillHasLevelOne)
                    {
                        if (s[rightParenPos + 1] == '+')
                            res += Compute(s, rightParenPos + 2, leftParenPos - 2);
                        else
                            res -= Compute(s, rightParenPos + 2, leftParenPos - 2);
                    }
                }
                if (rightParenPos == j || s[rightParenPos + 1] == '+')
                    res += Compute(s, rightParenPos + 2, j);
                else
                    res -= Compute(s, rightParenPos + 2, j);
                return res;
            }
            else
            {
                int res = 0;
                int slow = i - 1;
                int fast = i;
                if (s[i] == '+' || s[i] == '-')
                {
                    slow++;
                    fast++;
                }
                while (fast <= j)
                {
                    while (fast <= j)
                    {
                        if (s[fast] == '+' || s[fast] == '-')
                            break;
                        fast++;
                    }

                    int curr = int.Parse(s.Substring(slow + 1, fast - slow - 1));
                    if (slow == i - 1 || s[slow] == '+')
                        res += curr;
                    else
                        res -= curr;

                    slow = fast;
                    fast++;
                }
                return res;
            }
        }

        // for s[i..j], check if it has parenthese, if so, set the first
        //  left paren pos to parameter 'leftParen'
        static bool RangeContainsParen(string s, int i, int j, out int leftParenPos)
        {
            for (int k = i; k <= j; k++)
            {
                if (parenPos.Contains(k))
                {
                    leftParenPos = k;
                    return true;
                }
            }
            leftParenPos = -1;
            return false;
        }

    }
}
