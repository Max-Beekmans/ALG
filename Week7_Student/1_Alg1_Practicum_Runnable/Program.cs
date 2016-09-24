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
            NawQueueArray nawQueueArray = new NawQueueArray(4);

            NAW naw1 = new NAW("ABC", "straat", "schijndel");
            NAW naw2 = new NAW("YIJD", "dropstraat", "den bosch");
            NAW naw3 = new NAW("DEF", "kerkstraat", "amsterdam");
            NAW naw4 = new NAW("DEF", "dorpstraat", "amsterdam");
            NAW naw5 = new NAW("ABC", "kerkstraat", "amsterdam");

            nawQueueArray.Enqueue(naw1);
            nawQueueArray.Enqueue(naw2);
            nawQueueArray.Enqueue(naw3);
            nawQueueArray.Enqueue(naw4);
            nawQueueArray.Dequeue();

            nawQueueArray.Enqueue(naw5);
            nawQueueArray.Enqueue(naw1);

            var winkel = new Winkel(3,8,10);
            winkel.Run();

            System.Console.ReadKey();
        }
    }
}
