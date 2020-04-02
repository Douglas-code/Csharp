namespace ProductPriceTagConsole.Entities
{
    public class ImportedProduct : Product
    {
        public double CustomsFree { get; set; }

        public ImportedProduct()
        {

        }

        public ImportedProduct(string name, double price, double customsFree) : base(name, price)
        {
            CustomsFree = customsFree;
        }

        public override string PriceTag()
        {
            return base.PriceTag() + " (Customs free: $" + CustomsFree + ")";
        }

    }
}