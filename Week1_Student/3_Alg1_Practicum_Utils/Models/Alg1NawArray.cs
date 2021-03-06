﻿using Alg1_Practicum_Utils.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alg1_Practicum_Utils.Models
{
    public class Alg1NawArray
    {
        private NAW[] _array;
        public int Size { get; private set; }
        
        public Alg1NawArray(int size)
        {
            Size = size;
            _array = new NAW[size];
        }

        public void SetValues(NAW[] newArray)
        {
            newArray.CopyTo(_array, 0);
        }

        public NAW this[int index]
        {
            get
            {
                if (_array != null && Logger.Instance.Enabled)
                {
                    Logger.Instance.Log(
                        new LogItem
                        {
                            NewNaw1 = _array[index],
                            Index1 = index,
                            ArrayAction = ArrayAction.GET
                        }
                    );
                }
                return _array[index];
            }
            set
            {
                if (_array != null && Logger.Instance.Enabled)
                {
                    Logger.Instance.Log(
                        new LogItem
                        {
                            NewNaw1 = value,
                            OldNaw1 = _array[index],
                            Index1 = index,
                            ArrayAction = ArrayAction.SET
                        }
                    );
                }

                _array[index] = value;
            }
        }

        public NAW[] ToArray()
        {
            return (NAW[])_array.Clone();
        }

        public void Swap(int firstIndex, int secondIndex)
        {
            
            var lowestIndex = firstIndex < secondIndex ? firstIndex : secondIndex;
            var highestIndex = firstIndex > secondIndex ? firstIndex : secondIndex;
            if (Logger.Instance.Enabled)
            {
                Logger.Instance.Log(
                new LogItem
                {
                    NewNaw1 = _array[highestIndex],
                    OldNaw1 = _array[lowestIndex],
                    Index1 = lowestIndex,
                    NewNaw2 = _array[lowestIndex],
                    OldNaw2 = _array[highestIndex],
                    Index2 = highestIndex,
                    ArrayAction = ArrayAction.SWAP
                });
            }

            NAW temp = _array[firstIndex];
            _array[firstIndex] = _array[secondIndex];
            _array[secondIndex] = temp;
        }
    }
}
