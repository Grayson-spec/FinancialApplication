using api.Models;

namespace api.Repositories.Interfaces
{
    public interface IItemRepository
    {
        Task<IEnumerable<Item>> GetAllItemsAsync();
        Task<Item?> GetItemAsync(int id);
        Task<Item> CreateItemAsync(Item item);
        Task UpdateItemAsync(Item item);
        Task DeleteItemAsync(int id);
        Task<IEnumerable<Item>> GetItemsAsync(int pageIndex, int pageSize);
        Task<int> GetTotalItemsAsync();
    }
}