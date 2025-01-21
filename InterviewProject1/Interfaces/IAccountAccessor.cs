using InterviewProject1.Models;

namespace InterviewProject1.Interfaces
{
    /// <summary>
    /// The account accessor.
    /// </summary>
    public interface IAccountAccessor
    {
        /// <summary>
        /// Add money ot the account.
        /// </summary>
        /// <param name="accountId">The account unique Id.</param>
        /// <param name="amount"></param>
        /// <returns>Task</returns>
        Task AddDepositAsync(Guid accountId, double amount);

        /// <summary>
        /// The get account history.
        /// </summary>
        /// <param name="accountId">The account unique Id.</param>
        /// <returns>Account Transactions</returns>
        Task<IEnumerable<AccountTransaction>> GetAccountHistoryAsync(Guid accountId);

        /// <summary>
        /// Withdraw money from the account.
        /// </summary>
        /// <param name="accountId">The account unique Id.</param>
        /// <param name="amount"></param>
        /// <returns>Task</returns>
        Task WithdrawMoneyAsync(Guid accountId, double amount);
    }
}