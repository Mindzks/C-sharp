using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Web;

namespace LD_3_Hotels_WebApp
{
    /// <summary>
    /// This is linked list class
    /// </summary>
    public class BookingList<T> : IEnumerable<T> where T : IComparable<T>, IEquatable<T>
    {
        private BookingNode<T> head { get; set; }
        private BookingNode<T> tail { get; set; }
        private BookingNode<T> d { get; set; }

        public BookingList()
        {
            head = null;
            tail = null;
            d = null;
        }

        /// <summary>
        /// This method shows the head of the list
        /// </summary>
        public void Begin()
        {
            d = head;
        }
        /// <summary>
        /// This method shows the next of the list
        /// </summary>
        public void Next()
        {
            d = d.next;
        }
        /// <summary>
        /// This method returns true of false, acording to the condition checking. 
        /// </summary>
        /// <returns></returns>
        public bool Exist()
        {
            return d != null;
        }

        /// <summary>
        /// This method adds element type of T to the list
        /// </summary>
        /// <param name="item">The given element which has it's own type. It can be Person or Hotel, also the object which impliments IComparable and IEquatable</param>
        public void Add(T item)
        {
            BookingNode<T> temp = new BookingNode<T>(item);
            if (head != null)
            {
                tail.setNext(temp);
                tail = temp;
            }
            else
            {
                head = temp;
                tail = temp;
            }
        }

        /// <summary>
        /// This sort method uses compareTo method. Compare to is implimented in Person and Hotel classes.
        /// </summary>
        public void Sort()
        {
            for (BookingNode<T> i = head; i != null; i = i.next)
            {
                for (BookingNode<T> j = i.next; j != null; j = j.next)
                {
                    if (i.CompareTo(j) > 0)
                    {
                        T temp = i.data;
                        i.setData(j.data);
                        j.setData(temp);
                    }
                }
            }
        }
        
        public IEnumerator<T> GetEnumerator()
        {
            for (Begin(); Exist(); Next())
            {
                yield return d.data;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        
    }
}