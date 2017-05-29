using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using ATE.Classes.Enums;
using ATE.Interfaces;

namespace ATE.Classes
{
    public class Server:IServer
    {
        private  BillingSystem.Classes.BillingSystem BillingSystem { get; }
        public IDictionary<IPort,ITerminal> ServerLib { get; }
        public event EventHandler<int> CallHandlerEvent;
        public delegate void DataSender(Tuple<int, int, DateTime, DateTime> data);
        public event DataSender DataSendEvent;
        public Server(BillingSystem.Classes.BillingSystem billingSystem)
        {
            BillingSystem = billingSystem;
            ServerLib = new Dictionary<IPort, ITerminal>();
            DataSendEvent += BillingSystem.AddData;
        }
        public void AddContactPair(ITerminal terminal)
        {
            ServerLib.Add(terminal.Port,terminal);
        }
        public void CallHandler(Tuple<int, int> info)
        {
            try
            {
                var targetPort = ServerLib
                    .Where(x => x.Value.TerminalNumber == info.Item2)
                    .Select(x => x.Key)
                    .ElementAt(0);
                if (targetPort.PortState == (PortState.Connected | PortState.FreeToCall))
                {
                    targetPort.WhaitAnswer();
                    CallHandlerEvent += ServerLib[targetPort].WaitAnswer;
                    CallHandlerEvent?.Invoke(this, info.Item1);
                    CallHandlerEvent -= ServerLib[targetPort].WaitAnswer;
                }
                else
                {
                    CallHandlerEvent +=
                        ServerLib[
                                ServerLib.Where(x => x.Value.TerminalNumber == info.Item1)
                                    .Select(x => x.Key)
                                    .ElementAt(0)]
                            .PutDownPhone;
                    CallHandlerEvent?.Invoke(this, info.Item1);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("error in number!!!");
                ServerLib.Where(x => x.Value.TerminalNumber == info.Item1).ElementAt(0).Value
                    .PutDownPhone(this, info.Item1);
            }

            
        }

        public void CreateDataForBillingSys(Tuple<int, int, DateTime, DateTime> data)
        {
            ServerLib.Where(x => x.Value.TerminalNumber == data.Item1).ElementAt(0).Value.PutDownPhone(this, data.Item1);
            ServerLib.Where(x => x.Value.TerminalNumber == data.Item2).ElementAt(0).Value.PutDownPhone(this, data.Item2);

            DataSendEvent?.Invoke(data);
        }

    }
}
