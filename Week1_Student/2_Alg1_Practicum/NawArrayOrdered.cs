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
    public class NawArrayOrdered : INawArrayOrdered
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

        public int Count
        {
            get { return ItemCount(); }
        }

        public int ItemCount()
        {
            return _used;
        }

        public virtual void Add(NAW item)
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

        public bool Update(NAW oldValue, NAW newValue)
        {
            throw new NotImplementedException();
        }

        public Alg1NawArray Array
        {
            get { return _nawArray; }
            set { _nawArray = value; }
        }
    }
}


