using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airline.Interfaces
{
    public interface IFlyable
    {
        double FlightRange { get; }
        double MaxSpeed { get; }
        double MaxHeight { get; }
        double RunningLenght { get; }
        double MeanFreePath { get; }
        string Engines { get; }
        int NumEngines { get; }
        double FuelConsumption { get; }

    }
}
