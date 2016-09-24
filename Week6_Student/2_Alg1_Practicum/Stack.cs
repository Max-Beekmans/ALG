using Alg1_Practicum_Utils;
using Alg1_Practicum_Utils.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alg1_Practicum
{
    public class Stack
    {
        protected StackLink First { get; set; } //First = Top

        public void Push(string value)
        {
            StackLink newLink = new StackLink();
            newLink.String = value;
            newLink.Next = First;
            First = newLink;
        }

        public string Pop()
        {
            if(IsEmpty())
            {
                return null;
            }
            String returnString = First.String;
            First = First.Next;
            return returnString;
        }

        public string Peek()
        {
            if (IsEmpty())
            {
                return null;
            }
            return First.String;
        }

        public bool IsEmpty()
        {
            if (First == null)
            {
                return true;
            }
            return false;
        }
    }
}
