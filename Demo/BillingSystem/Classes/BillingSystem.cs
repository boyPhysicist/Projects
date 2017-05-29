using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BillingSystem.Interfaces;

namespace BillingSystem.Classes
{
    public class BillingSystem
    {
        private IDictionary<int, IContract> BillSys { get; }
        
        public BillingSystem()
        {
            BillSys = new Dictionary<int, IContract>();
            
        }

        public void AddUser(IContract contract)
        {
            BillSys.Add(contract.GiveTerminalNumber(),contract);
            
        }

        public void AddData(Tuple<int, int, DateTime, DateTime> data)
        {
            BillSys[data.Item1].AddStatisticCalls(new CallStatistic(data.Item3,data.Item4,data.Item2,
                BillSys[data.Item1].TariffPlan.CalculateCallCost(new Tuple<DateTime, DateTime>(data.Item3,data.Item4))));
        }

        public double InvoiceForCalls(ICollection<ICallStatistic> statistics, int month)
        {
            return statistics.Where(x => x.CallStart.Month == month).Select(x => x.CallCoast).Sum();
        }

        public double MonthBill(int telephoneNumber,int month)
        {
            return InvoiceForCalls(BillSys[telephoneNumber].StatisticCalls, month) +
                   BillSys[telephoneNumber].TariffPlan.SubscriptionFee;
        }

        public void DebitFromAccounts(DateTime date)
        {
            foreach (var item in BillSys)
            {
                item.Value.CashAccountChange(MonthBill(item.Key,date.Month));
            }
        }
    }
}
