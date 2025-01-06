using api.Models;
using API.Services;
using ItemModel = api.Models.Item;

namespace api.Services.Interfaces
{
    public interface IItemService
    {
        Task<IEnumerable<ItemModel>> GetAllItemsAsync();
        Task<ItemModel?> GetItemAsync(int id);
        Task<ItemModel> CreateItemAsync(ItemModel Item);
        Task UpdateItemAsync(ItemModel Item);
        Task DeleteItemAsync(int id);
        Task<PagedResult<ItemModel>> GetItemsAsync(int pageIndex, int pageSize);
    }
}