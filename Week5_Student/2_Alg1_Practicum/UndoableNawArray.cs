using Alg1_Practicum_Utils.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alg1_Practicum
{
    public class UndoableNawArray : NawArrayOrdered
    {
        private UndoLink _currentUndoLink;
        private UndoLink _first;

        public UndoLink First
        {
            get { return _first; }
        }

        public UndoLink Current
        {
            get { return _currentUndoLink; }
        }

        public UndoableNawArray(int size)
            : base(size)
        {
            _first = null;
            _currentUndoLink = null;
        }

        public override void Add(NAW naw)
        {
            base.Add(naw);
            AddOperation(Operation.ADD, naw);
        }

        public override bool Remove(NAW naw)
        {
            if (base.Remove(naw))
            {
                AddOperation(Operation.REMOVE, naw);
                return true;
            }
            return false;
        }

        public void Undo()
        {
            if (_currentUndoLink.Operation == Operation.REMOVE)
            {
                Add(_currentUndoLink.Naw);
                AddOperation(Operation.ADD, _currentUndoLink.Naw);
            }
            else
            {
                Remove(_currentUndoLink.Naw);
                AddOperation(Operation.REMOVE, _currentUndoLink.Naw);
            }
        }

        public void Redo()
        {
            if (_currentUndoLink.Previous.Operation == Operation.ADD)
            {
                Add(_currentUndoLink.Previous.Naw);
                AddOperation(Operation.ADD, _currentUndoLink.Previous.Naw);
            }
            else
            {
                Remove(_currentUndoLink.Previous.Naw);
                AddOperation(Operation.REMOVE, _currentUndoLink.Previous.Naw);
            }
        }

        private void AddOperation(Operation operation, NAW naw)
        {

            UndoLink newLink = new UndoLink();
            newLink.Operation = operation;
            newLink.Naw = naw;

            if (_first == null)
            {
                _first = newLink;
            }
            else
            {
                _currentUndoLink.Next = newLink;
                newLink.Previous = _currentUndoLink;
            }
            _currentUndoLink = newLink;

        }

    }
}
