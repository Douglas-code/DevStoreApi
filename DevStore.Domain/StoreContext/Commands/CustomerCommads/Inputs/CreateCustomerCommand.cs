namespace DevStore.Domain.StoreContext.Commands.CustomerCommads.Inputs
{
    public class CreateCustomerCommand
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Document { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }
    }
}
