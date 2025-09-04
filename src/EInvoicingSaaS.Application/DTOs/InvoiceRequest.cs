using System.ComponentModel.DataAnnotations;

namespace EInvoicingSaaS.Application.DTOs
{
    public class InvoiceRequest
    {
        [Required(ErrorMessage = "Factuurnummer is verplicht")]
        [StringLength(50, ErrorMessage = "Factuurnummer mag maximaal 50 karakters bevatten")]
        public string InvoiceNumber { get; set; } = string.Empty;

        [Required(ErrorMessage = "Uitgiftedatum is verplicht")]
        public DateTime IssueDate { get; set; } = DateTime.Today;

        [Required(ErrorMessage = "Vervaldatum is verplicht")]
        public DateTime DueDate { get; set; } = DateTime.Today.AddDays(30);

        [StringLength(100, ErrorMessage = "Leveranciersnaam mag maximaal 100 karakters bevatten")]
        public string SupplierName { get; set; } = "Your Company";

        [Required(ErrorMessage = "Klantnaam is verplicht")]
        [StringLength(100, ErrorMessage = "Klantnaam mag maximaal 100 karakters bevatten")]
        public string CustomerName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Straat is verplicht")]
        [StringLength(200, ErrorMessage = "Straat mag maximaal 200 karakters bevatten")]
        public string CustomerStreet { get; set; } = string.Empty;

        [Required(ErrorMessage = "Stad is verplicht")]
        [StringLength(100, ErrorMessage = "Stad mag maximaal 100 karakters bevatten")]
        public string CustomerCity { get; set; } = string.Empty;

        [Required(ErrorMessage = "Postcode is verplicht")]
        [RegularExpression(@"^[1-9]\d{3}$", ErrorMessage = "Ongeldige Belgische postcode")]
        public string CustomerPostalCode { get; set; } = string.Empty;

        [Range(0.01, double.MaxValue, ErrorMessage = "Nettobedrag moet groter zijn dan 0")]
        [DataType(DataType.Currency)]
        public decimal NetAmount { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "BTW-bedrag kan niet negatief zijn")]
        [DataType(DataType.Currency)]
        public decimal TaxAmount { get; set; }

        [Range(0, 100, ErrorMessage = "BTW-tarief moet tussen 0 en 100% liggen")]
        public decimal TaxRate { get; set; } = 21.0m; // Standard Dutch VAT rate

        [Required(ErrorMessage = "Omschrijving is verplicht")]
        [StringLength(500, ErrorMessage = "Omschrijving mag maximaal 500 karakters bevatten")]
        public string ItemDescription { get; set; } = string.Empty;

        [Range(0.01, double.MaxValue, ErrorMessage = "Eenheidsprijs moet groter zijn dan 0")]
        [DataType(DataType.Currency)]
        public decimal UnitPrice { get; set; }

        [Range(1, double.MaxValue, ErrorMessage = "Hoeveelheid moet groter zijn dan 0")]
        public decimal Quantity { get; set; } = 1;

        // Calculated property
        public decimal TotalAmount => NetAmount + TaxAmount;

        // Custom validation method
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (DueDate <= IssueDate)
            {
                yield return new ValidationResult(
                    "Vervaldatum moet na de uitgiftedatum liggen",
                    new[] { nameof(DueDate) });
            }

            if (Math.Abs(TaxAmount - (NetAmount * TaxRate / 100)) > 0.01m)
            {
                yield return new ValidationResult(
                    "BTW-bedrag komt niet overeen met berekening",
                    new[] { nameof(TaxAmount) });
            }

            if (Math.Abs(NetAmount - (UnitPrice * Quantity)) > 0.01m)
            {
                yield return new ValidationResult(
                    "Nettobedrag komt niet overeen met eenheidsprijs × hoeveelheid",
                    new[] { nameof(NetAmount) });
            }
        }
    }
}
