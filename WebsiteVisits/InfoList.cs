using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Web;

namespace WebsiteVisits
{
    class InfoList<T>:IEnumerable<T>
    {
        class Node
        {
            //The data which is saved in this node
            public T Data { get; set; }
            //Reference to another element
            public Node Link { get; set; }

            public Node(T data, Node link)
            {
                Data = data;
                Link = link;
            }
        }
        //begin of the list
        private Node Begin;
        //end of the list - tail
        private Node End;
        //this element is used if for cycle to iterate
        private Node Current;

        /// <summary>
        /// Initializes a new instance of the LinkList class with empty list.
        /// </summary>
        public InfoList()
        {
            Begin = End = Current = null;
        }

        /// <summary>
        /// Method appends new node to the end of the list and saves in it <paramref name="data"/>
        /// passed by the parameter.
        /// </summary>
        /// <param name="data">The data to be stored in the list.</param>
        public void Add(T x)
        {
            Node temp = new Node(x, null);
            if (Begin != null)
            {
                End.Link = temp;
                End = temp;
            }
            else
            {
                Begin = temp;
                End = temp;
            }
        }

        /// <summary>
        /// One of four interface methods devoted to loop through a list and get value stored in it.
        /// Method should be used to move internal pointer to the first element of the list.
        /// </summary>
        public void begin()
        {
            Current = Begin;
        }
        /// <summary>
        /// One of four interface methods devoted to loop through a list and get value stored in it.
        /// Method should be used to move internal pointer to the next element of the list.
        /// </summary>
        public void next()
        {
            Current = Current.Link;
        }
        /// <summary>
        /// One of four interface methods devoted to loop through a list and get value stored in it.
        /// Method should be used to check whether the internal pointer points to the element of the list.
        /// </summary>
        /// <returns>true, if the internal pointer points to some element of the list; otherwise,
        /// false.</returns>
        public bool exist()
        {
            return Current != null;
        }

        /// <summary>
        /// One of four interface methods devoted to loop through a list and get value stored in it.
        /// Method should be used to get the value stored in the node pointed by the internal pointer.
        /// </summary>
        /// <returns>the value of the element that is pointed by the internal pointer.</returns>
        public T Get()
        {
            return Current.Data;
        }

        /// <summary>
        /// This method goes through all the list and returns elements of that list
        /// </summary>
        /// <returns>Returns element which is type of T</returns>
        public IEnumerator<T> GetEnumerator()
        {
            for (begin(); exist(); next())
            {
                yield return Get();
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}