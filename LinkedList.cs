using System;
using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;

namespace LL_CS
{
    internal class LinkedListNode
    {
        public LinkedListNode next;
        public object data;

        public LinkedListNode(object data_)
        {
            data = data_;
        }
    }

    internal class LinkedList : IHLContainer
    {
        LinkedListNode head;
        LinkedListNode current;
        LinkedListNode tail;

        public LinkedList()
        {
            head = null;
            current = head;
            tail = head;
        }

        public LinkedListNode this[int index]
        {
            get
            {
                if (index < 0 || head == null)
                    throw new IndexOutOfRangeException();

                LinkedListNode node = head;

                while (index-- != 0)
                {
                    node = node.next;
                    if (node == null)
                        throw new IndexOutOfRangeException();
                }

                return node;
            }
            set
            {
                if (index < 0 || head == null)
                    throw new IndexOutOfRangeException();

                LinkedListNode node = head;

                while (index-- != 0)
                {
                    node = node.next;
                    if (node == null)
                        throw new IndexOutOfRangeException();
                }

                node = value;
            }
        }

        public int Count()
        {
            int ret = 0;

            LinkedListNode node = head;

            while (node != null)
            {
                node = node.next;
                ret++;
            }
            return ret;
        }

        public object First()
        {
            current = head;
            if (current == null)
                return null;
            return current.data;
        }

        public object Next()
        {
            if (current == null)
                return null;
            current = current.next;
            if (current == null)
                return null;
            return current.data;
        }

        public void AddHead(object aObj)
        {
            LinkedListNode node = head;

            head = new LinkedListNode(aObj);

            head.next = node;

            if (head.next == null)
                current = tail = head;
        }

        public object RemoveHead()
        {
            if (head == null)
                throw new IndexOutOfRangeException();

            if (current == head)
                current = head.next;

            head = head.next; // Memory leak? Are all objects in C# refcounted?

            if (head == null)
                return null;

            return head.data;
        }

        public void AddTail(object aObj)
        {
            if (tail == null)
            {
                AddHead(aObj);
                return;
            }
            tail.next = new LinkedListNode(aObj);
            tail = tail.next;
        }

        public object RemoveTail()
        {
            if (tail == null)
                return null;

            LinkedListNode node = head;

            if (node.next == null)
            {
                head = current = tail = null;
                return null;
            }

            while (node.next != tail)
            {
                node = node.next;
            }

            LinkedListNode ret = node.next;
            node.next = null;

            return ret.data;
        }

        public object At(int aPos)
        {
            return this[aPos];
        }

        private LinkedListNode _findPrevious(object aObject, IComparer aCmp)
        {
            LinkedListNode node = head;

            while (node.next != null && aCmp.Compare(aObject, node.next) == 0)
            {
                node = node.next;
            };

            return node;
        }

        public object Find(object aTestObject, IComparer aCmp)
        {
            LinkedListNode node = head;

            do {
                node = node.next;
            } while (node != null && aCmp.Compare(aTestObject, node) == 0);

            return node.data;
        }

        private object _removeNext(LinkedListNode aPrev)
        {
            if (aPrev == null)
                throw new IndexOutOfRangeException();

            if ( aPrev.next == null)
                throw new IndexOutOfRangeException();

            LinkedListNode ret = aPrev.next;

            aPrev.next = ret.next;

            return ret.data;
        }

        public object Remove(object aObj)
        {
            if (head == null || aObj == null)
                return null;
            if (Comparer<object>.Default.Compare(aObj, head.data) == 0)
                return RemoveHead();

            LinkedListNode previous = _findPrevious(aObj, Comparer<object>.Default);
            LinkedListNode deleted = previous.next;
            _removeNext(previous);
            return deleted.data;
        }

        public object RemoveAt(int aIdx)
        {
            if (aIdx < 0)
                throw new IndexOutOfRangeException();
            if (aIdx == 0)
                return RemoveHead();
            return _removeNext(this[aIdx-1]);
        }

        public void InsertSorted(object aObj, IComparer aCmp)
        {
            throw new NotImplementedException();
        }

        public void InsertAtPos(object aObj, int aPos)
        {
            if (aPos < 0)
                throw new IndexOutOfRangeException();

            if (aPos == 0)
                AddHead(aObj);

            if (head == null)
                throw new IndexOutOfRangeException();

            LinkedListNode node = head;
            while (node.next != null && aPos-- != 1)
            {
                node = node.next;
            }

            if (node == null)
                throw new IndexOutOfRangeException();

            LinkedListNode temp = node.next;
            node.next = new LinkedListNode(aObj);
            node.next.next = temp;
        }

        public void Print()
        {
            object obj = First();
            if (obj != null)
                Console.Write(obj);
            while (obj != null) 
            {
                Console.Write(", " + (obj = Next()));
            }
            Console.WriteLine();
        }
    }
}
