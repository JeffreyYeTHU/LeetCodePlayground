namespace LeetCode
{
    internal class FindCelebrity
    {
        public int Find()
        {
            // find candidate
            int n = 10;
            int candidate = 0;
            for (int other = 1; other < n; other++)
            {
                if (!Knows(other, candidate) || Knows(candidate, other))
                {
                    // the current candidate is not a celebrity
                    candidate = other;
                }
            }

            // check if the candidate is a celebrity
            for (int other = 0; other < n; other++)
            {
                if (other != candidate && (Knows(candidate, other) || !Knows(other, candidate)))
                {
                    return -1;
                }
            }
            return candidate;
        }

        private bool Knows(int a, int b)
        {
            return false;
        }
    }
}