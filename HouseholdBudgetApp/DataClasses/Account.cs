using HouseholdBudgetApp.Exceptions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseholdBudgetApp.DataClasses
{
    public class Account
    {
        private double _startingBalance;
        private List<Transaction> _transactionList;
        public ObservableCollection<SingleTransaction> SingleTransactionList { get; }
        public ObservableCollection<Category> CategoryList;

        public Account()
        {
            _transactionList = new List<Transaction>();
            SingleTransactionList = new ObservableCollection<SingleTransaction>();
            CategoryList = new ObservableCollection<Category>();
            FillCategoryList();
            _startingBalance = 0;
        }

        public void AddTransaction(Transaction newTransaction)
        {
            foreach (var transaction in _transactionList)
            {
                if (newTransaction.Conflicts(transaction))
                {
                    throw new ExistingTransactionException();
                }
            }
            _transactionList.Add(newTransaction);
        }

        private void FillCategoryList()
        {
            CategoryList.Add(new Category("Jedzenie", false, false, 0, 0));
            CategoryList.Add(new Category("Rachunki", false, false, 0, 0));
            CategoryList.Add(new Category("Rozrywka", false, false, 0, 0));
            CategoryList.Add(new Category("Praca", false, false, 0, 0));
            CategoryList.Add(new Category("Inne", false, false, 0, 0));
        }
    }
}
