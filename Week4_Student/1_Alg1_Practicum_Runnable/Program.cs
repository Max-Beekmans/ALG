using Alg1_Practicum;
using Alg1_Practicum_Utils.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alg1_Practicum_Runnable
{
    class Program
    {
        static void Main(string[] args)
        {
            NawLinkedList nawLinkedList = new NawLinkedList();

            NAW naw1 = new NAW("ABC","straat","schijndel");
            NAW naw2 = new NAW("YIJD", "dropstraat", "den bosch");
            NAW naw3 = new NAW("DEF", "kerkstraat", "amsterdam");
            NAW naw4 = new NAW("DEF", "dorpstraat", "amsterdam");
            NAW naw5 = new NAW("ABC", "kerkstraat", "amsterdam");


            //nawLinkedList.InsertTail(naw1);
            //Console.WriteLine("First: " + nawLinkedList._first.Naw);
            //Console.WriteLine("Last: " + nawLinkedList._last.Naw);
            //Console.WriteLine("NAW: " + nawLinkedList.GetNawAt(0));
            //nawLinkedList.InsertTail(naw2);
            //Console.WriteLine("First: " + nawLinkedList._first.Naw);
            //Console.WriteLine("Last: " + nawLinkedList._last.Naw);
            //Console.WriteLine("NAW: " + nawLinkedList.GetNawAt(1));
            //nawLinkedList.InsertTail(naw3);
            //Console.WriteLine("First: " + nawLinkedList._first.Naw);
            //Console.WriteLine("Last: " + nawLinkedList._last.Naw);
            //Console.WriteLine("NAW: " + nawLinkedList.GetNawAt(2));
            //nawLinkedList.InsertTail(naw4);
            //Console.WriteLine("First: " + nawLinkedList._first.Naw);
            //Console.WriteLine("Last: " + nawLinkedList._last.Naw);
            //Console.WriteLine("NAW: " + nawLinkedList.GetNawAt(3));
            //nawLinkedList.InsertTail(naw5);
            //Console.WriteLine("First: " + nawLinkedList._first.Naw);
            //Console.WriteLine("Last: " + nawLinkedList._last.Naw);
            //Console.WriteLine("NAW: " + nawLinkedList.GetNawAt(4));

            nawLinkedList.InsertHead(naw1);
            Console.WriteLine("First: " + nawLinkedList._first.Naw);
            Console.WriteLine("Last: " + nawLinkedList._last.Naw);
            Console.WriteLine("NAW: " + nawLinkedList.GetNawAt(0));
            nawLinkedList.InsertHead(naw2);
            Console.WriteLine("First: " + nawLinkedList._first.Naw);
            Console.WriteLine("Last: " + nawLinkedList._last.Naw);
            Console.WriteLine("NAW: " + nawLinkedList.GetNawAt(0));
            nawLinkedList.InsertHead(naw3);
            Console.WriteLine("First: " + nawLinkedList._first.Naw);
            Console.WriteLine("Last: " + nawLinkedList._last.Naw);
            Console.WriteLine("NAW: " + nawLinkedList.GetNawAt(0));
            nawLinkedList.InsertHead(naw4);
            Console.WriteLine("First: " + nawLinkedList._first.Naw);
            Console.WriteLine("Last: " + nawLinkedList._last.Naw);
            Console.WriteLine("NAW: " + nawLinkedList.GetNawAt(0));
            nawLinkedList.InsertHead(naw5);
            Console.WriteLine("First: " + nawLinkedList._first.Naw);
            Console.WriteLine("Last: " + nawLinkedList._last.Naw);
            Console.WriteLine("NAW: " + nawLinkedList.GetNawAt(0));

            nawLinkedList.BubbleSort();


            for (int i = 0; i < nawLinkedList.Count(); i++)
            {
                Console.WriteLine(nawLinkedList.GetNawAt(i));
            }

                System.Console.ReadKey();
        }
    }
}
