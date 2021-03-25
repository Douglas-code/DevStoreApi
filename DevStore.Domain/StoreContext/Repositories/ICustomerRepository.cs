using DevStore.Domain.StoreContext.Entities;

namespace DevStore.Domain.StoreContext.Repositories
{
    public interface ICustomerRepository
    {
        bool CheckDocument(string document);

        bool CheckEmail(string email);

        void Save(Customer customer);
    }
}
