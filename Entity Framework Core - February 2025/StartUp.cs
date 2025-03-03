using SoftUni.Data;
using SoftUni.Models;
using System.Text;

namespace SoftUni
{



    public class StartUp
    {
        public static void Main()
        {
            var context = new SoftUniContext();

            //Console.WriteLine(GetEmployeesFullInformation(contex)); //problem 3
            //Console.WriteLine(GetEmployeesWithSalaryOver50000(context)); //problem 4
            //Console.WriteLine(GetEmployeesFromResearchAndDevelopment(context)); //problem 5
           // Console.WriteLine(AddNewAddressToEmployee(context)); //problem 6
            //Console.WriteLine(GetEmployeesInPeriod(context)); //problem 7
            Console.WriteLine(GetAddressesByTown(context)); //problem 8

        }

        // problem 3

        public static string GetEmployeesFullInformation(SoftUniContext context)
        {
            // option 1 
            //return string.Join(Environment.NewLine, context.Employees
            //  .Select(e => $"{e.FirstName} {e.LastName} {e.MiddleName} {e.JobTitle} {e.Salary:f2}")
            //   .ToList());

            // option 2
            var employees = context.Employees
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    e.MiddleName,
                    e.JobTitle,
                    e.Salary
                })
                .ToList();

            StringBuilder sb = new StringBuilder();
            foreach (var e in employees)
            {
                sb.AppendLine($"{e.FirstName} {e.LastName} {e.MiddleName} {e.JobTitle} {e.Salary:f2}");
            }

            return sb.ToString().TrimEnd();
        }

        // problem 4

        public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
        {
            var richEmployees = context.Employees
                .Where(e => e.Salary > 50000)
                .Select(e => new
                {
                    e.FirstName,
                    e.Salary
                })
                .OrderBy(e => e.FirstName)
                .ToList();

            var sb = new StringBuilder();

            foreach (var e in richEmployees)
            {
                sb.AppendLine($"{e.FirstName} – {e.Salary:f2}");
            }

            return sb.ToString().TrimEnd();
        }

        // problem 5
        public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
        {

            var employees = context.Employees
                .Where(e=>e.Department.Name == "Research and Development")
                .Select(e=> new
                {
                    e.FirstName,
                    e.LastName,
                    e.Department,
                    e.Salary
                })
                .OrderBy(e=>e.Salary)
                .ThenByDescending(e => e.FirstName)
                .ToList();

            var sb = new StringBuilder();
            foreach (var e in employees)
            {
                sb.AppendLine($"{e.FirstName} {e.LastName} from {e.Department.Name} - ${e.Salary:f2}");
            }

            return sb.ToString().TrimEnd();
        }

        // problem 6
        public static string AddNewAddressToEmployee(SoftUniContext context)
        {
            Address newAddress = new Address
            {
                AddressText = "Vitoshka 15",
                TownId = 4
            };

            var nakov = context.Employees
                .FirstOrDefault(e => e.LastName == "Nakov");

            if (nakov != null)
            {
                nakov.Address = newAddress;
                context.SaveChanges();
            }

            var employee = context.Employees
                .OrderByDescending(e => e.AddressId)
                .Take(10)
                .Select(e=> e.Address.AddressText) 
                .ToList();

            return string.Join(Environment.NewLine, employee);
        }

        // problem 7
        public static string GetEmployeesInPeriod(SoftUniContext context)
        {

            var result = context.Employees
                .Take(10)
                .Select(e => new
                {
                    EmployeeNames = $"{e.FirstName} {e.LastName}",
                    ManigerNames = $"{e.Manager.FirstName} {e.Manager.LastName}",
                    Projects = e.EmployeesProjects
                    .Where(em => em.Project.StartDate.Year >= 2001 && em.Project.StartDate.Year <= 2003)
                    .Select(p => new
                    {
                        ProjectName = p.Project.Name,
                        p.Project.StartDate,
                        EndDay = p.Project.EndDate.HasValue ? p.Project.EndDate.Value.ToString("M/d/yyyy h:mm:ss tt") :
                        "not finished"
                    })
                    
                });

            StringBuilder sb = new StringBuilder();

            foreach (var e in result) 
            { 
                sb.AppendLine($"{e.EmployeeNames} - Manager: {e.ManigerNames}");
                if (e.Projects.Any())
                {
                    foreach (var p in e.Projects)
                    {
                        sb.AppendLine($"--{p.ProjectName} - {p.StartDate:M/d/yyyy h:mm:ss tt} - {p.EndDay}");
                        
                    }
                }
            }




            return sb.ToString().TrimEnd();
        }

        // problem 8
        public static string GetAddressesByTown(SoftUniContext context)
        {

            var result = context.Addresses
                .Select(a => new
                {
                    Text = a.AddressText,
                    TownName = a.Town.Name,
                    EmployeeCount = a.Employees.Count()
                })
                .OrderByDescending(e => e.EmployeeCount)
                .ThenBy(e => e.TownName)
                .ThenBy(e => e.Text)
                .Take(10)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var e in result)
            {
                sb.AppendLine($"{e.Text}, {e.TownName} - {e.EmployeeCount} employees");
            }

            return sb.ToString().TrimEnd();
        }

    }
}