using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseholdBudgetApp.DataClasses
{
    public class Category
    {
        private static int s_nextId = 1;

        public int Id { get; }
        public string Name { get; }
        public bool MonthlyLimitEnabled { get; }
        public bool YearlyLimitEnabled { get; }
        public double MonthlyLimit { get; }
        public double YearlyLimit { get; }

        public Category(
            string name,
            bool monthlyLimitEnabled,
            bool yearlyLimitEnabled,
            double monthlyLimit,
            double yearlyLimit
        )
        {
            Id = s_nextId++;
            Name = name;
            MonthlyLimitEnabled = monthlyLimitEnabled;
            YearlyLimitEnabled = yearlyLimitEnabled;
            MonthlyLimit = monthlyLimit;
            YearlyLimit = yearlyLimit;
        }
    }
}
