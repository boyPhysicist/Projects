using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airline.Interfaces
{
    public interface ICargo
    {
        double MaxTakeOffWeight { get; }
        double MaxLandingWeight { get; }
        double EmptyWeight { get; }
        double FuelTankCapacity { get; }
    }
}
