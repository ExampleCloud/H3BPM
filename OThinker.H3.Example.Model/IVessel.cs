﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OThinker.H3.Example.RemotingModel
{
    public interface IVessel
    {
        object InvokeMethod_O(string moduleName ,string methodName , object[] parameters);
    }
}
