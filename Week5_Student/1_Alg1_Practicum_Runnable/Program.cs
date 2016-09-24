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
            NawDoublyLinkedList nawDoublyLinkedList = new NawDoublyLinkedList();

            NAW naw1 = new NAW("ABC", "straat", "schijndel");
            NAW naw2 = new NAW("YIJD", "dropstraat", "den bosch");
            NAW naw3 = new NAW("DEF", "kerkstraat", "amsterdam");
            NAW naw4 = new NAW("DEF", "dorpstraat", "amsterdam");
            NAW naw5 = new NAW("ABC", "kerkstraat", "amsterdam");

            nawDoublyLinkedList.InsertHead(naw1);
            nawDoublyLinkedList.InsertHead(naw2);
            nawDoublyLinkedList.InsertHead(naw3);
            nawDoublyLinkedList.InsertHead(naw4);
            nawDoublyLinkedList.InsertHead(naw5);

            nawDoublyLinkedList.BubbleSort();

            for (int i = 0; i < nawDoublyLinkedList._length; i++)
            {
                Console.WriteLine(nawDoublyLinkedList.GetNawAt(i)); 
            }
            System.Console.ReadKey();
        }
    }
}
