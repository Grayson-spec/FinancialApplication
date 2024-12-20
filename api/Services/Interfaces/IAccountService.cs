using api.Models;
using API.Services;
using AccountModel = api.Models.Account;

namespace api.Services.Interfaces
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