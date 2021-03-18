namespace DevStore.Domain.StoreContext.Entities
{
    public class OrderItem
    {
        public OrderItem(Product product, int quantity)
        {
            Product = product;
            Quantity = quantity;
            Price = product.Price;
        }

        public Product Product { get; private set; }

        public int Quantity { get; private set; }

        public decimal Price { get; private set; }
    }
}
