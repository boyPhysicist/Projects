using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATE.Classes.Enums;
using ATE.Interfaces;

namespace ATE.Classes
{
    public class Port : IPort
    {

        public PortState PortState { get; set; }
        private readonly Server _server;
        public PortState EconomyPortState { get; set; }

        public delegate void MethodBox(Tuple<int, int,DateTime> param);

        public event MethodBox Calling;

        public Port(Server server)
        {
            _server = server;
            PortState = PortState.Disconnected;
            EconomyPortState = PortState.UnBlocked;
        }

        public void Connect()
        {
            PortState = PortState.Connected;
        }

        public void ConnectToServer(Tuple<int, int> param)
        {
            Tuple<int, int, DateTime> serverData = new Tuple<int, int, DateTime>(param.Item1,
                param.Item2, DateTime.Now);
            Calling += _server.CallHandler;
            Calling?.Invoke(serverData);
        }

        public void Disconnect()
        {
            PortState = PortState.Disconnected;
        }

        public void Block()
        {
            EconomyPortState = PortState.Blocked;
        }

        public void UnBlock()
        {
            EconomyPortState = PortState.UnBlocked;
        }
    }
}
