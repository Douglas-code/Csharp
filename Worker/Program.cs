using System;
using Exemplo.Entities;
using Exemplo.Entities.Enums;
using System.Globalization;

namespace Exemplo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter department's name: ");
            string name = Console.ReadLine();

            Department department = new Department(name);
            Console.WriteLine("Enter worker data: ");
            Console.Write("name: ");
            string workerName = Console.ReadLine();
            Console.Write("Level (Junior/MidLevel/Senior): ");
            WorkerLevel level = Enum.Parse<WorkerLevel>(Console.ReadLine());
            Console.Write("Base Salary: ");
            double baseSalary = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            Worker worker = new Worker(workerName, level, baseSalary, department);
            
            Console.WriteLine();
            Console.Write("How many contracts to this worker: ");
            int n = int.Parse(Console.ReadLine());
            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine($"Enter #{i} contract data: ");
                Console.Write("Date: ");
                DateTime date = DateTime.Parse(Console.ReadLine());
                Console.Write("Value per hour: ");
                double valuePerHour = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                Console.Write("Duration (hours): ");
                int duration = int.Parse(Console.ReadLine());
                HourContract contract = new HourContract(date, valuePerHour, duration);
                worker.AddContract(contract);
            }

            Console.WriteLine("Enter month and year to calculate income (MM/YYYY)");
            string dateMY = Console.ReadLine();
            int month = int.Parse(dateMY.Substring(0,2));
            int year = int.Parse(dateMY.Substring(3));
            Console.WriteLine("Name: " + worker.Name);
            Console.WriteLine("Department: " + worker.Department.Name);
            Console.WriteLine("Income: " + worker.Income(year, month).ToString("F2", CultureInfo.InvariantCulture));
        }
    }
}
