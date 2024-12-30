using System.ComponentModel.DataAnnotations;
using api.Models;
using api.Repositories.Interfaces;
using api.Repositories;
using api.Services.Interfaces;
using Microsoft.Build.Framework;
using Microsoft.Extensions.Logging;
using static API.Repositories.InvoiceRepository;
using InvoiceModel = api.Models.Invoice;
using API.Services;

namespace api.Services
{
    public class InvoiceService(IInvoiceRepository repository, ILogger<InvoiceService> logger) : IInvoiceService
    {
        private readonly IInvoiceRepository _repository = repository;
        private readonly Microsoft.Extensions.Logging.ILogger _logger = logger;

        public async Task<IEnumerable<InvoiceModel>> GetAllInvoicesAsync()
        {
            return await _repository.GetAllInvoicesAsync();
        }

        public async Task<InvoiceModel?> GetInvoiceAsync(int id)
        {
            return await _repository.GetInvoiceAsync(id);
        }

        public async Task<InvoiceModel> CreateInvoiceAsync(InvoiceModel invoice)
        {
            if (invoice == null)
            {
                throw new ArgumentNullException(nameof(invoice));
            }

            // Validate invoice data
            if (string.IsNullOrEmpty(invoice.InvoiceNumber))
            {
                throw new ValidationException("invoice name is required");
            }

            try
            {
                return await _repository.CreateInvoiceAsync(invoice);
            }
            catch (RepositoryException ex)
            {
                // Log and re-throw exception
                _logger.LogError(ex, "Error creating invoice");
                throw;
            }
        }

        public async Task UpdateInvoiceAsync(InvoiceModel invoice)
        {
            if (invoice == null)
            {
                throw new ArgumentNullException(nameof(invoice));
            }

            try
            {
                await _repository.UpdateInvoiceAsync(invoice);
            }
            catch (RepositoryException ex)
            {
                // Log and re-throw exception
                _logger.LogError(ex, "Error updating invoice");
                throw;
            }
        }

        public async Task DeleteInvoiceAsync(int id)
        {
            try
            {
                await _repository.DeleteInvoiceAsync(id);
            }
            catch (RepositoryException ex)
            {
                // Log and re-throw exception
                _logger.LogError(ex, "Error deleting invoice");
                throw;
            }
        }

        public Task<PagedResult<InvoiceModel>> GetInvoicesAsync(int pageIndex, int pageSize)
        {
            throw new NotImplementedException();
        }//
    }

    
}