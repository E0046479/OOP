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
        public BankAccount()
        {
            accountNumber = null;
            accountHolder = null;
            balance = 0;
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

        public void Withdraw(double amount)
        {
            if (amount <= balance)
            {
                balance -= amount;
            }
        }

        public void Deposit(double amount)
        {
            balance += amount;
        }

        public void TransferTo(double amount, BankAccount another)
        {
            if (balance >= amount)
            {
                balance -= amount;
                another.balance += amount;
            }
        }

        public double Show()
        {
            return balance;
        }

        // Properties

        public string AccountNumber
        {
            get
            {
                return accountNumber;
            }
            set
            {
                accountNumber = value;
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
            set
            {
                balance = value;
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
