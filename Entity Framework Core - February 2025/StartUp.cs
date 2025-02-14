using SoftUni.Data;
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
            Console.WriteLine(GetEmployeesFromResearchAndDevelopment(context)); //problem 5

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

    }
}