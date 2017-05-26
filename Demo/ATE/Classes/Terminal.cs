using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATE.Classes.Enums;
using ATE.Interfaces;

namespace ATE.Classes
{
    public class Terminal : ITerminal
    {
        public int TerminalNumber { get; }
        public IPort Port { get;}
        private TerminalState _terminalState;
        public TerminalState TerminalState => _terminalState;
        private DateTime _starTime;
        private DateTime _stopTime;
        public delegate void MethodBox(Tuple<int, int> param);
        public event MethodBox Calling;

        public Terminal(int number, IPort port)
        {
            _terminalState = TerminalState.Waiting;
            Port = port;
            TerminalNumber = number;
        }
        public void Answer()
        {
            if (_terminalState == TerminalState.IncomingCall)
            {
                _starTime = DateTime.Now;
            }
        }

        public void Call(int number)
        {
            _terminalState = TerminalState.OutgoingCall;
            _starTime = DateTime.Now;
            Calling += Port.ConnectToServer;
            Tuple<int,int> x = new Tuple<int, int>(TerminalNumber,number);
            Calling?.Invoke(x);
            Calling -= Port.ConnectToServer;
        }

        public void PutDownPhone()
        {
            _stopTime = DateTime.Now;
        }

        public void WaitAnswer(object server,int incomingNumber)
        {
            _terminalState = TerminalState.IncomingCall;
        }
    }
}
