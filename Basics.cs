
using System;
using System.Collections;
using System.Text;

namespace LL_CS
{
    class DemoLink
    {
        public DemoLink next;
        public string data;

        public DemoLink(string aData)
        {
            data = aData;
        }
    }


    // Zeigt die prinzipielle Funktionsweise und den Aufbau einer Linked-List
    class LLDemo
    {
        DemoLink root = new DemoLink(""); // Zeiger auf den Anfang der Liste

        static void Main(string[] args)
        {
            LinkedList ll = new LinkedList();
            for (int i = 0; i < 10; i++)
            {
                ll.AddTail(i);
                ll.AddTail(i);
            }

            ll.InsertAtPos(42, 5);

            while (ll.Count() > 0)
            {
                ll.Print();
                Console.ReadLine();
                ll.RemoveAt(ll.Count()/2);
            }

            if (ll.Find(42, Int32.Comparer)

            Console.ReadLine();
        }

        // Liste erzeugen ( Bef�llen ) Liste erzeugen ( Bef�llen )Liste erzeugen ( Bef�llen )
        void CreateList()
        {
            DemoLink obj; // Hilfsvariable

            obj = new DemoLink("aaa"); // Ein Listenelement erzeugen

            root = obj; // 1'stes Listenelement in die Liste einh�ngen

            obj = new DemoLink("bbb"); // 2'tes Listenelement erzeugen

            // 2'tes Listenelement einh�ngen
            obj.next = root; root = obj;

            obj = new DemoLink("ccc"); // 3'tes Listenelement erzeugen

            // 3'tes Listenelement einh�ngen
            obj.next = root; root = obj;
        }

        // Alle Listenelemente besuchen um Sie z.B. auszugeben
        void IterateList()
        {
            // Einen Iterator zum Besuchen aller Listenelemente erzeugen
            // und auf die Wurzel ( root ) der Liste setzen
            DemoLink iter = root;
            while (iter != null) // Das Next des letzen Listenelements ist 0 => die Abbruchbedingung der Iteration
            {
                Console.WriteLine("{0}", iter.data);
                iter = iter.next;
            }
        }

        // Listenelemente entfernen Listenelemente entfernen Listenelemente entfernen
        void RemoveElements()
        {
            DemoLink obj;

            // 1'tes Listenelement aus der Liste ausketten
            obj = root;
            root = root.next;

            // n�chstes Listenelement aus der Liste ausketten
            obj = root;
            root = root.next;
        }
    }
}
