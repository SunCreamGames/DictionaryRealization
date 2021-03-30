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
        public int Count { get; set; }

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
