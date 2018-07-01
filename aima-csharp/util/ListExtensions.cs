using System;
using System.Collections;
using System.Collections.Generic;

namespace aima.core.util
{
    // A simple extension for list to remove a value at given location.
    public static class ListExtensions
    {
        public static T PopAt<T>(this List<T> list, int index)
        {
            T removed = list[index];
            list.RemoveAt(index);
            return removed;
        }
    }
}
