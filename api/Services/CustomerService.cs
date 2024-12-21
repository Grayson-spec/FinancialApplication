using System.ComponentModel.DataAnnotations;
using api.Models;
using api.Repositories.Interfaces;
using api.Repositories;
using api.Services.Interfaces;
using Microsoft.Build.Framework;
using Microsoft.Extensions.Logging;
using static API.Repositories.CustomerRepository;
using CustomerModel = api.Models.Customer;
using API.Services;

namespace api.Services
{
    public class CustomerService(ICustomerRepository repository, ILogger<CustomerService> logger) : ICustomerService
    {
        private readonly ICustomerRepository _repository = repository;
        private readonly Microsoft.Extensions.Logging.ILogger _logger = logger;

        public async Task<IEnumerable<CustomerModel>> GetAllCustomersAsync()
        {
            return await _repository.GetAllCustomersAsync();
        }

        public async Task<CustomerModel?> GetCustomerAsync(int id)
        {
            return await _repository.GetCustomerAsync(id);
        }

        public async Task<CustomerModel> CreateCustomerAsync(CustomerModel customer)
        {
            if (customer == null)
            {
                throw new ArgumentNullException(nameof(customer));
            }

            // Validate customer data
            if (string.IsNullOrEmpty(customer.CustomerName))
            {
                throw new ValidationException("Customer name is required");
            }

            try
            {
                return await _repository.CreateCustomerAsync(customer);
            }
            catch (RepositoryException ex)
            {
                // Log and re-throw exception
                _logger.LogError(ex, "Error creating customer");
                throw;
            }
        }

        public async Task UpdateCustomerAsync(CustomerModel customer)
        {
            if (customer == null)
            {
                throw new ArgumentNullException(nameof(customer));
            }

            try
            {
                await _repository.UpdateCustomerAsync(customer);
            }
            catch (RepositoryException ex)
            {
                // Log and re-throw exception
                _logger.LogError(ex, "Error updating customer");
                throw;
            }
        }

        public async Task DeleteCustomerAsync(int id)
        {
            try
            {
                await _repository.DeleteCustomerAsync(id);
            }
            catch (RepositoryException ex)
            {
                // Log and re-throw exception
                _logger.LogError(ex, "Error deleting customer");
                throw;
            }
        }

        public Task<PagedResult<CustomerModel>> GetCustomersAsync(int pageIndex, int pageSize)
        {
            throw new NotImplementedException();
        }

        
    }
}