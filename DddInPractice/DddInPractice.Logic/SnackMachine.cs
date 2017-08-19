namespace DddInPractice.Logic
{
    public sealed class SnackMachine : Entity
    {
        public Money MoneyInTransaction { get; set; }
        public Money MoneyInMachine { get; set; }

        public void ReturnMoney()
        {
            // MoneyInTransaction = 0;
        }

        public void InsertMoney(Money money)
        {
            MoneyInTransaction += money;
        }

        public void BuySnack()
        {
            MoneyInMachine += MoneyInTransaction;
            // MoneyInTransaction = 0;
        }
    }
}
