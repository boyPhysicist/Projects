using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airline.Interfaces
{
    public interface IFlyable
    {
        
        double MaxSpeed { get; }
        double MaxHeight { get; }
        double RunningLenght { get; }
        double MeanFreePath { get; }
        string EnginesName { get; }
        int NumEngines { get; }
        

    }
}
