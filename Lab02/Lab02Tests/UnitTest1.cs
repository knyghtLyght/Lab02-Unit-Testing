using System;
using Xunit;
using Lab02;

namespace Lab02Tests
{
    public class UnitTest1
    {
        [Theory]
        [InlineData(0, "Your current balance is $0")]
        [InlineData(50, "Your current balance is $50")]
        [InlineData(-1, "Your current balance is $-1")] //Should not happen

        public void CanReturnBalance(decimal balance, string expected)
        {
            Assert.Equal(expected, Lab02.Program.BalanceCheck(balance));
        }

        [Theory]
        [InlineData(0, 0, 0)]
        [InlineData(0, 5, 5)]
        [InlineData(5, 5, 10)]
        [InlineData(0, -5, -5)] //Should never happen but will not break if it dose.
        [InlineData(-5, 5, 0)] //Also should never happen.

        public void CanReturnDeposit(decimal balance, decimal valueAdd, decimal expected)
        {
            Assert.Equal(expected, Lab02.Program.CashAdd(balance,valueAdd));
        }

        [Theory]
        [InlineData(0, 0, 0)]
        [InlineData(50, 25, 25)]
        [InlineData(0, 50, -50)] //Should never happen
        [InlineData(-50, 50, -100)] //Should never happen
        [InlineData(50, -50, 100)] //Should never happen

        public void CanReturnWhithdrawl(decimal balance, decimal valueRemove, decimal expected)
        {
            Assert.Equal(expected, Lab02.Program.CashRemove(balance, valueRemove));
        }

        [Theory]
        [InlineData(new string[3] { "well", "hi", "there" },"test", new string[4] { "well", "hi", "there", "test" })]

        public void CanReturnModedArray(string[] history, string newEntry, string[] expected)
        {
            Assert.Equal(expected, Lab02.Program.HistoryTracker(history, newEntry));
        }
    }
}
