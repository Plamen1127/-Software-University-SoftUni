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
            //Console.WriteLine(GetAddressesByTown(context)); //problem 8
            //Console.WriteLine(GetEmployee147(context)); //problem 9
            //Console.WriteLine(GetDepartmentsWithMoreThan5Employees(context)); //problem 10
            //Console.WriteLine(GetLatestProjects(context)); //problem 11
            //Console.WriteLine(IncreaseSalaries(context)); //problem 12
            Console.WriteLine(GetEmployeesByFirstNameStartingWithSa(context)); //problem 13


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
                .Where(e => e.Department.Name == "Research and Development")
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    e.Department,
                    e.Salary
                })
                .OrderBy(e => e.Salary)
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
                .Select(e => e.Address.AddressText)
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

        // problem 9
        public static string GetEmployee147(SoftUniContext context)
        {
            var getEmployee = context.Employees
                .Where(e => e.EmployeeId == 147)
                .Select(e => new
                {
                    FirrstName = e.FirstName,
                    LastName = e.LastName,
                    JobTitle = e.JobTitle,
                    Projectse = e.EmployeesProjects
                    .Select(p => p.Project.Name)
                   
                })
                .FirstOrDefault();

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{getEmployee.FirrstName} {getEmployee.LastName} - {getEmployee.JobTitle}");

            foreach (var e in getEmployee.Projectse.OrderBy(p => p))
            {
                sb.AppendLine(e);
            }

            return sb.ToString().TrimEnd();
        }

        // problem 10
        public static string GetDepartmentsWithMoreThan5Employees(SoftUniContext context)
        {
            var result = context.Departments
                .Where(d => d.Employees.Count > 5)
                .Select(d => new
                {
                    DepartmentName = d.Name,
                    ManagerFirstName = d.Manager.FirstName,
                    ManagerLastName = d.Manager.LastName,
                    Employees = d.Employees
                    .Select(e => new
                    {
                        FirstName = e.FirstName,
                        LastName = e.LastName,
                        JobTaite = e.JobTitle,
                    })
                })
                .OrderBy(e => e.Employees.Count());

            StringBuilder sb = new StringBuilder();

            foreach (var d in result)
            {
                sb.AppendLine($"{d.DepartmentName} - {d.ManagerFirstName} {d.ManagerLastName}");

                foreach(var e in d.Employees.OrderBy(e=>e.FirstName).ThenBy(e => e.LastName))
                {
                    sb.AppendLine($"{e.FirstName} {e.LastName} - {e.JobTaite}");
                }
            }

            return sb.ToString().TrimEnd();
                
        }

        // problem 11
        public static string GetLatestProjects(SoftUniContext context)
        {
            var result = context.Projects
                .OrderByDescending(p => p.StartDate)
                .Select(p => new
                {
                    Name = p.Name,
                    Description = p.Description,
                    StartDate = p.StartDate
                })
                .Take(10);

            StringBuilder sb = new StringBuilder();

            foreach (var d in result.OrderBy(p=>p.Name))
            {
                sb.AppendLine($"{d.Name}");
                sb.AppendLine($"{d.Description}");
                sb.AppendLine($"{d.StartDate:M/d/yyyy h:mm:ss tt}");
            }

            return sb.ToString().TrimEnd();
        }

        // problem 12
        public static string IncreaseSalaries(SoftUniContext context)
        {

            var result = context.Employees
                .Where(e => e.Department.Name == "Engineering" || e.Department.Name == "Tool Design" || e.Department.Name == "Marketing" || e.Department.Name == "Information Services")
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    Selary = e.Salary * 1.12m,
                })
                .OrderBy(e => e.FirstName)
                .ThenBy(e => e.LastName);

            StringBuilder sb = new StringBuilder();

            foreach (var e in result)
            {
                sb.AppendLine($"{e.FirstName} {e.LastName} (${e.Selary:f2})");
            }

            return sb .ToString().TrimEnd();
        }

        // problem 13
        public static string GetEmployeesByFirstNameStartingWithSa(SoftUniContext context)
        {
            var result = context.Employees
                .Where(e=>e.FirstName.StartsWith("Sa"))
                .Select(e => new
                {
                    e.FirstName, 
                    e.LastName,
                    e.JobTitle,
                    e.Salary
                })
                .OrderBy(e => e.FirstName)
                .ThenBy(e => e.LastName);

            StringBuilder sb = new StringBuilder();

            foreach (var e in result)
            {
                sb.AppendLine($"{e.FirstName} {e.LastName} - {e.JobTitle} - (${e.Salary:f2})");
            }

            return sb.ToString().TrimEnd();
        }
    }
}