using Flunt.Notifications;
using Flunt.Validations;

namespace DevStore.Domain.StoreContext.ValueObjects
{
    public class Email : Notifiable
    {
        public Email(string adress)
        {
            this.Address = adress;

            AddNotifications
            (
                new Contract()
                    .Requires()
                    .IsEmail(this.Address, "Email", "Email inválido")
            );
        }

        public string Address { get; private set; }

        public override string ToString()
        {
            return this.Address;
        }
    }
}
