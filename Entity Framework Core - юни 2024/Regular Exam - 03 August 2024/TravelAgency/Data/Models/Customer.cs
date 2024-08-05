using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgency.Data.Models;

using static Data.DataConstrains;

public class Customer
{
    [Key]
    public int Id { get; set; }


    [Required]
    [MaxLength(CustomerFullNameMaxLenght)]
    public string FullName { get; set; } = null!;


    [Required]
    [MaxLength(CustomerImeilMaxLenght)]
    public string Email { get; set; } = null!;


    [Required]
    [StringLength(13, MinimumLength = 13)]
    [RegularExpression(@"\+\d{12}")]
    public string PhoneNumber  { get; set; } = null!;

    public virtual ICollection<Booking> Bookings { get; set; } = new HashSet<Booking>();
}
