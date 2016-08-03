using System;
using System.Collections.Generic;

namespace DSA.ConsoleApp.DataStructures
{
    public class MyDynamicArray<T>
    {
        private const int DefaultCapacity = 2;

        private static readonly T[] EmptyArray = new T[0];
        
        // This count is the actual number of elements in the array that are not empty spaces
        private int itemCount;
        private T[] items;

        // Gets and sets the capacity of this list.  The capacity is the size of
        // the internal array used to hold items.  When set, the internal 
        // array of the list is reallocated to the given capacity.
        public int Capacity
        {
            get { return items.Length; }
            set
            {
                if(value < itemCount)
                    throw new ArgumentOutOfRangeException($"Value cannot be less than {itemCount}");

                // No need to do anything just return
                if(value == items.Length)
                    return;

                if (value == 0)
                    Empty();

                ExpandToSize(value);
            }
        }

        public int Count => itemCount;

        public MyDynamicArray()
        {
            items = EmptyArray;
        }

        public void Add(T item)
        {
            if(itemCount == Capacity)
                EnsureCapacity(itemCount + 1);

            items[itemCount++] = item;
        }

        public bool Contains(T item)
        {
            if (item == null)
            {
                for (int i = 0; i < itemCount; i++)
                    if (items[i] == null)
                        return true;

                return false;
            }

            // EqualityComparer<T>.Default will check if T is implementing IEquatable interface
            // if so the Equals method will be called on the interface
            // otherwise if T has overriden Equals it will use that
            // as a last resort it will use reference equality
            var comparer = EqualityComparer<T>.Default;
            for (int i = 0; i < itemCount; i++)
                if (comparer.Equals(items[i], item))
                    return true;

            return false;
        }

        public int IndexOf(T item)
        {
            var comparer = EqualityComparer<T>.Default;
            for (int i = 0; i < itemCount; i++)
                if (comparer.Equals(items[i], item))
                    return i;

            return -1;
        }

        public void Remove(T item)
        {
            var removeIndex = IndexOf(item);
            if(removeIndex >= 0)
                RemoveAt(removeIndex);
        }

        public void RemoveAt(int index)
        {
            if(index < 0 || index >= itemCount)
                throw new IndexOutOfRangeException();

            itemCount--;
            if (index < itemCount)
                Array.Copy(sourceArray: items, sourceIndex: index + 1, destinationArray: items, destinationIndex: index, length: itemCount - index);

            items[itemCount] = default(T);
        }

        private void Empty()
        {
            items = EmptyArray;
        }

        private void EnsureCapacity(int min)
        {
            // No need to worry about reallocation
            if(Capacity > min)
                return;

            var newCapacity = Capacity == 0 ? DefaultCapacity : Capacity * 2;

            // If newCapacity is > min, then use other or vice versa
            Capacity = Math.Max(newCapacity, min);
        }

        private void ExpandToSize(int newSize)
        {
            var newArray = new T[newSize];

            // Only copy over elements to the new array 
            // if previous allocation had any elements at all.
            if (itemCount > 0)
                Array.Copy(items, 0, newArray, 0, itemCount);

            items = newArray;
        }
    }
}