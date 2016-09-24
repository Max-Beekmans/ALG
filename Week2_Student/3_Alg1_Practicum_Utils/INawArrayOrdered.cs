using Alg1_Practicum_Utils.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alg1_Practicum_Utils
{
    public interface INawArrayOrdered : INawArray, INawArrayOrdered_wk2
    {
        int Find(NAW item);
        
        bool Remove(NAW item);
        
        void RemoveAtIndex(int index);
        
        bool Update(NAW oldValue, NAW newValue);

        void UpdateAll(NAW item, NAW newValue);
    }

    public interface INawArrayOrdered_wk2
    {
        NAW this[int index] { get; set; }
    }
}
