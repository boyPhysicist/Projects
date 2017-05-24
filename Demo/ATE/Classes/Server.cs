using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATE.Classes.Enums;
using ATE.Interfaces;

namespace ATE.Classes
{
    public class Server
    {
        private IDictionary<IPort,ITerminal> ServerLib { get; }
        private ICollection<IPort> ServerSource { get; }

        public void CallHandler(Tuple<int, int, DateTime> info)
        {
          var targetPort = ServerLib.Where(x => x.Value.TerminalNumber == info.Item2).Select(x => x.Key).ElementAt(0);
            if (targetPort.PortState == (PortState.Connected|PortState.FreeToCall))
            {

            }
            else
            {
                
            }
            

        }

    }
}
