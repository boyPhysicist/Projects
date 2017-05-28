using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BillingSystem.Interfaces;

namespace BillingSystem.Classes
{
    public class CallStatistic : ICallStatistic
    {
        public DateTime CallStart { get; }

        public DateTime CallStop { get; }
        public TimeSpan ConversationDuration { get; }
        public int TargetNumber { get; }

        public double CallCoast { get; }

        public CallStatistic(DateTime callStart, DateTime callStop, int targetNumber, double callCoast)
        {
            CallStart = callStart;
            CallStop = callStop;
            TargetNumber = targetNumber;
            CallCoast = callCoast;
            ConversationDuration = callStop.Subtract(CallStart);
        }
    }
}
