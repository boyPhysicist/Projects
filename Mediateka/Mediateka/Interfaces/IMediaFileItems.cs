﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediateka.Interfaces
{
    public interface IMediaFileItems
    {
        double Size { get; }
        string Name { get; }

        string Url { get; }
    }
}
