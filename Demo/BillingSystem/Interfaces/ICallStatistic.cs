using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillingSystem.Interfaces
{
    public interface ICallStatistic
    {
        DateTime CallStart { get; }
        DateTime CallStop { get; }
        TimeSpan ConversationDuration { get; }
        int TargetNumber { get; }
        double CallCoast { get; }
    }
}
