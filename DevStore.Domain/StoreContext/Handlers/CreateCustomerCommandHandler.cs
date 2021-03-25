using DevStore.Domain.StoreContext.Commands.CustomerCommads.Inputs;
using DevStore.Domain.StoreContext.Commands.CustomerCommads.Outputs;
using DevStore.Domain.StoreContext.Entities;
using DevStore.Domain.StoreContext.ValueObjects;
using DevStore.Shared.Commands;
using DevStore.Shared.Handlers;
using Flunt.Notifications;
using System;

namespace DevStore.Domain.StoreContext.Handlers
{
    public class CreateCustomerCommandHandler : Notifiable, ICommandHandler<CreateCustomerCommand>
    {
        public ICommandResult Handle(CreateCustomerCommand command)
        {
            Name name = new Name(command.FirstName, command.LastName);
            Document document = new Document(command.Document);
            Email email = new Email(command.Email);

            Customer customer = new Customer(name, document, email, command.Phone);

            AddNotifications(name.Notifications);
            AddNotifications(document.Notifications);
            AddNotifications(email.Notifications);
            
            return new CreateCustomerCommandResult(Guid.NewGuid(), name.ToString(), email.Address);
        }
    }
}
