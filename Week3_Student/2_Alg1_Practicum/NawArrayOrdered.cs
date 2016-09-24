using Alg1_Practicum_Utils;
using Alg1_Practicum_Utils.Exceptions;
using Alg1_Practicum_Utils.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alg1_Practicum
{
    public class NawArrayOrdered : INawArrayOrdered, IBinarySearch
    {
        protected Alg1NawArray _nawArray;
        protected int _size = 20;
        protected int _used;

        // ==================== Vervang de implementatie van deze methodes met jouw uitwerking van week 2 ==================

        public NawArrayOrdered(int initialSize)
        {
            _size = initialSize;

            if (_size > 0 && _size < 1000000)
            {
                _nawArray = new Alg1NawArray(_size);
            }
            else
            {
                throw new NawArrayOrderedInvalidSizeException();
            }
        }

        public int Find(NAW item)
        {
            for (int i = 0; i < _used; i++)
            {
                if (_nawArray[i].Naam.CompareTo(item.Naam) == 0)
                {
                    return i;
                }
                else if (_nawArray[i].Adres.CompareTo(item.Adres) == 0)
                {
                    return i;
                }
                else if (_nawArray[i].Woonplaats.CompareTo(item.Woonplaats) == 0)
                {
                    return i;
                }
            }
            return -1;
        }

        public void RemoveAtIndex(int index)
        {
            if (index < _used)
            {
                int j = index;
                for (int k = _used; k > j; k--)
                {
                    _nawArray[k] = _nawArray[k - 1];
                }
            }
            else
            {
                throw new NawArrayOrderedOutOfBoundsException();
            }
        }

        public bool Update(NAW oldValue, NAW newValue)
        {
            throw new NotImplementedException();
        }

        public void UpdateAll(NAW item, NAW newValue)
        {
            throw new NotImplementedException();
        }

        public void Add(NAW item)
        {
            if (_used < _size)
            {
                int j;
                for (j = 0; j < _used; j++)
                {
                    if (_nawArray[j].CompareTo(item) > 0)
                    {
                        break;
                    }
                }
                for (int k = _used; k > j; k--)
                {
                    _nawArray[k] = _nawArray[k - 1];
                }
                _nawArray[j] = item;
                _used++;
            }
            else
            {
                throw new NawArrayOrderedOutOfBoundsException();
            }
        }

        public void AddBinary(NAW item)
        {
            int lowerBound = 0;
            int upperBound = _used - 1;
            int currentInt;

            while (true)
            {
                currentInt = (lowerBound + upperBound) / 2;
                if (_nawArray[currentInt].CompareTo(item) > 0 || _nawArray[currentInt + 1].CompareTo(item) < 0)
                {
                    for (int k = _used; k > currentInt; k--)
                    {
                        _nawArray[k] = _nawArray[k - 1];
                    }
                    _nawArray[currentInt] = item;
                    break;
                }
                else
                {
                    if (_nawArray[currentInt].CompareTo(item) < 0)
                    {
                        lowerBound = currentInt + 1;
                    }
                    else
                    {
                        upperBound = currentInt - 1;
                    }
                }
            }
        }

        public int FindBinary(NAW item)
        {
            int lowerBound = 0;
            int upperBound = _used - 1;
            int currentInt;

            while (true)
            {
                currentInt = (lowerBound + upperBound) / 2;
                if (lowerBound > upperBound)
                {
                    return -1;
                }
                else if (_nawArray[currentInt] == item)
                {
                    return currentInt;
                }
                else
                {
                    if (_nawArray[currentInt].CompareTo(item) < 0)
                    {
                        lowerBound = currentInt + 1;
                    }
                    else
                    {
                        upperBound = currentInt - 1;
                    }
                }
            }
        }

        // ==================== Pas onderstaande methodes aan op jouw attribuutnaam ==============================

        public int Count
        {
            get { return ItemCount(); }
         
            set { _used = value; } // <<== Vul je eigen attribuutnaam in

        }

        public int ItemCount()
        {
            return _used; // <<== Vul je eigen attribuutnaam in
        }

        // ==================== Laat onderstaande methodes ongemoeid ===================================

        public Alg1NawArray Array
        {
            get { return _nawArray; }
            set { _nawArray = value; }
        }


    }
}


