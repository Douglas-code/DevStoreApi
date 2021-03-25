using DevStore.Domain.StoreContext.Enums;
using DevStore.Shared.Entities;
using System;

namespace DevStore.Domain.StoreContext.Entities
{
    public class Delivery : Entity
    {
        public Delivery(DateTime estimatedDekiveryDate)
        {
            this.CreateDate = DateTime.Now;
            this.EstimatedDeliveryDate = estimatedDekiveryDate;
            this.Status = EDeliveryStatus.Waiting;
        }

        public DateTime CreateDate { get; private set; }

        public DateTime EstimatedDeliveryDate { get; private set; }

        public EDeliveryStatus Status { get; private set; }

        public void Ship()
        {
            this.Status = EDeliveryStatus.Shipped;
        }

        public void Cancel()
        {
            this.Status = EDeliveryStatus.Canceled;
        }
    }
}
