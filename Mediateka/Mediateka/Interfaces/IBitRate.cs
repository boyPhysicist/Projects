using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediateka.Interfaces
{
    public interface IBitRate
    { 
        double BitPerSecond
        {
            get;
        }
        double Time { get; }
    }
}
