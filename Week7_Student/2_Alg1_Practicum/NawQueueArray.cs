using Alg1_Practicum_Utils;
using Alg1_Practicum_Utils.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Alg1_Practicum_Utils.Exceptions;

namespace Alg1_Practicum
{
    public class NawQueueArray
    {
        public int Front { get; set; }

        public int Rear { get; set; }

        protected Alg1NawArray _array; // interne array
        protected int _count;          // aantal gebruikte indexen in interne array
        protected int _size;           // omvang van interne array

        public NawQueueArray(int initialSize)
        {
            // aanmaken intern array
            if ((initialSize > 0) && (initialSize <= 1000))
            {
                _size = initialSize;
            }
            else
            {
                throw new NawQueueArrayInvalidSizeException();
            }

            _array = new Alg1NawArray(_size);


            // verdere initialisatie

        }

        public void Enqueue(NAW naw)
        {
            if (Rear == _size)
            {
                Rear = 0;
            }

            if (_count != _size)
            {
                _array[Rear] = naw;
                Rear++;
                _count++;
            }
        }

        public NAW Dequeue()
        {
            if (_count != 0)
            {
                NAW temp = _array[Front];
                _array[Front] = null;
                Front++;
                _count--;
                return temp;
            }
            return null;
        }

        public int Count()
        {
            return _count;
        }
    }

}
