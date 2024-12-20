using api.Models;
using AccountModel = api.Models.Account;

namespace API.Services.Interfaces
{
    public interface IAccountService
    {
        Task<IEnumerable<AccountModel>> GetAllAccountsAsync();
        Task<AccountModel?> GetAccountAsync(int id);
        Task<AccountModel> CreateAccountAsync(AccountModel account);
        Task UpdateAccountAsync(AccountModel account);
        Task DeleteAccountAsync(int id);
        Task<PagedResult<AccountModel>> GetAccountsAsync(int pageIndex, int pageSize);
    }
}