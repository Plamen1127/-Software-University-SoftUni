using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boardgames.DataProcessor.ImportDto;
using static Data.DataConstrains;

public class ImportSellerDto
{
    [Required]
    [MinLength(SellerNameMinLenght)]
    [MaxLength(SellerNameMaxLenght)]
    public string Name { get; set; } = null!;


    [Required]
    [MinLength(AddressMinLenght)]
    [MaxLength(AddressMaxLenght)]
    public string Address { get; set; } = null!;


    [Required]
    public string Country { get; set; } = null!;

    [Required]
    [RegularExpression(@"www\.[a-zA-Z0-9-]+\.com")]
    public string Website { get; set; } = null!;

    [Required]
    [JsonProperty("Boardgames")]
    public int[] BoardgamesId { get; set; } = null!;
}
