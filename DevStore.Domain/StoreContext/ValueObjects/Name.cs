using Flunt.Notifications;
using Flunt.Validations;

namespace DevStore.Domain.StoreContext.ValueObjects
{
    public class Name : Notifiable
    {
        public Name(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;

            AddNotifications(
                new Contract()
                    .Requires()
                    .HasMinLen(this.FirstName, 3, "FirstName", "O Nome deve conter pelo menos 3 caracteres")
                    .HasMinLen(this.LastName, 3, "LastName", "O Sobrenome deve conter pelo menos 3 caracteres")
                    .HasMaxLen(this.FirstName, 40, "FirstName", "O Nome deve conter no máximo 40 caracteres")
                    .HasMaxLen(this.LastName, 40, "LastName", "O Sobrenome deve conter no máximo 40 caracteres")
           );
        }

        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public override string ToString()
        {
            return $"{this.FirstName} {this.LastName}";
        }
    }
}
