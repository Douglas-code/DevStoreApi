using DevStore.Shared.Commands;
using Flunt.Notifications;
using Flunt.Validations;

namespace DevStore.Domain.StoreContext.Commands.CustomerCommads.Inputs
{
    public class CreateCustomerCommand : Notifiable, ICommand
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Document { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }


        public bool Validate()
        {
            AddNotifications(new Contract()
                .HasMinLen(this.FirstName, 3, "FirstName", "O Nome deve conter pelo menos 3 caracteres")
                .HasMinLen(this.LastName, 3, "LastName", "O Sobrenome deve conter pelo menos 3 caracteres")
                .HasMaxLen(this.FirstName, 40, "FirstName", "O Nome deve conter no máximo 40 caracteres")
                .HasMaxLen(this.LastName, 40, "LastName", "O Sobrenome deve conter no máximo 40 caracteres")
                .IsEmail(this.Email, "Email", "E-mail inválido!")
                .HasLen(this.Document, 11, "Document", "CPF inválido!")
            );

            return this.Valid;
        }
    }
}
