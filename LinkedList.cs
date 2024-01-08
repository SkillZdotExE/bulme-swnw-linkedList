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
        }

        public object RemoveHead()
        {
            return _removeNext(null).data;
        }

        public void AddTail(object aObj)
        {
            _insertNext(tail, aObj);
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

            LinkedListNode ret = _removeNext(node);

            return ret.data;
        }

        public object At(int aPos)
        {
            return this[aPos];
        }

        private LinkedListNode _findPrevious(object aObject, IComparer aCmp)
        {
            if (head == null)
                return null;
            if (aCmp.Compare(head.data, aObject) == 0)
                return null;

            LinkedListNode node = head;

            while (node.next != null && aCmp.Compare(aObject, node.next.data) != 0)
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

            if (aCmp.Compare(aTestObject, node.data) == 0)
                return node;

            do
            {
                node = node.next;
            } while (node != null && aCmp.Compare(aTestObject, node.data) != 0);

            return node;
        }

        public object Find(object aTestObject, IComparer aCmp)
        {
            LinkedListNode node = _find(aTestObject, aCmp);
            return node == null ? null : node.data;
        }

        private LinkedListNode _removeNext(LinkedListNode aPrev)
        {
            LinkedListNode ret;
            if (aPrev == null)
            {
                if (head == null)
                    throw new IndexOutOfRangeException();
                if (current == head)
                    current = current.next;
                ret = head;
                head = head.next;
                if (head == null)
                    head = current = tail = null;
                return ret;
            }

            if (aPrev.next == null)
                throw new IndexOutOfRangeException();

            if (aPrev.next == current)
                current = aPrev;
            if (aPrev.next == tail)
                tail = aPrev;

            ret = aPrev.next;
            aPrev.next = aPrev.next.next;

            return ret;
        }

        public object Remove(object aObj)
        {
            if (Find(aObj, Comparer.Default) == null) //Help
                return null;
            LinkedListNode node = _findPrevious(aObj, Comparer.Default);
            return _removeNext(node).data;
        }

        public object RemoveAt(int aIdx)
        {
            if (aIdx < 0)
                throw new IndexOutOfRangeException();
            if (aIdx == 0)
                return RemoveHead();
            return _removeNext(this[aIdx-1]).data;
        }

        private void _insertNext(LinkedListNode aPrev, object aObj)
        {
            LinkedListNode node = new LinkedListNode(aObj);
            if (aPrev == null)
            {
                node.next = head;
                if (head == null)
                    head = current = tail = node;
                head = node;
                return;
            }
            if (aPrev.next == null)
                tail = node;
            node.next = aPrev.next;
            aPrev.next = node;
        }

        public void InsertSorted(object aObj, IComparer aCmp)
        {
            if (aObj == null) 
                throw new IndexOutOfRangeException();
            if (head == null)
            {
                AddHead(aObj);
                return;
            }

            if (head.next == null)
            {
                InsertAtPos(aObj, aCmp.Compare(head.data, aObj) > 0 ? 0 : 1);
                return;
            }

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
            {
                AddHead(aObj);
                return;
            }

            if (head == null)
                throw new IndexOutOfRangeException();

            LinkedListNode node = head;
            while (node.next != null && aPos-- != 1)
            {
                node = node.next;
            }

            if (node == null)
                throw new IndexOutOfRangeException();

            _insertNext(node, aObj);
        }

        public void Print()
        {
            LinkedListNode node = head;
            while (node != null) 
            {
                Console.Write(node.data);
                if (node.next != null)
                    Console.Write(", ");
                node = node.next;
            }
            Console.WriteLine();
        }
    }
}
