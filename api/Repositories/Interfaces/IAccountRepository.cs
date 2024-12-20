using api.Models;

namespace api.Repositories.Interfaces
{
    public interface IAccountRepository
    {
        Task<IEnumerable<Account>> GetAllAccountsAsync();
        Task<Account?> GetAccountAsync(int id);
        Task<Account> CreateAccountAsync(Account account);
        Task UpdateAccountAsync(Account account);
        Task DeleteAccountAsync(int id);
        Task<IEnumerable<Account>> GetAccountsAsync(int pageIndex, int pageSize);
        Task<int> GetTotalAccountsAsync();
    }
}