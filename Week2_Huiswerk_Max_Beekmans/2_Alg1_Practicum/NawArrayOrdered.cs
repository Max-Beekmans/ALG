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
        private int _size;
        private int _used;

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

        public bool Remove(NAW item)
        {
            throw new NotImplementedException();
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

        public int Count
        {
            get
            {
                return ItemCount();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public int ItemCount()
        {
            return _used;
        }

        public Alg1NawArray Array
        {
            get
            {
                return _nawArray;
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public NAW this[int index]
        {
            get
            {
                return _nawArray[index];
            }
            set
            {
                _nawArray[index] = value;
            }
        }

        public void AddBinary(NAW item)
        {
            throw new NotImplementedException();
        }

        public int FindBinary(NAW item)
        {
            int lowerBound = 0;
            int upperBound = _used - 1;
            int currentInt;

            while (true)
            {
                currentInt = (lowerBound + upperBound) / 2;
                if (_nawArray[currentInt] == item)
                {
                    return currentInt;
                }
                else if (lowerBound > upperBound)
                {
                    return -1;
                }
                else
                {
                    if (_nawArray[currentInt].CompareTo(item) > 0)
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
    }
}


