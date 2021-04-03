using DevStore.Domain.StoreContext.Commands;
using DevStore.Domain.StoreContext.Commands.CustomerCommads.Inputs;
using DevStore.Domain.StoreContext.Commands.CustomerCommads.Outputs;
using DevStore.Domain.StoreContext.Entities;
using DevStore.Domain.StoreContext.Repositories;
using DevStore.Domain.StoreContext.Services;
using DevStore.Domain.StoreContext.ValueObjects;
using DevStore.Shared.Commands;
using DevStore.Shared.Handlers;
using Flunt.Notifications;
using System;

namespace DevStore.Domain.StoreContext.Handlers
{
    public class CreateCustomerCommandHandler : Notifiable, ICommandHandler<CreateCustomerCommand>
    {
        private readonly ICustomerRepository _repository;
        private readonly IEmailService _emailService;

        public CreateCustomerCommandHandler(ICustomerRepository repository, IEmailService emailService)
        {
            this._repository = repository;
            this._emailService = emailService;
        }

        public ICommandResult Handle(CreateCustomerCommand command)
        {
            if (!command.Validate())
            {
                return new CommandResult(false, "Falha ao cadastrar cliente", command.Notifications);
            }

            if (this._repository.CheckDocument(command.Document))
            {
                AddNotification("Document", "Este CPF já está em uso");
            }

            if (this._repository.CheckEmail(command.Email))
            {
                AddNotification("Email", "Este email já está em uso");
            }

            Name name = new Name(command.FirstName, command.LastName);
            Document document = new Document(command.Document);
            Email email = new Email(command.Email);

            Customer customer = new Customer(name, document, email, command.Phone);

            AddNotifications(name.Notifications);
            AddNotifications(document.Notifications);
            AddNotifications(email.Notifications);

            if (this.Invalid)
            {
                return new CommandResult(false, "Falha ao cadastrar cliente", this.Notifications);
            }

            this._repository.Save(customer);

            this._emailService.Send(email.Address, "dg@gmail.com", "Bem Vindo", "Seja bem vindo a Dev Store!");

            return new CommandResult(true, "Cliente cadastrado com successo!", new { Id = customer.Id, Name = customer.Name.ToString(), Email = customer.Email.Address }); ;
        }
    }
}
