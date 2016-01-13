using System;
using System.Collections;

namespace LinkedList
{

    public class MyLinkedList : IEnumerable
    {
        private class Node
        {
            public Node Next { get; set; }
            public Node Prev { get; set; }
            public object Data { get; set; }
        }

        //Foreach implementation with IEnumerator object

        private class LinkedListEnumerator : IEnumerator
        {
            private MyLinkedList _linkedList;
            private Node _cursor;

            public LinkedListEnumerator(MyLinkedList list)
            {
                _linkedList = list;
                _cursor = list.Head;
            }

            public object Current
            {
                get
                {
                    return _cursor.Data;
                }
            }

            public bool MoveNext()
            {
                if (_cursor.Next != null)
                {
                    _cursor = _cursor.Next;
                    return true;
                }
                else
                    return false;
            }

            public void Reset()
            {
                _cursor = _linkedList.Head;
            }
        }

        private Node Head { get; set; }
        private Node Tail { get; set; }
        private int size = 0;

        public int Length
        {
            get { return size; }
            set { size = value; }
        }


        //Add node to the last position
        public void AddLast(object data)
        {
            //First run
            if (Head == null)
            {
                Head = Tail = new Node();
                Head.Data = data;
                Length++;

            }
            //Second++ run
            else
            {
                Node newNode = new Node();
                newNode.Data = data;
                newNode.Prev = Tail;
                Tail.Next = newNode;
                Tail = newNode;
                Length++;
            }
        }

        //Add node to the first position
        public void AddFirst(object data)
        {
            //First run 
            if (Head == null)
            {
                Head = Tail = new Node();
                Tail.Data = data;
                Length++;
            }
            //Second++ Run
            else
            {
                Node newNode = new Node();
                newNode.Data = data;
                newNode.Next = Head;
                Head.Prev = newNode;
                Head = newNode;
                Length++;
            }
        }

        //Get [index] element from the list
        public object ElementAt(int index)
        {
            if (index < Length)
            {
                Node nodeCursor = Head;

                for (int i = 1; i <= index; i++)
                {
                    nodeCursor = nodeCursor.Next;
                }
                return nodeCursor.Data;
            }
            else
            {
                return null;
            }

        }

        //Insert element into [index] position in the list
        public void AddAt(int index, object obj)
        {
            if (index < Length)
            {
                Node nodeCursor = Head;
                Node prevNode = null;
                Node nextNode = null;

                for (int i = 1; i <= index; i++)
                {
                    nodeCursor = nodeCursor.Next;
                }
                prevNode = nodeCursor.Prev;
                nextNode = nodeCursor;
                Node newNode = new Node();
                newNode.Data = obj;
                newNode.Next = nextNode;
                newNode.Prev = prevNode;
                prevNode.Next = newNode;
                nextNode.Prev = newNode;
                Length++;

            }
        }

        //Remove [index] element fomr the list
        public void RemoveAt(int index)
        {
            if (index < Length)
            {
                Node nodeCursor = Head;
                Node prevNode = null;
                Node nextNode = null;

                for (int i = 1; i <= index; i++)
                {
                    nodeCursor = nodeCursor.Next;
                }
                prevNode = nodeCursor.Prev;
                nextNode = nodeCursor.Next;
                prevNode.Next = nextNode;
                nextNode.Prev = prevNode;
                Length--;

            }
        }

        public IEnumerator GetEnumerator()
        {

            return (IEnumerator)new LinkedListEnumerator(this);

        }


        //public IEnumerator GetEnumerator()
        //{
        //    Node iterator = Head;
        //    while (iterator.Next != null)
        //    {
        //        yield return iterator;
        //        iterator = iterator.Next;
        //    }
        //}
    }

}
