using System;
using DddInPractice.Logic;
using FluentAssertions;
using Xunit;

namespace DddInPractice.Tests
{
    public class MoneySpecs
    {
        [Fact]
        public void GivenTwoMonies_Sum_CorrectlyAddsBothMonies()
        {
            var money1 = new Money(1, 2, 3, 4, 5, 6);
            var money2 = new Money(1, 2, 3, 4, 5, 6);

            var sum = money1 + money2;

            sum.OneCentCount.Should().Be(2);
            sum.TenCentCount.Should().Be(4);
            sum.QuarterCount.Should().Be(6);
            sum.OneDollarCount.Should().Be(8);
            sum.FiveDollarCount.Should().Be(10);
            sum.TwentyDollarCount.Should().Be(12);
        }

        [Fact]
        public void GivenTwoEqualMonies_Equal_ReturnsTrue()
        {
            var money1 = new Money(1, 2, 3, 4, 5, 6);
            var money2 = new Money(1, 2, 3, 4, 5, 6);

            money1.ShouldBeEquivalentTo(money2);
            money2.Should().Be(money1);
            money1.GetHashCode().Should().Be(money2.GetHashCode());
        }

        [Fact]
        public void Two_Moneys_Should_Not_Equal_If_Same_Value_But_Different_Denominator()
        {
            var twentyOneDollars = new Money(0, 0, 0, 20, 0, 0);
            var twentyDollar = new Money(0, 0, 0, 0, 0, 1);

            twentyOneDollars.Should().NotBe(twentyDollar);
            twentyDollar.GetHashCode().Should().NotBe(twentyOneDollars.GetHashCode());
        }

        [Theory]
        [InlineData(-1, 0, 0, 0, 0, 0)]
        [InlineData(0, -1, 0, 0, 0, 0)]
        [InlineData(0, 0, -1, 0, 0, 0)]
        [InlineData(0, 0, 0, -1, 0, 0)]
        [InlineData(0, 0, 0, 0, -1, 0)]
        [InlineData(0, 0, 0, 0, 0, -1)]
        public void GivenNegativeMoney_CreateNewInstanceOfMoney_ThrowsInvalidOperationException(
            int oneCentCount, 
            int tenCentCount, 
            int quarterCount, 
            int oneDollarCount, 
            int fiveDollarCount, 
            int twentyDollarCount)
        {
            Action action = () => new Money(oneCentCount, tenCentCount, quarterCount, oneDollarCount, fiveDollarCount, twentyDollarCount);

            action.ShouldThrow<InvalidOperationException>();
        }

        [Theory]
        [InlineData(0, 0, 0, 0, 0, 0, 0)]
        [InlineData(1, 2, 3, 0, 0, 0, 0.96)]
        [InlineData(1, 2, 3, 4, 0, 0, 4.96)]
        [InlineData(1, 2, 3, 4, 5, 0, 29.96)]
        [InlineData(1, 2, 3, 4, 5, 6, 149.96)]
        public void GivenDenomination_CreateNewInstanceOfMoney_MoneyCorrectlyContainsItsValue(
            int oneCentCount, 
            int tenCentCount, 
            int quarterCount, 
            int oneDollarCount, 
            int fiveDollarCount, 
            int twentyDollarCount, 
            decimal expectedValue)
        {
            var money = new Money(oneCentCount, tenCentCount, quarterCount, oneDollarCount, fiveDollarCount, twentyDollarCount);

            money.Amount.Should().Be(expectedValue);
        }
    }
}