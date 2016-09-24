using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Alg1_Practicum_Utils.Models;

namespace Alg1_Practicum
{
    public class Winkel
    {
        private int _simStep = 0;
        private int _maxSimSteps = 0;

        public Winkel(int aantalKassas, int maxKlantenPerStap, int aantalSimulatieStappen)
        {
            _maxSimSteps = aantalSimulatieStappen;
            // Vul deze constructor verder aan
        }

        public void Stap()
        {
            // doe hier alle acties die per SimulatieStap moeten worden gedaan
            // -Klanten worden ad random toegevoegd aan de wachtrijen van de kassa's
            // -Klanten worden geholpen door de kassa's
        }

        public void Run()
        {
            // deze methode hoef je niet aan te passen
            for (_simStep = 0; _simStep < _maxSimSteps; _simStep++)
            {
                this.Stap();
                this.Show();
                System.Console.ReadKey();
            }
        }

        public void Show()
        {
            // implementeer deze methode
        }
    }
}
