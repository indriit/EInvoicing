namespace EInvoicingSaaS.Domain.Entities
{
    public class InvoiceLineItem
    {
        public int Id { get; set; }
        public int InvoiceId { get; set; }
        public string Description { get; set; } = string.Empty;
        public decimal Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal VatRate { get; set; }
        public decimal LineTotal { get; set; }
        public string UnitOfMeasure { get; set; } = "pcs";

        // Navigation property
        public Invoice Invoice { get; set; } = null!;
    }
}
