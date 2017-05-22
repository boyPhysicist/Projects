using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATE.Interfaces
{
    public interface IServer
    {
        IDictionary<IPort,ITerminal> ServerComposition { get; set; }
        Tuple<string, DateTime, string> SendData();
        void Connect();
        void Disconnect();
    }
}
