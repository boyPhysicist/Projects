using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airline.Interfaces
{
    public interface IAirplanesModel
    { 
        double Length { get; }
        double WingSpan { get; }
        double Height { get; }
        double WingArea { get; }

    }
}
