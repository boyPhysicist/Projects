using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BillingSystem.Interfaces;

namespace BillingSystem.Classes
{
    public class SubFeeFreeTariffPlan : ITariffPlan
    {
        public string Name { get; }
        public double SubscriptionFee { get; set; }
        public readonly double CostPerTimeUnit;
        public readonly int TimeUnit;

        public SubFeeFreeTariffPlan(string name, double costPerTimeUnit)
        {
            SubscriptionFee = 0;
            Name = name;
            CostPerTimeUnit = costPerTimeUnit;
            TimeUnit = 60;
        }

        public double CalculateCallCost(Tuple<DateTime, DateTime> callTiming)
        {
            double cost = (callTiming.Item2.Hour * 60 * 60 + callTiming.Item2.Minute * 60 + callTiming.Item2.Second)
                          * CostPerTimeUnit / TimeUnit;
            if (cost <=0)
            {
                cost = CostPerTimeUnit;
            }

            return cost;
        }
    }
}
