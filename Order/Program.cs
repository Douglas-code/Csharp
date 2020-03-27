using System;
using Ex.Entities.Enums;
using Ex.Entities;
using System.Globalization;

namespace Ex
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter  client data: ");
            Console.Write("Name: ");
            string clientName = Console.ReadLine();
            Console.Write("Email: ");
            string clientEmail = Console.ReadLine();
            Console.Write("BirthDate: ");
            DateTime birth = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Enter order data: ");
            Console.Write("status: ");
            OrderStatus status = Enum.Parse<OrderStatus>(Console.ReadLine());

            Client client = new Client(clientName, clientEmail, birth);
            Order order = new Order(DateTime.Now, status, client);


            Console.Write("How many items to the order: ");
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine($"Enter #{i} item data: ");
                Console.Write("Product name: ");
                string productName = Console.ReadLine();
                Console.Write("Product Price: ");
                double price = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                Product product = new Product(productName, price);
                Console.Write("Quantity: ");
                int quantity = int.Parse(Console.ReadLine());

                OrderItem item = new OrderItem(quantity, price, product);
                order.AddItem(item);
            }

            Console.WriteLine();
            Console.WriteLine("Order Sumary: ");
            Console.WriteLine(order);
        }
    }
}
