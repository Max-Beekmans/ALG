using Alg1_Practicum_Utils;
using Alg1_Practicum_Utils.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alg1_Practicum
{
    public class NawDoublyLinkedList 
    {
        public DoubleLink First { get; set; }
        public DoubleLink Last { get; set; }

        public int _length;


        public void InsertHead(NAW naw)
        {
            DoubleLink newLink = new DoubleLink();
            newLink.Naw = naw;
            if(First == null)
            {
                Last = newLink;
            }
            else
            {
                First.Previous = newLink;
                newLink.Next = First;
            }
            First = newLink;
            _length++;
        }

        public NAW GetNawAt(int index)
        {
            if (index < _length)
            {
                DoubleLink current = First;
                for (int i = 0; i < index; i++)
                {
                    current = current.Next;
                }
                return current.Naw;
            }
            return null;
        }

        public DoubleLink GetLinkAt(int index)
        {
            if (index < _length)
            {
                DoubleLink current = First;
                for (int i = 0; i < index; i++)
                {
                    current = current.Next;
                }
                return current;
            }
            return null;
        }

        public DoubleLink SwapLinkWithNext(DoubleLink link)
        {
            DoubleLink rightLink = link.Next;

            if (link == Last)
            {
                return null;
            }

            if (link == First)
            {
                First = rightLink;
            }
            else
            {
                link.Previous.Next = rightLink;
            }

            if (rightLink == Last)
            {
                Last = link;
            }
            else
            {
                rightLink.Next.Previous = link;
            }

            link.Next = rightLink.Next;
            rightLink.Previous = link.Previous;
            link.Previous = rightLink;
            rightLink.Next = link;    

            return rightLink;
        }

        public void BubbleSort()
        {

            DoubleLink inboundLink;
            DoubleLink outboundLink = Last.Previous;

            while (outboundLink != First.Next)
            {
                inboundLink = First;
                while (inboundLink != outboundLink)
                {

                    if (inboundLink.Naw.CompareTo(inboundLink.Next.Naw) > 0)
                    {
                        SwapLinkWithNext(inboundLink);
                    }
                    inboundLink = inboundLink.Next;
                }
                outboundLink = outboundLink.Previous;
            }
        }

        public BigO OrderOfBubbleSort()
        {
            return BigO.N2;  // <= vul juiste Orde in
        }

    }
}
