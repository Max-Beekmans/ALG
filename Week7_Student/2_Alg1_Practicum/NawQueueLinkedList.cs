using Alg1_Practicum_Utils;
using Alg1_Practicum_Utils.Models;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alg1_Practicum
{
    public class NawQueueLinkedList
    {
        public Link First { get; set; }

        protected Link Last { get; set; }

        private int _count;

        public void Enqueue(NAW naw)
        {
            Link newLink = new Link();
            newLink.Naw = naw;
            if (First == null)
            {
                First = newLink;
            }
            else
            {
                Last.Next = newLink;
            }
            Last = newLink;
            _count++;
        }

        public NAW Dequeue()
        {
            NAW tempNaw = new NAW();
           
            if (_count != 0)
            {
                tempNaw = First.Naw;
                if (_count > 1)
                {
                    First = First.Next;
                }
                else
                {
                    First = null;
                    Last = null;
                }
                _count--;
                return tempNaw;
            }
            return null;
        }

        public int Count()
        {
            return _count;
        }
    }

 }
