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


[XmlType(nameof(Address))]
public class ImportAddressDto
{
    [XmlElement(nameof(StreetName))]
    [Required]
    [MinLength(AddressMinLenght)]
    [MaxLength(AddressMaxLenght)]
    public string StreetName { get; set; } = null!;


    [XmlElement(nameof(StreetNumber))]
    [Required]
    public int StreetNumber { get; set; }


    [XmlElement(nameof(PostCode))]
    [Required]
    public string PostCode { get; set; } = null!;


    [XmlElement(nameof(City))]
    [Required]
    [MinLength(CityMinLenght)]
    [MaxLength(CityNameMaxLenght)]
    public string City { get; set; } = null!;


    [XmlElement(nameof(Country))]
    [Required]
    [MinLength(CountryMinLenght)]
    [MaxLength(CountryMaxLenght)]
    public string Country { get; set; } = null!;
}

