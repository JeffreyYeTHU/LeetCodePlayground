using System;

namespace LeetCode
{
    public class MyPriorityQueue
    {
        // implement a min heap
        // do not use index 0
        // leftChildIdx = 2*pIdx, rightChildIdx = 2*pIdx + 1
        // parentIdx = chilidIdx/2
        // do not consider auto resize

        private int[] _heap;
        private int _size;
        private int _capacity;
        public MyPriorityQueue(int capacity)
        {
            _heap = new int[capacity + 1];
            _size = 0;
            _capacity = capacity;
        }

        public void Offer(int val){
            if(_size == _capacity)
                throw new Exception("Queue is full");
            _size++;
            _heap[_size] = val;
            SiftUp(_size);
        }

        public int Poll(){
            if(_size == 0)
                throw new Exception("Queue is empty");
            int val = _heap[1];
            _heap[1] = _heap[_size];
            _size--;
            SiftDown(1);
            return val;
        }

        private void SiftUp(int idx){
            while(idx > 1 && _heap[idx] < _heap[idx/2]){
                int temp = _heap[idx];
                _heap[idx] = _heap[idx/2];
                _heap[idx/2] = temp;
                idx = idx/2;
            }
        }

        private void SiftDown(int idx){
            while(2*idx <= _size){
                int minIdx = 2*idx;
                if(minIdx < _size && _heap[minIdx] > _heap[minIdx+1]){
                    minIdx++;
                }
                if(_heap[idx] < _heap[minIdx]){
                    break;
                }
                int temp = _heap[idx];
                _heap[idx] = _heap[minIdx];
                _heap[minIdx] = temp;
                idx = minIdx;
            }
        }
    }
}