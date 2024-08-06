﻿namespace Invoices.DataProcessor
{
    using Invoices.Data;
    using Invoices.Data.Models;
    using Invoices.DataProcessor.ExportDto;
    using Invoices.Utilitis;
    using Microsoft.VisualBasic;
    using Newtonsoft.Json;
    using System.Globalization;

    public class Serializer
    {
        public static string ExportClientsWithTheirInvoices(InvoicesContext context, DateTime date)
        {
            XmlHelper xmlHelper = new XmlHelper();
            const string xmlRoot = "Clients";

            ExportClientDto[] clientsToExport = context.Clients
                .Where(c=>c.Invoices.Any(i=>DateTime.Compare(i.IssueDate, date)>0))
                .Select(c=> new ExportClientDto()
                {
                    ClientName = c.Name,
                    VatNumber = c.NumberVat,
                    Invoices = c.Invoices
                    .OrderBy(i=>i.IssueDate)
                    .ThenByDescending(i=>i.DueDate)
                    .Select(i=>new ExportClientsInvoicesDto()
                    {
                        InvoiceNumber = i.Number,
                        InvoiceAmount = i.Amount,
                        Currency = i.CurrencyType.ToString(),
                        DueDate = i.DueDate.ToString("d", CultureInfo.InvariantCulture)

                    })
                    .ToArray(),
                    InvoicesCount = c.Invoices.Count()
                   
                })
                .OrderByDescending(c=>c.InvoicesCount)
                .ThenBy(c=>c.ClientName)
                .ToArray();

            return xmlHelper.Serialize(clientsToExport, xmlRoot);
        }

        public static string ExportProductsWithMostClients(InvoicesContext context, int nameLength)
        {

            ExportProductDto[] productsToExpoer = context.Products
                .Where(p => p.ProductsClients.Any())
                .Where(p => p.ProductsClients.Any(c => c.Client.Name.Length >= nameLength))
                .Select(p => new ExportProductDto()
                {
                    Name = p.Name,
                    Price = p.Price,
                    Category = p.CategoryType.ToString(),
                    Clients = p.ProductsClients
                    .Where(c => c.Client.Name.Length >= nameLength)
                    .Select(c => new ExportProductClientsDto()
                    {
                        Name = c.Client.Name,
                        NumberVat = c.Client.NumberVat,
                    })
                    .OrderBy(c => c.Name)
                    .ToArray()
                })
                .OrderByDescending(c => c.Clients.Length)
                .ThenBy(p => p.Name)
                .Take(5)
                .ToArray();

            return JsonConvert.SerializeObject(productsToExpoer, Formatting.Indented);
        }
        
    }
}