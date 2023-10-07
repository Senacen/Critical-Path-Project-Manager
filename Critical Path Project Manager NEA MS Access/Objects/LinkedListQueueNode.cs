﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Critical_Path_Project_Manager_NEA_MS_Access.Objects
{
    internal class LinkedListQueueNode<T>
    {
        private LinkedListQueueNode<T> next;
        private T item;
        public LinkedListQueueNode(T item)
        {
            this.item = item;
            next = null;
        }
        public LinkedListQueueNode<T> getNext()
        {
            return next;
        }
        public T getItem()
        {
            return item;
        }
        public void setNext(LinkedListQueueNode<T> next)
        {
            this.next = next;
        }
    }
}
