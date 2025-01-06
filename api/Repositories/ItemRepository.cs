using System.ComponentModel.DataAnnotations;
using api.Data;
using api.Models;
using api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

// Potential Error with ItemNumber

namespace API.Repositories
{
    public class ItemRepository(AppDbContext context, ILogger<ItemRepository> logger) : IItemRepository
    {
        private readonly AppDbContext _context = context;
        private readonly ILogger _logger = logger;

        public async Task<IEnumerable<Item>> GetAllItemsAsync()
        {
            try
            {
                return await _context.Items.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting all accounts");
                throw new RepositoryException("Error getting all accounts", ex);
            }
        }

        public async Task<Item?> GetItemAsync(int id)
        {
            try
            {
                return await _context.Items.FindAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError (ex, "Error getting Item by id");
                throw new RepositoryException("Error getting Item by id", ex);
            }
        }

        public async Task<Item> CreateItemAsync(Item Item)
        {
            if (Item == null)
            {
                throw new ArgumentNullException(nameof(Item));
            }

            if (string.IsNullOrEmpty(Item.ItemName))
            {
                throw new ValidationException("Item name is required");
            }

            try
            {
                _context.Items.Add(Item);
                await _context.SaveChangesAsync();
                return Item;
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError(ex, "Error creating Item");
                throw new RepositoryException("Error creating Item", ex);
            }
        }

        public async Task UpdateItemAsync(Item item)
        {
             if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            // Validate Item data
            if (string.IsNullOrEmpty(item.ItemName))
            {
                throw new ValidationException("Item number is required");
            }

            try
            {
                _context.Entry(item).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                _logger.LogError(ex, "Concurrency error updating Item");
                throw new RepositoryException("Concurrency error updating Item", ex);
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError(ex, "Error updating Item");
                throw new RepositoryException("Error updating Item", ex);
            }
        }

        public async Task DeleteItemAsync(int id)
        {
            try
            {
                var Item = await GetItemAsync(id);
                if (Item != null)
                {
                    _context.Items.Remove(Item);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting Item");
                throw new RepositoryException("Error deleting Item", ex);
            }
        }

        public Task<IEnumerable<Item>> GetItemsAsync(int pageIndex, int pageSize)
        {
            throw new NotImplementedException();
        }

        public Task<int> GetTotalItemsAsync()
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