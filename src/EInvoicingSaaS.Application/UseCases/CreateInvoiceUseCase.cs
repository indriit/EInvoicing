using EInvoicingSaaS.Application.DTOs;
using EInvoicingSaaS.Application.Interfaces;
using EInvoicingSaaS.Domain.Entities;
using EInvoicingSaaS.Domain.Interfaces;
using System;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace EInvoicingSaaS.Application.UseCases
{
    public class CreateInvoiceUseCase : ICreateInvoiceUseCase
    {
        private readonly IInvoiceRepository _invoiceRepository;

        public CreateInvoiceUseCase(IInvoiceRepository invoiceRepository)
        {
            _invoiceRepository = invoiceRepository;
        }

        public async Task<string> ExecuteAsync(InvoiceRequest request)
        {
            // Basic validation
            if (string.IsNullOrWhiteSpace(request.InvoiceNumber))
                throw new ArgumentException("Invoice number is required.");
            if (request.NetAmount <= 0)
                throw new ArgumentException("Net amount must be greater than 0.");

            // Create domain entity
            var invoice = new Invoice
            {
                InvoiceNumber = request.InvoiceNumber,
                IssueDate = request.IssueDate,
                DueDate = request.DueDate,
                SupplierName = request.SupplierName,
                CustomerName = request.CustomerName,
                NetAmount = request.NetAmount,
                TaxAmount = request.TaxAmount,
                TotalAmount = request.NetAmount + request.TaxAmount,
                Currency = "EUR",
                Status = "Draft",
                CreatedAt = DateTime.UtcNow
            };

            // Save to repository
            await _invoiceRepository.CreateAsync(invoice);

            // Generate simple XML representation
            var xml = new XElement("Invoice",
                new XElement("InvoiceNumber", invoice.InvoiceNumber),
                new XElement("InvoiceDate", invoice.IssueDate.ToString("yyyy-MM-dd")),
                new XElement("DueDate", invoice.DueDate.ToString("yyyy-MM-dd")),
                new XElement("Supplier", invoice.SupplierName),
                new XElement("Buyer", invoice.CustomerName),
                new XElement("NetAmount", invoice.NetAmount),
                new XElement("VatAmount", invoice.TaxAmount),
                new XElement("TotalAmount", invoice.TotalAmount),
                new XElement("Currency", invoice.Currency)
            );

            return xml.ToString();
        }
    }
}
