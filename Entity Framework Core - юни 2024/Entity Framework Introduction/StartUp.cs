
using Microsoft.EntityFrameworkCore;
using SoftUni.Data;
using SoftUni.Models;
using System.Text;

public class StartUp
{

    public static void Main()
    {
        var contex = new SoftUniContext();
        //Console.WriteLine(GetEmployeesFullInformation(contex)); //problem 3
        //Console.WriteLine(GetEmployeesWithSalaryOver50000(contex)); //problem 4
        //Console.WriteLine(GetEmployeesFromResearchAndDevelopment(contex)); //problem 5
        //Console.WriteLine(AddNewAddressToEmployee(contex)); //problem 6
        //Console.WriteLine(GetEmployeesInPeriod(contex)); //problem 7
        //Console.WriteLine(GetAddressesByTown(contex)); //problem 8
        //Console.WriteLine(GetEmployee147(contex)); //problem 9
        // Console.WriteLine(GetDepartmentsWithMoreThan5Employees(contex)); //problem 10
        //Console.WriteLine(GetLatestProjects(contex)); //problem 11
        //Console.WriteLine(IncreaseSalaries(contex)); //problem 12
        // Console.WriteLine(GetEmployeesByFirstNameStartingWithSa(contex)); //problem 13
        //Console.WriteLine(DeleteProjectById(contex)); //problem 13


    }

    //problem 3
    public static string GetEmployeesFullInformation(SoftUniContext context)
    {
        //option 1
        // return string.Join(Environment.NewLine, context.Employees
        // .Select(e => $"{e.FirstName} {e.LastName} {e.MiddleName} {e.JobTitle} {e.Salary:f2}")
        //  .ToList());


        //option 2
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

        var sb = new StringBuilder();

        foreach (var employee in employees)
        {
            sb.AppendLine($"{employee.FirstName} {employee.LastName} {employee.MiddleName} {employee.JobTitle} {employee.Salary:f2}");
        }

        return sb.ToString().TrimEnd();

    }

    //problem 4
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
        var employes = context.Employees
            .Select(e => new
            {
                e.FirstName,
                e.LastName,
                e.Department,
                e.Salary
            })
            .Where(e => e.Department.Name == "Research and Development")
            .OrderBy(e => e.Salary)
            .ThenByDescending(e => e.FirstName)
            .ToList();

        var sb = new StringBuilder();
        foreach (var e in employes)
        {
            sb.AppendLine($"{e.FirstName} {e.LastName} from {e.Department.Name} - ${e.Salary:f2}");
        }

        return sb.ToString().TrimEnd();
    }

    //problem 6
    public static string AddNewAddressToEmployee(SoftUniContext context)
    {
        Address newAddress = new Address()
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

        var employees = context.Employees
            .OrderByDescending(e => e.AddressId)
            .Take(10)
            .Select(e => e.Address.AddressText);

        return string.Join(Environment.NewLine, employees);

    }

    //problem 7
    public static string GetEmployeesInPeriod(SoftUniContext context)
    {

        var result = context.Employees
            .Take(10)
            .Select(e => new
            {
                EmployeeName = $"{e.FirstName} {e.LastName}",
                ManagerName = $"{e.Manager.FirstName} {e.Manager.LastName}",
                Projects = e.EmployeesProjects
                .Where(ep => ep.Project.StartDate.Year >= 2001 && ep.Project.StartDate.Year <= 2003)
                .Select(ep => new
                {
                    ep.Project.Name,
                    ep.Project.StartDate,
                    EndDate = ep.Project.EndDate.HasValue ? ep.Project.EndDate.Value.ToString("M/d/yyyy h:mm:ss tt") :
                    "not finished"
                })
            });

        var sb = new StringBuilder();
        foreach (var e in result)
        {
            sb.AppendLine($"{e.EmployeeName} - Manager: {e.ManagerName}");
            if (e.Projects.Any())
            {
                foreach (var p in e.Projects)
                {
                    sb.AppendLine($"--{p.Name} - {p.StartDate:M/d/yyyy h:mm:ss tt} - {p.EndDate}");
                }
            }
        }

        return sb.ToString().TrimEnd();
    }


    //problem 8
    public static string GetAddressesByTown(SoftUniContext context)
    {
        var adress = context.Addresses
            .Select(a => new
            {
                Text = a.AddressText,
                Town = a.Town.Name,
                EmployeeCount = a.Employees.Count()
            })
            .OrderByDescending(a => a.EmployeeCount)
            .ThenBy(a => a.Town)
            .ThenBy(a => a.Text)
            .Take(10)
            .ToList();

        var sb = new StringBuilder();

        foreach (var e in adress)
        {
            sb.AppendLine($"{e.Text}, {e.Town} - {e.EmployeeCount} employees");
        }

        return sb.ToString().TrimEnd();
    }

    //problem 9 
    public static string GetEmployee147(SoftUniContext context)
    {
        var employee147 = context.Employees
            .Where(e => e.EmployeeId == 147)
            .Select(e => new
            {
                FirstName = e.FirstName,
                LastName = e.LastName,
                JobTitle = e.JobTitle,
                Projects = e.EmployeesProjects
                .Select(ep => ep.Project.Name)
            })
            .FirstOrDefault();

        var sb = new StringBuilder();

        sb.AppendLine($"{employee147.FirstName} {employee147.LastName} - {employee147.JobTitle}");

        foreach (var e in employee147.Projects.OrderBy(p => p))
        {
            sb.AppendLine(e);
        }
        return sb.ToString().TrimEnd();
    }

    //problem 10
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
                    JobTitle = e.JobTitle,
                })
            })
            .OrderBy(d => d.Employees.Count())
            .ThenBy(d => d.DepartmentName)
            .Take(10);

        var sb = new StringBuilder();

        foreach (var d in result)
        {
            sb.AppendLine($"{d.DepartmentName} - {d.ManagerFirstName}  {d.ManagerLastName}");

            foreach (var e in d.Employees.OrderBy(e => e.FirstName).ThenBy(e => e.LastName))
            {
                sb.AppendLine($"{e.FirstName} {e.LastName} - {e.JobTitle}");
            }
        }

        return sb.ToString().TrimEnd();
    }

    //problem 11
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


        var sb = new StringBuilder();
        foreach (var d in result.OrderBy(d => d.Name))
        {
            sb.AppendLine(d.Name);
            sb.AppendLine(d.Description);
            sb.AppendLine($"{d.StartDate:M/d/yyyy h:mm:ss tt}");

        }
        return sb.ToString().TrimEnd();
    }

    //problem 12
    public static string IncreaseSalaries(SoftUniContext context)
    {
        var employeesIncreaseSalaries = context.Employees
            .Where(e => e.Department.Name == "Engineering" || e.Department.Name == "Tool Design" || e.Department.Name == "Marketing" || e.Department.Name == "Information Services")
            .Select(e => new
            {
                FirstName = e.FirstName,
                LastName = e.LastName,
                Salary = e.Salary * 1.12m,
            })
            .OrderBy(e => e.FirstName)
            .ThenBy(e => e.LastName);

        var sb = new StringBuilder();

        foreach (var e in employeesIncreaseSalaries)
        {
            sb.AppendLine($"{e.FirstName} {e.LastName} (${e.Salary:f2})");
        }

        return sb.ToString().TrimEnd();
    }


    //problem 13
    public static string GetEmployeesByFirstNameStartingWithSa(SoftUniContext context)
    {
        var result = context.Employees
            .Where(e => e.FirstName.StartsWith("Sa"))
            .Select(e => new
            {
                FirstName = e.FirstName,
                LastName = e.LastName,
                JobTitle = e.JobTitle,
                Salary = e.Salary
            })
            .OrderBy(e => e.FirstName)
            .ThenBy(e => e.LastName)
            .ToList();

        var sb = new StringBuilder();

        foreach (var e in result)
        {
            sb.AppendLine($"{e.FirstName} {e.LastName} - {e.JobTitle} - (${e.Salary:f2})");
        }
        return sb.ToString().TrimEnd();
    }

    //problem 14
    public static string DeleteProjectById(SoftUniContext context)
    {

        var epToDelet = context.EmployeesProjects
            .Where(ep => ep.ProjectId == 2);

        context.EmployeesProjects.RemoveRange(epToDelet);
        var projectToDelet = context.Projects.Find(2);
        if (projectToDelet != null)
        {
            context.Projects.Remove(projectToDelet);
            context.SaveChanges();
        }


        var project = context.Projects
            .Select(p => p.Name)
            .Take(10);

        return string.Join(Environment.NewLine, project);
    }

    //problem 15
    public static string RemoveTown(SoftUniContext context)
    {
        var adressToDelete = context.Addresses
                   .Where(a => a.Town.Name == "Seattle")
                   .ToList();
        context.Addresses.RemoveRange(adressToDelete);

        var townToDelete = context.Towns
            .Where(t => t.Name == "Seattle")
            .FirstOrDefault();

        context.Towns.Remove(townToDelete);

        context.SaveChanges();

        return $"{adressToDelete.Count} addresses in Seattle were deleted";
    }

}