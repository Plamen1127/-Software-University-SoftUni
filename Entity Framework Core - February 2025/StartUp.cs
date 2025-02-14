using SoftUni.Data;
using System.Text;

namespace SoftUni
{



    public class StartUp
    {
        public static void Main()
        {
            var context = new SoftUniContext();
            Console.WriteLine(GetEmployeesFullInformation(context));

        }

        // problem 1

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
    }
}