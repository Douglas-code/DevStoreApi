using DevStore.Shared.Entities;

namespace DevStore.Domain.StoreContext.Entities
{
    public class OrderItem : Entity
    {
        public OrderItem(Product product, int quantity)
        {
            Product = product;
            Quantity = quantity;
            Price = product.Price;

            product.DecreaseQuantity(quantity);
        }

        public Product Product { get; private set; }

        public int Quantity { get; private set; }

        public decimal Price { get; private set; }
    }
}
