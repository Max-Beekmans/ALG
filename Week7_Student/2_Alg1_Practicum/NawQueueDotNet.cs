using Alg1_Practicum_Utils;
using Alg1_Practicum_Utils.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alg1_Practicum
{
    public class NawQueueDotNet
    {

        private Queue<NAW> nawQueue;

        public NawQueueDotNet()
        {
            nawQueue = new Queue<NAW>();
        }
   
        public void Enqueue(NAW naw)
        {
            nawQueue.Enqueue(naw);
        }

        public NAW Dequeue()
        {
            if (Count() != 0)
            {
                return nawQueue.Dequeue();
            }
            return null;
        }

        public int Count()
        {
            return nawQueue.Count;
        }

    }
}
