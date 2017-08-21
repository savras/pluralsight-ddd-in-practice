using System;
using System.Linq.Expressions;
using DddInPractice.Logic;
using FluentAssertions;
using Xunit;
using static DddInPractice.Logic.Money;

namespace DddInPractice.Tests
{
    public class SnackMachineSpecs
    {
        [Fact]
        public void GivenMoneyInTransaction_ReturnMoney_CorrectlyEmptiesMoneyInTransaction()
        {
            // Arrange
            var snackMachine = new SnackMachine();
            snackMachine.InsertMoney(Dollar);

            // Act
            snackMachine.ReturnMoney();

            // Assert
            snackMachine.MoneyInTransaction.Amount.Should().Be(0m);
        }

        [Fact]
        public void GivenInsertedMoney_InsertMoney_CorrectlyPutsMoneyInTracsaction()
        {
            var snackMachine = new SnackMachine();

            snackMachine.InsertMoney(FiveDollar);
            snackMachine.InsertMoney(Quarter);

            snackMachine.MoneyInTransaction.Amount.Should().Be(5.25m);
        }

        [Fact]
        public void GivenInsertionOfTwoOfTheSameMoneyAtOneTime_InsertMoney_ThrowsException()
        {
            var snackMachine = new SnackMachine();
            var twoDollars = Dollar + Dollar;

            Action action = () => snackMachine.InsertMoney(twoDollars);

            action.ShouldThrow<InvalidOperationException>();
        }

        [Fact]
        public void GivenTwoDollars_BuySnack_EmptiesTransaction_And_AddsToMoneyInside()
        {
            var snackMachine = new SnackMachine();
            snackMachine.InsertMoney(Dollar);
            snackMachine.InsertMoney(Dollar);

            snackMachine.BuySnack();

            snackMachine.MoneyInTransaction.Should().Be(None);
            snackMachine.MoneyInMachine.Amount.Should().Be(2m);
        }
    }
}
