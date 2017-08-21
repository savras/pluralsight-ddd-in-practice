using System;
using System.Linq;
using static DddInPractice.Logic.Money;

namespace DddInPractice.Logic
{
    public sealed class SnackMachine : Entity
    {
        public Money MoneyInTransaction { get; private set; } = None;
        public Money MoneyInMachine { get; private set; } = None;

        public void ReturnMoney()
        {
            MoneyInTransaction = None;
        }

        public void InsertMoney(Money money)
        {
            var monies = new[]
            {
                OneCent,
                TenCent,
                Quarter,
                Dollar,
                FiveDollar,
                TwentyDollar
            };

            if (!monies.Contains(money))
            {
                throw new InvalidOperationException();
            }

            MoneyInTransaction += money;
        }

        public void BuySnack()
        {
            MoneyInMachine += MoneyInTransaction;
            MoneyInTransaction = None;
        }
    }
}
