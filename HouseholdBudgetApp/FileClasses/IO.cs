using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using HouseholdBudgetApp.DataClasses;
using Microsoft.Win32;

namespace HouseholdBudgetApp.FileClasses
{
    internal class IO
    {
        public string FilePath = "";

        public IO() { }

        public bool SelectFile(bool isSave)
        {
            FileDialog dialog;
            if (isSave)
            {
                dialog = new SaveFileDialog();
            }
            else
            {
                dialog = new OpenFileDialog();
            }

            dialog.FileName = "budżet";
            dialog.DefaultExt = ".txt";
            dialog.Filter = "Pliki tekstowe|*.txt";

            bool? result = dialog.ShowDialog();

            if (result == true)
            {
                FilePath = dialog.FileName;
            }
            
            // przekształcenie nullowalnego boola na nienullowalny
            return result.HasValue && result.Value;
        }

        public Account LoadData()
        {
            List<string> fileData = File.ReadAllLines(FilePath).ToList();

            string owner = fileData[0];
            fileData.RemoveAt(0);
            float saldo = float.Parse(fileData[0]);
            fileData.RemoveAt(0);

            Account account = new Account(owner);
            account.saldo = saldo;

            foreach (string line in fileData)
            {
                string[] data = line.Split(';');

                float amount = float.Parse(data[1]);
                DateTime date = DateTime.Parse(data[2]);

                SingleTransaction transaction = new SingleTransaction(data[0], amount, date, data[3]);

                transaction.info.isConstant = bool.Parse(data[4]);

                if (transaction.info.isConstant )
                {
                    transaction.info.timeSpan = int.Parse(data[5]);
                    transaction.info.howMany = int.Parse(data[6]);
                }

                if (amount < 0) account.setExpense(transaction);
                else account.setIncome(transaction);
            }

            return account;

        }

        public void SaveData(Account account)
        {
            List<string> toSave = new List<string>();

            toSave.Add(account.getOwner());
            toSave.Add(account.saldo.ToString());

            foreach (SingleTransaction expense in account.expense)
            {
                string s;
                s = expense.getName() + ";";
                s += expense.getAmount().ToString() + ";";
                s += expense.getDate().ToShortDateString() + ";";
                s += expense.getCategories().ToString() + ";";
                s += expense.info.isConstant.ToString() + ";";

                if (expense.info.isConstant)
                {
                    s += expense.info.timeSpan.ToString() + ";";
                    s += expense.info.howMany.ToString() + ";";
                }
                toSave.Add(s);
            }

            foreach (SingleTransaction income in account.income)
            {
                string s;
                s = income.getName() + ";";
                s += income.getAmount().ToString() + ";";
                s += income.getDate().ToShortDateString() + ";";
                s += income.getCategories().ToString() + ";";
                s += income.info.isConstant.ToString() + ";";

                if(income.info.isConstant) 
                {
                    s += income.info.timeSpan.ToString() + ";";
                    s += income.info.howMany.ToString() + ";";
                }

                toSave.Add(s);
            }

            File.WriteAllLines(FilePath, toSave);
        }
    }
}
