using System.ComponentModel.DataAnnotations;
using api.Models;
using api.Repositories.Interfaces;
using api.Repositories;
using api.Services.Interfaces;
using Microsoft.Build.Framework;
using Microsoft.Extensions.Logging;
using static API.Repositories.AccountRepository;
using AccountModel = api.Models.Account;
using API.Services;

namespace api.Services
{
    public class AccountService(IAccountRepository repository, ILogger<AccountService> logger) : IAccountService
    {
        private readonly IAccountRepository _repository = repository;
        private readonly Microsoft.Extensions.Logging.ILogger _logger = logger;

        public async Task<IEnumerable<AccountModel>> GetAllAccountsAsync()
        {
            return await _repository.GetAllAccountsAsync();
        }

        public async Task<AccountModel?> GetAccountAsync(int id)
        {
            return await _repository.GetAccountAsync(id);
        }

        public async Task<AccountModel> CreateAccountAsync(AccountModel account)
        {
            if (account == null)
            {
                throw new ArgumentNullException(nameof(account));
            }

            // Validate account data
            if (string.IsNullOrEmpty(account.AccountName))
            {
                throw new ValidationException("Account name is required");
            }

            try
            {
                return await _repository.CreateAccountAsync(account);
            }
            catch (RepositoryException ex)
            {
                // Log and re-throw exception
                _logger.LogError(ex, "Error creating account");
                throw;
            }
        }

        public async Task UpdateAccountAsync(AccountModel account)
        {
            if (account == null)
            {
                throw new ArgumentNullException(nameof(account));
            }

            try
            {
                await _repository.UpdateAccountAsync(account);
            }
            catch (RepositoryException ex)
            {
                // Log and re-throw exception
                _logger.LogError(ex, "Error updating account");
                throw;
            }
        }

        public async Task DeleteAccountAsync(int id)
        {
            try
            {
                await _repository.DeleteAccountAsync(id);
            }
            catch (RepositoryException ex)
            {
                // Log and re-throw exception
                _logger.LogError(ex, "Error deleting account");
                throw;
            }
        }

        public Task<PagedResult<AccountModel>> GetAccountsAsync(int pageIndex, int pageSize)
        {
            throw new NotImplementedException();
        }
    }
}