﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassicUO.Utility.Coroutines
{
    public enum CoroutineStatus : byte
    {
        Paused,
        Running,
        Complete,
        Cancelled,
        Disposed,
        Error
    }
}
