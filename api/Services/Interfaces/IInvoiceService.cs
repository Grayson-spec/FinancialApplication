using api.Models;
using API.Services;
using InvoiceModel = api.Models.Invoice;

namespace api.Services.Interfaces
{
    public interface IInvoiceService
    {
        Task<IEnumerable<InvoiceModel>> GetAllInvoicesAsync();
        Task<InvoiceModel?> GetInvoiceAsync(int id);
        Task<InvoiceModel> CreateInvoiceAsync(InvoiceModel invoice);
        Task UpdateInvoiceAsync(InvoiceModel invoice);
        Task DeleteInvoiceAsync(int id);
        Task<PagedResult<InvoiceModel>> GetInvoicesAsync(int pageIndex, int pageSize);
    }
}