using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Linq;
using TravelAgency.Data;
using TravelAgency.Data.Models;
using TravelAgency.DataProcessor.ExportDtos;
using TravelAgency.Utilitis;

namespace TravelAgency.DataProcessor
{
    public class Serializer
    {
        public static string ExportGuidesWithSpanishLanguageWithAllTheirTourPackages(TravelAgencyContext context)
        {
            XmlHelper xmlHelper = new XmlHelper();
            const string xmlRoot = "Guides";

            ExportGuidesDto[] guidesToExport = context.Guides
                .Where(g => (int)g.Language == 3)
                .Include(g => g.TourPackagesGuides)
                .Select(g => new ExportGuidesDto()
                {
                    FullName = g.FullName,
                    TourPackages = g.TourPackagesGuides
                    .Select(tp => new ExportTourPackagesDto()
                    {
                        Name = tp.TourPackage.PackageName,
                        Description = tp.TourPackage.Description,
                        Price = tp.TourPackage.Price
                    })
                    .OrderByDescending(tp=>tp.Price)
                    .ThenBy(tp=>tp.Name)
                    .ToArray()
                })
                .OrderByDescending(g => g.TourPackages.Count())
                .ThenBy(g=>g.FullName)
                .ToArray();

            return xmlHelper.Serialize(guidesToExport, xmlRoot);
        }

        public static string ExportCustomersThatHaveBookedHorseRidingTourPackage(TravelAgencyContext context)
        {
            ExportCustomerDto[] customersToExpoert = context.Customers
                .Where(c => c.Bookings.Any(b => b.TourPackage.PackageName == "Horse Riding Tour"))
                .Select(c => new ExportCustomerDto()
                {
                    FullName = c.FullName,
                    PhoneNumber = c.PhoneNumber,
                    Bookings = c.Bookings
                    .Where(b=> b.TourPackage.PackageName == "Horse Riding Tour")
                    .OrderBy(c=>c.BookingDate)
                    .Select(b => new ExportBookingDto()
                    {
                        TourPackageName = "Horse Riding Tour",
                        Date = b.BookingDate.ToString("yyyy-MM-dd"),


                    })
                    .ToArray()
                })
                .OrderByDescending(b=>b.Bookings.Length)
                .ThenBy(c=>c.FullName)
               
                .ToArray ();

            return JsonConvert.SerializeObject(customersToExpoert, Formatting.Indented);

        }
    }
}
