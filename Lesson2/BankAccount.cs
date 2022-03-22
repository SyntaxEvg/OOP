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


        public override string ToString()
        {
            return $"Номер счета: {AccountNumber};" +
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

        public BankAccount(decimal bal)
        {
            AccountNumber = Guid.NewGuid();
            Balance = bal;
            _accountType = AccountType.Deposit;
        }

        public BankAccount(AccountType accountType)
        {
            AccountNumber = Guid.NewGuid();
            Balance = 0;
            _accountType = accountType;
        }

        public BankAccount(decimal balance, AccountType accountType)
        {
            AccountNumber = Guid.NewGuid();
            Balance = balance;
            _accountType = accountType;
        }
        /// <summary>
        /// потратить деньги
        /// </summary>
        /// <param name="money"></param>
        /// <returns></returns>
        public decimal SpendMoney(decimal money)
        {
            if (Balance < money) return 0;
            Balance -= money;
            return money;
        }

        public void PutMoney(decimal money)
        {
            Balance += money;
        }

        
    }
}
