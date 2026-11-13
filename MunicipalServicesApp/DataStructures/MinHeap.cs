using System;
using System.Collections.Generic;

namespace MunicipalServicesApp.DataStructures
{
    internal class MinHeap
    {
        private class HeapItem
        {
            public ReportedIssue Issue { get; set; }
            public int Priority { get; set; }

            public HeapItem(ReportedIssue issue, int priority)
            {
                Issue = issue;
                Priority = priority;
            }
        }

        private readonly List<HeapItem> heap
            = new List<HeapItem>();

        public int Count
        {
            get { return heap.Count; }
        }

        public void Insert(ReportedIssue issue)
        {
            int priority = GetPriority(issue.Category);

            HeapItem item =
                new HeapItem(issue, priority);

            heap.Add(item);

            HeapifyUp(heap.Count - 1);
        }

        public ReportedIssue Peek()
        {
            if (heap.Count == 0)
            {
                return null;
            }

            return heap[0].Issue;
        }

        public ReportedIssue RemoveMin()
        {
            if (heap.Count == 0)
            {
                return null;
            }

            ReportedIssue minimumIssue =
                heap[0].Issue;

            heap[0] = heap[heap.Count - 1];

            heap.RemoveAt(heap.Count - 1);

            if (heap.Count > 0)
            {
                HeapifyDown(0);
            }

            return minimumIssue;
        }

        private void HeapifyUp(int index)
        {
            while (index > 0)
            {
                int parentIndex =
                    (index - 1) / 2;

                if (heap[index].Priority >=
                    heap[parentIndex].Priority)
                {
                    break;
                }

                Swap(index, parentIndex);

                index = parentIndex;
            }
        }

        private void HeapifyDown(int index)
        {
            while (true)
            {
                int leftChild =
                    (2 * index) + 1;

                int rightChild =
                    (2 * index) + 2;

                int smallest = index;

                if (leftChild < heap.Count &&
                    heap[leftChild].Priority <
                    heap[smallest].Priority)
                {
                    smallest = leftChild;
                }

                if (rightChild < heap.Count &&
                    heap[rightChild].Priority <
                    heap[smallest].Priority)
                {
                    smallest = rightChild;
                }

                if (smallest == index)
                {
                    break;
                }

                Swap(index, smallest);

                index = smallest;
            }
        }

        private void Swap(int firstIndex, int secondIndex)
        {
            HeapItem temporary =
                heap[firstIndex];

            heap[firstIndex] =
                heap[secondIndex];

            heap[secondIndex] =
                temporary;
        }

        private int GetPriority(string category)
        {
            if (string.IsNullOrWhiteSpace(category))
            {
                return 6;
            }

            switch (category.ToLower())
            {
                case "public safety":
                    return 1;

                case "electricity":
                    return 2;

                case "water and sanitation":
                    return 3;

                case "roads":
                    return 4;

                case "waste management":
                    return 5;

                default:
                    return 6;
            }
        }
    }
}