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

        public delegate void MethodBox(Tuple<int, int> param);

        public event MethodBox Calling;

        public Port(Server server)
        {
            _server = server;
            PortState = PortState.Disconnected|PortState.Busy;
            EconomyPortState = PortState.UnBlocked;
        }

        public void Connect()
        {
            PortState = PortState.Connected | PortState.FreeToCall;
        }

        public void ConnectToServer(Tuple<int, int> param)
        {
            Tuple<int, int> serverData = new Tuple<int, int>(param.Item1,
                param.Item2);
            Calling += _server.CallHandler;
            Calling?.Invoke(serverData);
            Calling -= _server.CallHandler;
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

        public void WhaitAnswer()
        {
            PortState = PortState.Connected | PortState.Busy;
            
        }
    }
}
