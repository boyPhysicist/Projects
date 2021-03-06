﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BillingSystem.Interfaces;

namespace BillingSystem.Classes
{
    public class Contract:IContract
    {
        public int Id { get; }
        public ISubscriber Subscriber { get; }
        public ITariffPlan TariffPlan { get; set; }
        public ICollection<ICallStatistic> StatisticCalls { get; }
        public int TerminalNumber { get; }
        public double CashAccount { get; private set; }

        public DateTime CreationDate { get; private set; }

        public Contract(int id, ISubscriber subscriber, ITariffPlan tariffPlan)
        {
            Id = id;
            Subscriber = subscriber;
            TariffPlan = tariffPlan;
            StatisticCalls =new List<ICallStatistic>();
            TerminalNumber = GiveTerminalNumber();
            CashAccount = 0;
            CreationDate = DateTime.Now;
        }
        public int GiveTerminalNumber()
        {
            return 100000 + Subscriber.Id;
        }

        public void AddStatisticCalls(ICallStatistic callStatistic)
        {
            StatisticCalls.Add(callStatistic);
        }

        public IEnumerable<ICallStatistic> GetSortByCallTime()
        {
           return StatisticCalls
                .AsEnumerable()
                .OrderBy(x => x.ConversationDuration);
        }

        public IEnumerable<ICallStatistic> GetSortByCallCoast()
        {
            return StatisticCalls
                .AsEnumerable()
                .OrderBy(x => x.CallCoast);
        }

        public IEnumerable<ICallStatistic> GetDateCall(int year, int month, int day)
        {
            return StatisticCalls.AsEnumerable().Select(x => x)
                .Where(x => x.CallStart.Year == year 
                && x.CallStart.Month == month 
                && x.CallStart.Day == day);
        }

        public IEnumerable<ICallStatistic> GetByNumber(int number)
        {
            return StatisticCalls
                .Select(x => x)
                .Where(x => x.TargetNumber == number);
        }

        public void CashAccountChange(double summ)
        {
            CashAccount += summ;
        }

        public void TariffPlanChange(ITariffPlan tarrPlan)
        {
            if (CreationDate.Month == DateTime.Now.Month)
            {
                CreationDate = DateTime.Now;
                TariffPlan = tarrPlan;
            }
            
        }
    }
}
