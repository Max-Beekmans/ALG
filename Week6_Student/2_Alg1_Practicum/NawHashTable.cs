using Alg1_Practicum_Utils;
using Alg1_Practicum_Utils.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alg1_Practicum
{
    public class NawHashTable
    {
        protected Alg1NawArray _array;

        private int _count = 0;

        public NawHashTable(int initialSize)
        {
            _array = new Alg1NawArray(initialSize);
        }

        public bool Add(NAW naw)
        {
            if (_count < _array.Size)
            {
                    int hashVal = naw.GetHashCode();
                    hashVal = hashVal%_array.Size;
                    if (hashVal < 0)
                    {
                        hashVal = Math.Abs(hashVal);
                    }
                    while (_array[hashVal] != null)
                    {
                        hashVal++;
                        hashVal = hashVal % _array.Size;
                    }
                    _array[hashVal] = naw;
                    _count++;
                    return true;
             }
            return false;
        }

        public bool Remove(NAW naw)
        {
            int hashVal = naw.GetHashCode();
            hashVal = hashVal%_array.Size;
            if (hashVal < 0)
            {
                hashVal = Math.Abs(hashVal);
            }
            while (_array[hashVal] != null)
            {
                if (_array[hashVal].CompareTo(naw) == 0)
                {
                    _array[hashVal] = null;
                    return true;
                }
                hashVal++;
                hashVal = hashVal % _array.Size;
            }
            return false;
        }
    }
}
