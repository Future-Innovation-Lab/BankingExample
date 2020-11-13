using System;

namespace Banking
{
    public class Transaction
    {
        public decimal Amount {get;set;}
        public string Description {get;set;}
        public DateTime TransactionDate {get;set;}
    
        public Transaction(decimal amount, DateTime date, string description)
        {
         Amount = amount;
         TransactionDate = date;
         Description = description;
        }
    }
}