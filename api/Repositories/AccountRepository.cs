using System.ComponentModel.DataAnnotations;
using api.Data;
using api.Models;
using api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace API.Repositories
{
    public class AccountRepository(AppDbContext context, ILogger<AccountRepository> logger) : IAccountRepository
    {
        private readonly AppDbContext _context = context;
        private readonly ILogger _logger = logger;

        public async Task<IEnumerable<Account>> GetAllAccountsAsync()
        {
            try
            {
                return await _context.Accounts.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting all accounts");
                throw new RepositoryException("Error getting all accounts", ex);
            }
        }

        public async Task<Account?> GetAccountAsync(int id)
        {
            try
            {
                return await _context.Accounts.FindAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError (ex, "Error getting account by id");
                throw new RepositoryException("Error getting account by id", ex);
            }
        }

        public async Task<Account> CreateAccountAsync(Account account)
        {
            if (account == null)
            {
                throw new ArgumentNullException(nameof(account));
            }

            if (string.IsNullOrEmpty(account.AccountName))
            {
                throw new ValidationException("Account name is required");
            }

            try
            {
                _context.Accounts.Add(account);
                await _context.SaveChangesAsync();
                return account;
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError(ex, "Error creating account");
                throw new RepositoryException("Error creating account", ex);
            }
        }

        public async Task UpdateAccountAsync(Account account)
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
                _context.Entry(account).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                _logger.LogError(ex, "Concurrency error updating account");
                throw new RepositoryException("Concurrency error updating account", ex);
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError(ex, "Error updating account");
                throw new RepositoryException("Error updating account", ex);
            }
        }

        public async Task DeleteAccountAsync(int id)
        {
            try
            {
                var account = await GetAccountAsync(id);
                if (account != null)
                {
                    _context.Accounts.Remove(account);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting account");
                throw new RepositoryException("Error deleting account", ex);
            }
        }

        public Task<IEnumerable<Account>> GetAccountsAsync(int pageIndex, int pageSize)
        {
            throw new NotImplementedException();
        }

        public Task<int> GetTotalAccountsAsync()
        {
            throw new NotImplementedException();
        }
        public class RepositoryException : Exception
    {
        public RepositoryException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
    }

    
}