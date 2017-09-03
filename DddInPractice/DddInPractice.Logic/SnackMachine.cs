using System;
using System.Collections.Generic;
using System.Linq;
using static DddInPractice.Logic.Money;

namespace DddInPractice.Logic
{
    public sealed class SnackMachine : Entity
    {
        public Money MoneyInTransaction { get; private set; }
        public Money MoneyInMachine { get; private set; }
        public IList<Slot> Slots { get; private set; }

        public SnackMachine()
        {
            MoneyInTransaction = None;
            MoneyInMachine = None;
            Slots = new List<Slot>
            {
                new Slot(null, 0, 0m, this, 1),
                new Slot(null, 0, 0m, this, 2),
                new Slot(null, 0, 0m, this, 3)
            };
        }

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

        public void BuySnack(int position)
        {
            var slot = Slots.Single(s => s.Position == position);
            slot.Quantity--;

            MoneyInMachine += MoneyInTransaction;
            MoneyInTransaction = None;
        }

        public void LoadSnacks(int position, Snack snack, int quantity, decimal price)
        {
            var slot = Slots.Single(s => s.Position == position);
            slot.Snack = snack;
            slot.Quantity = quantity;
            slot.Price = price;
        }
    }
}
