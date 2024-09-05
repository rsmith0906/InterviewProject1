using InterviewProject1.Interfaces;
using InterviewProject1.Models;
using System.Collections.Generic;
using System.Globalization;
using System.Text.Json;

namespace InterviewProject1
{
    /// <summary>
    /// The user account accessor.
    /// </summary>
    public class UserAccountAccessor : IUserAccountAccessor
    {
        /// <summary>
        /// DB Context.
        /// </summary>
        private readonly DbContext dbContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserAccountAccessor"/> class.
        /// </summary>
        public UserAccountAccessor(DbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        /// <inheritdoc/>
        public async Task AddDepositAsync(double amount)
        {
            var transactions = (List<AccountTransaction>)await this.dbContext.GetData<AccountTransaction>();

            transactions.Add(new AccountTransaction()
            {
                Amount = amount,
                Date = DateTime.UtcNow,
                TransactionType = TransactionType.Deposit
            });

            await this.dbContext.SaveData(transactions);

            Console.WriteLine($"Deposit: {amount.ToString("C", CultureInfo.CurrentCulture)}");
        }

        /// <inheritdoc/>
        public async Task WithdrawMoneyAsync(double amount)
        {
            var transactions = (List<AccountTransaction>)await this.dbContext.GetData<AccountTransaction>();

            transactions.Add(new AccountTransaction()
            {
                Amount = amount,
                Date = DateTime.UtcNow,
                TransactionType = TransactionType.Withdrawal
            });

            await this.dbContext.SaveData(transactions);

            Console.WriteLine($"Withdrawal: {amount.ToString("C", CultureInfo.CurrentCulture)}");
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<AccountTransaction>> GetAccountHistoryAsync()
        {
            var transactions = await this.dbContext.GetData<AccountTransaction>();
            return transactions;
        }
    }
}
