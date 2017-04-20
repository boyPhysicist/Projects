using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airline.Classes
{
    [Flags]
    public enum SalonClasses
    {
        Economy = 1,
        Business = 2,
        FirstClass = 4

    }
}
