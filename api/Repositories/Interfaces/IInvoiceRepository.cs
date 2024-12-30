using api.Models;

namespace api.Repositories.Interfaces
{
    public interface IInvoiceRepository
    {
        Task<IEnumerable<Invoice>> GetAllInvoicesAsync();
        Task<Invoice?> GetInvoiceAsync(int id);
        Task<Invoice> CreateInvoiceAsync(Invoice invoice);
        Task UpdateInvoiceAsync(Invoice invoice);
        Task DeleteInvoiceAsync(int id);
        Task<IEnumerable<Invoice>> GetInvoicesAsync(int pageIndex, int pageSize);
        Task<int> GetTotalInvoicesAsync();
    }
}