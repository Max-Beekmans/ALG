using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alg1_Practicum_Test.TestExtensions
{
    [System.AttributeUsage(System.AttributeTargets.Method)]
    public class AantalPuntenAlsSlaagtAttribute : System.Attribute
    {
        public double Score { get; set; }

        public AantalPuntenAlsSlaagtAttribute(double score)
        {
            this.Score = score;
        }
    }
}
