using Alg1_Practicum_Utils.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alg1_Practicum_Utils
{
    public interface ILinkedList
    {
        Link Head();
 
        void InsertHead(NAW naw);

        void RemoveHead();

        int Count();

        int CountCalculated(); 

        int CountStored(); 

        int FindNaw(NAW naw);

        void RemoveAllNaw(NAW naw);

        void Show();

    }

    public interface INawLinkedList
    {
        NAW GetNawAt(int index);

        void SetNawAt(int index, NAW naw);
 
    }

    public interface ITwoWayLinkedList
    {
        Link Tail();

        void InsertTail(NAW naw);

        void RemoveTail();
    }
}
