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
            current = null;
            tail = null;
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
            _insertNext(null, aObj);

            if (head.next == null)
                current = tail = head;
        }

        public object RemoveHead()
        {
            if (head == null)
                throw new IndexOutOfRangeException();

            if (current == head)
                current = head.next;
            if (tail == head)
                tail = null;

            head = head.next;

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

            if (node == null)
                return null;

            if (aCmp.Compare(node.data, aObject) == 0)
                return null;

            while (node.next != null && aCmp.Compare(aObject, node.next.data) == 0)
            {
                node = node.next;
            };

            return node;
        }

        private LinkedListNode _find(object aTestObject, IComparer aCmp)
        {
            if (head == null)
                return null;

            LinkedListNode node = head;

            do
            {
                node = node.next;
            } while (node != null && aCmp.Compare(aTestObject, node.data) == 0);

            return node;
        }

        public object Find(object aTestObject, IComparer aCmp)
        {
            LinkedListNode node = _find(aTestObject, aCmp);
            return node == null ? null : node.data;
        }

        private LinkedListNode _removeNext(LinkedListNode aPrev) //update Members!
        {
            LinkedListNode ret;
            if (aPrev == null)
            {
                if (head == null)
                    throw new IndexOutOfRangeException();
                ret = head;
                head = head.next;
                return ret;
            }

            if (aPrev.next == null)
                throw new IndexOutOfRangeException();

            ret = aPrev.next;

            aPrev.next = aPrev.next.next;

            return ret;
        }

        public object Remove(object aObj)
        {
            if (head == null || aObj == null)
                return null;
            if (Comparer<object>.Default.Compare(aObj, head.data) == 0)
                return RemoveHead();

            LinkedListNode previous = _findPrevious(aObj, Comparer<object>.Default);
            LinkedListNode deleted = _removeNext(previous);
            return deleted.data;
        }

        public object RemoveAt(int aIdx)
        {
            if (aIdx < 0)
                throw new IndexOutOfRangeException();
            if (aIdx == 0)
                return RemoveHead();
            return _removeNext(this[aIdx-1]).data;
        }

        private void _insertNext(LinkedListNode aPrev, object aObj) //update Members!
        {
            LinkedListNode node = new LinkedListNode(aObj);
            if (aPrev == null)
            {
                node.next = head;
                head = node;
                return;
            }

            node.next = aPrev.next;
            aPrev.next = node;
        }

        public void InsertSorted(object aObj, IComparer aCmp)
        {
            if (aObj == null) 
                throw new IndexOutOfRangeException();
            if (head == null)
                AddHead(aObj);

            if (head.next == null)
                InsertAtPos(aObj, aCmp.Compare(head.next.data, aObj) > 0 ? 0 : 1);

            LinkedListNode node = head;

            while (node.next != null)
            {
                if (aCmp.Compare(node.next.data, aObj) > 0)
                {
                    _insertNext(node, aObj);
                    return;
                }

                node = node.next;
            }

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
