using Airline.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airline.Interfaces
{
    public interface IPassenger
    {
       SalonClasses SalonClass { get; }
        int NumSeats { get; }

    }
}
