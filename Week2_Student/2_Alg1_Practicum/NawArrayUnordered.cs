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
    public class NawArrayUnordered : INawArrayUnordered, IBubbleSort
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

        public int Count
        {
            get
            {
                return ItemCount();
            }
            set
            {
                _used = value;
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
                _nawArray = value;
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

        public void RemoveFirstNaam(string itemNaam)
        {
            RemoveAtIndex(FindNaam(itemNaam));
        }

        public void RemoveLastNaam(string itemNaam)
        {
            for (int i = _used; i > -1; i--)
            {
                if (_nawArray[i].Naam.Equals(itemNaam))
                {
                    RemoveAtIndex(i);
                    break;
                }
            }
        }

        public int RemoveAllNaam(string itemNaam)
        {
            int k = 0;

            for (int i = 0; i < _used; i++)
            {
                if (_nawArray[i].Naam.Equals(itemNaam))
                {
                    RemoveAtIndex(i);
                    k++;
                }
            }
            return k;
        }

        public INawArrayOrdered ToNawArrayOrdered()
        {
            NawArrayOrdered newObject = new NawArrayOrdered(_size);
            for (int i = 0; i < _used; i++)
            {
                newObject.Add(this._nawArray[i]);
            }
            return newObject;
        }

        public void BubbleSort()
        {
            int outbound;
            int inbound;

            for (outbound = _used - 1; outbound > 1; outbound--)
            {
                for (inbound = 0; inbound < outbound; inbound++)
                {
                    if (_nawArray[inbound].CompareTo(_nawArray[inbound + 1]) > 0)
                    {
                        _nawArray.Swap(inbound, (inbound + 1));
                    }
                }
            }
        }

        public void BubbleSortInverted()
        {
            int outbound;
            int inbound;

            for (outbound = 0; outbound < 1; outbound++)
            {
                for (inbound = _used - 1; inbound > outbound; inbound--)
                {
                    if (_nawArray[inbound].CompareTo(_nawArray[inbound - 1]) > 0)
                    {
                        _nawArray.Swap(inbound, (inbound - 1));
                    }
                }
            }
        }
    }
}
