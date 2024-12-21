using System.ComponentModel.DataAnnotations;
using api.Data;
using api.Models;
using api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace API.Repositories
{
    public class CustomerRepository(AppDbContext context, ILogger<CustomerRepository> logger) : ICustomerRepository
    {
        private readonly AppDbContext _context = context;
        private readonly ILogger _logger = logger;

        public async Task<IEnumerable<Customer>> GetAllCustomersAsync()
        {
            try
            {
                return await _context.Customers.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting all customers");
                throw new RepositoryException("Error getting all customers", ex);
            }
        }

        public async Task<Customer?> GetCustomerAsync(int id)
        {
            try
            {
                return await _context.Customers.FindAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError (ex, "Error getting customer by id");
                throw new RepositoryException("Error getting customer by id", ex);
            }
        }

        public async Task<Customer> CreateCustomerAsync(Customer customer)
        {
            if (customer == null)
            {
                throw new ArgumentNullException(nameof(customer));
            }

            if (string.IsNullOrEmpty(customer.CustomerName))
            {
                throw new ValidationException("Customer name is required");
            }

            try
            {
                _context.Customers.Add(customer);
                await _context.SaveChangesAsync();
                return customer;
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError(ex, "Error creating customer");
                throw new RepositoryException("Error creating customer", ex);
            }
        }

        public async Task UpdateCustomerAsync(Customer customer)
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
                _context.Entry(customer).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                _logger.LogError(ex, "Concurrency error updating customer");
                throw new RepositoryException("Concurrency error updating customer", ex);
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError(ex, "Error updating customer");
                throw new RepositoryException("Error updating customer", ex);
            }
        }

        public async Task DeleteCustomerAsync(int id)
        {
            try
            {
                var customer = await GetCustomerAsync(id);
                if (customer != null)
                {
                    _context.Customers.Remove(customer);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting customer");
                throw new RepositoryException("Error deleting customer", ex);
            }
        }

        public Task<IEnumerable<Customer>> GetCustomersAsync(int pageIndex, int pageSize)
        {
            throw new NotImplementedException();
        }

        public Task<int> GetTotalCustomersAsync()
        {
            throw new NotImplementedException();
        }
       

        public class RepositoryException(string message, Exception innerException) : Exception(message, innerException)
        {
        }
    }

    
}