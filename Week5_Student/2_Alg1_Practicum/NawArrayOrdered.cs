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
    public class NawArrayOrdered 
    {
        protected Alg1NawArray _nawArray;
        protected int _size = 20;
        protected int _used = 0;

        public NawArrayOrdered(int initialSize)
        {
            if ((initialSize > 0) && (initialSize <= 1000000))
            {
                _size = initialSize;
            }
            else
            {
                throw new NawArrayOrderedInvalidSizeException();
            }

            _nawArray = new Alg1NawArray(_size);
        }

        public int Count
        {
            // huiswerk 1.6
            get { return _used; }
            set { _used = value; }

        }

        public virtual void Add(NAW item)
        {
            if (_used == 0)
            {
                _nawArray[0] = item;
                _used++;
            }
            else if (_used < _size)
            {
                // zoek invoegpositie
                bool inserted = false;

                for (int i = 0; !inserted && (i < _used); i++)
                {
                    if (_nawArray[i].CompareTo(item) >= 0)
                    {
                        // maak ruimte
                        for (int j = _used; j > i; j--)
                        {
                            _nawArray[j] = _nawArray[j - 1];
                        }
                        // voeg nieuw element in
                        _nawArray[i] = item;
                        _used++;
                        inserted = true;
                    }
                }
                if (!inserted)
                {
                    // Geen groter item gevonden, invoegen aan einde
                    _nawArray[_used] = item;
                    _used++;
                }
            }
            else
            {
                throw new NawArrayOrderedOutOfBoundsException();
            }
        }


        public int Find(NAW item)
        {
            if (_used > 0)
            { // doorzoek array
                for (int i = 0; i < _used; i++)
                {
                    if (_nawArray[i].CompareTo(item) == 0)
                    {
                        return i;
                    }
                }
            }

            return -1;
        }



        public virtual bool Remove(NAW item)
        {
            int index = Find(item);

            if (index != -1)
            {
                RemoveAtIndex(index);
                return true;
            }

            return false;
        }

        public void RemoveAtIndex(int index)
        {
            if (index >= 0 && index < _used)
            {
                _used--;

                for (int i = index; i < _used; i++)
                {
                    _nawArray[i] = _nawArray[i + 1];
                }
            }
        }

        public Alg1NawArray Array
        {
            get { return _nawArray; }
            set { _nawArray = value; }
        }
    }
}


