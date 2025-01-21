using InterviewProject1.Interfaces;
using InterviewProject1.Models;

namespace InterviewProject1
{
    /// <summary>
    /// The balance engine.
    /// </summary>
    public class BalanceEngine
    {
        /// <summary>
        /// The account accessor.
        /// </summary>
        private readonly IAccountAccessor accountAccessor;

        /// <summary>
        /// Initializes a new instance of the <see cref="BalanceEngine"/> class.
        /// </summary>
        /// <param name="accountAccessor"></param>
        public BalanceEngine(IAccountAccessor accountAccessor)
        {
            this.accountAccessor = accountAccessor;
        }

        /// <summary>
        /// Gets the balance of the account.
        /// </summary>
        /// <param name="accountId">The account unique Id.</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Task<double> GetBalanceAsync(Guid accountId)
        {
            throw new NotImplementedException();
        }
    }
}
