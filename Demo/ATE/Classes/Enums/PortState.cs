﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATE.Classes.Enums
{
    [Flags]
    public enum PortState
    {
        Connected,
        Disconnected,
        Blocked,
        UnBlocked,
        FreeToCall,
        Busy

    }
}
