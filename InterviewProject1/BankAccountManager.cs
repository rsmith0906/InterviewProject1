using InterviewProject1.Interfaces;

namespace InterviewProject1
{
    /// <summary>
    /// The bank account manager.
    /// </summary>
    public class BankAccountManager
    {
        /// <summary>
        /// The balance engine.
        /// </summary>
        private readonly BalanceEngine balanceEngine;

        /// <summary>
        /// The account accessor.
        /// </summary>
        private readonly IAccountAccessor accountAccessor;

        /// <summary>
        /// Initializes a new instance of the <see cref="BankAccountManager"/> class.
        /// </summary>
        /// <param name="balanceEngine">Balance engine.</param>
        /// <param name="accountAccessor">Account accessor.</param>
        public BankAccountManager(
            BalanceEngine balanceEngine,
            IAccountAccessor accountAccessor)
        {
            this.balanceEngine = balanceEngine;
            this.accountAccessor = accountAccessor;
        }

        /// <summary>
        /// Deposits the specified amount into the account.
        /// </summary>
        /// <param name="accountId">The account unique Id.</param>
        /// <param name="amount"></param>
        public async Task DepositAsync(Guid accountId, double amount)
        {
            await this.accountAccessor.AddDepositAsync(accountId, amount);
        }

        /// <summary>
        /// Withdraws the specified amount from the account.
        /// </summary>
        /// <param name="accountId">The account unique Id.</param>
        /// <param name="amount"></param>
        public async Task WithdrawAsync(Guid accountId, double amount)
        {
            await this.accountAccessor.WithdrawMoneyAsync(accountId, amount);
        }

        /// <summary>
        /// Gets the balance of the account.
        /// </summary>
        /// <param name="accountId">The account unique Id.</param>
        /// <returns>Account Balance.</returns>
        public async Task<double> GetBalanceAsync(Guid accountId)
        {
            return await this.balanceEngine.GetBalanceAsync(accountId);
        }
    }
}
