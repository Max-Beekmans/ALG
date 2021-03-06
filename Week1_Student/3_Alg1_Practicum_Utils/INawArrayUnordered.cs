﻿using Alg1_Practicum_Utils.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alg1_Practicum_Utils
{
    public interface INawArrayUnordered : INawArray, INawArrayUnordered_wk1
    { }

    public interface INawArrayUnordered_wk1 
    {
        int FindNaam(string itemNaam);

        void RemoveAtIndex(int index);

        void RemoveFirstNaam(string itemNaam);

        void RemoveLastNaam(string itemNaam);

        int RemoveAllNaam(string itemNaam);
    }
}
