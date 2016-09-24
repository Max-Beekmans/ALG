using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Alg1_Practicum;
using Alg1_Practicum_Utils.Models;
using Alg1_Practicum_Utils.Exceptions;

namespace Alg1_Practicum
{
    public class Kassa
    {
        private NawPriorityQueue _queue; // De kassa dient gebruik te maken van jouw eigen NawPriorityQueue klasse

        public Kassa(int aantalKlantenPerStap)
        {
            // vul de constructor aan
        }

        public void SluitAan(NAW klant)
        {
            // vul deze methode aan
            // bereken de prioriteit van de nieuwe klant (=lengte van zijn naam) en voeg deze in _queue in.
        }

        public void VerwerkKlanten()
        {
            // Verwerk random tussen 0 en maxAantalKlantenPerStap klanten
            // Haal ze uit de queue maar onthoudt welke klanten er in deze simulatiestap geholpen zijn zodat show dit kan afdrukken
        }

        public int BerekenPrioriteit(NAW klant)
        {
            return klant.Naam.Length;
        }

        public void Show()
        {
            // implementeer deze methode
        }

    }
}
