using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillingSystem.Interfaces
{
    public interface IContract
    {
        
        int Id { get; }
        int GiveTerminalNumber();
        ISubscriber Subscriber { get; }
        ITariffPlan TariffPlan { get; set; }
        ICollection<ICallStatistic> StatisticCalls { get; }
        void AddStatisticCalls(ICallStatistic callStatistic);
    }
}
