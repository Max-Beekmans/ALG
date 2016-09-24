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

            // voorbeeld uitprobeercode

            var nieuwArray = new NawArrayUnordered(20);
            nieuwArray.Add(new NAW("Persoon1", "Adres1", "Woonplaats1"));
            var persoon = new NAW("Persoon 1", "Adres 5", "Woonplaats 1");
            int index = nieuwArray.FindNaam(persoon.Naam);
           
            System.Console.ReadKey();
        }
    }
}
