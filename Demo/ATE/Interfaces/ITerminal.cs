using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATE.Classes.Enums;

namespace ATE.Interfaces
{
    public interface ITerminal
    {
        int TerminalNumber { get;}
        TerminalState TerminalState { get; }
        IPort Port { get; }
        void Call(int number);
        void PutDownPhone();
        void Answer();
        void WaitAnswer(object server,int number);
    }
}
