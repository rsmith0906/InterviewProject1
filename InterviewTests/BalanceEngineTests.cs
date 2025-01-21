using InterviewProject1;
using InterviewProject1.Interfaces;
using InterviewProject1.Models;
using Moq;

namespace InterviewTests
{
    [TestClass]
    public class BalanceEngineTests
    {
        /// <summary>
        /// Tests BalanceEngine GetBalanceAsync method returns correct account balance.
        /// </summary>
        [TestMethod]
        public async Task Test_BalanceEngine_BalanceEngine_AccountBalance()
        {
            // Arrange
            Guid accountId = Guid.NewGuid();

            var mockAccountAccessor = new Mock<IAccountAccessor>();
            mockAccountAccessor.Setup(x => x.GetAccountHistoryAsync(It.IsAny<Guid>()))
                .ReturnsAsync(new List<AccountTransaction>
                {
                    new AccountTransaction
                    {
                        TransactionId = Guid.NewGuid(),
                        AccountId = accountId,
                        Amount = 10.0,
                        TransactionType = TransactionType.Deposit
                    },
                    new AccountTransaction
                    {
                        TransactionId = Guid.NewGuid(),
                        AccountId = accountId,
                        Amount = 6.0,
                        TransactionType = TransactionType.Withdrawal
                    }
                });


            BalanceEngine balanceEngine = new(mockAccountAccessor.Object);

            // Act
            double balance = await balanceEngine.GetBalanceAsync(accountId);

            // Assert
            Assert.AreEqual(4.0, balance);
        }
    }
}