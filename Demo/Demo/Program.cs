using ATE.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;

namespace Demo
{
    public class Program
    {
        static void Main(string[] args)
        {
            Server server =new Server();
            Port port1 = new Port(server);
            Port port2 = new Port(server);
            port1.Connect();
            port2.Connect();
            Terminal terminal1 = new Terminal(123456,port1);
            Terminal terminal2 = new Terminal(123457,port2);
            server.AddContactPair(terminal1);
            server.AddContactPair(terminal2);

            terminal1.Call(123457);

            Console.ReadLine();

        }
    }
}
