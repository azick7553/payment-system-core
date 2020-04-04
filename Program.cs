using System;

namespace payment_system
{
    class Program
    {
        static void Main(string[] args)
        {
            Account acc1 = new Account() { Id = 1, AccountNumber = new Random().Next(1, 1000).ToString() };
            Account acc2 = new Account() { Id = 2, AccountNumber = new Random().Next(1, 1000).ToString() };
            Account acc3 = new Account() { Id = 3, AccountNumber = new Random().Next(1, 1000).ToString() };
            Currency currTjs = new Currency()
            {
                Id = 1,
                ShortName = "TJS"
            };
            Currency currUSD = new Currency()
            {
                Id = 2,
                ShortName = "USD"
            };

            acc1.AccountCurrency = currTjs;
            acc2.AccountCurrency = currTjs;
            acc3.AccountCurrency = currUSD;

            Customer cust1 = new Customer()
            {
                Id = 1,
                LastName = "Test",
                FirstName = "Test",
                MiddleName = "Test",
                Accounts = new Account[] { acc1, acc2, acc3 }
            };

            if (cust1.Accounts != null)
            {
                foreach (var custAccounts in cust1.Accounts)
                {
                    System.Console.WriteLine($"Номер счета: {custAccounts.AccountNumber}\nВалюта счета:{custAccounts.AccountCurrency.ShortName}");
                }
            }
            else
            {
                System.Console.WriteLine("У клиента нету счетов!!!");
            }




        }
    }
    class Account
    {
        public int Id { get; set; }
        public string AccountNumber { get; set; }
        public Currency AccountCurrency { get; set; }
        public decimal AccountBalance { get; set; }
        public PaymentHistory AccountPaymentHistory { get; set; }
    }

    class Customer
    {
        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public Account[] Accounts { get; set; }
    }

    class Currency
    {
        public int Id { get; set; }
        public string ShortName { get; set; }
    }
    class PaymentHistory
    {
        public int Id { get; set; }
        public Currency PaymentCurrenct { get; set; }
        public decimal PaymantAmount { get; set; }
    }


}
