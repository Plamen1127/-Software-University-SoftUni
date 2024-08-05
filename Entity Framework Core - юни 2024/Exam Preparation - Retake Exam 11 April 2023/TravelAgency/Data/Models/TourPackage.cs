using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgency.Data.Models;
using static Data.DataConstrains;

public class TourPackage
{
    
    public int Id { get; set; }

    [Required]
    [MaxLength(TourPackageNameMaxLenght)]
    public string PackageName { get; set; } = null!;


    [MaxLength(DescriptionMaxLenght)]
    public string? Description  { get; set; }

    [Required]
    public decimal Price  { get; set; }

    public virtual ICollection<TourPackageGuide> TourPackagesGuides { get; set; }   = new HashSet<TourPackageGuide>();

    public virtual ICollection<Booking> Bookings { get; set; } = new HashSet<Booking>();
}

