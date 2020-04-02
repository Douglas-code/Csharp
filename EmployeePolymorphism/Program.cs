using System;
using System.Collections.Generic;
using EmployeePolymorphism.Entities;
using System.Globalization;

namespace EmployeePolymorphism
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Employee> listEmployee = new List<Employee>();

            Console.Write("Enter the number of employees: ");
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine($"Employee #{i} data: ");
                Console.Write("Outsourced (y/n)? ");
                char ch = char.Parse(Console.ReadLine());
                Console.Write("Name: ");
                string name = Console.ReadLine();
                Console.Write("Hour: ");
                int hours = int.Parse(Console.ReadLine());
                Console.Write("Value Per Hour: ");
                double valuePerHour = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                if (ch == 'y')
                {
                    Console.Write("Additional charge: ");
                    double additionalCharge = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                    listEmployee.Add(new OutsourcedEmployee(name, hours, valuePerHour, additionalCharge));
                }
                else
                {
                    listEmployee.Add(new Employee(name, hours, valuePerHour));
                }
            }

            Console.WriteLine();
            Console.WriteLine("PAYMENTS: ");

            foreach(Employee emp in listEmployee){
                Console.WriteLine(emp.Name + " - $ " + emp.Payment().ToString("F2", CultureInfo.InvariantCulture));
            }
        }
    }
}
