using Invoices.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Invoices.DataProcessor.ImportDto;

using static Data.DataConstrains;

[XmlType(nameof(Client))]
public class ImportClientDto
{
    [XmlElement(nameof(Name))]
    [Required]
    [MinLength(ClientNameMinLenght)]
    [MaxLength(ClientNameMaxLenght)]
    public string Name { get; set; } = null!;


    [XmlElement(nameof(NumberVat))]
    [Required]
    [MinLength(NumberVatMinLenght)]
    [MaxLength(NumberVatMaxLenght)]
    public string NumberVat { get; set; } = null!;

    [XmlArray(nameof(Addresses))]
    public ImportAddressDto[] Addresses { get; set; } = null!;
}

