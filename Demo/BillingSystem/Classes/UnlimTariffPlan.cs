using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BillingSystem.Interfaces;

namespace BillingSystem.Classes
{
    public class UnlimTariffPlan : ITariffPlan
    {
        public double SubscriptionFee { get; set; }

        public string Name { get; }

        public UnlimTariffPlan(string name, double subscriptionFee)
        {
            Name = name;
            SubscriptionFee = subscriptionFee;
        }

        public double CalculateCallCost(Tuple<DateTime, DateTime> callTiming)
        {
            return 0;
        }
    }
}
