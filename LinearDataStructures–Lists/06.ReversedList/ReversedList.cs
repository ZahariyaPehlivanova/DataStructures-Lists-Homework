using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

public class ReversedList<T> : IEnumerable<T>
{
    private const int DefaultCapacity = 4;

    private int count = 0;

    private T[] elements;

    public ReversedList(int capacity = DefaultCapacity)
    {
        this.elements = new T[capacity];
    }

    public int Capacity
    {
        get
        {
            return this.elements.Length;
        }
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
            return this.elements[index];
        }

        set
        {
            if (index >= this.count || index < 0)
            {
                throw new ArgumentOutOfRangeException("Invalid index: " + index);
            }

            this.elements[index] = value;
        }
    }

    public void Add(T element)
    {
        if (this.count == this.elements.Length)
        {
            this.ResizeArray(true);
        }

        this.elements[this.count] = element;
        this.count++;
    }
    
    public void Clear()
    {
        this.elements = new T[DefaultCapacity];
        this.count = 0;
    }

    public IEnumerator<T> GetEnumerator()
    {
        int currentIndex = this.count - 1;

        while (currentIndex != 0)
        {
            yield return this.elements[currentIndex];
            currentIndex--;
        }
    }

    public void Remove(int index)
    {
        if (this.elements.Length == 2 * this.count)
        {
            this.ResizeArray(false);
        }

        if (index >= this.count || index < 0)
        {
            throw new IndexOutOfRangeException("Index was outside the bounds of the array");
        }

        T[] helpArray = new T[this.elements.Length];
        Array.Copy(this.elements, 0, helpArray, 0, index);
        Array.Copy(this.elements, index + 1, helpArray, index, this.elements.Length - index - 1);
        this.elements = helpArray;
        this.count--;
    }
    
    public override string ToString()
    {
        StringBuilder result = new StringBuilder();

        result.Append("{");
        for (int i = this.count - 1; i >= 0; i--)
        {
            result.Append(this.elements[i]);
            if (i > 0)
            {
                result.Append(", ");
            }
        }

        result.Append("}");

        return result.ToString();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
    
    private void ResizeArray(bool increase)
    {
        int newSize = 0;
        if (increase)
        {
            newSize = this.count * 2;
        }
        else
        {
            newSize = this.elements.Length / 2;
        }

        Array.Resize<T>(ref this.elements, newSize);
    }
}