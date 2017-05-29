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
                item.Value.CashAccountChange(-MonthBill(item.Key,date.Month));
            }
        }

        public void ChangeTariffPlan(int number,ITariffPlan tariff)
        {
            BillSys[number].TariffPlanChange(tariff);
        }

        public IEnumerable<ICallStatistic> GetSortByCallTime(int number)
        {
            return BillSys[number]
                .StatisticCalls
                .AsEnumerable()
                .OrderBy(x => x.ConversationDuration);
        }

        public IEnumerable<ICallStatistic> GetSortByCallCoast(int number)
        {
            return BillSys[number]
                .StatisticCalls
                .AsEnumerable()
                .OrderBy(x => x.CallCoast);
        }

        public IEnumerable<ICallStatistic> GetDateCall(int year, int month, int day, int number)
        {
            return BillSys[number]
                .StatisticCalls
                .AsEnumerable()
                .Select(x => x)
                .Where(x => x.CallStart.Year == year
                            && x.CallStart.Month == month
                            && x.CallStart.Day == day);
        }

        public IEnumerable<ICallStatistic> GetByNumber(int number,int targetNumber)
        {
            return BillSys[number]
                .StatisticCalls
                .Select(x => x)
                .Where(x => x.TargetNumber == targetNumber);
        }

        public void CashAccountChange(int number, double summ)
        {
            BillSys[number].CashAccountChange(summ);
        }
    }
}
