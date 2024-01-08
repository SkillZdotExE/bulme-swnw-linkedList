
using System;
using System.Collections;
using System.Diagnostics.Eventing.Reader;
using System.Text;

namespace LL_CS
{

    // Zeigt die prinzipielle Funktionsweise und den Aufbau einer Linked-List
    class LLDemo
    {
        static void testLinkedList(IHLContainer ll)
        {
            Console.WriteLine("\n\n### testLinkedList");
            Console.WriteLine("\nLinkedList has " + ll.Count() + " elements:");
            ll.Print();

            Console.WriteLine("\nAdding to head:");
            ll.AddHead("head");
            Console.WriteLine("(" + ll.Count() + " elements)");
            ll.Print();


            Console.WriteLine("\nAdding to tail:");
            ll.AddTail("tail");
            Console.WriteLine("(" + ll.Count() + " elements)");
            ll.Print();

            Console.WriteLine("\nInserting to middle:");
            ll.InsertAtPos("middle", ll.Count() / 2);
            ll.InsertAtPos("middle", ll.Count() / 2);
            Console.WriteLine("(" + ll.Count() + " elements)");
            ll.Print();

            Console.WriteLine("\nFinding element:");
            Console.WriteLine("head: " + ll.Find("head", StringComparer.Ordinal));
            Console.WriteLine("tail: " + ll.Find("tail", StringComparer.Ordinal));
            Console.WriteLine("middle: " + ll.Find("middle", StringComparer.Ordinal));

            Console.WriteLine("\nRemoving head:");
            ll.RemoveHead();
            Console.WriteLine("(" + ll.Count() + " elements)");
            ll.Print();

            Console.WriteLine("\nRemoving tail:");
            ll.RemoveTail();
            Console.WriteLine("(" + ll.Count() + " elements)");
            ll.Print();

            Console.WriteLine("\nRemoving middle:");
            ll.RemoveAt(ll.Count()/2);
            Console.WriteLine("(" + ll.Count() + " elements)");
            ll.Print();

            Console.WriteLine("\nFind and remove:");
            ll.Remove("middle");
            Console.WriteLine("(" + ll.Count() + " elements)");
            ll.Print();


            Console.WriteLine("\nIterating with First() and Next():");

            int i = 0;
            for (object o = ll.First(); o != null; o = ll.Next())
            {
                Console.WriteLine(i + ": " + o.ToString());
                i++;
            }

            Console.WriteLine("\nFinished testing!");
        }
        static void testLinkedList_edgecases()
        {
            Console.WriteLine("\n\n### testLinkedList_edgecases");
            LinkedList ll = new LinkedList();

            Console.WriteLine("\nRemoving Head of empty list");
            try { 
                ll.RemoveHead();
            } catch (Exception e) 
            {
                Console.WriteLine(e.Message);
            }
            Console.WriteLine("\nRemoving Tail of empty list");
            try
            {
                ll.RemoveTail();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.WriteLine("\nRemoving nonexistent element");
            try
            {
                ll.Remove("nonexistent");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.WriteLine("\nIterating empty LinkedList with First() and Next():");

            int i = 0;
            for (object o = ll.First(); o != null; o = ll.Next())
            {
                Console.WriteLine(i + ": " + o.ToString());
                i++;
            }

            ll.AddHead("abc");
            Console.WriteLine("\nRemoving Head of one-element list");
            ll.RemoveHead();
            ll.AddHead("abc");
            Console.WriteLine("\nRemoving Tail of one-element list");
            ll.RemoveTail();

            Console.WriteLine("\nFinished testing edgecases!");
        }

        static void testLinkedList_insertSorted()
        {
            Console.WriteLine("\n\n### testLinkedList_insertSorted");
            LinkedList ll = new LinkedList();
            ll.AddTail("a");
            ll.AddTail("b");
            ll.AddTail("d");
            ll.AddTail("e");
            Console.WriteLine("\nInsert \"c\" into LinkedList:");
            ll.Print();
            ll.InsertSorted("c", StringComparer.Ordinal);
            ll.Print();

            while (ll.Count() > 0)
                ll.RemoveHead();

            ll.AddTail("a");
            Console.WriteLine("\nInsert \"c\" into LinkedList:");
            ll.Print();
            ll.InsertSorted("c", StringComparer.Ordinal);
            ll.Print();

            while (ll.Count() > 0)
                ll.RemoveHead();

            ll.AddTail("e");
            Console.WriteLine("\nInsert \"c\" into LinkedList:");
            ll.Print();
            ll.InsertSorted("c", StringComparer.Ordinal);
            ll.Print();

            while (ll.Count() > 0)
                ll.RemoveHead();

            Console.WriteLine("\nInsert \"c\" into empty LinkedList:");
            ll.InsertSorted("c", StringComparer.Ordinal);
            ll.Print();

            Console.WriteLine("\nFinished testing InsertSorted!");
        }

        static void Main(string[] args)
        {
            LinkedList ll = new LinkedList();
            ll.AddTail("a");
            ll.AddTail("b");
            ll.AddTail("c");
            ll.AddTail("d");
            testLinkedList(ll);
            testLinkedList_edgecases();
            testLinkedList_insertSorted();
            Console.ReadLine();
        }
    }
}
