using DevStore.Shared.Commands;
using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;

namespace DevStore.Domain.StoreContext.Commands.OrderCommands.Inputs
{
    public class PlaceOrderCommand : Notifiable, ICommand
    {
        public PlaceOrderCommand()
        {
            this.OrderItems = new List<AddOrderItemCommand>();
        }

        public Guid Customer { get; set; }

        public IList<AddOrderItemCommand> OrderItems { get; set; }

        public bool Validate()
        {
            AddNotifications(new Contract()
                .Requires()
                .HasLen(this.Customer.ToString(), 36, "Customer", "Identificador do cliente não é valido")
                .IsGreaterThan(this.OrderItems.Count, 0, "Items", "Nenhum Item do pedido foi encontrado")
            );
            return this.Valid;
        }
    }
}
