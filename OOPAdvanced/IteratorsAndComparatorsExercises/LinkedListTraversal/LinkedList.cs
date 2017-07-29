using System;
using System.Collections;
using System.Collections.Generic;

public class LinkedList<T> : IEnumerable<T>
{
    private LinkNode Head { get; set; }
    private LinkNode Tail { get; set; }

    public int Count
    {
        get;
        private set;
    }

    public void Add(T element)
    {
        var newNode = new LinkNode(element);

        if (this.Count == 0)
        {
            this.Head = newNode;
            this.Tail = newNode;
        }
        else
        {
            newNode.Previous = this.Tail;
            this.Tail.Next = newNode;
            this.Tail = newNode;
        }

        this.Count++;
    }

    public bool Remove(T element)
    {
        if (this.Count == 0)
        {

            return false;
        }

        var node = this.Head;
        while (node != null)
        {
            if (node.Value.Equals(element))
            {
                if (node.Previous == null && node.Next == null)
                {
                    this.Head = null;
                    this.Tail = null;
                    this.Count--;
                    return true;
                }
                else if (node.Previous == null && node.Next != null)
                {
                    this.Head = node.Next;
                    this.Head.Previous = null;
                    this.Count--;
                    return true;
                }
                else if (node.Next == null && node.Previous != null)
                {
                    this.Tail = node.Previous;
                    this.Tail.Next = null;
                    this.Count--;
                    return true;
                }
                else if (node.Next != null && node.Previous != null)
                {
                    node.Previous.Next = node.Next;
                    node.Next.Previous = node.Previous;
                    this.Count--;
                    return true;
                }
                else
                {
                    return false;
                }
            }

            node = node.Next;
        }

        return false;
    }

    public IEnumerator<T> GetEnumerator()
    {
        var node = this.Head;
        while (node != null)
        {
            yield return node.Value;
            node = node.Next;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public class LinkNode
    {
        public LinkNode(T value)
        {
            this.Value = value;
        }

        public LinkNode Previous { get; set; }
        public LinkNode Next { get; set; }
        public T Value { get; set; }
    }
}