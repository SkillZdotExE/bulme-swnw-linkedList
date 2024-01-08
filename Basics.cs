
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
            Console.WriteLine("LinkedList has " + ll.Count() + " elements:");
            ll.Print();

            Console.WriteLine("Adding to head:");
            ll.AddHead("head");
            Console.WriteLine("(" + ll.Count() + " elements)");
            ll.Print();


            Console.WriteLine("Adding to tail:");
            ll.AddTail("tail");
            Console.WriteLine("(" + ll.Count() + " elements)");
            ll.Print();

            Console.WriteLine("Inserting to middle:");
            ll.InsertAtPos("middle", ll.Count() / 2);
            ll.InsertAtPos("middle", ll.Count() / 2);
            Console.WriteLine("(" + ll.Count() + " elements)");
            ll.Print();

            Console.WriteLine("Finding element:");
            Console.WriteLine("head: " + ll.Find("head", StringComparer.Ordinal));
            Console.WriteLine("tail: " + ll.Find("tail", StringComparer.Ordinal));
            Console.WriteLine("middle: " + ll.Find("middle", StringComparer.Ordinal));

            Console.WriteLine("Removing head:");
            ll.RemoveHead();
            Console.WriteLine("(" + ll.Count() + " elements)");
            ll.Print();

            Console.WriteLine("Removing tail:");
            ll.RemoveTail();
            Console.WriteLine("(" + ll.Count() + " elements)");
            ll.Print();

            Console.WriteLine("Removing middle:");
            ll.RemoveAt(ll.Count()/2);
            Console.WriteLine("(" + ll.Count() + " elements)");
            ll.Print();

            Console.WriteLine("Find and remove:");
            ll.Remove("middle");
            Console.WriteLine("(" + ll.Count() + " elements)");
            ll.Print();


            Console.WriteLine("Iterating with First() and Next():");

            int i = 0;
            for (object o = ll.First(); o != null; o = ll.Next())
            {
                Console.WriteLine(i + ": " + o.ToString());
                i++;
            }

            Console.WriteLine("Finished testing!");
        }
        static void testLinkedList_edgecases()
        {
            LinkedList ll = new LinkedList();

            Console.WriteLine("Removing Head of empty list");
            try { 
                ll.RemoveHead();
            } catch (Exception e) 
            {
                Console.WriteLine(e.Message);
            }
            Console.WriteLine("Removing Tail of empty list");
            try
            {
                ll.RemoveTail();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.WriteLine("Removing nonexistent element");
            try
            {
                ll.Remove("nonexistent");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.WriteLine("Iterating empty LinkedList with First() and Next():");

            int i = 0;
            for (object o = ll.First(); o != null; o = ll.Next())
            {
                Console.WriteLine(i + ": " + o.ToString());
                i++;
            }

            ll.AddHead("abc");
            Console.WriteLine("Removing Head of one-element list");
            ll.RemoveHead();
            ll.AddHead("abc");
            Console.WriteLine("Removing Tail of one-element list");
            ll.RemoveTail();

            Console.WriteLine("Finished testing edgecases!");
        }

        static void testLinkedList_insertSorted()
        {
            LinkedList ll = new LinkedList();
            ll.AddTail("a");
            ll.AddTail("b");
            ll.AddTail("d");
            ll.AddTail("e");
            Console.WriteLine("Insert \"c\" into LinkedList:");
            ll.Print();
            ll.InsertSorted("c", StringComparer.Ordinal);
            ll.Print();

            while (ll.Count() > 0)
                ll.RemoveHead();

            ll.AddTail("a");
            Console.WriteLine("Insert \"c\" into LinkedList:");
            ll.Print();
            ll.InsertSorted("c", StringComparer.Ordinal);
            ll.Print();

            while (ll.Count() > 0)
                ll.RemoveHead();

            ll.AddTail("e");
            Console.WriteLine("Insert \"c\" into LinkedList:");
            ll.Print();
            ll.InsertSorted("c", StringComparer.Ordinal);
            ll.Print();

            while (ll.Count() > 0)
                ll.RemoveHead();

            Console.WriteLine("Insert \"c\" into empty LinkedList:");
            ll.InsertSorted("c", StringComparer.Ordinal);
            ll.Print();

            Console.WriteLine("Finished testing InsertSorted!");
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
