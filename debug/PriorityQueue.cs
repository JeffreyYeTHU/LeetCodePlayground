namespace LeetCode
{
    // Simple implementation, do not consider auto scale for internal array
    // arr[0] - do not use
    // so the actual data start with index 1, this come with a benifit that
    // parent and child relation is simplier:
    // p -> c1 = 2*p, c2 = 2*p+1;
    // c -> p = c/2
    public sealed class PriorityQueue
    {
        private int[] arr = new int[32];
        private int count = 0;
        public void Offer(int a)
        {
            count++;
            arr[count] = a;
            LiftUp(count);
        }

        public int Poll()
        {
            Swap(1, count);
            int val = arr[count];
            arr[count] = 0;
            count--;
            PushDown(1);
            return val;
        }

        private void LiftUp(int idx)
        {
            while (idx > 1 && arr[idx / 2] > arr[idx])
            {
                Swap(idx / 2, idx);
                idx = idx / 2;
            }
        }

        private void PushDown(int p)
        {
            while (p <= count / 2)
            {
                int leftIdx = 2 * p;
                int rightIdx = 2 * p + 1;
                if (rightIdx <= count)
                {
                    // both left and right child exist
                    if (arr[p] > arr[leftIdx] || arr[p] < arr[rightIdx])
                    {
                        if (arr[leftIdx] < arr[rightIdx])
                        {
                            Swap(p, leftIdx);
                            p = leftIdx;
                        }
                        else
                        {
                            Swap(p, rightIdx);
                            p = rightIdx;
                        }
                    }
                    else
                        break;
                }
                else
                {
                    // only left child exist
                    if (arr[p] > arr[leftIdx])
                    {
                        Swap(p, leftIdx);
                        p = leftIdx;
                    }
                    else
                        break;
                }
            }
        }

        private void Swap(int i, int j)
        {
            int temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }
    }
}