using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Banking
{
    public class BankAccount
    {
        [PrimaryKey, AutoIncrement]
        public int BankAccountId { get; set; }

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

        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public List<Transaction> Transactions { get; set; }


        [ForeignKey(typeof(Customer))] public int CustomerId { get; set; }

        public BankAccount()
        {
            AccountNumber = LastAccountNumber++;

            Transactions = new List<Transaction>();
        }

        public Transaction DepositMoney(decimal amount, DateTime date, string description)
        {
            Transaction transaction = new Transaction(amount, date, description);

            Transactions.Add(transaction);

            return transaction;
        }
        public Transaction WithdrawMoney(decimal amount, DateTime date, string description)
        {
            if (Balance - amount < 0)
                throw new InvalidOperationException("Insuffienct Funds");    

            Transaction transaction = new Transaction(-amount, date, description);

            Transactions.Add(transaction);

            return transaction;
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