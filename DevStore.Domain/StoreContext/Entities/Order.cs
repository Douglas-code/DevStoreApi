using DevStore.Domain.StoreContext.Enums;
using DevStore.Shared.Entities;
using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DevStore.Domain.StoreContext.Entities
{
    public class Order : Entity
    {
        private readonly IList<OrderItem> _items;
        private readonly IList<Delivery> _deliveries;

        public Order(Customer customer)
        {
            this.Customer = customer;
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

        public void AddItem(Product product, int quantity)
        {
            this.AddNotifications(new Contract().IsGreaterThan(quantity, product.QuantityOnHAnd, "OrderItem", $"Produto {product.Title} " +
                $"não tem {quantity} em estoque"));

            OrderItem item = new OrderItem(product, quantity);
            this._items.Add(item);
        }

        public void Place() 
        {
            this.Number = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 8).ToUpper();
            this.AddNotifications(new Contract().AreEquals(0, this._items.Count, "Order", "Este pedido não possui itens")); 
        }

        public void Pay()
        {
            this.Status = EOrderStatus.Paid;
        }

        public void Ship()
        {
            List<Delivery> deliveries = new List<Delivery>();
            int count = 1;

            foreach(OrderItem item in this._items)
            {
                if(count == 5)
                {
                    count = 0;
                    deliveries.Add(new Delivery(DateTime.Now.AddDays(5)));
                }
                count++;
            }

            deliveries.ForEach(x => x.Ship());
            deliveries.ForEach(x => this._deliveries.Add(x));
        }

        public void Cancel()
        {
            this.Status = EOrderStatus.Canceled;
            this._deliveries.ToList().ForEach(x => x.Cancel());
        }
    }
}
