﻿using System;
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

        public double CalculateCallCost(Tuple<DateTime,DateTime> callTiming)
        {
            double cost = Math.Ceiling((double)(callTiming.Item2.Hour * 60 * 60 + callTiming.Item2.Minute * 60 + callTiming.Item2.Second)/_timeUnit
                -(double)(callTiming.Item1.Hour * 60 * 60 + callTiming.Item1.Minute * 60 + callTiming.Item1.Second) / _timeUnit)*_costPerTimeUnit;


            return cost;
        }
    }
}
