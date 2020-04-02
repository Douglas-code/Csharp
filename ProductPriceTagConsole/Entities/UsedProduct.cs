using System;
using System.Globalization;

namespace ProductPriceTagConsole.Entities
{
    public class UsedProduct : Product
    {
        public DateTime Date { get; set; }

        public UsedProduct()
        {

        }

        public UsedProduct(string name, double price, DateTime date) : base(name, price)
        {
            Date = date;
        }

        public override string PriceTag()
        {
            return Name + " (used)  $" + Price.ToString("F2", CultureInfo.InvariantCulture)  + " (Manufacture date: " + Date.ToString("dd/MM/yyyy") + ")";
        }
    }
}