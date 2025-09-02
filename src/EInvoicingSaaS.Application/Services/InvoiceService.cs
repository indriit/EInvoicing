using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EInvoicingSaaS.Application.DTOs;
using EInvoicingSaaS.Application.Interfaces;
using EInvoicingSaaS.Domain.Entities;
using EInvoicingSaaS.Domain.Interfaces;

namespace EInvoicingSaaS.Application.Services
{
    public class InvoiceService : IInvoiceService
    {
        private readonly IInvoiceRepository _invoiceRepository;

        public InvoiceService(IInvoiceRepository invoiceRepository)
        {
            _invoiceRepository = invoiceRepository;
        }

        public async Task<string> CreateInvoiceAsync(InvoiceRequest request)
        {
            var invoice = new Invoice
            {
                InvoiceNumber = request.InvoiceNumber,
                IssueDate = request.IssueDate,
                DueDate = request.DueDate,
                CustomerName = request.CustomerName,
                CustomerStreet = request.CustomerStreet,
                CustomerCity = request.CustomerCity,
                CustomerPostalCode = request.CustomerPostalCode,
                NetAmount = request.NetAmount,
                TaxAmount = request.TaxAmount,
                TaxRate = request.TaxRate,
                TotalAmount = request.TotalAmount,
                CreatedAt = DateTime.UtcNow
            };

            await _invoiceRepository.AddAsync(invoice);
            return invoice.InvoiceNumber;
        }

        public async Task<IEnumerable<InvoiceResponse>> GetInvoicesAsync()
        {
            var invoices = await _invoiceRepository.GetAllAsync();
            return invoices.Select(i => new InvoiceResponse
            {
                Id = i.Id,
                InvoiceNumber = i.InvoiceNumber,
                CustomerName = i.CustomerName,
                CustomerAddress = $"{i.CustomerStreet}, {i.CustomerCity} {i.CustomerPostalCode}",
                Amount = i.NetAmount,
                TaxAmount = i.TaxAmount,
                TaxRate = i.TaxRate,
                TotalAmount = i.TotalAmount,
                IssueDate = i.IssueDate,
                DueDate = i.DueDate,
                Status = i.Status,
                Description = i.Description,
                Notes = i.Notes,
                CreatedAt = i.CreatedAt,
                UpdatedAt = i.UpdatedAt
            });
        }

        public async Task<InvoiceResponse?> GetInvoiceByIdAsync(int id)
        {
            var invoice = await _invoiceRepository.GetByIdAsync(id);
            if (invoice == null) return null;

            return new InvoiceResponse
            {
                Id = invoice.Id,
                InvoiceNumber = invoice.InvoiceNumber,
                CustomerName = invoice.CustomerName,
                CustomerAddress = $"{invoice.CustomerStreet}, {invoice.CustomerCity} {invoice.CustomerPostalCode}",
                Amount = invoice.NetAmount,
                TaxAmount = invoice.TaxAmount,
                TaxRate = invoice.TaxRate,
                TotalAmount = invoice.TotalAmount,
                IssueDate = invoice.IssueDate,
                DueDate = invoice.DueDate,
                Status = invoice.Status,
                Description = invoice.Description,
                Notes = invoice.Notes,
                CreatedAt = invoice.CreatedAt,
                UpdatedAt = invoice.UpdatedAt
            };
        }

        public async Task<bool> DeleteInvoiceAsync(int id)
        {
            return await _invoiceRepository.DeleteAsync(id);
        }
    }
}
