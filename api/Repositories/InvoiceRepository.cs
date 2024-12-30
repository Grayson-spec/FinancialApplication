using System.ComponentModel.DataAnnotations;
using api.Data;
using api.Models;
using api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

// Potential Error with invoiceNumber

namespace API.Repositories
{
    public class InvoiceRepository(AppDbContext context, ILogger<InvoiceRepository> logger) : IInvoiceRepository
    {
        private readonly AppDbContext _context = context;
        private readonly ILogger _logger = logger;

        public async Task<IEnumerable<Invoice>> GetAllInvoicesAsync()
        {
            try
            {
                return await _context.Invoices.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting all accounts");
                throw new RepositoryException("Error getting all accounts", ex);
            }
        }

        public async Task<Invoice?> GetInvoiceAsync(int id)
        {
            try
            {
                return await _context.Invoices.FindAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError (ex, "Error getting invoice by id");
                throw new RepositoryException("Error getting invoice by id", ex);
            }
        }

        public async Task<Invoice> CreateInvoiceAsync(Invoice invoice)
        {
            if (invoice == null)
            {
                throw new ArgumentNullException(nameof(invoice));
            }

            if (string.IsNullOrEmpty(invoice.InvoiceNumber))
            {
                throw new ValidationException("Invoice name is required");
            }

            try
            {
                _context.Invoices.Add(invoice);
                await _context.SaveChangesAsync();
                return invoice;
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError(ex, "Error creating invoice");
                throw new RepositoryException("Error creating invoice", ex);
            }
        }

        public async Task UpdateInvoiceAsync(Invoice invoice)
        {
             if (invoice == null)
            {
                throw new ArgumentNullException(nameof(invoice));
            }

            // Validate invoice data
            if (string.IsNullOrEmpty(invoice.InvoiceNumber))
            {
                throw new ValidationException("Invoice number is required");
            }

            try
            {
                _context.Entry(invoice).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                _logger.LogError(ex, "Concurrency error updating invoice");
                throw new RepositoryException("Concurrency error updating invoice", ex);
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError(ex, "Error updating invoice");
                throw new RepositoryException("Error updating invoice", ex);
            }
        }

        public async Task DeleteInvoiceAsync(int id)
        {
            try
            {
                var invoice = await GetInvoiceAsync(id);
                if (invoice != null)
                {
                    _context.Invoices.Remove(invoice);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting invoice");
                throw new RepositoryException("Error deleting invoice", ex);
            }
        }

        public Task<IEnumerable<Invoice>> GetInvoicesAsync(int pageIndex, int pageSize)
        {
            throw new NotImplementedException();
        }

        public Task<int> GetTotalInvoicesAsync()
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