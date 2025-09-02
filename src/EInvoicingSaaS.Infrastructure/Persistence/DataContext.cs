using Microsoft.EntityFrameworkCore;
using EInvoicingSaaS.Domain.Entities;

namespace EInvoicingSaaS.Infrastructure.Persistence
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoiceLineItem> InvoiceLineItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure Invoice entity
            modelBuilder.Entity<Invoice>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.InvoiceNumber).IsRequired().HasMaxLength(50);
                entity.Property(e => e.SupplierName).IsRequired().HasMaxLength(200);
                entity.Property(e => e.SupplierAddress).HasMaxLength(500);
                entity.Property(e => e.SupplierVatNumber).HasMaxLength(50);
                entity.Property(e => e.CustomerName).IsRequired().HasMaxLength(200);
                entity.Property(e => e.CustomerAddress).HasMaxLength(500);
                entity.Property(e => e.CustomerEmail).HasMaxLength(255);
                entity.Property(e => e.CustomerStreet).HasMaxLength(200);
                entity.Property(e => e.CustomerCity).HasMaxLength(100);
                entity.Property(e => e.CustomerPostalCode).HasMaxLength(20);
                entity.Property(e => e.Currency).HasMaxLength(3);
                entity.Property(e => e.Status).HasMaxLength(20);
                entity.Property(e => e.TotalAmount).HasPrecision(18, 2);
                entity.Property(e => e.TaxAmount).HasPrecision(18, 2);
                entity.Property(e => e.NetAmount).HasPrecision(18, 2);
                entity.Property(e => e.TaxRate).HasPrecision(5, 2);
                entity.Property(e => e.Description).HasMaxLength(1000);
                entity.Property(e => e.Notes).HasMaxLength(500);

                // Configure relationship with line items
                entity.HasMany(e => e.LineItems)
                      .WithOne(li => li.Invoice)
                      .HasForeignKey(li => li.InvoiceId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            // Configure InvoiceLineItem entity
            modelBuilder.Entity<InvoiceLineItem>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Description).IsRequired().HasMaxLength(500);
                entity.Property(e => e.UnitOfMeasure).HasMaxLength(10);
                entity.Property(e => e.Quantity).HasPrecision(18, 4);
                entity.Property(e => e.UnitPrice).HasPrecision(18, 4);
                entity.Property(e => e.VatRate).HasPrecision(5, 4);
                entity.Property(e => e.LineTotal).HasPrecision(18, 2);
            });
        }
    }
}
