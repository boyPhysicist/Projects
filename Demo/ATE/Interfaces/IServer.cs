using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATE.Interfaces
{
    public interface IServer
    {

        IDictionary<IPort, ITerminal> ServerLib { get; }
        void CreateDataForBillingSys(Tuple<int, int, DateTime, DateTime> data);
        
    }
}
