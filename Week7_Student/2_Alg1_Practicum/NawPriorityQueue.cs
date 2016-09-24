using Alg1_Practicum_Utils;
using Alg1_Practicum_Utils.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alg1_Practicum
{
    public class NawPriorityQueue
    {
        private int _count;

        private SortedDictionary<int, NawQueueLinkedList> _priorityQueue = new SortedDictionary<int, NawQueueLinkedList>();  // <= vervang hier Object met een geschikte combinatie van een .net klasse en jouw eigen NawQueueLinkedList Klasse
        public void Enqueue(int priority, NAW naw)
        {
            if (!_priorityQueue.ContainsKey(priority))
            {
                _priorityQueue.Add(priority, new NawQueueLinkedList());
            }
            _count++;

            _priorityQueue[priority].Enqueue(naw);
        }

        public NAW Dequeue()
        {
            var result = _priorityQueue.First().Value.Dequeue();
            if (result == null)
            {
                _priorityQueue.Remove(_priorityQueue.First().Key);
                Dequeue();
            }
            return result;
        }

        public int Count()
        {
            return _priorityQueue.Count();
        }

        public void Show()
        {
            // Deze methode is alleen nodig voor de Bonus huiswerkopdracht !
            throw new NotImplementedException();
        }
    }
}
