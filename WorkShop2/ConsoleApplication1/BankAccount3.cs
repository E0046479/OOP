using System;
using System.Collections.Generic;
using System.Collections;
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

        // change virtual to be override
        public virtual bool Withdraw(double amount)
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

        public virtual double CalculateAnnualInterest()
        {
            return balance * (1 / 100);
        }

        public void CreditInterest()
        {
            Deposit(CalculateAnnualInterest());
        }

        // instead of Show() method used toString()
        //public virtual string Show()
        //{
        //    string m = String.Format
        //                ("[Account:accountNumber={0},accountHolder={1},balance={2}]",
        //                 AccountNumber, AccountHolder, Balance);
        //    return (m);
        //}

        public override string ToString()
        {
            string m = String.Format
                        ("{0}\t{1}\t{2}",
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

        // Redefine Code....
        //public new double CalculateAnnualInterest()
        //{
        //    return Balance * (0.25 / 100);
        //}

        //public new string Show()
        //{
        //    string m = String.Format
        //                ("[CurrentAccount:accountNumber={0},accountHolder={1},balance={2}]",
        //                 AccountNumber, AccountHolder, Balance);
        //    return (m);
        //}

        // Overriding using virtual and override in Polymorphisms
        public override double CalculateAnnualInterest()
        {
            return Balance * (0.25 / 100);
        }

        // Instead of Show() method used ToString()
        //public override string Show()
        //{
        //    string m = String.Format
        //                ("[CurrentAccount:accountNumber={0},accountHolder={1},balance={2}]",
        //                 AccountNumber, AccountHolder, Balance);
        //    return (m);
        //}

        public override string ToString()
        {
            string m = String.Format
                        ("{0}\t{1}\t{2}",
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

        // Redefine depend on Reference Variable....
        //public new bool Withdraw(double amount)
        //{
        //        Balance -= amount;
        //    return true;
        //}

        //public new double CalculateAnnualInterest()
        //{
        //    double result = 0;
        //    if (Balance > 0)
        //    {
        //        result = Balance * (positiveInterest / 100);
        //    }
        //    else
        //    {
        //        result = Balance * (negativeInterest / 100);
        //    }
        //    return result;
        //}

        //public new string Show()
        //{
        //    string m = String.Format
        //                 ("[OverdraftAccount:accountNumber={0},accountHolder={1},balance={2}]",
        //                  AccountNumber, AccountHolder.Show(), Balance);
        //    return (m);
        //}

        // Overriding using virtual and override in Polymorphisms

        public override bool Withdraw(double amount)
        {
            Balance -= amount;
            return true;
        }

        public override double CalculateAnnualInterest()
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

        // Instead of Show() used ToString()
        //public override string Show()
        //{
        //    string m = String.Format
        //                 ("[OverdraftAccount:accountNumber={0},accountHolder={1},balance={2}]",
        //                  AccountNumber, AccountHolder.Show(), Balance);
        //    return (m);
        //}

        public override string ToString()
        {
            string m = String.Format
                         ("{0}\t{1}\t{2}",
                          AccountNumber, AccountHolder, Balance);
            return (m);
        }
    }
    class Customer2
    {
        // Attribute
        string name, address, passportNumber;
        int age;
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

        //public string Show()
        //{
        //    string m = String.Format
        //         ("[Customer:name={0},address={1},passport={2},age={3}]",
        //                  name, address, passportNumber, Age);
        //    return (m);
        //}

        public override string ToString()
        {
            return string.Format("{0}\t{1}\t{2}\t{3}", name, address, passportNumber, Age);
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


    class BankBranch { 

        // Attributes
        string branchName, branchManager;
        List<BankAccount3> bankAccounts = new List<BankAccount3>();

        // Constructors
        public BankBranch() : this("","")
        {

        }

        public BankBranch(string branchName, string branchManager)
        {
            this.branchName = branchName;
            this.branchManager = branchManager;
        }

        // Accessor And Mutator
        public string GetBranchName (){
            return branchName;
        }

        public string GetBranchManager(){
            return branchManager;
        }
        
        public List<BankAccount3> GetBankAccounts(){
            return bankAccounts;
        }

        public void SetBranchName (string branchName){
            this.branchName = branchName;
        }

        public void SetBranchManager(string branchManager){
            this.branchManager = branchManager;
        }
        
        public void SetBankAccounts(List<BankAccount3> bankAccounts){
            this.bankAccounts = bankAccounts;
        }

        // Methods

        public void AddAccount(BankAccount3 bankAccount){
            bankAccounts.Add(bankAccount);
        }

        public void PrintCustomers(){
            List<Customer2> customerList = new List<Customer2>();
            for (int i = 0; i < bankAccounts.Count; i++)
            {
                Customer2 customer = bankAccounts[i].AccountHolder;
                if (customerList.IndexOf(customer) < 0)
                {
                    customerList.Add(customer);
                }
            }
            Console.WriteLine("Customer Name\tAddress\t\tPassport\tAge");
            foreach (Customer2 customer in customerList){
                Console.WriteLine(string.Format("{0}\t{1}\t{2}\t\t{3}",customer.Name, customer.Address, customer.PassportNumber, customer.Age));
            }
        }

        public double TotalDeposits(){
            double totalDeposits = 0;
            for (int i = 0; i < bankAccounts.Count; i++)
            {
                if (bankAccounts[i].Balance > 0)
                {
                    totalDeposits += bankAccounts[i].Balance;
                }
            }
            return totalDeposits;
        }

        public double TotalInterestPaid(){
            double totalInterest = 0;
            for(int i=0; i<bankAccounts.Count; i++){
                double interest = bankAccounts[i].CalculateAnnualInterest();
                if(interest > 0){
                    totalInterest += interest;
                }
            }
            return totalInterest;
        }

        public double TotalInterestEarned(){
            double totalInterest = 0;
            for(int i=0; i<bankAccounts.Count; i++){
                double interest = bankAccounts[i].CalculateAnnualInterest();
                if(interest < 0){
                    totalInterest += (-interest);
                }
            }
            return totalInterest;
        }

        public void CreditInterest()
        {
            for (int i = 0; i < bankAccounts.Count; i++)
            {
                bankAccounts[i].CreditInterest();
            }
        }
        public void PrintAccounts()
        {
            Console.WriteLine("AccountNumber\tName\t\tAddress\t\tPassport Age\tBalance");
            for (int i = 0; i < bankAccounts.Count; i++)
                Console.WriteLine(bankAccounts[i]);
        }
    }
    

    class BankTest3
    {
        public static void Main(string[] args)
        {
            //Customer2 cus1 = new Customer2("Tan Ah Kow", "2 Rich Street",
            //                          "P123123", 20);
            //Customer2 cus2 = new Customer2("Kim May Mee", "89 Gold Road",
            //                          "P334412", 60);

            // Redefine depend on reference variables....

            //BankAccount3 a1 = new BankAccount3("S0000223", cus1, 2000);
            //Console.WriteLine(a1.CalculateAnnualInterest());
            //OverDraftAccount a2 = new OverDraftAccount("O1230124", cus1, 2000);
            //Console.WriteLine(a2.CalculateAnnualInterest());
            //CurrentAccount a3 = new CurrentAccount("C1230125", cus2, 2000);
            //Console.WriteLine(a3.CalculateAnnualInterest());

            // Override method
            //BankAccount3 a1 = new BankAccount3("S0000223", cus1, 2000);
            //Console.WriteLine(a1.CalculateAnnualInterest());

            //BankAccount3 a2 = new OverDraftAccount("O1230124", cus1, 2000);
            //Console.WriteLine(a2.CalculateAnnualInterest());

            //BankAccount3 a3 = new CurrentAccount("C1230125", cus2, 2000);
            //Console.WriteLine(a3.CalculateAnnualInterest());

            //... For Workshop 5 ...
            BankBranch branch = new BankBranch("KOKO Bank Branch",
                                              "Tan Mon Nee");
            Customer2 cus1 = new Customer2("Tan Ah Kow", "2 Rich Street",
                                      "P345123", 40);
            Customer2 cus2 = new Customer2("Lee Tee Kim", "88 Fatt Road",
                                      "P678678", 54);
            Customer2 cus3 = new Customer2("Alex Gold", "91 Dream Cove",
                                      "P333221", 34);
            branch.AddAccount(new BankAccount3("S1230123", cus1, 2000));
            branch.AddAccount(new OverDraftAccount("O1230124", cus1, 2000));
            branch.AddAccount(new CurrentAccount("C1230125", cus2, 2000));
            branch.AddAccount(new OverDraftAccount("O1230126", cus3, -2000));
            branch.PrintCustomers();
            branch.PrintAccounts();
            Console.WriteLine(branch.TotalInterestEarned());
            Console.WriteLine(branch.TotalInterestPaid());
            branch.CreditInterest();
            branch.PrintAccounts();

        }
    }
}
