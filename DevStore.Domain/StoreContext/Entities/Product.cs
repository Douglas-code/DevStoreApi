namespace DevStore.Domain.StoreContext.Entities
{
    public class Product
    {
        public Product(string title, string description, string image, decimal price, int quantityOnHAnd)
        {
            this.Title = title;
            this.Description = description;
            this.Image = image;
            this.Price = price;
            this.QuantityOnHAnd = quantityOnHAnd;
        }

        public string Title { get; private set; }

        public string Description { get; private set; }

        public string Image { get; private set; }

        public decimal Price { get; private set; }

        public int QuantityOnHAnd { get; private set; }

        public void DecreaseQuantity(int quantity)
        {
            this.QuantityOnHAnd -= quantity;
        }

        public override string ToString()
        {
            return this.Title;
        }
    }
}
