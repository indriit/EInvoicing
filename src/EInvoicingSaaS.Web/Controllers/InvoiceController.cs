using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using EInvoicingSaaS.Application.Interfaces;
using EInvoicingSaaS.Application.DTOs;
using EInvoicingSaaS.Domain.Interfaces;

namespace EInvoicingSaaS.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InvoiceController : ControllerBase
    {
        private readonly ICreateInvoiceUseCase _createInvoiceUseCase;
        private readonly IInvoiceRepository _invoiceRepository;

        public InvoiceController(ICreateInvoiceUseCase createInvoiceUseCase, IInvoiceRepository invoiceRepository)
        {
            _createInvoiceUseCase = createInvoiceUseCase;
            _invoiceRepository = invoiceRepository;
        }

        [HttpPost]
        public async Task<IActionResult> CreateInvoice([FromBody] InvoiceRequest request)
        {
            try
            {
                var xmlString = await _createInvoiceUseCase.ExecuteAsync(request);
                return Ok(new { XmlOutput = xmlString });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Fout bij genereren factuur: {ex.Message}");
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllInvoices()
        {
            var invoices = await _invoiceRepository.GetAllAsync();
            return Ok(invoices);
        }
    }
}
