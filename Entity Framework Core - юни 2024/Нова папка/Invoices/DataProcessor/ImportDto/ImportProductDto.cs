using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoices.DataProcessor.ImportDto;

using static Data.DataConstrains;

public class ImportProductDto
{
    [Required]
    [MinLength(ProductNameMinLenght)]
    [MaxLength(ProductNameMaxLenght)]
    public string Name { get; set; } = null!;


    [Required]
    [Range(typeof(decimal), ProductPriceMin, ProductPriceMax)]
    public decimal Price { get; set; }


    [Required]
    [Range(0,4)]
    public int CategoryType { get; set; }

    [Required]
    public int[] Clients { get; set; } = null!;

}
