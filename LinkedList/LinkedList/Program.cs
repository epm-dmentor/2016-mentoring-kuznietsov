using System;

namespace LinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            MyLinkedList l1 = new MyLinkedList();

            Console.WriteLine();

            for (int i = 0; i < 10; i++)
            {
                l1.AddLast(i);
            }
            //PrintList(l1);

            //l1.AddAt(5, "INSERTED");
            //PrintList(l1);

            //l1.RemoveAt(5);
            //PrintList(l1);
            Console.ReadLine();


            foreach (object n in l1)
            {
                Console.WriteLine(n);
            }
            Console.ReadLine();

        }

        private static void PrintList(MyLinkedList l1)
        {
            for (int i = 0; i < l1.Length; i++)
            {
                Console.WriteLine(l1.ElementAt(i));
            }
            Console.ReadLine();
        }
    }
}
