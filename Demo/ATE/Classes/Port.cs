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
        public PortState PortState { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public PortState EconomyPortState => throw new NotImplementedException();

        public void Connect()
        {
            throw new NotImplementedException();
        }

        public void Disconnect()
        {
            throw new NotImplementedException();
        }
    }
}
