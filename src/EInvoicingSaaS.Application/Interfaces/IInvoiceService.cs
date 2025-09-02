using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EInvoicingSaaS.Application.DTOs;

namespace EInvoicingSaaS.Application.Interfaces
{
    public interface IInvoiceService
    {
        Task<string> CreateInvoiceAsync(InvoiceRequest request);
        Task<IEnumerable<InvoiceResponse>> GetInvoicesAsync();
        Task<InvoiceResponse?> GetInvoiceByIdAsync(int id);
        Task<bool> DeleteInvoiceAsync(int id);
    }
}
