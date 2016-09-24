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
            //NAW naw1 = new NAW("ABC", "straat", "schijndel");
            //NAW naw2 = new NAW("YIJD", "dropstraat", "den bosch");
            //NAW naw3 = new NAW("DEF", "kerkstraat", "amsterdam");
            //NAW naw4 = new NAW("DEF", "dorpstraat", "amsterdam");
            //NAW naw5 = new NAW("ABC", "kerkstraat", "amsterdam");
            //NAW naw6 = new NAW("ABC", "kerkstraat", "amsterdam");

            //NawHashTable nawHash = new NawHashTable(10);

            //nawHash.Add(naw1);
            //nawHash.Add(naw5);
            //nawHash.Add(naw6);
            //nawHash.Add(naw2);
            //nawHash.Add(naw3);
            //nawHash.Add(naw4);

            String goodxml = "<child><body></body></child>";
            String badxml = "<child><body></body><child>";

            XmlValidator xmlValidator = new XmlValidator();
            if (xmlValidator.Validate(badxml))
            {
                Console.WriteLine("Succes!");
            }
            else
            {
                Console.WriteLine("Fail!");
            }

               

    
            System.Console.ReadKey();
        }
    }
}
