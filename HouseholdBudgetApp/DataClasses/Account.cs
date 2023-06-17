using System.Collections.Generic;

namespace HouseholdBudgetApp.DataClasses
{
    public class Account
    {
        private string owner = string.Empty;
        public float saldo = 0;
        public List<SingleTransaction> income = new List<SingleTransaction>();
        public List<SingleTransaction> expense = new List<SingleTransaction>();

        public string getOwner()
        {
            return owner;
        }

        public void setIncome(SingleTransaction transaction)
        {
            income.Add(transaction);
            saldo += transaction.getAmount();
        }

        public void setExpense(SingleTransaction transaction)
        {
            expense.Add(transaction);
            saldo += transaction.getAmount();
        }

        public Account(string o) { owner = o; }

        public float CalculateSaldo()   //do przeliczania od nowa w razie potrzeby xD
        {
            float calculated = 0.0f;
            foreach (SingleTransaction transaction in income) calculated += transaction.getAmount();
            foreach (SingleTransaction transaction in expense) calculated -= transaction.getAmount();
            return calculated;
        }

        public void CheckNextConstantTransactions() //nie wiem gdzie dokładnie to wywołać xD
        {
            foreach(SingleTransaction transaction in income) 
            { 
                if(transaction.info.isConstant)
                {
                    SingleTransaction next = transaction.CheckNextTransaction();
                    if(next!=null) setIncome(next);
                }
            }

            foreach (SingleTransaction transaction in expense)
            {
                if (transaction.info.isConstant)
                {
                    SingleTransaction next = transaction.CheckNextTransaction();
                    if(next!=null) setExpense(next);
                }
            }
        }

    }
}
