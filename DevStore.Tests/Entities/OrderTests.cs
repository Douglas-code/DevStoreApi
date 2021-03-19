using DevStore.Domain.StoreContext.Entities;
using DevStore.Domain.StoreContext.Enums;
using DevStore.Domain.StoreContext.ValueObjects;
using Xunit;

namespace DevStore.Tests.Entities
{
    public class OrderTests
    {
        private Product _mouse;

        private Product _keyboard;

        private Product _chair;

        private Product _monitor;

        private Customer _customer;

        private Order _order;

        public OrderTests()
        {
            Name name = new Name("Douglas", "Pereira");
            Document document = new Document("01140839080");
            Email email = new Email("Dg@gmail.com");
            this._customer = new Customer(name, document, email, "12321312312");
            this._order = new Order(this._customer);

            this._mouse = new Product("Mouse Gamer", "Mouse", "mouse.png", 100M, 10);
            this._keyboard = new Product("Teclado Gamer", "Teclado", "teclado.png", 100M, 10);
            this._chair = new Product("Cadeira Gamer", "Cadeira", "cadeira.png", 100M, 10);
            this._monitor = new Product("Monitor Gamer", "Monitor", "monitor.png", 100M, 10);
        }

        [Fact]
        public void ShouldCreateOrderWhenValid()
        {
            Assert.True(this._order.Valid);
        }

        [Fact]
        public void StatusShouldBeCretedWhenOrderCreated()
        {
            Assert.Equal(EOrderStatus.Created, this._order.Status);
        }

        [Fact]
        public void ShouldReturnTwoWhenAddedTwoValidItems()
        {
            this._order.AddItem(this._monitor, 5);
            this._order.AddItem(this._mouse, 5);
            Assert.Equal(2, this._order.Items.Count);
        }

        [Fact]
        public void ShouldReturnFiveWhenAddedPurrchasedFiveItem()
        {
            this._order.AddItem(this._mouse, 5);
            Assert.Equal(5, this._mouse.QuantityOnHAnd);
        }

        [Fact]
        public void ShouldReturnNumberWhenOrderPlaced()
        {
            this._order.Place();
            Assert.False(this._order.Number == "");
        }

        [Fact]
        public void ShouldReturnPaidWhenOrderPaid()
        {
            this._order.Pay();
            Assert.Equal(EOrderStatus.Paid, this._order.Status);
        }

        [Fact]
        public void ShouldReturnTwoShippingsWhenPurchasedTenProducts()
        {
            this._order.AddItem(this._monitor, 1);
            this._order.AddItem(this._monitor, 1);
            this._order.AddItem(this._monitor, 1);
            this._order.AddItem(this._monitor, 1);
            this._order.AddItem(this._monitor, 1);
            this._order.AddItem(this._monitor, 1);
            this._order.AddItem(this._monitor, 1);
            this._order.AddItem(this._monitor, 1);
            this._order.AddItem(this._monitor, 1);
            this._order.AddItem(this._monitor, 1);
            this._order.Ship();
            Assert.Equal(2, this._order.Deliveries.Count);
        }

        [Fact]
        public void StatusShouldBeCanceledWhenCaceledOrder()
        {
            this._order.Cancel();
            Assert.Equal(EOrderStatus.Canceled, this._order.Status);
        }

        [Fact]
        public void ShoulCancelShippingsWhenOrderCanceled()
        {
            this._order.AddItem(this._monitor, 1);
            this._order.AddItem(this._monitor, 1);
            this._order.AddItem(this._monitor, 1);
            this._order.AddItem(this._monitor, 1);
            this._order.AddItem(this._monitor, 1);
            this._order.AddItem(this._monitor, 1);
            this._order.AddItem(this._monitor, 1);
            this._order.AddItem(this._monitor, 1);
            this._order.AddItem(this._monitor, 1);
            this._order.AddItem(this._monitor, 1);
            this._order.Ship();
            this._order.Cancel();

            foreach(Delivery delivery in this._order.Deliveries)
            {
                Assert.Equal(EDeliveryStatus.Canceled, delivery.Status);
            }
        }
    }
}
