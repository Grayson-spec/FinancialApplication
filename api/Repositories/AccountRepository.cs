using api.Data;
using api.Models;
using api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API.Repositories
{
    public class AccountRepository(AppDbContext context, ILogger<AccountRepository> logger) : IAccountRepository
    {
        private readonly AppDbContext _context = context;
        private readonly ILogger _logger = logger;

        public async Task<IEnumerable<Account>> GetAllAccountsAsync()
        {
            return await _context.Accounts.ToListAsync();
        }

        public async Task<Account?> GetAccountAsync(int id)
        {
            return await _context.Accounts.FindAsync(id);
        }

        public async Task<Account> CreateAccountAsync(Account account)
        {
            _context.Accounts.Add(account);
            await _context.SaveChangesAsync();
            return account;
        }

        public async Task UpdateAccountAsync(Account account)
        {
            _context.Entry(account).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAccountAsync(int id)
        {
            var account = await GetAccountAsync(id);
            if (account != null)
            {
                _context.Accounts.Remove(account);
                await _context.SaveChangesAsync();
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
    }

    
}