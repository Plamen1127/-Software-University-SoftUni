using Boardgames.Data.Models;
using Boardgames.Data.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Boardgames.DataProcessor.ImportDto;

using static Data.DataConstrains;

[XmlType(nameof(Boardgame))]
public class ImportBoardgameDto
{
    [XmlElement(nameof(Name))]
    [Required]
    [MinLength(BoardgameNameMinLenght)]
    [MaxLength(BoardgameNameMaxLenght)]
    public string Name { get; set; } = null!;


    [XmlElement(nameof(Rating))]
    [Required]
    [Range(RatingMin, RatingMax)]
    public double Rating { get; set; }



    [XmlElement(nameof(YearPublished))]
    [Required]
    [Range(YearPublishedMin, YearPublishedMax)]
    public int YearPublished { get; set; }


    [XmlElement(nameof(CategoryType))]
    [Required]
    public int CategoryType { get; set; }


    [XmlElement(nameof(Mechanics))]
    public string Mechanics { get; set; } = null!;
}
