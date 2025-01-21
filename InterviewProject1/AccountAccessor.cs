using InterviewProject1.Interfaces;
using InterviewProject1.Models;
using System.Collections.Generic;
using System.Globalization;
using System.Text.Json;

namespace InterviewProject1
{
    /// <summary>
    /// The account accessor.
    /// </summary>
    public class AccountAccessor : IAccountAccessor
    {
        /// <summary>
        /// DB Context.
        /// </summary>
        private readonly DbContext dbContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="AccountAccessor"/> class.
        /// </summary>
        public AccountAccessor(DbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        /// <inheritdoc/>
        public async Task<Guid> AddDepositAsync(Guid accountId, double amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Amount must be greater than zero.");
            }

            Guid transactionId = Guid.NewGuid();

            var transactions = (List<AccountTransaction>)await this.dbContext.GetData<AccountTransaction>();

            transactions.Add(new AccountTransaction()
            {
                TransactionId = transactionId,
                AccountId = accountId,
                Amount = amount,
                Date = DateTime.UtcNow,
                TransactionType = TransactionType.Deposit
            });

            await this.dbContext.SaveData(transactions);

            Console.WriteLine($"Deposit: {amount.ToString("C", CultureInfo.CurrentCulture)}");

            return transactionId;
        }

        /// <inheritdoc/>
        public async Task<Guid> WithdrawMoneyAsync(Guid accountId, double amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Amount must be greater than zero.");
            }

            Guid transactionId = Guid.NewGuid();

            var transactions = (List<AccountTransaction>)await this.dbContext.GetData<AccountTransaction>();

            transactions.Add(new AccountTransaction()
            {
                TransactionId = transactionId,
                AccountId = accountId,
                Amount = amount,
                Date = DateTime.UtcNow,
                TransactionType = TransactionType.Withdrawal
            });

            await this.dbContext.SaveData(transactions);

            Console.WriteLine($"Withdrawal: {amount.ToString("C", CultureInfo.CurrentCulture)}");

            return transactionId;
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<AccountTransaction>> GetAccountHistoryAsync(Guid accountId)
        {
            var transactions = await this.dbContext.GetData<AccountTransaction>();
            return transactions.Where(transaction => transaction.AccountId == accountId);
        }
    }
}
