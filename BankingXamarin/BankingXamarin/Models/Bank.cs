using SQLite;
using SQLiteNetExtensions.Attributes;
using System.Collections.Generic;

namespace Banking
{
    public class Bank
    {
        [PrimaryKey, AutoIncrement]
        public int BankId { get; set; }

        public string BankName { get; set; }
        public int BranchCode { get; set; }
        public string BranchName { get; set; }

        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public List<Customer> BankingCustomers { get; set; }

        public Bank()
        {
            BankingCustomers = new List<Customer>();
        }

        public Bank(string bankName, int branchCode, string branchName)
        {
            BankName = bankName;
            BranchCode = branchCode;
            BranchName = branchName; 

            BankingCustomers = new List<Customer>();   
        }

        public void AddCustomer(Customer customer)
        {
            BankingCustomers.Add(customer);
        }
    }
}