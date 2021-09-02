using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = "1 + 1 ";
            int res = Compute(new LinkedList<char>(s.ToCharArray()));
        }

        static int Compute(LinkedList<char> strChars)
        {
            var stk = new Stack<int>();
            char op = '+';
            int num = 0;
            while (strChars.Count != 0)
            {
                char c = strChars.First();
                strChars.RemoveFirst();

                if (c == '(')
                    num = Compute(strChars);

                if (char.IsDigit(c))
                    num = num * 10 + (c - '0');

                if ((!char.IsDigit(c) && c != ' ') || strChars.Count == 0)
                {
                    switch (op)
                    {
                        case '+':
                            stk.Push(num);
                            break;

                        case '-':
                            stk.Push(-num);
                            break;
                    }

                    // update sign and num
                    num = 0;
                    op = c;
                }

                if (c == ')')
                    break;
            }

            return stk.Sum();
        }
    }
}
