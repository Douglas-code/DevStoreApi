using DevStore.Domain.StoreContext.ValueObjects;
using System.Collections.Generic;

namespace DevStore.Domain.StoreContext.Entities
{
    public class Customer
    {
        public Customer(Name name, Document document, Email email, string phone)
        {
            this.Name = name;
            this.Document = document;
            this.Email = email;
            this.Phone = phone;
            this.Address = new List<Address>();
        }

        public Name Name { get; private set; }

        public Document Document { get; private set; }

        public Email Email { get; private set; }

        public string Phone { get; private set; }

        public IReadOnlyCollection<Address> Address { get; private set; }

        public override string ToString()
        {
            return this.Name.ToString();
        }
    }
}
