using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;

namespace Banking
{
    public class Customer
    {
        [PrimaryKey, AutoIncrement]
        public int CustomerId { get; set; }

        public string IdNumber { get; set; }
        public string ResidentialAddress { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
       
        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public List<BankAccount> BankAccounts { get; set; }

        [ForeignKey(typeof(Bank))]
        public int BankId { get; set; }

        [ManyToOne]
        public Bank Bank { get; set; }

        public Customer()
        {
            BankAccounts = new List<BankAccount>();
        }

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