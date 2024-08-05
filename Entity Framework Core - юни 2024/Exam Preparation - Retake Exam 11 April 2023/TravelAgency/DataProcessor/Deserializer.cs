using Microsoft.VisualBasic;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Text;
using TravelAgency.Data;
using TravelAgency.Data.Models;
using TravelAgency.DataProcessor.ImportDtos;
using TravelAgency.Utilitis;

namespace TravelAgency.DataProcessor
{
    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data format!";
        private const string DuplicationDataMessage = "Error! Data duplicated.";
        private const string SuccessfullyImportedCustomer = "Successfully imported customer - {0}";
        private const string SuccessfullyImportedBooking = "Successfully imported booking. TourPackage: {0}, Date: {1}";

        public static string ImportCustomers(TravelAgencyContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();
            XmlHelper xmlHelper = new XmlHelper();
            const string xmlRoot = "Customers";

            ICollection<Customer> customerToInport = new List<Customer>();

            ImportCustomersDto[] deserelizerCustomers =
                xmlHelper.Deserialize<ImportCustomersDto[]>(xmlString, xmlRoot);

            foreach (ImportCustomersDto customerDto in deserelizerCustomers)
            {

                if (!IsValid(customerDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                if ((customerToInport.Any(c => c.FullName == customerDto.FullName)) ||
                    (customerToInport.Any(c => c.PhoneNumber == customerDto.PhoneNumber)) ||
                    (customerToInport.Any(c => c.Email == customerDto.Email)))
                {
                    sb.AppendLine(DuplicationDataMessage);
                    continue;
                }
                if ((context.Customers.Any(c => c.FullName == customerDto.FullName)) ||
                    (context.Customers.Any(c => c.PhoneNumber == customerDto.PhoneNumber)) ||
                    (context.Customers.Any(c => c.Email == customerDto.Email)))
                {
                    sb.AppendLine(DuplicationDataMessage);
                    continue;
                }



                Customer newCustumer = new Customer()
                {
                    PhoneNumber= customerDto.PhoneNumber,
                    FullName= customerDto.FullName,
                    Email= customerDto.Email,
                };

                customerToInport.Add(newCustumer);
                sb.AppendLine(string.Format(SuccessfullyImportedCustomer, newCustumer.FullName));

            }
            context.Customers.AddRange(customerToInport);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportBookings(TravelAgencyContext context, string jsonString)
        {
            ICollection<Booking> bookingToInport = new List<Booking>();

            StringBuilder sb = new StringBuilder();
            ImportBookingDto[] deserializerBooking =
                JsonConvert.DeserializeObject<ImportBookingDto[]>(jsonString)!;

            foreach (ImportBookingDto bookingDto in deserializerBooking)
            {
                if (!IsValid(bookingDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                bool isIssueDateValid = DateTime
                   .TryParseExact(bookingDto.BookingDate, "yyyy-MM-dd",  CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime issueDate);
                if (isIssueDateValid == false )
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var customerId = context.Customers.FirstOrDefault(c => c.FullName == bookingDto.CustomerName).Id;
                var tourpackageId = context.TourPackages.FirstOrDefault(tp=>tp.PackageName==bookingDto.TourPackageName).Id;


                if (customerId == 0 || tourpackageId == 0)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Booking newBooking = new Booking()
                {
                    BookingDate = issueDate,
                    CustomerId = customerId,
                    TourPackageId = tourpackageId
                };

                bookingToInport.Add(newBooking);
                sb.AppendLine(string.Format(SuccessfullyImportedBooking, bookingDto.TourPackageName, bookingDto.BookingDate ));


            }

            context.Bookings.AddRange(bookingToInport);
            context.SaveChanges();

            return sb.ToString();

        }

            public static bool IsValid(object dto)
        {
            var validateContext = new ValidationContext(dto);
            var validationResults = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(dto, validateContext, validationResults, true);

            foreach (var validationResult in validationResults)
            {
                string currValidationMessage = validationResult.ErrorMessage;
            }

            return isValid;
        }
    }
}
