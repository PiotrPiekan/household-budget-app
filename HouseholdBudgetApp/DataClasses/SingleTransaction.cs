using System;
using System.Windows.Automation.Peers;
using System.Windows.Controls;

namespace HouseholdBudgetApp.DataClasses
{
    public class SingleTransaction
    {
        string name = string.Empty;
        float amount = 0.0f;
        DateTime date;
        string categories = string.Empty; //jeszcze do dopracowania
        public ConstantTransactionInfo info;


        public string getName()
        {
            return name;
        }

        public void setName(string value)
        {
            if (value.Length != 0) name = value;
        }

        public float getAmount()
        {
            return amount;
        }

        public void setAmount(float value)
        {
            if (value != 0) amount = value;
        }

        public DateTime getDate()
        {
            return date;
        }

        public string getCategories()
        {
            return categories;
        }
        public SingleTransaction(string n, float a, DateTime d, string c)
        {
            name = n;
            amount = a;
            date = d;
            categories = c;
        }

        public SingleTransaction CheckNextTransaction() //nie mam na to większego pomysłu XD
        {
            if (info.howMany > 0)
            {
                DateTime today = DateTime.Now;
                if (String.Compare(today.ToShortDateString(), date.AddDays(info.timeSpan).ToShortDateString()) == 0)
                {
                    SingleTransaction next = new SingleTransaction(name, amount, today, categories);
                    next.info.isConstant = true;
                    next.info.timeSpan = info.timeSpan;
                    next.info.howMany = info.howMany - 1;
                    info.howMany = 0;
                    return next;
                }
            }
            return null;
        }
    }

    public struct ConstantTransactionInfo
    {
        public bool isConstant { get; set; } = false; //czy transakcja się powtarza
        public int timeSpan { get; set; } = 0;        //co ile sie powtarza (zapisane w dniach)
        public int howMany { get; set; } = 0;         //ile razy się powtarza

        public ConstantTransactionInfo(bool isC, int tS, int hm)
        {
            isConstant = isC;
            timeSpan = tS;
            howMany = hm;
        }

        public string toString()
        {
            String s = isConstant.ToString() + " " + timeSpan.ToString() + " " + howMany.ToString();
            return s;
        }
    }
}
