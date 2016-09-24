using Alg1_Practicum_Utils;
using Alg1_Practicum_Utils.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Alg1_Practicum_Utils;

namespace Alg1_Practicum
{
    public class NawLinkedList : ILinkedList, ITwoWayLinkedList, INawLinkedList
    {
        public Link _first; // wijst naar eerste element in de lijst
        public Link _last;  // wijst naar laatste element in de lijst
        protected int _length; // is gelijk aan het aantal links in de lijst 

        public Link Head()
        {
            return _first;
        }

        public Link Tail()
        {
            return _last;
        }

        public int Count()
        {
            return CountStored();
        }

        //=====================================================================================================================
        // Code boven deze lijn is gegeven en hoef je niet aan te passen, hieronder staan de methodes die je gaat implementeren
        //=====================================================================================================================


        public void RemoveHead()
        {
            if (_length != 0)
            {
                if (_length > 1)
                {
                    _first = _first.Next;
                }
                else
                {
                    _first = null;
                    _last = null;
                }
                _length--;
            }
        }


        public int CountCalculated()
        {
            int count = 0;
            Link current = _first;
            while (current != null)
            {
                count++;
                current = current.Next;
            }
            return count;
        }

        public int CountStored()
        {
            return _length;
        }

        public void Show()
        {
            Link current = _first;
            while (current != null)
            {
                current.Naw.Show();
                current = current.Next;
            }
        }

        public int FindNaw(NAW naw)
        {
            Link current = _first;
            for (int i = 0; i < _length; i++)
            {
                if (current.Naw == naw)
                {
                    return i;
                }
                current = current.Next;
            }
            return -1;
        }

        public void RemoveAllNaw(NAW naw)
        {
            Link current = _first;
            Link previous = null;
            Link previousLast = null;
            while (current != null)
            {
                if (current.Naw.CompareTo(naw) == 0)
                {
                    if (current == _first)
                    {
                        _first = current.Next;
                    }
                    else if (current == _last)
                    {
                        _last = previousLast;
                    }
                    previous.Next = current.Next;
                    _length--;
                }
                else
                {
                    previousLast = current;
                }
                previous = current;
                current = current.Next;
            }
        }

        public void InsertHead(NAW naw)
        {
            Link newLink = new Link();
            newLink.Naw = naw;
            if (_first == null)
            {
                _last = newLink;
            }
            else
            {
                newLink.Next = _first;
            }
            _first = newLink;
            _length++;
        }

        public void InsertTail(NAW naw)
        {
            Link newLink = new Link();
            newLink.Naw = naw;
            if (_first == null)
            {
                _first = newLink;
            }
            else
            {
                _last.Next = newLink;
            }
            _last = newLink;
            _length++;
            
        }

        public void RemoveTail()
        {
            if (_length != 0)
            {
                if (_length != 1)
                {
                    Link current = _first;
                    while (current.Next != _last)
                    {
                        current = current.Next;
                    }
                    current.Next = null;
                    _last = current;
                }
                else
                {
                    _last = null;
                    _first = null;
                }
                _length--;
            }
        }

        public NAW GetNawAt(int index)
        {
            if(index < _length)
            {
                Link current = _first;
                for (int i = 0; i < index; i++)
                {
                    current = current.Next;
                }
                return current.Naw;
            }
            return null;
        }

        public void SetNawAt(int index, NAW naw)
        {
            if (index < _length)
            {
                if (index == 0)
                {
                    _first.Naw = naw;
                }
                else if (index == _length - 1)
                {
                    _last.Naw = naw;
                }
                else
                {
                    Link current = _first;
                    for (int i = 0; i <= index; i++)
                    {
                        if (i == index)
                        {
                            current.Naw = naw;
                        }
                        current = current.Next;
                    }
                }
            } //invalid index
        }

        public void BubbleSort()
        {
            int outbound;
            int inbound;

            for (outbound = _length - 1; outbound > 1; outbound--)
            {
                for (inbound = 0; inbound < outbound; inbound++)
                {
                    NAW naw1 = GetNawAt(inbound);
                    NAW naw2 = GetNawAt(inbound + 1);
                    if (naw1.CompareTo(naw2) > 0)
                    {
                        SetNawAt(inbound, naw2);
                        SetNawAt(inbound + 1, naw1);
                    }
                }
            }
        }

        public BigO OrderOfBubbleSort()
        {
            return BigO.N4;
        }

    }
}
