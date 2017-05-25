using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BillingSystem.Interfaces;

namespace BillingSystem.Classes
{
    public class BaseTariffPlan : ITariffPlan
    {
        public string Name { get; }
        public double SubscriptionFee { get; set; }
        private readonly double _costPerTimeUnit;
        private readonly int _timeUnit;

        public BaseTariffPlan(string name, double costPerTimeUnit, int timeUnit, double subscriptionFee)
        {
            SubscriptionFee = subscriptionFee;
            Name = name;
            _costPerTimeUnit = costPerTimeUnit;
            _timeUnit = timeUnit;
        }

        public Tuple<DateTime, DateTime, double> CalculateCallCost(Tuple<DateTime,DateTime> callTiming)
        {
            double cost = (callTiming.Item2.Hour * 60 * 60 + callTiming.Item2.Minute * 60 + callTiming.Item2.Second)
                          * _costPerTimeUnit / _timeUnit;

            return new Tuple<DateTime, DateTime, double>(callTiming.Item1,callTiming.Item2,cost);
        }
    }
}
