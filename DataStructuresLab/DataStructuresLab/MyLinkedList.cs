using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;

namespace DataStructuresLab
{
    public class MyLinkedList<T>
    {
        Node<T> head;
        Node<T> tail;
        public int Count { get; private set; }

        public void Add(T value)
        {
            Node<T> node = new Node<T>(value);
            if (head == null)
                head = node;
            else
            {
                tail.Next = node;
                node.Previous = tail;
            }
            tail = node;
            Count++;
        }
        public void AddFirst(T value)
        {
            Node<T> node = new Node<T>(value);
            Node<T> temp = head;
            node.Next = temp;
            head = node;
            if(Count == 0)
            {
                tail = head;
            }
            else
            {
                temp.Previous = node;
            }
            Count++;
        }
        public Node<T> GetFirst()
        {
            return head;
        }
        public bool Contains(T value)
        {
            Node<T> current = head;
            while (current != null)
            {
                if (current.Value.Equals(value))
                    return true;
                current = current.Next;
            }
            return false;
        }
        public void Clear()
        {
            head = null;
            tail = null;
            Count = 0;
        }
        public void Remove(T value)
        {
            Node<T> current = head;
            while (current != null)
            {
                if (current.Value.Equals(value))
                {
                    break;
                }
                current = current.Next;
            }
            if (current != null)
            {
                if (current.Next != null)
                {
                    current.Next.Previous = current.Previous;
                }
                else
                {
                    tail = current.Previous;
                }
                if (current.Previous != null)
                {
                    current.Previous.Next = current.Next;
                }
                else
                {
                    head = current.Next;
                }
                Count--;
            }
        }
        public void RemoveFirst()
        {
            if (head.Next != null)
            {
                head.Next.Previous = head.Previous;
                head = head.Next;
            }
        }
        public void RemoveLast()
        {
            if (tail.Previous != null) 
            {
                tail.Previous.Next = tail.Next;
                tail = tail.Previous;
            }
        }
    }
    public class Node<T>
    {
        public T Value { get; set; }
        public Node<T> Next { get; set; }
        public Node<T> Previous { get; set; }
        public Node(T value)
        {
            Value = value;
        }
    }
}
