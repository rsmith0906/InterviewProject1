using InterviewProject1;
using InterviewProject1.Interfaces;
using InterviewProject1.Models;

namespace InterviewTests
{
    [TestClass]
    public class AccountAccessorTests
    {
        /// <summary>
        /// Tests AccountAccessor AddDepositAsync method.
        /// </summary>
        [TestMethod]
        public async Task Test_AccountAccessor_AddDepositAsync()
        {
            // Arrange
            IAccountAccessor accountAccessor = new AccountAccessor(new DbContext());

            Guid accountId = Guid.NewGuid();
            double depositAmount = 10.0;

            // Act
            Guid transactionId = await accountAccessor.AddDepositAsync(accountId, depositAmount);

            // Assert
            var transactions = await accountAccessor.GetAccountHistoryAsync(accountId);
            var transaction = transactions.FirstOrDefault(t => t.TransactionId == transactionId);

            Assert.IsNotNull(transaction);
            Assert.AreEqual(transactionId, transaction.TransactionId);
            Assert.AreEqual(depositAmount, transaction.Amount);
            Assert.AreEqual(TransactionType.Deposit, transaction.TransactionType);
        }

        /// <summary>
        /// Tests AccountAccessor WithdrawMoneyAsync method.
        /// </summary>
        [TestMethod]
        public async Task Test_AccountAccessor_WithdrawMoneyAsync()
        {
            // Arrange
            IAccountAccessor accountAccessor = new AccountAccessor(new DbContext());

            Guid accountId = Guid.NewGuid();
            double depositAmount = 10.0;
            double withdrawAmount = 6.5;

            await accountAccessor.AddDepositAsync(accountId, depositAmount);

            // Act
            Guid transactionId = await accountAccessor.WithdrawMoneyAsync(accountId, withdrawAmount);

            // Assert
            var transactions = await accountAccessor.GetAccountHistoryAsync(accountId);
            var transaction = transactions.FirstOrDefault(t => t.TransactionId == transactionId);

            Assert.IsNotNull(transaction);
            Assert.AreEqual(transactionId, transaction.TransactionId);
            Assert.AreEqual(withdrawAmount, transaction.Amount);
            Assert.AreEqual(TransactionType.Withdrawal, transaction.TransactionType);
        }
    }
}