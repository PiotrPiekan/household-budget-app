using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseholdBudgetApp.DataClasses
{
    class Transaction
    {
        public int Id { get; }
        public string Name { get; }
        public int CategoryId { get; }
        public double Value { get; }
        public DateTime Date { get; }
        public bool IsRepeating { get; }
        public short RepeatIntervalAmount { get; }
        public short RepeatIntervalType { get; }
        public short RepeatCount { get; }
        public Transaction(
            int id,
            string name,
            int categoryId,
            double amount,
            DateTime date,
            bool isRepeating,
            short repeatIntervalAmount,
            short repeatIntervalType,
            short repeatCount
        )
        {
            Id = id;
            Name = name;
            CategoryId = categoryId;
            Value = amount;
            Date = date;
            IsRepeating = isRepeating;
            RepeatIntervalAmount = repeatIntervalAmount;
            RepeatIntervalType = repeatIntervalType;
            RepeatCount = repeatCount;
        }

        public bool Conflicts(Transaction transaction)
        {
            return transaction.Name == Name;
        }
    }
}
