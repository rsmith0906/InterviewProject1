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
        /// The user account accessor.
        /// </summary>
        private readonly IUserAccountAccessor userAccountAccessor;

        /// <summary>
        /// Initializes a new instance of the <see cref="BalanceEngine"/> class.
        /// </summary>
        /// <param name="userAccountAccessor"></param>
        public BalanceEngine(IUserAccountAccessor userAccountAccessor)
        {
            this.userAccountAccessor = userAccountAccessor;
        }

        /// <summary>
        /// Gets the balance of the account.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Task<double> GetBalance()
        {
            throw new NotImplementedException();
        }
    }
}
