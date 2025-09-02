using EInvoicingSaaS.Application.DTOs;
using System.Threading.Tasks;

namespace EInvoicingSaaS.Application.Interfaces
{
    public interface ICreateInvoiceUseCase
    {
        Task<string> ExecuteAsync(InvoiceRequest request);
    }
}
