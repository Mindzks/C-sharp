using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LD_3_Hotels_WebApp
{
    class BookingNode<T> where T : IComparable<T>, IEquatable<T>
    {
        public T data { get; private set; }
        public BookingNode<T> next { get; private set; }

        public BookingNode(T x)
        {
            data = x;
            next = null;
        }
        /// <summary>
        /// Sets the data of the next element
        /// </summary>
        /// <param name="node">This is BookingNode element which has his data and the pointer</param>
        public void setNext(BookingNode<T> node)
        {
            next = node;
        }
        /// <summary>
        /// This method is used in Booking list class for sorting. It changes the data of the element.
        /// </summary>
        /// <param name="Data">The data with the specific type</param>
        public void setData(T Data)
        {
            data = Data;
        }
        /// <summary>
        /// This method is used in sort method in BookingList class. It compares two nodes.
        /// </summary>
        /// <param name="other">The specific node with its own type. T represents the type</param>
        /// <returns>True of false according to the compareto method of the given object</returns>
        public int CompareTo(BookingNode<T> other)
        {
            return data.CompareTo(other.data);
        }

    }
}