using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATE.Interfaces
{
    public interface ITerminal
    {
        int TerminalNumber { get;}
        IPort Port { get; }
        void Call(int number);
        void PutDownPhone();
        void Answer();
    }
}
