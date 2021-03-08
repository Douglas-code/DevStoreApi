namespace DevStore.Domain.StoreContext.ValueObjects
{
    public class Email
    {
        public Email(string adress)
        {
            this.Address = adress;
        }

        public string Address { get; private set; }

        public override string ToString()
        {
            return this.Address;
        }
    }
}
