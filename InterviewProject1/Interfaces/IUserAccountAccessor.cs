using InterviewProject1.Models;

namespace InterviewProject1.Interfaces
{
    /// <summary>
    /// The user account accessor.
    /// </summary>
    public interface IUserAccountAccessor
    {
        /// <summary>
        /// The add deposit.
        /// </summary>
        /// <param name="amount"></param>
        /// <returns></returns>
        Task AddDepositAsync(double amount);

        /// <summary>
        /// The get account history.
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<AccountTransaction>> GetAccountHistoryAsync();

        /// <summary>
        /// The get balance.
        /// </summary>
        /// <param name="amount"></param>
        /// <returns></returns>
        Task WithdrawMoneyAsync(double amount);
    }
}