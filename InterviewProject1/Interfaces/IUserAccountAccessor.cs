using InterviewProject1.Models;

namespace InterviewProject1.Interfaces
{
    public interface IUserAccountAccessor
    {
        Task AddDeposit(double amount);
        Task<List<AccountTransaction>> GetAccountHistory();
        Task WithdrawMoney(double amount);
    }
}