using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class BankAccount2
    {
         // Attribute
        string accountNumber, accountHolder;
        double balance;

        // Constructor
        public BankAccount2()
        {
            accountNumber = null;
            accountHolder = null;
            balance = 0;
        }

        public BankAccount2(string accountNumber, string accountHolder, double balance)
        {
            this.accountNumber = accountNumber;
            this.accountHolder = accountHolder;
            this.balance = balance;
        }

        public BankAccount2(string accountNumber, Customer customer, double balance)
        {
            this.accountNumber = accountNumber;
            this.customer = customer;
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

        public void TransferTo(double amount, BankAccount2 another)
        {
            if (balance >= amount)
            {
                balance -= amount;
                another.Balance += amount;
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

    class Customer
    {
        // Attribute
        string name, address, passportNumber;
        DateTime dateOfBirth;

        // Constructors
        public Customer()
        {
            name = null;
            address = null;
            passportNumber = null;
            dateOfBirth = new DateTime();
        }

        public Customer(string name, string address, string passportNumber, DateTime dateOfBirth)
        {
            this.name = name;
            this.address = address;
            this.passportNumber = passportNumber;
            this.dateOfBirth = dateOfBirth;
        }

        // Method

        public string GetAge()
        {
            return this.passportNumber.Substring(0,2);
        }
    }

    class BankTest2
    {
        public static void Main(string[] args)
        {
            Customer y = new Customer("Tan Ah Kow", "20, Seaside Road", "XXX20", new DateTime(1989, 10, 11));
            Customer z = new Customer("Kim Lee Keng", "2, Rich View", "XXX9F", new DateTime(1993, 4, 25));
            BankAccount2 a = new BankAccount2("001-001-001", y, 2000);
            BankAccount2 b = new BankAccount2("001-001-002", z, 5000);
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
