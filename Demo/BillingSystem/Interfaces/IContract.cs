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
        double CashAccount { get; }
        void CashAccountChange(double summ);
        DateTime CreationDate { get; }
        ISubscriber Subscriber { get; }
        ITariffPlan TariffPlan { get; set; }
        void TariffPlanChange(ITariffPlan tarrPlan);
        ICollection<ICallStatistic> StatisticCalls { get; }
        void AddStatisticCalls(ICallStatistic callStatistic);
    }
}
