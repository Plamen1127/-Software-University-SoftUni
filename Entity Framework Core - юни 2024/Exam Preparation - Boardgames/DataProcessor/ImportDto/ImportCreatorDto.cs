using Boardgames.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Boardgames.DataProcessor.ImportDto;

using static Data.DataConstrains;

[XmlType(nameof(Creator))]
public class ImportCreatorDto
{
    [XmlElement(nameof(FirstName))]
    [Required]
    [MinLength(CreatorFirstNameMinLenght)]
    [MaxLength(CreatorFirstNameMaxLenght)]
    public string FirstName { get; set; } = null!;


    [XmlElement(nameof(LastName))]
    [Required]
    [MinLength(CreatorLastNameMinLenght)]
    [MaxLength(CreatorLastNameMaxLenght)]
    public string LastName { get; set; } = null!;

    [XmlArray(nameof(Boardgames))]
    public ImportBoardgameDto[] Boardgames { get; set; } = null!;

}
