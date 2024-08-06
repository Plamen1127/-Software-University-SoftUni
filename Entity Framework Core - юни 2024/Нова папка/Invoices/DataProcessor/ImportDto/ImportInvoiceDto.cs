using Invoices.Data.Models.Enums;
using Invoices.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoices.DataProcessor.ImportDto;

using static Data.DataConstrains;

public class ImportInvoiceDto
{
    [Required]
    [Range(NumberMinLenght, NumberMaxLenght)]
    public int Number { get; set; }

    [Required]
    public string IssueDate { get; set; } = null!;

    [Required]
    public string DueDate { get; set; } = null!;

    [Required]
    public decimal Amount { get; set; }

    [Required]
    [Range(CurenciTypeMin, CurenciTypeMax)]
    public int CurrencyType { get; set; }

    [Required]
    public int ClientId { get; set; }

}
