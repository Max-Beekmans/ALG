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
    public class NawArrayUnordered : INawArrayUnordered, IBubbleSort, IInsertionSort, ISelectionSort
    {
        protected Alg1NawArray _nawArray;
        protected int _size;
        protected int _used;

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


        // ==================== Vervang de implementatie van deze methodes met jouw uitwerking van week 2 ==================

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
            for (int i = 0; i < _used - 1; i++) 
            {
                _nawArray[i] = _nawArray[i + 1];
            }
            _used--;
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
                newObject.Add(_nawArray[i]);
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

        public void BubbleSortAlternative(int[] rij)
        {
            int outer = 0;
            int inner = 0;
            int temp  = 0;

            for (outer = rij.Length - 1; outer > 0; outer--)
            {
                if (rij[inner] >= rij[inner + 1])
                {
                    temp            = rij[inner];
                    rij[inner]      = rij[inner + 1];
                    rij[inner + 1]  = temp;
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

        // ==================== Maak onderstaande methodes voor week 3 ===================================

        public void InsertionSort()
        {
            int inbound;
            int outbound;
            NAW temp;

            for (outbound = 1; outbound < _used; outbound++)
            {
                temp = _nawArray[outbound];
                inbound = outbound;
                while (inbound > 0 && _nawArray[inbound - 1].CompareTo(temp) >= 0)
                {
                    _nawArray[inbound] = _nawArray[inbound - 1];
                    --inbound;
                }
                if (outbound != inbound)
                {
                    _nawArray[inbound] = temp;
                }
            }
        }

        public void InsertionSortInverted()
        {
            int inbound = 0;
            int outbound;
            NAW temp;

            for (outbound = 1; outbound < _used; outbound++)
            {
                temp = _nawArray[outbound];
                while (inbound <= _used && _nawArray[inbound + 1].CompareTo(temp) >= 0)
                {
                    _nawArray[inbound] = _nawArray[inbound + 1];
                    ++inbound;
                }
                _nawArray[inbound] = temp;
            }
        }

        public void SelectionSort()
        {
            int outbound;
            int inbound;
            int lowest;

            for (outbound = 0; outbound < _used; outbound++)
            {
                lowest = outbound;
                for (inbound = outbound + 1; inbound < _used - 1; inbound++)
                {
                    if (_nawArray[inbound].CompareTo(_nawArray[lowest]) < 0)
                    {
                        lowest = inbound;
                    }
                    if (outbound != lowest)
                    {
                        _nawArray.Swap(outbound, lowest);
                    }
                }
            }
        }

        public void SelectionSortInverted()
        {
            int outbound;
            int inbound;
            int lowest;

            for (outbound = 0; outbound < _used; outbound++)
            {
                lowest = outbound;
                for (inbound = _used - 1; inbound > 0; inbound--)
                {
                    if (_nawArray[inbound].CompareTo(_nawArray[lowest]) < 0)
                    {
                        lowest = inbound;
                    }
                    if (outbound != lowest)
                    {
                        _nawArray.Swap(outbound, lowest);
                    }
                }
            }
        }

        // ==================== Laat onderstaande methodes ongemoeid ===================================

        public Alg1NawArray Array
        {
            get { return _nawArray; }
            set { _nawArray = value; }
        }
    }

}
