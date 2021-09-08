namespace LeetCode
{
    public sealed class Sorter
    {
        public void BubbleSort(int[] arr)
        {
            for (int i = arr.Length - 1; i >= 0; i--)
            {
                for (int j = 0; j < i; j++)
                {
                    if (arr[j] > arr[j + 1])
                        Swap(arr, j, j + 1);
                }
            }
        }

        public void QuickSort(int[] arr, int left, int right)
        {
            if (left >= right)
                return;

            int lo = left;
            int hi = right;
            int key = arr[lo];
            while (lo < hi)
            {
                while (lo < hi && arr[hi] >= key)
                    hi--;
                arr[lo] = arr[hi];
                while (lo < hi && arr[lo] <= key)
                    lo++;
                arr[hi] = arr[lo];
            }
            arr[lo] = key;
            QuickSort(arr, left, lo - 1);
            QuickSort(arr, lo + 1, right);
        }

        public void InsertSort(int[] arr)
        {
            for (int i = 1; i < arr.Length; i++)
            {
                int temp = arr[i];
                for (int j = i - 1; j >= 0; j--)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        arr[j + 1] = arr[j];
                        arr[j] = temp;
                    }
                    else
                        break;
                }
            }
        }

        public void ShellSort(int[] arr)
        {
            for (int d = arr.Length; d >= 1; d /= 2)
            {
                for (int i = d; i < arr.Length; i++)
                {
                    int temp = arr[i];
                    for (int j = i - d; j >= 0; j -= d)
                    {
                        if (arr[j] > temp)
                        {
                            arr[j + d] = arr[j];
                            arr[j] = temp;
                        }
                        else
                            break;
                    }
                }
            }
        }

        public void SelectSort(int[] arr)
        {
            for (int i = 0; i < arr.Length - 1; i++)
            {
                int minIdx = i;
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[j] < arr[minIdx])
                        minIdx = j;
                }
                Swap(arr, minIdx, i);
            }
        }

        public void HeapSort(int[] arr)
        {
            var pq = new PriorityQueue();
            foreach (int a in arr)
                pq.Offer(a);
            for (int i = 0; i < arr.Length; i++)
                arr[i] = pq.Poll();
        }

        public int[] MergeSort(int[] arr)
        {
            return MergeSort(arr, 0, arr.Length - 1);
        }

        private int[] MergeSort(int[] arr, int left, int right)
        {
            if (left == right)
                return new int[] { arr[left] };

            int mid = left + (right - left) / 2;
            var leftPart = MergeSort(arr, left, mid);
            var rightPart = MergeSort(arr, mid + 1, right);
            return Merge(leftPart, rightPart);
        }

        private int[] Merge(int[] leftPart, int[] rightPart)
        {
            int m = leftPart.Length;
            int n = rightPart.Length;
            int[] res = new int[m + n];
            int i = 0;
            int j = 0;
            int k = 0;
            while (i < m || j < n)
            {
                if ((i < m && j >= n) ||
                    (i < m && j < n && leftPart[i] < rightPart[j]))
                {
                    res[k] = leftPart[i];
                    k++;
                    i++;
                }
                else
                {
                    res[k] = rightPart[j];
                    k++;
                    j++;
                }
            }
            return res;
        }

        private void Swap(int[] arr, int p, int q)
        {
            int temp = arr[p];
            arr[p] = arr[q];
            arr[q] = temp;
        }
    }
}