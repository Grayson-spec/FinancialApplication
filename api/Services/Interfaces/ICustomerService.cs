using api.Models;
using API.Services;
using CustomerModel = api.Models.Customer;

namespace api.Services.Interfaces
{
    public interface ICustomerService
    {
        Task<IEnumerable<CustomerModel>> GetAllCustomersAsync();
        Task<CustomerModel?> GetCustomerAsync(int id);
        Task<CustomerModel> CreateCustomerAsync(CustomerModel customer);
        Task UpdateCustomerAsync(CustomerModel customer);
        Task DeleteCustomerAsync(int id);
        Task<PagedResult<CustomerModel>> GetCustomersAsync(int pageIndex, int pageSize);
    }
}