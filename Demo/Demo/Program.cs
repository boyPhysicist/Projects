﻿using ATE.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using BillingSystem.Classes;

namespace Demo
{
    public class Program
    {
        static void Main(string[] args)
        {

            BillingSystem.Classes.BillingSystem billingSystem = new BillingSystem.Classes.BillingSystem();
            Contract contract1 = new Contract(1,new Subscriber("Name1",18,1),new BaseTariffPlan("Base",1,1,100) );
            Contract contract2 = new Contract(2, new Subscriber("Name2", 19, 2), new UnlimTariffPlan("Unlim",1000));
            Contract contract3 = new Contract(3, new Subscriber("Name3", 20, 3), new BaseTariffPlan("Base1", 2, 20, 100));
            Contract contract4 = new Contract(4, new Subscriber("Name4", 21, 4), new BaseTariffPlan("Base2", 3, 35, 100));
            billingSystem.AddUser(contract1);
            billingSystem.AddUser(contract2);
            billingSystem.AddUser(contract3);
            billingSystem.AddUser(contract4);
            Server server =new Server(billingSystem);
            Port port1 = new Port(server);
            Port port2 = new Port(server);
            Port port3 = new Port(server);
            Port port4 = new Port(server);
            port1.Connect();
            port2.Connect();
            port3.Connect();
            port4.Connect();
            Terminal terminal1 = new Terminal(contract1.GiveTerminalNumber(),port1);
            Terminal terminal2 = new Terminal(contract2.TerminalNumber,port2);
            Terminal terminal3 = new Terminal(contract3.TerminalNumber, port3);
            Terminal terminal4 = new Terminal(contract4.GiveTerminalNumber(), port4);




            server.AddContactPair(terminal1);
            server.AddContactPair(terminal2);
            server.AddContactPair(terminal3);
            server.AddContactPair(terminal4);

            terminal1.Call(100001);

            Console.WriteLine(terminal1.TerminalState.ToString());
            //terminal2.Answer();
            //Thread.Sleep(5000);
            //terminal2.PutDownPhone();
            //terminal1.Call(100003);
            //terminal3.Answer();
            //Thread.Sleep(3000);
            //terminal3.PutDownPhone();
            //Console.WriteLine(contract1.StatisticCalls.Count);
            Console.ReadLine();

        }
    }
}
