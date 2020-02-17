using Microsoft.EntityFrameworkCore;
using SoftUni.Data;
using SoftUni.Models;
using System;
using System.Linq;
using System.Text;

namespace SoftUni
{
    public class StartUp
    {
        public static void Main()
        {
            var context = new SoftUniContext();

            var result = GetEmployeesInPeriod(context);

            Console.WriteLine(result);
        }
        public static string GetEmployeesFullInformation(SoftUniContext context)
        {
            var sb = new StringBuilder();

            var employees = context.Employees
                .OrderBy(e => e.EmployeeId)
                .Select(e => new { e.FirstName, e.MiddleName, e.LastName, e.JobTitle, e.Salary });

            foreach (var e in employees)
            {
                sb.AppendLine($"{e.FirstName} {e.LastName} {e.MiddleName} {e.JobTitle} {e.Salary:f2}");
            }

            return sb.ToString().TrimEnd();
        }
        public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
        {
            var sb = new StringBuilder();

            var employees = context.Employees
                .Where(e => e.Salary > 50000)
                .OrderBy(e => e.FirstName)
                .Select(e => new { e.FirstName, e.Salary });

            foreach (var e in employees)
            {
                sb.AppendLine($"{e.FirstName} - {e.Salary:f2}");
            }

            return sb.ToString().Trim();
        }
        public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
        {
            var sb = new StringBuilder();

            var employees = context.Employees
                .Select(e => new { e.FirstName, e.LastName, e.Department.Name, e.Salary })
                .Where(d => d.Name == "Research and Development")
                .OrderBy(e => e.Salary)
                .ThenByDescending(e => e.FirstName);

            foreach (var e in employees)
            {
                sb.AppendLine($"{e.FirstName} {e.LastName} from {e.Name} - ${e.Salary:f2}");
            }

            return sb.ToString().Trim();

        }
        public static string AddNewAddressToEmployee(SoftUniContext context)
        {
            var sb = new StringBuilder();

            var address = new Address { AddressText = "Vitoshka 15", TownId = 4, };

            var nakov = context.Employees.First(e => e.LastName == "Nakov");

            nakov.Address = address;

            context.SaveChanges();

            var employees = context.Employees
                .OrderByDescending(e => e.AddressId)
                .Take(10)
                .Select(e => e.Address.AddressText);

            sb.Append(string.Join(Environment.NewLine, employees));

            return sb.ToString().Trim();
        }
        public static string GetEmployeesInPeriod(SoftUniContext context)
        {
            var employees = context.Employees.Where(e => e.EmployeesProjects.Any(ep => ep.Project.StartDate.Year >= 2001 && ep.Project.StartDate.Year <= 2003))
               .Select(e => new
               {
                   FirstName = e.FirstName,
                   LastName = e.LastName,
                   ManagerFirstName = e.Manager.FirstName,
                   ManagerLastName = e.Manager.LastName,
                   Projects = e.EmployeesProjects.Select(ep => new
                   {
                       ProjectName = ep.Project.Name,
                       ProjectStartDate = ep.Project.StartDate,
                       ProjectEndDate = ep.Project.EndDate
                   })
               }).Take(10);

            StringBuilder employeeManagerResult = new StringBuilder();

            foreach (var employee in employees)
            {
                employeeManagerResult.AppendLine($"{employee.FirstName} {employee.LastName} - Manager: {employee.ManagerFirstName} {employee.ManagerLastName}");

                foreach (var project in employee.Projects)
                {
                    var startDate = project.ProjectStartDate.ToString("M/d/yyyy h:mm:ss tt");
                    var endDate = project.ProjectEndDate.HasValue ? project.ProjectEndDate.Value.ToString("M/d/yyyy h:mm:ss tt") : "not finished";

                    employeeManagerResult.AppendLine($"--{project.ProjectName} - {startDate} - {endDate}");
                }
            }
            return employeeManagerResult.ToString().TrimEnd();
        }
       
        public static string GetAddressesByTown(SoftUniContext context)
        {
            var sb = new StringBuilder();

            var addresses = context.Addresses
                .Select(x => new { Address = x.AddressText, Town = x.Town.Name, EmployeesCount = x.Employees.Count })
                .OrderByDescending(x => x.EmployeesCount)
                .ThenBy(x => x.Town)
                .ThenBy(x => x.Address)
                .Take(10);

            foreach (var a in addresses)
            {
                sb.AppendLine($"{a.Address}, {a.Town} - {a.EmployeesCount} employees");
            }

            return sb.ToString().Trim();
        }
        public static string GetEmployee147(SoftUniContext context)
        {
            var sb = new StringBuilder();

            var employee = context.Employees
                .First(x => x.EmployeeId == 147);

            sb.AppendLine($"{employee.FirstName} {employee.LastName} - {employee.JobTitle}");

            var employeeProject = context.EmployeesProjects
                .Where(x => x.EmployeeId == 147)
                .OrderBy(x => x.Project.Name)
                .Select(x => x.Project.Name);

            foreach (var x in employeeProject)
            {
                sb.AppendLine(x);
            }

            return sb.ToString().Trim();
        }
        public static string GetDepartmentsWithMoreThan5Employees(SoftUniContext context)
        {
            var sb = new StringBuilder();

            var departments = context.Departments
                .Where(x => x.Employees.Count > 5)
                .Select(x => new { x.Manager, x.Name, x.Employees })
                .OrderBy(x => x.Employees.Count)
                .ThenBy(x => x.Name);

            foreach (var x in departments)
            {
                sb.AppendLine($"{x.Name} - {x.Manager.FirstName} {x.Manager.LastName}");

                foreach (var y in x.Employees.OrderBy(y => y.FirstName).ThenBy(y => y.LastName))
                {
                    sb.AppendLine($"{y.FirstName} {y.LastName} - {y.JobTitle}");
                }
            }

            return sb.ToString().Trim();
        }
        public static string GetLatestProjects(SoftUniContext context)
        {
            var sb = new StringBuilder();

            var projects = context.Projects
                .OrderByDescending(x => x.StartDate)
                .Take(10)
                .OrderBy(x => x.Name);

            foreach (var x in projects)
            {
                sb.AppendLine(x.Name)
                    .AppendLine(x.Description)
                    .AppendLine(string.Format("{0:G}", x.StartDate));
            }

            return sb.ToString().Trim();
        }
        public static string IncreaseSalaries(SoftUniContext context)
        {
            var sb = new StringBuilder();

            var employees = context.Employees
                .Where(e => e.Department.Name == "Engineering"
                || e.Department.Name == "Tool Design"
                || e.Department.Name == "Marketing"
                || e.Department.Name == "Information Services");

            foreach (var e in employees)
            {
                e.Salary *= 1.12m;
            }

            context.SaveChanges();

            var result = employees
                .OrderBy(e => e.FirstName)
                .ThenBy(e => e.LastName)
                .Select(e => new { e.FirstName, e.LastName, e.Salary });

            foreach (var e in result)
            {
                sb.AppendLine($"{e.FirstName} {e.LastName} (${e.Salary:f2})");
            }

            return sb.ToString().Trim();
        }
        public static string GetEmployeesByFirstNameStartingWithSa(SoftUniContext context)
        {
            var sb = new StringBuilder();

            var employees = context.Employees
                .Where(e => e.FirstName.StartsWith("Sa"))
                .Select(e => new { e.FirstName, e.LastName, e.JobTitle, e.Salary })
                .OrderBy(e => e.FirstName)
                .ThenBy(e => e.LastName);

            foreach (var e in employees)
            {
                sb.AppendLine($"{e.FirstName} {e.LastName} - {e.JobTitle} - (${e.Salary:f2})");
            }

            return sb.ToString().Trim();
        }
        public static string DeleteProjectById(SoftUniContext context)
        {
            var sb = new StringBuilder();

            var project = context.Projects.Find(2);

            var projectsToRemove = context.EmployeesProjects
                .Where(p => p.ProjectId == 2);

            foreach (var p in projectsToRemove)
            {
                context.EmployeesProjects.Remove(p);
            }

            context.Projects.Remove(project);

            context.SaveChanges();

            var result = context.Projects
                .Select(x => x.Name)
                .Take(10);

            foreach (var e in result)
            {
                sb.AppendLine(e);
            }

            return sb.ToString().Trim();
        }
        public static string RemoveTown(SoftUniContext context)
        {
            var empFromSeattle = context.Employees
                .Where(e => e.Address.Town.Name == "Seattle");

            foreach (var e in empFromSeattle)
            {
                e.Address = null;
            }

            var addressesToRemove = context.Addresses
                .Where(a => a.Town.Name == "Seattle");

            var numberOfAdresses = addressesToRemove.Count();

            context.Addresses.RemoveRange(addressesToRemove);

            var townToRemove = context.Towns
                .Where(t => t.Name == "Seattle")
                .First();

            context.Towns.Remove(townToRemove);

            context.SaveChanges();

            return $"{numberOfAdresses} addresses in Seattle were deleted";
        }
    }
}
