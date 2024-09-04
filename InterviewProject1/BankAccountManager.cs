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
        /// <returns></returns>
        public async Task Deposit(double amount)
        {
            await this.userAccountAccessor.AddDeposit(amount);
        }

        /// <summary>
        /// Withdraws the specified amount from the account.
        /// </summary>
        /// <param name="amount"></param>
        /// <returns></returns>
        public async Task Withdraw(double amount)
        {
            await this.userAccountAccessor.WithdrawMoney(amount);
        }

        /// <summary>
        /// Gets the balance of the account.
        /// </summary>
        /// <returns></returns>
        public async Task<double> GetBalance()
        {
            return await this.balanceEngine.GetBalance();
        }
    }
}
