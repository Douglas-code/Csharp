using System.Globalization;
using System;
using System.Collections.Generic;
using EmployeeLinqConsole.Entities;
using System.IO;
using System.Linq;

namespace EmployeeLinqConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = "Files/in.txt";
            Console.WriteLine("File full path: " + Path.GetFullPath(path));
            Console.Write("Enter Salary: ");
            double salaryEmp = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            List<Employee> employees = new List<Employee>();

            using (StreamReader streamReader = File.OpenText(path))
            {
                while (!streamReader.EndOfStream)
                {
                    string[] fields = streamReader.ReadLine().Split(",");
                    string name = fields[0];
                    string email = fields[1];
                    double salary = double.Parse(fields[2], CultureInfo.InvariantCulture);
                    employees.Add(new Employee(name, email, salary));
                }
            }

            Console.WriteLine();
            Console.WriteLine("Employees: ");
            foreach (Employee e in employees)
            {
                Console.WriteLine(e);
            }

            Console.WriteLine();
            var moreThanSalary = employees.Where(e => e.Salary > salaryEmp).OrderBy(e => e.Name).Select(e => e.Email).ToList();
            Console.WriteLine("Email of people whose salary is more than " + salaryEmp.ToString("F2", CultureInfo.InvariantCulture) + ": ");
            foreach (string str in moreThanSalary)
            {
                Console.WriteLine(str);
            }

            Console.WriteLine();
            var sum = employees.Where(e => e.Name[0] == 'M' || e.Name[0] == 'm').Select(e => e.Salary).DefaultIfEmpty(0.0).Sum();
            Console.WriteLine("Sum of salary of people whose name starts with 'M': " + sum.ToString("F2", CultureInfo.InvariantCulture));
        }
    }
}
