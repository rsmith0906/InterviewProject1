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
        /// The user account accessor.
        /// </summary>
        private readonly IUserAccountAccessor userAccountAccessor;

        /// <summary>
        /// Initializes a new instance of the <see cref="BankAccountManager"/> class.
        /// </summary>
        /// <param name="balanceEngine"></param>
        /// <param name="userAccountAccessor"></param>
        public BankAccountManager(
            BalanceEngine balanceEngine,
            IUserAccountAccessor userAccountAccessor)
        {
            this.balanceEngine = balanceEngine;
            this.userAccountAccessor = userAccountAccessor;
        }

        /// <summary>
        /// Deposits the specified amount into the account.
        /// </summary>
        /// <param name="amount"></param>
        public async Task DepositAsync(double amount)
        {
            await this.userAccountAccessor.AddDepositAsync(amount);
        }

        /// <summary>
        /// Withdraws the specified amount from the account.
        /// </summary>
        /// <param name="amount"></param>
        public async Task WithdrawAsync(double amount)
        {
            await this.userAccountAccessor.WithdrawMoneyAsync(amount);
        }

        /// <summary>
        /// Gets the balance of the account.
        /// </summary>
        /// <returns>Account Balance.</returns>
        public async Task<double> GetBalanceAsync()
        {
            return await this.balanceEngine.GetBalanceAsync();
        }
    }
}
