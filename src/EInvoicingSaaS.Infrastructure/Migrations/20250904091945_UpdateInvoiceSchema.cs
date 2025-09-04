using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EInvoicingSaaS.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateInvoiceSchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BuyerVatNumber",
                table: "Invoices");

            migrationBuilder.RenameColumn(
                name: "VatAmount",
                table: "Invoices",
                newName: "TaxAmount");

            migrationBuilder.RenameColumn(
                name: "InvoiceDate",
                table: "Invoices",
                newName: "IssueDate");

            migrationBuilder.RenameColumn(
                name: "BuyerName",
                table: "Invoices",
                newName: "CustomerStreet");

            migrationBuilder.RenameColumn(
                name: "BuyerAddress",
                table: "Invoices",
                newName: "Notes");

            migrationBuilder.AddColumn<string>(
                name: "CustomerAddress",
                table: "Invoices",
                type: "TEXT",
                maxLength: 500,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CustomerCity",
                table: "Invoices",
                type: "TEXT",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CustomerEmail",
                table: "Invoices",
                type: "TEXT",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CustomerName",
                table: "Invoices",
                type: "TEXT",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CustomerPostalCode",
                table: "Invoices",
                type: "TEXT",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Invoices",
                type: "TEXT",
                maxLength: 1000,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "TaxRate",
                table: "Invoices",
                type: "TEXT",
                precision: 5,
                scale: 2,
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CustomerAddress",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "CustomerCity",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "CustomerEmail",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "CustomerName",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "CustomerPostalCode",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "TaxRate",
                table: "Invoices");

            migrationBuilder.RenameColumn(
                name: "TaxAmount",
                table: "Invoices",
                newName: "VatAmount");

            migrationBuilder.RenameColumn(
                name: "Notes",
                table: "Invoices",
                newName: "BuyerAddress");

            migrationBuilder.RenameColumn(
                name: "IssueDate",
                table: "Invoices",
                newName: "InvoiceDate");

            migrationBuilder.RenameColumn(
                name: "CustomerStreet",
                table: "Invoices",
                newName: "BuyerName");

            migrationBuilder.AddColumn<string>(
                name: "BuyerVatNumber",
                table: "Invoices",
                type: "TEXT",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }
    }
}
