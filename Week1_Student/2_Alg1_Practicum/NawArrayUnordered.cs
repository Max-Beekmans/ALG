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
    public class NawArrayUnordered : INawArrayUnordered
    {
        protected Alg1NawArray _nawArray;

        private int _size;
        private int _used;


        public NawArrayUnordered(int initialSize)
        {
            _size = initialSize;

            if (_size > 0 && _size < 1000000)
            {
                _nawArray = new Alg1NawArray(_size);

            }
            else
            {
                throw new NawArrayUnorderedInvalidSizeException();
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

        public void Add(NAW item)
        {
            if (_used < _size)
            {
                _nawArray[_used] = item;
                _used++;
            }
            else
            {
                throw new NawArrayUnorderedOutOfBoundsException();
            }

        }

        public int FindNaam(string itemNaam)
        {
            for (int i = 0; i < _used; i++)
            {
                if (_nawArray[i].Naam.Equals(itemNaam))
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
                throw new NawArrayUnorderedOutOfBoundsException();
            }
        }

        public void RemoveFirstNaam(string gezochteNaam)
        {
            RemoveAtIndex(FindNaam(gezochteNaam));
        }

        public void RemoveLastNaam(string gezochteNaam)
        {
            for (int i = _used; i > -1; i--)
            {
                if (_nawArray[i].Naam.Equals(gezochteNaam))
                {
                    RemoveAtIndex(i);
                    break;
                }
            }
        }

        public int RemoveAllNaam(string gezochteNaam)
        {
            int k = 0;

            for (int i = 0; i < _used; i++)
            {
                if (_nawArray[i].Naam.Equals(gezochteNaam))
                {
                    RemoveAtIndex(i);
                    k++;
                }
            }
            return k;
        }

        public Alg1NawArray Array
        {
            get { return _nawArray; }
            set { _nawArray = value; }
        }
    }
}
