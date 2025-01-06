using System.ComponentModel.DataAnnotations;
using api.Models;
using api.Repositories.Interfaces;
using api.Repositories;
using api.Services.Interfaces;
using Microsoft.Build.Framework;
using Microsoft.Extensions.Logging;
using static API.Repositories.InvoiceRepository;
using ItemModel = api.Models.Item;
using API.Services;

namespace api.Services
{
    public class ItemService(IItemRepository repository, ILogger<ItemService> logger) : IItemService
    {
        private readonly IItemRepository _repository = repository;
        private readonly Microsoft.Extensions.Logging.ILogger _logger = logger;

        public async Task<IEnumerable<ItemModel>> GetAllItemsAsync()
        {
            return await _repository.GetAllItemsAsync();
        }

        public async Task<ItemModel?> GetItemAsync(int id)
        {
            return await _repository.GetItemAsync(id);
        }

        public async Task<ItemModel> CreateItemAsync(ItemModel item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            // Validate item data
            if (string.IsNullOrEmpty(item.ItemName))
            {
                throw new ValidationException("item name is required");
            }

            try
            {
                return await _repository.CreateItemAsync(item);
            }
            catch (RepositoryException ex)
            {
                // Log and re-throw exception
                _logger.LogError(ex, "Error creating item");
                throw;
            }
        }

        public async Task UpdateItemAsync(ItemModel item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            try
            {
                await _repository.UpdateItemAsync(item);
            }
            catch (RepositoryException ex)
            {
                // Log and re-throw exception
                _logger.LogError(ex, "Error updating item");
                throw;
            }
        }

        public async Task DeleteItemAsync(int id)
        {
            try
            {
                await _repository.DeleteItemAsync(id);
            }
            catch (RepositoryException ex)
            {
                // Log and re-throw exception
                _logger.LogError(ex, "Error deleting item");
                throw;
            }
        }

        public Task<PagedResult<ItemModel>> GetItemsAsync(int pageIndex, int pageSize)
        {
            throw new NotImplementedException();
        }//
    }

    
}