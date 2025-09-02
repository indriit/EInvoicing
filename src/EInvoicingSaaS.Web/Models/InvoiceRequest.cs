namespace EInvoicingSaaS.Web.Models
{
    public class InvoiceRequest
    {
        public string InvoiceNumber { get; set; } = string.Empty;
        public string CustomerName { get; set; } = string.Empty;
        public string CustomerStreet { get; set; } = string.Empty;
        public string CustomerCity { get; set; } = string.Empty;
        public decimal NetAmount { get; set; }
        public decimal TaxAmount { get; set; }
        public decimal TaxRate { get; set; }
        public string ItemDescription { get; set; } = string.Empty;
        public decimal UnitPrice { get; set; }
        public decimal Quantity { get; set; }
    }
}
