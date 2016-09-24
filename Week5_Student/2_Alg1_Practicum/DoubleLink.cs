using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alg1_Practicum_Utils.Models
{
    public class DoubleLink
    {
        private DoubleLink _previous;
        private DoubleLink _next;

        public NAW Naw { get; set; }

        public DoubleLink Previous { get; set; }
 
        public DoubleLink Next { get; set; }       
    }
}
