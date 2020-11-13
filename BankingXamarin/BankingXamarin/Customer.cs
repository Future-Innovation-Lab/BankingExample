using System;
using System.Collections.Generic;

namespace Banking
{
    public class Customer
    {
        public string IdNumber { get; set; }
        public string ResidentialAddress { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public List<BankAccount> BankAccounts { get; set; }

        public Customer(string idNumber, string address, string firstName, string lastName)
        {
            IdNumber = idNumber;
            ResidentialAddress = address;
            FirstName = firstName;
            LastName = lastName;

            BankAccounts = new List<BankAccount>();

        }

        public BankAccount ApplyForBankAccount()
        {
            BankAccount bankAccount = new BankAccount();
            BankAccounts.Add(bankAccount);

            return bankAccount;
        }
    }
}