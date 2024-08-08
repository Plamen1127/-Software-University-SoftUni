using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boardgames.Data.Models;

using static Data.DataConstrains;

public class Creator
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(CreatorFirstNameMaxLenght)]
    public string FirstName { get; set; } = null!;


    [Required]
    [MaxLength(CreatorLastNameMaxLenght)]
    public string LastName { get; set; } = null!;


    public virtual ICollection<Boardgame> Boardgames { get; set; } = new HashSet<Boardgame>();



}
