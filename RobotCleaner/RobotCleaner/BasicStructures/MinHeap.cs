﻿using System;
using System.Collections.Generic;
using System.Text;

namespace RobotCleaner.BasicStructures
{
    public class MinHeap<T> where T : IComparable
    {
        private List<T> elements = new List<T>();

        public int GetSize()
        {
            return elements.Count;
        }

        public T GetMin()
        {
            return elements.Count > 0 ? elements[0] : default(T);
        }

        public void Add(T item)
        {
            elements.Add(item);
            HeapifyUp(elements.Count - 1);
        }

        public T PopMin()
        {
            if (elements.Count > 0)
            {
                T item = elements[0];
                elements[0] = elements[elements.Count - 1];
                elements.RemoveAt(elements.Count - 1);

                HeapifyDown(0);
                return item;
            }

            throw new InvalidOperationException("Heap is empty.");
        }

        private void HeapifyUp(int index)
        {
            var parent = GetParent(index);
            if (parent >= 0 && elements[index].CompareTo(elements[parent]) < 0)
            {
                var temp = elements[index];
                elements[index] = elements[parent];
                elements[parent] = temp;

                this.HeapifyUp(parent);
            }
        }

        private void HeapifyDown(int index)
        {
            var smallest = index;

            var left = GetLeft(index);
            var right = GetRight(index);

            if (left < GetSize() && elements[left].CompareTo(elements[index]) < 0)
            {
                smallest = left;
            }

            if (right < GetSize() && elements[right].CompareTo(elements[smallest]) < 0)
            {
                smallest = right;
            }

            if (smallest != index)
            {
                var temp = elements[index];
                elements[index] = elements[smallest];
                elements[smallest] = temp;

                HeapifyDown(smallest);
            }

        }

        private int GetParent(int index)
        {
            if (index <= 0)
            {
                return -1;
            }

            return (index - 1) / 2;
        }

        private int GetLeft(int index)
        {
            return 2 * index + 1;
        }

        private int GetRight(int index)
        {
            return 2 * index + 2;
        }
    }
}
