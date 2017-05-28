using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATE.Classes.Enums;

namespace ATE.Interfaces
{
    public interface IPort
    {
        PortState PortState { get;}
        PortState EconomyPortState { get;}
        void SendData(object obj, Tuple<int, int, DateTime, DateTime> data);

        void Connect();
        void Disconnect();
        void ConnectToServer(Tuple<int,int> param);
        void WhaitAnswer();
    }
}
