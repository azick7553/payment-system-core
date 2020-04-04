using System;
using System.Collections.Generic;
using System.Linq;

namespace payment_system
{
    class Program
    {
        static Customer[] CustArr;
        static void Main(string[] args)
        {
            MyStaticClass.ShowDateTimeByCustomFormat("dd/MM/yyyy");
            MyStaticClass.MyStaticField = "myStatic";
            bool working = true;
            while (working)
            {
                System.Console.Write("\n1.Создать счёт\n2.Список клиентов\n5.Выход\t\nChoice:");
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        {
                            if (CustArr != null)
                            {

                                CustArr = CreateCustomer();
                            }
                            else
                            {
                                CustArr = new Customer[0];
                                CustArr = CreateCustomer();
                            }
                        }; break;

                    case "2": ShowCustomers(); break;
                    case "5":
                        working = false;
                        break;
                }
            }
        }

        private static void ShowCustomers()
        {
            if (CustArr != null)
            {
                for (int i = 0; i < CustArr.Length; i++)
                {
                    if (CustArr[i] != null)
                    {
                        System.Console.WriteLine($"Id:{CustArr[i].Id}\nLastName:{CustArr[i].LastName}\nFistName:{CustArr[i].FirstName}\nMiddleName:{CustArr[i].MiddleName}");
                    }
                }
            }
        }

        public static Customer[] CreateCustomer()
        {
            int tempId = 0;
            if (CustArr != null)
            {
                for (int i = 0; i < CustArr.Length; i++)
                {
                    if (CustArr[i] != null)
                    {
                        if (tempId < CustArr[i].Id)
                        {
                            tempId = CustArr[i].Id;
                        }
                    }
                }
            }
            tempId++;
            System.Console.Write("LastName:");
            string lastName = Console.ReadLine();
            System.Console.Write("FirstName:");
            string firtName = Console.ReadLine();
            System.Console.Write("MiddleName:");
            string middleName = Console.ReadLine();
            Customer tempCustomer = new Customer()
            {
                Id = tempId,
                LastName = lastName,
                FirstName = firtName,
                MiddleName = middleName
            };
            var tempList = CustArr.ToList();//Convert ot List for adding new object
            tempList.Add(tempCustomer);//add new object into list
            return tempList.ToArray();//retrun List converted to Array
        }
    }
    /// <summary>
    /// Account for keep account information and payments
    /// </summary>
    class Account
    {
        public int Id { get; set; }
        public int CustId { get; set; }
        public string AccountNumber { get; set; }
        public Currency AccountCurrency { get; set; }
        public decimal AccountBalance { get; set; }
        public PaymentHistory AccountPaymentHistory { get; set; }

        /// <summary>
        /// Получаем баланс счета
        /// </summary>
        /// <returns>Баланс счета</returns>
        public decimal GetBalance()
        {
            return this.AccountBalance;
        }
        /// <summary>
        /// Получаем баланс счета на указанную дату
        /// </summary>
        /// <param name="balanceDate"></param>
        /// <returns>AccountBalance</returns>
        public decimal GetBalance(DateTime balanceDate)
        {
            return this.AccountBalance;
        }
    }

    class Customer
    {
        //TODO: Реализовать историю платежей клиента
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
        public int AcccountNumber { get; set; }
        public Currency PaymentCurrenct { get; set; }
        public decimal PaymantAmount { get; set; }
    }

    static class MyStaticClass
    {
        public static string MyStaticField { get; set; }

        public static void ShowDateTimeByCustomFormat(string format)
        {
            System.Console.WriteLine(DateTime.Now.ToString(format));
        }
    }

}
// Account acc1 = new Account() { Id = 1, AccountNumber = new Random().Next(1, 1000).ToString() };
// Account acc2 = new Account() { Id = 2, AccountNumber = new Random().Next(1, 1000).ToString() };
// Account acc3 = new Account() { Id = 3, AccountNumber = new Random().Next(1, 1000).ToString() };
// Currency currTjs = new Currency()
// {
//     Id = 1,
//     ShortName = "TJS"
// };
// Currency currUSD = new Currency()
// {
//     Id = 2,
//     ShortName = "USD"
// };

// acc1.AccountCurrency = currTjs;
// acc2.AccountCurrency = currTjs;
// acc3.AccountCurrency = currUSD;

// Customer cust1 = new Customer()
// {
//     Id = 1,
//     LastName = "Test",
//     FirstName = "Test",
//     MiddleName = "Test",
//     Accounts = new Account[] { acc1, acc2, acc3 }
// };

// if (cust1.Accounts != null)
// {
//     foreach (var custAccounts in cust1.Accounts)
//     {
//         System.Console.WriteLine($"Номер счета: {custAccounts.AccountNumber}\nВалюта счета:{custAccounts.AccountCurrency.ShortName}");
//     }
// }
// else
// {
//     System.Console.WriteLine("У клиента нету счетов!!!");
// }