using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class BankAccount3
    {
         // Attribute
        string accountNumber;
        Customer2 accountHolder;
        double balance;

        // Constructor
        public BankAccount3(): this("000-000-000", new Customer2(), 0)
        {
        }

        public BankAccount3(string accountNumber, Customer2 accountHolder, double balance)
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

        public Customer2 GetAccountHolder()
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

        public void SetAccountHolder(Customer2 accountHolder)
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

        public bool TransferTo(double amount, BankAccount3 another)
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

        public double CalculateAnnualInterest()
        {
            return balance * (1 / 100);
        }

        public void CreditInterest()
        {
            Deposit(CalculateAnnualInterest());
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

        public Customer2 AccountHolder
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
            protected set
            {
                balance = value;
            }
        }
    }

    class CurrentAccount : BankAccount3
    {
        public CurrentAccount(string accountNumber, Customer2 accountHolder, double balance):base(accountNumber, accountHolder, balance){

        }

        public new double CalculateAnnualInterest()
        {
            return Balance * (0.25 / 100);
        }

        public string Show()
        {
            string m = String.Format
                        ("[CurrentAccount:accountNumber={0},accountHolder={1},balance={2}]",
                         AccountNumber, AccountHolder, Balance);
            return (m);
        }
    }

    class OverDraftAccount : BankAccount3
    {
        static double positiveInterest = 0.25, negativeInterest = 6;
        public OverDraftAccount(string accountNumber, Customer2 accountHolder, double balance)
            : base(accountNumber, accountHolder, balance)
        {

        }

        public new bool WithDraw(double amount)
        {
                Balance -= amount;
            return true;
        }

        public new double CalculateAnnualInterest()
        {
            double result = 0;
            if (Balance > 0)
            {
                result = Balance * (positiveInterest / 100);
            }
            else
            {
                result = Balance * (negativeInterest / 100);
            }
            return result;
        }

        public string Show()
        {
            string m = String.Format
                         ("[OverdraftAccount:accountNumber={0},accountHolder={1},balance={2}]",
                          AccountNumber, AccountHolder.Show(), Balance);
            return (m);
        }
    }
    class Customer2
    {
        // Attribute
        string name, address, passportNumber;
        DateTime dateOfBirth;

        // Constructors
        public Customer2()
        {
            name = null;
            address = null;
            passportNumber = null;
            dateOfBirth = new DateTime();
        }

        public Customer2(string name, string address, string passportNumber)
        {
            this.name = name;
            this.address = address;
            this.passportNumber = passportNumber;
        }

        public Customer2(string name, string address, string passportNumber, DateTime dateOfBirth)
        {
            this.name = name;
            this.address = address;
            this.passportNumber = passportNumber;
            this.dateOfBirth = dateOfBirth;
        }

        public Customer2(string name, string address, string passportNumber, int age)
            : this(name, address, passportNumber)
        {
            this.dateOfBirth = new DateTime(DateTime.Now.Year-age,1,1);
        }

        // Method

        public int GetAge()
        {
            return DateTime.Now.Year - dateOfBirth.Year;
        }

        public string Show()
        {
            string m = String.Format
                 ("[Customer:name={0},address={1},passport={2},age={3}]",
                          name, address, passportNumber, Age);
            return (m);
        }

        // Properties
        public string Name
        {
            get
            {
                return name;
            }
        }

        public string Address
        {
            get
            {
                return address;
            }
            set
            {
                address = value;
            }
        }

        public string PassportNumber
        {
            get
            {
                return passportNumber;
            }
            set
            {
                passportNumber = value;
            }
        }

        public int Age
        {
            get
            {
                return DateTime.Now.Year - dateOfBirth.Year;
            }
        }
    }

    

    

    class BankTest3
    {
        public static void Main(string[] args)
        {
            Customer2 cus1 = new Customer2("Tan Ah Kow", "2 Rich Street",
                                      "P123123", 20);
            Customer2 cus2 = new Customer2("Kim May Mee", "89 Gold Road",
                                      "P334412", 60);

            BankAccount3 a1 = new BankAccount3("S0000223", cus1, 2000);
            Console.WriteLine(a1.CalculateAnnualInterest());
            OverDraftAccount a2 = new OverDraftAccount("O1230124", cus1, 2000);
            Console.WriteLine(a2.CalculateAnnualInterest());
            CurrentAccount a3 = new CurrentAccount("C1230125", cus2, 2000);
            Console.WriteLine(a3.CalculateAnnualInterest());
        }
    }
}
