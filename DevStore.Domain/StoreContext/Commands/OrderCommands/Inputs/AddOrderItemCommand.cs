using System;

namespace DevStore.Domain.StoreContext.Commands.OrderCommands.Inputs
{
    public class AddOrderItemCommand
    {
        public Guid Product { get; set; }

        public int Quantity { get; set; }
    }
}
