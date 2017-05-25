using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillingSystem.Interfaces
{
    public interface ISubscriber
    {
        string Name { get; }
        int Age { get; }
        int Id { get; }

    }
}
