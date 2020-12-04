using System;
using Xamarin.Forms;
using Banking;
using BankingXamarin.Services;

namespace BankingXamarin
{
    public partial class BankingPage : ContentPage
    {
        private BankAccount _account;
        private Customer _customer;


        private BankingDatabase _bankingDatabase;

        public BankingPage()
        {
            InitializeComponent();

            _bankingDatabase = new BankingDatabase();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();


            _customer = _bankingDatabase.GetCustomerByIdNumber("7766445424");
            _account = _bankingDatabase.GetCurrectAccount(_customer);

            DisplayTransactionsLabel.Text = _account.GetTransactionHistory();

        }

        private void DepositButton_Clicked(object sender, EventArgs e)
        {
            decimal depositAmount = 0;
            var valid = decimal.TryParse(DepositAmountEntry.Text, out depositAmount);
            var reason = DepositReasonEntry.Text;
            if (valid)
            {
                var trans = _account.DepositMoney(depositAmount, DateTime.Now, reason);

                _bankingDatabase.SaveTransaction(_account, trans);

                DisplayTransactionsLabel.Text = _account.GetTransactionHistory();

            }
            else
            {
                DisplayAlert("Validation Error", "Please Enter a Number", "Cancel");
            }

        }

        private void DisplayTransactionsButton_Clicked(object sender, EventArgs e)
        {
            var account = _bankingDatabase.GetCurrectAccount(_customer);
            Navigation.PushAsync(new TransactionsPage(account));
        }

        private void WithdrawButton_Clicked(object sender, EventArgs e)
        {
            decimal withdrawAmount = 0;
            var valid = decimal.TryParse(WithdrawAmountEntry.Text, out withdrawAmount);

            try
            {
                var reason = DepositReasonEntry.Text;
                if (valid)
                {
                    var trans = _account.WithdrawMoney(withdrawAmount, DateTime.Now, reason);

                    _bankingDatabase.SaveTransaction(_account, trans);

                    DisplayTransactionsLabel.Text = _account.GetTransactionHistory();

                }
                else
                {
                    DisplayAlert("Validation Error", "Please Enter a Number", "Cancel");
                }
            }
            catch(Exception ex)
            {
                DisplayAlert("Transaction Error", ex.Message, "Cancel");
            }
        }
    }
}
