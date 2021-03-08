using DevStore.Domain.StoreContext.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DevStore.Domain.StoreContext.Entities
{
    public class Order
    {
        private readonly IList<OrderItem> _items;
        private readonly IList<Delivery> _deliveries;

        public Order(Customer customer)
        {
            this.Customer = customer;
            this.Number = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 8).ToUpper();
            this.CreateDate = DateTime.Now;
            this.Status = EOrderStatus.Created;
            this._items = new List<OrderItem>();
            this._deliveries = new List<Delivery>();
        }

        public Customer Customer { get; private set; }

        public string Number { get; private set; }

        public DateTime CreateDate { get; private set; }

        public EOrderStatus Status { get; private set; }

        public IReadOnlyCollection<OrderItem> Items => this._items.ToArray();

        public IReadOnlyCollection<Delivery> Deliveries => this._deliveries.ToArray();

        public void AddItem(OrderItem item)
        {
            this._items.Add(item);
        }

        public void AddDelivery(Delivery delivery)
        {
            this._deliveries.Add(delivery);
        }

        public void Place() { }
    }
}
