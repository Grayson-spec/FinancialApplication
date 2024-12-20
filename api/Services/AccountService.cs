using api.Models;
using api.Repositories.Interfaces;
using API.Repositories;
using API.Services.Interfaces;
using AccountModel = api.Models.Account;

namespace API.Services
{
    public class AccountService(IAccountRepository repository) : IAccountService
    {
        private readonly IAccountRepository _repository = repository;

        public async Task<IEnumerable<AccountModel>> GetAllAccountsAsync()
        {
            return await _repository.GetAllAccountsAsync();
        }

        public async Task<AccountModel?> GetAccountAsync(int id)
        {
            return await _repository.GetAccountAsync(id);
        }

        public async Task<Account> CreateAccountAsync(Account account)
        {
            return await _repository.CreateAccountAsync(account);
        }

        public async Task UpdateAccountAsync(AccountModel account)
        {
            await _repository.UpdateAccountAsync(account);
        }

        public async Task DeleteAccountAsync(int id)
        {
            await _repository.DeleteAccountAsync(id);
        }

        public Task<PagedResult<AccountModel>> GetAccountsAsync(int pageIndex, int pageSize)
        {
            throw new NotImplementedException();
        }
    }
}