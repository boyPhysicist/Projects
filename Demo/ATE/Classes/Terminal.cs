using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATE.Interfaces;

namespace ATE.Classes
{
    public class Terminal : ITerminal
    {
        public int TerminalNumber { get; }

        public IPort Port { get; }

        public delegate void MethodBox(Tuple<int, int> param);

        public event MethodBox Calling;

        public Terminal(int number, IPort port)
        {
            Port = port;
            TerminalNumber = number;
            Calling += Port.ConnectToServer;
        }
        public void Answer()
        {
            throw new NotImplementedException();
        }

        public void Call(int number)
        {
            Tuple<int,int> x = new Tuple<int, int>(TerminalNumber,number);
            Calling?.Invoke(x);
        }

        public void PutDownPhone()
        {
            throw new NotImplementedException();
        }
    }
}
