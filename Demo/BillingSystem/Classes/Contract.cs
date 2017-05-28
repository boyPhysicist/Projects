using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BillingSystem.Interfaces;

namespace BillingSystem.Classes
{
    public class Contract:IContract
    {
        public int Id { get; }
        public ISubscriber Subscriber { get; }
        public ITariffPlan TariffPlan { get; set; }
        public ICollection<ICallStatistic> StatisticCalls { get; }
        public readonly int TerminalNumber;

        public Contract(int id, ISubscriber subscriber, ITariffPlan tariffPlan)
        {
            Id = id;
            Subscriber = subscriber;
            TariffPlan = tariffPlan;
            StatisticCalls =new List<ICallStatistic>();
            TerminalNumber = GiveTerminalNumber();

        }
        public int GiveTerminalNumber()
        {
            return 100000 + Subscriber.Id;
        }

        public void AddStatisticCalls(ICallStatistic callStatistic)
        {
            StatisticCalls.Add(callStatistic);
        }
    }
}
