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
        private int _incomingNumber;
        private int _outgoingnumber;
        private DateTime _starTime;
        private DateTime _stopTime;
        public IPort Port { get; }
        private TerminalState _terminalState;
        public TerminalState TerminalState => _terminalState;
        public delegate void MethodBox(Tuple<int, int> param);
        public event MethodBox Calling;
        public event EventHandler<Tuple<int, int, DateTime, DateTime>> SendDataEvent;
        public event Action StatusChange;
        public Terminal(int number, IPort port)
        {
            _terminalState = TerminalState.Waiting;
            Port = port;
            TerminalNumber = number;
            StatusChange += Port.Connect;
            SendDataEvent += Port.SendData;
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
            _outgoingnumber = number;
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
            //_terminalState = TerminalState.Waiting;
            //StatusChange?.Invoke();
            SendDataEvent?.Invoke(this,
                TerminalState == TerminalState.OutgoingCall
                    ? new Tuple<int, int, DateTime, DateTime>(TerminalNumber, _outgoingnumber, _starTime, _stopTime)
                    : new Tuple<int, int, DateTime, DateTime>(_incomingNumber, TerminalNumber, _starTime, _stopTime));
            //SendDataEvent -= Port.SendData;
        }

        public void PutDownPhone(object server,int terminalNumber)
        {
            if (typeof(Server) == server.GetType()&&TerminalNumber==terminalNumber)
            {
                _terminalState = TerminalState.Waiting;
                StatusChange?.Invoke();
                //SendDataEvent -= Port.SendData;
                
            }
        }

        public void WaitAnswer(object server,int incomingNumber)
        {
            _terminalState = TerminalState.IncomingCall;
            _incomingNumber = incomingNumber;
        }
    }
}
