using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillingSystem.Interfaces
{
    public interface ITariffPlan
    {
        double CalculateCallCost(Tuple<DateTime,DateTime> callTiming);
        double SubscriptionFee { get; set; }
        string Name { get; }
    }
}
