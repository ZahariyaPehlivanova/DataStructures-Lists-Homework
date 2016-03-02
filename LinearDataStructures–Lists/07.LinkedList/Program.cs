using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

public class LinkedList<T> : IEnumerable<T>
{
    private int count;

    private ListNode<T> head;

    private ListNode<T> tail;

    public LinkedList()
    {
        this.head = null;
        this.tail = null;
        this.count = 0;
    }

    public int Count
    {
        get
        {
            return this.count;
        }
    }

    public T this[int index]
    {
        get
        {

            ListNode<T> currNode = this.head;
            for (int i = 0; i < index; i++)
            {
                currNode = currNode.Next;
            }

            return currNode.Element;
        }

        set
        {
            if (index >= this.count || index < 0)
            {
                throw new ArgumentOutOfRangeException("Invalid index: " + index);
            }

            ListNode<T> currNode = this.head;
            for (int i = 0; i < index; i++)
            {
                currNode = currNode.Next;
            }

            currNode.Element = value;
        }
    }
   
    public void AddFirst(T item)
    {
        if (this.head == null)
        {
            this.head = new ListNode<T>(item);
            this.tail = this.head;
        }
        else
        {
            ListNode<T> newNode = new ListNode<T>(item);
            newNode.Next = this.head;
            this.head = newNode;
        }

        this.count++;
    }

    public void AddLast(T item)
    {
        if (this.head == null)
        {
            this.head = new ListNode<T>(item);
            this.tail = this.head;
        }
        else
        {
            ListNode<T> newNode = new ListNode<T>(item, this.tail);
            this.tail = newNode;
        }

        this.count++;
    }

    public void Clear()
    {
        this.head = null;
        this.count = 0;
    }
    
    public int FirstIndexOf(T item)
    {
        var currIndex = 0;
        var currNode = this.head;

        while (currIndex < this.count)
        {
            if (currNode.Element.Equals(item))
            {
                return currIndex;
            }

            currNode = currNode.Next;
            currIndex++;
        }

        return -1;
    }

    public IEnumerator<T> GetEnumerator()
    {
        var node = this.head;
        while (node != null)
        {
            yield return node.Element;
            node = node.Next;
        }
    }

    public int LastIndexOf(T item)
    {
        var currIndex = 0;
        var currNode = this.head;
        int lastIndex = -1;

        while (currIndex < this.count)
        {
            if (currNode.Element.Equals(item))
            {
                lastIndex = currIndex;
            }

            currNode = currNode.Next;
            currIndex++;
        }

        return lastIndex;
    }
    
    public T Remove(int index)
    {
        if (index >= this.count || index < 0)
        {
            throw new ArgumentOutOfRangeException("Ivalid index: " + index);
        }

        int currIndex = 0;
        ListNode<T> currNode = this.head;
        ListNode<T> prevNode = null;

        while (currIndex < index)
        {
            prevNode = currNode;
            currNode = currNode.Next;
            currIndex++;
        }
        
        this.count--;

        if (this.count == 0)
        {
            this.head = null;
        }
        else if (prevNode == null)
        {
            this.head = currNode.Next;
        }
        else
        {
            prevNode.Next = currNode.Next;
        }
        
        ListNode<T> lastNode = null;

        if (this.head != null)
        {
            lastNode = this.head;
            while (lastNode.Next != null)
            {
                lastNode = lastNode.Next;
            }
        }

        this.tail = lastNode;

        return currNode.Element;
    }
    
    public int RemoveElement(T item)
    {
        if (this.FirstIndexOf(item) < 0)
        {
            throw new ArgumentException("Element does not exists");
        }

        int indexOfItem = this.FirstIndexOf(item);

        if (this.head == null)
        {
            throw new InvalidOperationException("Cannot remove element from empty list.");
        }
        else if (item.Equals(this.head.Element))
        {
            this.head = this.head.Next;
        }
        else
        {
            var currNode = this.head;
            ListNode<T> prevNode = new ListNode<T>(item);
            while (!currNode.Element.Equals(item))
            {
                prevNode = currNode;
                currNode = currNode.Next;
            }

            prevNode.Next = currNode.Next;
        }

        this.count--;

        var tempNode = this.head;

        if (this.head != null)
        {
            while (tempNode.Next != null)
            {
                tempNode = tempNode.Next;
            }
        }

        this.tail = tempNode;

        return indexOfItem;
    }
    
    public override string ToString()
    {
        StringBuilder result = new StringBuilder();
        ListNode<T> currNode = this.head;

        while (currNode != null)
        {
            result.Append(currNode.Element);

            if (currNode.Next != null)
            {
                result.Append(", ");
            }

            currNode = currNode.Next;
        }

        return string.Format("[{0}]", result.ToString());
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }

    private class ListNode<E>
    {
        private E element;

        private ListNode<E> next;

        public ListNode(E element)
        {
            this.Element = element;
            this.Next = null;
        }

        public ListNode(E element, ListNode<E> prevNode)
        {
            this.Element = element;
            prevNode.Next = this;
        }

        public E Element
        {
            get
            {
                return this.element;
            }

            set
            {
                this.element = value;
            }
        }

        public ListNode<E> Next
        {
            get
            {
                return this.next;
            }

            set
            {
                this.next = value;
            }
        }
    }
}