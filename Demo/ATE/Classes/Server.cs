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

        public event EventHandler<int> CallHandlerEvent;
        public Server()
        {
            ServerLib = new Dictionary<IPort, ITerminal>();
        }

        public void AddContactPair(ITerminal terminal)
        {
            ServerLib.Add(terminal.Port,terminal);
        }

        public void CallHandler(Tuple<int, int> info)
        {
          var targetPort = ServerLib.Where(x => x.Value.TerminalNumber == info.Item2).Select(x => x.Key).ElementAt(0);
            if (targetPort.PortState == (PortState.Connected|PortState.FreeToCall))
            {
                targetPort.WhaitAnswer();
                CallHandlerEvent += ServerLib[targetPort].WaitAnswer;
                CallHandlerEvent?.Invoke(this, info.Item1);
            }
            else
            {
                
            }
            

        }

    }
}
