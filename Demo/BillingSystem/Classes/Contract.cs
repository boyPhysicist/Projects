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
        public ITariffPlan TariffPlan { get; }
        public IDictionary<DateTime, Tuple<DateTime, DateTime, double>> StatisticCalls { get; }
        

        public Contract(int id, ISubscriber subscriber, ITariffPlan tariffPlan)
        {
            Id = id;
            Subscriber = subscriber;
            TariffPlan = tariffPlan;
            StatisticCalls = new Dictionary<DateTime, Tuple<DateTime, DateTime, double>>();
            
        }
        public int GiveTerminalNumber()
        {
            return 100000 + Subscriber.Id;
        }
    }
}
