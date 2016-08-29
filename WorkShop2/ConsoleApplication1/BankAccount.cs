using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class BankAccount
    {
        // Attribute
        string accountNumber, accountHolder;
        double balance;

        // Constructor
        public BankAccount(): this("000-000-000", "NO NAME", 0)
        {
        }

        public BankAccount(string accountNumber, string accountHolder, double balance)
        {
            this.accountNumber = accountNumber;
            this.accountHolder = accountHolder;
            this.balance = balance;
        }

        // Methods
        public string GetAccountNumber()
        {
            return accountNumber;
        }

        public string GetAccountHolder()
        {
            return accountHolder;
        }

        public double GetBalance()
        {
            return balance;
        }

        public void SetAccountNumber(string accountNumber)
        {
            this.accountNumber = accountNumber;
        }

        public void SetAccountHolder(string accountHolder)
        {
            this.accountHolder = accountHolder;
        }

        public void SetAccountNumber(double balance)
        {
            this.balance = balance;
        }

        public bool Withdraw(double amount)
        {
            bool isWithdrawSuccess = false;
            if (amount <= balance)
            {
                balance -= amount;
                isWithdrawSuccess = true;
            }
            else
            {
                Console.Error.WriteLine("Withdrawal for {0} is unsuccessful",
                   AccountHolder);
            }
            return isWithdrawSuccess;
        }

        public void Deposit(double amount)
        {
            balance += amount;
        }

        public bool TransferTo(double amount, BankAccount another)
        {
            bool isTransferToSuccess = false;
            if (Withdraw(amount))
            {
                // balance -= amount;
                // another.balance += amount;
                another.Deposit(amount);
                isTransferToSuccess = true;
            }
            else
            {
                Console.Error.WriteLine("TransferTo for {0} is unsuccessful",
                    AccountHolder);
            }
            return isTransferToSuccess;
        }

        public string Show()
        {
            string m = String.Format
                        ("[Account:accountNumber={0},accountHolder={1},balance={2}]",
                         AccountNumber, AccountHolder, Balance);
            return (m);
        }

        // Properties

        public string AccountNumber
        {
            get
            {
                return accountNumber;
            }
        }

        public string AccountHolder
        {
            get
            {
                return accountHolder;
            }
            set
            {
                accountHolder = value;
            }
        }

        public double Balance
        {
            get
            {
                return balance;
            }
        }
    }

    class BankTest
    {
        static void Main(string[] args)
        {
            BankAccount a = new BankAccount("001-001-001", "Tan Ah Kow", 2000);
            BankAccount b = new BankAccount("001-001-002", "Kim Keng Lee", 5000);
            Console.WriteLine(a.Show());
            Console.WriteLine(b.Show());
            a.Deposit(100);
            Console.WriteLine(a.Show());
            a.Withdraw(200);
            Console.WriteLine(a.Show());
            a.TransferTo(300, b);
            Console.WriteLine(a.Show());
            Console.WriteLine(b.Show());
        }
    }
}
