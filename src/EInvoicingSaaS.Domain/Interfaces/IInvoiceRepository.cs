using EInvoicingSaaS.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EInvoicingSaaS.Domain.Interfaces
{
    public interface IInvoiceRepository
    {
        Task<Invoice> CreateAsync(Invoice invoice);
        Task<Invoice> AddAsync(Invoice invoice);
        Task<Invoice?> GetByIdAsync(int id);
        Task<IEnumerable<Invoice>> GetAllAsync();
        Task<Invoice> UpdateAsync(Invoice invoice);
        Task<bool> DeleteAsync(int id);
    }
}
