using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseholdBudgetApp.DataClasses
{
    class Category
    {
        private int _id;
        private string _name;
        private double _monthlyLimit;
        private double _yearlyLimit;
        public int Id { get; set; }
        public string Name { get; set; }
        public double MonthlyLimit { get; set; }
        public double YearlyLimit { get; set; }

        public Category()
        {

        }
    }
}
