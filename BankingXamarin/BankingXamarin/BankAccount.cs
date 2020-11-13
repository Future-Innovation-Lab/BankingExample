using System;
using System.Collections.Generic;
using System.Text;

namespace Banking
{
    public class BankAccount
    {
        private static int LastAccountNumber = 6000;

        public int AccountNumber { get; set; }

        public decimal Balance
        {
            get
            {
                decimal tempBalance = 0;

                for(int count = 0; count < Transactions.Count;count++)
                {
                    Transaction transaction = Transactions[count];
                    tempBalance += transaction.Amount;
                }

                return tempBalance;
            }

        }

        public List<Transaction> Transactions { get; set; }

        public BankAccount()
        {
            AccountNumber = LastAccountNumber++;

            Transactions = new List<Transaction>();
        }

        public void DepositMoney(decimal amount, DateTime date, string description)
        {
            Transaction transaction = new Transaction(amount, date, description);

            Transactions.Add(transaction);
        }
        public void WithdrawMoney(decimal amount, DateTime date, string description)
        {
            if (Balance - amount < 0)
                throw new InvalidOperationException("Insuffienct Funds");    

            Transaction transaction = new Transaction(-amount, date, description);

            Transactions.Add(transaction);
        }

        public string GetTransactionHistory()
        {
            StringBuilder sb = new StringBuilder();

            foreach(var transaction in Transactions)
            {
                string lineItem = Balance + "   " + transaction.Amount + "   " + transaction.TransactionDate.ToString() + "   " + transaction.Description ;
                sb.AppendLine(lineItem);
            }

            return sb.ToString();
        }
    }
}