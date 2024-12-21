using api.Models;

namespace api.Repositories.Interfaces
{
    public interface ICustomerRepository 
    {
        Task<IEnumerable<Customer>> GetAllCustomersAsync();
        Task<Customer?> GetCustomerAsync(int id);
        Task<Customer> CreateCustomerAsync(Customer customer);
        Task UpdateCustomerAsync(Customer customer);
        Task DeleteCustomerAsync(int id);
        Task<IEnumerable<Customer>> GetCustomersAsync(int pageIndex, int pageSize);
        Task<int> GetTotalCustomersAsync();

    }
}