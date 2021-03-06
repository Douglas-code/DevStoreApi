using DevStore.Domain.StoreContext.Enums;
using System;

namespace DevStore.Domain.StoreContext.Entities
{
    public class Delivery
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
    }
}
