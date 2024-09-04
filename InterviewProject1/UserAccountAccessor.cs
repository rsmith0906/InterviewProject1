using InterviewProject1.Interfaces;
using InterviewProject1.Models;
using System.Globalization;
using System.Text.Json;

namespace InterviewProject1
{
    /// <summary>
    /// The user account accessor.
    /// </summary>
    public class UserAccountAccessor : IUserAccountAccessor
    {
        private List<AccountTransaction> transactions;
        private readonly string transactionsJsonPath = Path.Combine(Directory.GetCurrentDirectory(), "transactions.json");

        /// <summary>
        /// Initializes a new instance of the <see cref="UserAccountAccessor"/> class.
        /// </summary>
        public UserAccountAccessor()
        {
        }

        /// <inheritdoc/>
        public async Task AddDeposit(double amount)
        {
            transactions = await GetAccountHistory();

            transactions.Add(new AccountTransaction()
            {
                Amount = amount,
                Date = DateTime.UtcNow,
                TransactionType = TransactionType.Deposit
            });
            await SaveTransactionsToJsonAsync();

            Console.WriteLine($"Deposit: ${amount.ToString("C", CultureInfo.CurrentCulture)}");
        }

        /// <inheritdoc/>
        public async Task WithdrawMoney(double amount)
        {
            transactions.Add(new AccountTransaction()
            {
                Amount = amount,
                Date = DateTime.UtcNow,
                TransactionType = TransactionType.Withdrawal
            });
            await SaveTransactionsToJsonAsync();

            Console.WriteLine($"Withdrawal: ${amount.ToString("C", CultureInfo.CurrentCulture)}");
        }

        /// <inheritdoc/>
        public async Task<List<AccountTransaction>> GetAccountHistory()
        {
            if (!File.Exists(transactionsJsonPath))
            {
                return new List<AccountTransaction>();
            }

            string json = await File.ReadAllTextAsync(transactionsJsonPath);
            List<AccountTransaction> history = JsonSerializer.Deserialize<List<AccountTransaction>>(json);
            return history;
        }

        private async Task SaveTransactionsToJsonAsync()
        {
            string json = JsonSerializer.Serialize(transactions);
            await File.WriteAllTextAsync(transactionsJsonPath, json);
        }
    }
}
