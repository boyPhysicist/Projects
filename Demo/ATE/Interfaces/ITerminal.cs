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
        IPort Port { get; }
        TerminalStates State { get; }
        void Connect(IPort port);

    }
}
