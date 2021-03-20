using System;
using System.Collections.Generic;

namespace DevStore.Domain.StoreContext.Commands.OrderCommands.Inputs
{
    public class PlaceOrderCommand
    {
        public Guid Customer { get; set; }

        public IList<AddOrderItemCommand> OrderItems { get; set; }
    }
}
