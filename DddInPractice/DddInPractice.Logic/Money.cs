using System;

namespace DddInPractice.Logic
{
    public class Money : ValueObject<Money>
    {
        public int OneCentCount { get; }
        public int TenCentCount { get; }
        public int QuarterCount { get; }
        public int OneDollarCount { get; }
        public int FiveDollarCount { get; }
        public int TwentyDollarCount { get; }

        public decimal Amount => OneCentCount * 0.01m+ 
            TenCentCount * 0.10m + 
            QuarterCount * 0.25m + 
            OneDollarCount + 
            FiveDollarCount * 5 + 
            TwentyDollarCount * 20;

        public Money(int oneCentCount, int tenCentCount, int quarterCount, int oneDollarCount, int fiveDollarCount, int twentyDollarCount)
        {
            if (oneCentCount < 0)
                { throw new InvalidOperationException(); }
            if (tenCentCount < 0)
                { throw new InvalidOperationException(); }
            if (quarterCount < 0)
                { throw new InvalidOperationException(); }
            if (oneDollarCount < 0)
                { throw new InvalidOperationException(); }
            if (fiveDollarCount < 0)
                { throw new InvalidOperationException(); }
            if (twentyDollarCount< 0)
                { throw new InvalidOperationException(); }

            OneCentCount = oneCentCount;
            TenCentCount = tenCentCount;
            QuarterCount = quarterCount;
            OneDollarCount = oneDollarCount;
            FiveDollarCount = fiveDollarCount;
            TwentyDollarCount = twentyDollarCount;
        }

        public static Money operator +(Money money1, Money money2)
        {
            var sum = new Money
                (
                money1.OneCentCount + money2.OneCentCount,
                money1.TenCentCount + money2.TenCentCount,
                money1.QuarterCount + money2.QuarterCount,
                money1.OneDollarCount + money2.OneDollarCount,
                money1.FiveDollarCount + money2.FiveDollarCount,
                money1.TwentyDollarCount + money2.TwentyDollarCount
                );

            return sum;
        }

        protected override bool EqualsCore(Money other)
        {
            return OneCentCount == other.OneCentCount
                   && TenCentCount == other.TenCentCount
                   && QuarterCount == other.QuarterCount
                   && FiveDollarCount == other.FiveDollarCount
                   && TwentyDollarCount == other.TwentyDollarCount;
        }

        protected override int GetHashCodeCore()
        {
            unchecked
            {
                var hashCode = OneCentCount;
                hashCode = (hashCode*397) ^ TenCentCount;
                hashCode = (hashCode*397) ^ QuarterCount;
                hashCode = (hashCode*397) ^ FiveDollarCount;
                hashCode = (hashCode*397) ^ TwentyDollarCount;
                return hashCode;
            }
        }
    }
}