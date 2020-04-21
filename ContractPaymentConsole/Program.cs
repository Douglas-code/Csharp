using ContractPaymentConsole.Entities;
using ContractPaymentConsole.Services;
using System.Globalization;
using System;

namespace ContractPaymentConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Enter contract data");
                Console.Write("Number: ");
                int number = int.Parse(Console.ReadLine());
                Console.Write("Date (dd/MM/yyyy): ");
                DateTime date = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                Console.Write("Contract value: ");
                double totalValue = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                Console.Write("Enter number of installments: ");
                int numberInstallments = int.Parse(Console.ReadLine());

                Contract contract = new Contract(number, date, totalValue);
                ContractService contractService = new ContractService(new PaypalService());
                contractService.ProcessContract(contract, numberInstallments);

                Console.WriteLine();
                Console.WriteLine("INSTALLMENTS: ");
                foreach (Installment installments in contract.Installments)
                {
                    Console.WriteLine(installments);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
