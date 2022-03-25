using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson2
{

    internal class BankAccount
    {/// <summary>
     /// номер счета
     /// </summary>
        private Guid accountNumber;
        private decimal balance;

        /// <summary>
        /// тип банковского счета
        /// </summary>
        private AccountType _accountType;

        private string nameUser;

        public string NameUser
        {
            get { return nameUser; }
            set { nameUser = value; }
        }
        public bool Transaction(BankAccount bankAccount, decimal money)
        {
            bool ToClientBalance =this.SpendMoney(money) > 0;
            if (ToClientBalance)
            {
                bankAccount.PutMoney(money);//кладем товарищу на счет
                return true;
            }
            return false;
        }



        public override string ToString()
        {
            return $"Клиент: {nameUser}" +
                $"Номер счета: {AccountNumber};" +
                $" Тип счета: {_accountType}; " +
                $"Остаток: {balance}.";
        }

        public Guid AccountNumber { 
            get
            {
                return accountNumber;
            }
            set
            {
                accountNumber = value;
            }

        }
        public decimal Balance
        {
            get { return balance; }
            set { balance = value; }
        }

        public BankAccount()
        {
            Balance = 0;
            _accountType = AccountType.Deposit;
          
        }

        public BankAccount(decimal bal,string User)
        {
            AccountNumber = Guid.NewGuid();
            Balance = bal;
            _accountType = AccountType.Deposit;
            NameUser = User;
        }

        public BankAccount(AccountType accountType)
        {
            AccountNumber = Guid.NewGuid();
            Balance = 0;
            _accountType = accountType;
        }

        public BankAccount(decimal balance, AccountType accountType,string User)
        {
            AccountNumber = Guid.NewGuid();
            Balance = balance;
            _accountType = accountType;
            NameUser = User;
        }
        /// <summary>
        /// потратить деньги
        /// </summary>
        public decimal SpendMoney(decimal money)
        {
            if (Balance < money) 
                return 0;
            Balance -= money;
            return money;
        }

        public void PutMoney(decimal money)
        {
            Balance += money;
        }

        
    }
}
