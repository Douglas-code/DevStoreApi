using DevStore.Domain.StoreContext.Entities;
using DevStore.Domain.StoreContext.Queries;

namespace DevStore.Domain.StoreContext.Repositories
{
    public interface ICustomerRepository
    {
        bool CheckDocument(string document);

        bool CheckEmail(string email);

        void Save(Customer customer);

        CustomerOrdersCountResult GetCustomerOrdersCount(string document);
    }
}
