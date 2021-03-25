using DevStore.Domain.StoreContext.Enums;
using DevStore.Shared.Commands;
using Flunt.Notifications;
using System;

namespace DevStore.Domain.StoreContext.Commands.CustomerCommads.Inputs
{
    public class AddAddressCommand : Notifiable, ICommand
    {
        public Guid Id { get; set; }

        public string Street { get; set; }

        public string Number { get; set; }

        public string Complement { get; set; }

        public string District { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string Country { get; set; }

        public string ZipCode { get; set; }

        public EAddressType Type { get; set; }

        public bool Validate()
        {
            return this.Valid;
        }
    }
}
